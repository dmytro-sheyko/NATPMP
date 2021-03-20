using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NATPMP
{
    public partial class MainForm : Form
    {
        private const int PORT_NAT_PMP = 5351;
        private const byte VER = 0;
        private const byte OP_ADR = 0;
        private const byte OP_TCP = 2;
        private const int TIMEOUT = 2000;
        private const int R_SUCCESS = 0;
        private const int R_UNSUPPORTED_VERSION = 1;
        private const int R_REFUSED = 2;
        private const int R_NETWORK_FAILURE = 3;
        private const int R_OUT_OF_RESOURCES = 4;
        private const int R_UNSUPPORTED_OPCODE = 5;

        private readonly UdpClient udp_;

        public MainForm()
        {
            InitializeComponent();
            udp_ = new UdpClient(0, AddressFamily.InterNetwork);
            udp_.Client.ReceiveTimeout = TIMEOUT;
            Debug.WriteLine($"{udp_.Client.LocalEndPoint}");
        }

        private async void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (buttonStop.Enabled)
            {
                try
                {
                    IPAddress gatewayIP = IPAddress.Parse(comboGateway.Text.Trim());
                    int portLocal = ParsePort(textLocalPort.Text.Trim());
                    await RequestMapping(udp_, new IPEndPoint(gatewayIP, PORT_NAT_PMP), portLocal, 0, 0);
                }
                catch (Exception x)
                {
                    Debug.WriteLine(x);
                }
            }
            udp_.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IList<IPAddress> candidates = GetGatewayCandidates();
            foreach (var item in candidates)
            {
                Debug.WriteLine($"{item}");
                comboGateway.Items.Add(item);
            }
            if (candidates.Count > 0)
            {
                comboGateway.SelectedIndex = 0;
            }
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            textExternalAddress.Text = "";
            textStatus.Text = "";
            buttonStart.Enabled = false;
            string externalFullAddress = null;
            string status = "OK";
            bool mapped = false;
            int mappedPort = 0;
            try
            {
                IPAddress gatewayIP = IPAddress.Parse(comboGateway.Text.Trim());
                int portLocal = ParsePort(textLocalPort.Text.Trim());
                int portDesired = ParsePort(textExternalPort.Text.Trim());
                int lifetime = int.Parse(textLifetime.Text.Trim());
                Tuple<IPEndPoint, IPAddress> result0 = await RequestExternalIPAddress(udp_, new IPEndPoint(gatewayIP, PORT_NAT_PMP));
                externalFullAddress = "" + result0.Item2;
                if (portLocal != 0)
                {
                    mappedPort = await RequestMapping(udp_, result0.Item1, portLocal, portDesired, lifetime);
                    externalFullAddress += ":" + mappedPort;
                    mapped = true;
                }
            }
            catch (Exception x)
            {
                status = x.Message;
            }
            Invoke((MethodInvoker)(() =>
            {
                textExternalAddress.Text = externalFullAddress;
                textStatus.Text = status;
                if (mapped)
                {
                    buttonStop.Enabled = true;
                    comboGateway.Enabled = false;
                    textLocalPort.Enabled = false;
                    textExternalPort.Enabled = false;
                    textLifetime.Enabled = false;
                    textExternalPort.Text = "" + mappedPort;
                }
                else
                {
                    buttonStart.Enabled = true;
                }
            }));
        }

        private async void buttonStop_Click(object sender, EventArgs e)
        {
            textExternalAddress.Text = "";
            textStatus.Text = "";
            buttonStop.Enabled = false;
            string status = "OK";
            bool mapped = true;
            try
            {
                IPAddress gatewayIP = IPAddress.Parse(comboGateway.Text.Trim());
                int portLocal = ParsePort(textLocalPort.Text.Trim());
                int portDesired = ParsePort(textExternalPort.Text.Trim());
                mapped = false;
                await RequestMapping(udp_, new IPEndPoint(gatewayIP, PORT_NAT_PMP), portLocal, portDesired, 0);
            }
            catch (Exception x)
            {
                status = x.Message;
            }
            Invoke((MethodInvoker)(() =>
            {
                textStatus.Text = status;
                if (mapped)
                {
                    buttonStop.Enabled = true;
                }
                else
                {
                    buttonStart.Enabled = true;
                    comboGateway.Enabled = true;
                    textLocalPort.Enabled = true;
                    textExternalPort.Enabled = true;
                    textLifetime.Enabled = true;
                    textExternalAddress.Text = "";
                }
            }));
        }

        static async Task<Tuple<IPEndPoint, IPAddress>> RequestExternalIPAddress(UdpClient udp, IPEndPoint gateway)
        {
            udp.Connect(gateway);
            byte[] data = new byte[] { VER, OP_ADR, };
            Debug.WriteLine($"OUTGOING: {gateway} {ByteArrayToString(data)}");
            udp.Send(data, data.Length);
            return await Task.Run(() =>
            {
                IPEndPoint peer = null;
                byte[] incoming;
                try
                {
                    incoming = udp.Receive(ref peer);
                    Debug.WriteLine($"INCOMING: {peer} {ByteArrayToString(incoming)}");
                }
                catch (Exception x)
                {
                    Debug.WriteLine($"{x}");
                    throw;
                }
                if (incoming.Length == 12)
                {
                    CheckResult(incoming);
                    IPAddress addr = new IPAddress(new byte[] { incoming[8], incoming[9], incoming[10], incoming[11] });
                    return Tuple.Create(peer, addr);
                }
                else
                {
                    throw new Exception($"incoming.Length = {incoming.Length}, expected 12");
                }
            });
        }

        static async Task<int> RequestMapping(UdpClient udp, IPEndPoint gateway, int localPort, int desiredPort, int lifetime)
        {
            udp.Connect(gateway);
            byte[] data = new byte[] {
                VER, OP_TCP, 0, 0,
                (byte) (localPort >> 8), (byte) localPort,
                (byte) (desiredPort >> 8), (byte) desiredPort,
                (byte) (lifetime >> 24), (byte) (lifetime >> 16), (byte) (lifetime >> 8), (byte) lifetime,
            };
            Debug.WriteLine($"OUTGOING: {gateway} {ByteArrayToString(data)}");
            udp.Send(data, data.Length);
            return await Task.Run(() =>
            {
                IPEndPoint peer = null;
                byte[] incoming;
                try
                {
                    incoming = udp.Receive(ref peer);
                    Debug.WriteLine($"INCOMING: {peer} {ByteArrayToString(incoming)}");
                }
                catch (Exception x)
                {
                    Debug.WriteLine($"{x}");
                    throw;
                }
                if (incoming.Length == 16)
                {
                    CheckResult(incoming);
                    int mappedPort = (incoming[10] & 0xff) << 8 | (incoming[11] & 0xff);
                    return mappedPort;
                }
                else
                {
                    throw new Exception($"incoming.Length = {incoming.Length}, expected 16");
                }
            });
        }


        static void CheckResult(byte[] incoming)
        {
            int res = ((incoming[2] & 0xff) << 8) | ((incoming[3] & 0xff));
            CheckResult(res);
        }

        static void CheckResult(int res)
        {
            switch (res)
            {
                case R_SUCCESS:
                    return;
                case R_UNSUPPORTED_VERSION:
                    throw new Exception($"{res}: Unsupported Version");
                case R_REFUSED:
                    throw new Exception($"{res}: Not Authorized/Refused");
                case R_NETWORK_FAILURE:
                    throw new Exception($"{res}: Network Failure");
                case R_OUT_OF_RESOURCES:
                    throw new Exception($"{res}: Out of resources");
                case R_UNSUPPORTED_OPCODE:
                    throw new Exception($"{res}: Unsupported opcode");
                default:
                    throw new Exception($"{res}: ???");
            }
        }

        private static int ParsePort(string portText)
        {
            int port = 0;
            if (portText.Length > 0)
            {
                port = int.Parse(portText);
                if (port > IPEndPoint.MaxPort)
                {
                    throw new ArgumentOutOfRangeException("port", portText, $"port={port} is greater than {IPEndPoint.MaxPort}");
                }
                else if (port < IPEndPoint.MinPort)
                {
                    throw new ArgumentOutOfRangeException("port", portText, $"port={port} is less than {IPEndPoint.MinPort}");
                }
            }
            return port;
        }

        static IList<IPAddress> GetGatewayCandidates()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .Where(a => a != null)
                .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                .ToList();
        }
        static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat(" {0:x2}", b);
            return hex.ToString();
        }
    }
}
