namespace Serial.Assistant.GUI;

using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;

public partial class MainForm : Form {
    private readonly SerialPort serialPort = new SerialPort();

    public MainForm() {
        InitializeComponent();

        cbPort.DataSource = SerialPortHelper.PortNames;
        cbBaud.DataSource = SerialPortHelper.BaudRates;
        cbDataBits.DataSource = SerialPortHelper.DataBits;
        cbParity.DataSource = SerialPortHelper.Parities;
        cbStopBits.DataSource = SerialPortHelper.StopBits;
        cbHandshake.DataSource = SerialPortHelper.Handshakes;
        cbEncoding.DataSource = SerialPortHelper.Encodings;
        cbNewLine.DataSource = SerialPortHelper.NewLines;

        cbEncoding.DisplayMember = nameof(Encoding.BodyName);

        cbPort.SelectedItem = SerialPortHelper.PortNames.FirstOrDefault();
        cbBaud.SelectedItem = 9600;
        cbDataBits.SelectedItem = 8;
        cbParity.SelectedItem = Parity.None;
        cbStopBits.SelectedItem = StopBits.One;
        cbHandshake.SelectedItem = Handshake.None;
        cbEncoding.SelectedItem = Encoding.ASCII;
        cbNewLine.SelectedItem = @"\r\n";

        serialPort.DataReceived += (_, _) => {
            try {
                BeginInvoke(UpdateView, serialPort.ReadLine());
            } catch (Exception) {
            }
        };
    }

    private void UpdateView(string str) {
        str = cbMode.Checked ? StringHelper.ByteStringToHexString(str, " ") : Regex.Unescape(str);
        tbView.AppendText($"{str}{Regex.Unescape((string)cbNewLine.SelectedItem)}");
    }

    private void cbPort_MouseEnter(object sender, EventArgs e) {
        var portNames = SerialPortHelper.PortNames;
        if (cbPort.DataSource is not IEnumerable<string> es || !portNames.SequenceEqual(es)) {
            cbPort.DataSource = portNames;
        }
    }

    private void btnPort_Click(object sender, EventArgs e) {
        if (cbPort.SelectedItem is not string portName) {
            return;
        }
        if ("Open" == btnPort.Text) {
            serialPort.PortName = portName;
            serialPort.BaudRate = (int)cbBaud.SelectedItem;
            serialPort.DataBits = (int)cbDataBits.SelectedItem;
            serialPort.Parity = (Parity)cbParity.SelectedItem;
            serialPort.StopBits = (StopBits)cbStopBits.SelectedItem;
            serialPort.Handshake = (Handshake)cbHandshake.SelectedItem;
            serialPort.Encoding = (Encoding)cbEncoding.SelectedItem;
            serialPort.NewLine = Regex.Unescape((string)cbNewLine.SelectedItem);
            serialPort.Open();
            panel1.Enabled = false;
            btnPort.Text = "Close";
        } else {
            serialPort.Close();
            panel1.Enabled = true;
            btnPort.Text = "Open";
        }
    }

    private void btnSend_Click(object sender, EventArgs e) {
        if (!serialPort.IsOpen) {
            return;
        }
        var str = tbSend.Text;
        str = cbMode.Checked ? StringHelper.HexStringToByteString(str) : Regex.Unescape(str);
        serialPort.WriteLine(str);
        UpdateView(str);
        if (cbKeep.Checked) {
            return;
        }
        tbSend.Clear();
    }

    private void btnClear_Click(object sender, EventArgs e) {
        tbView.Clear();
        tbSend.Clear();
    }
}
