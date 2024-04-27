namespace Serial.Assistant;

using System.IO.Ports;
using System.Text;

public static class SerialPortHelper {
    public static string[] PortNames => SerialPort.GetPortNames();
    public static readonly int[] BaudRates;
    public static readonly int[] DataBits = { 5, 6, 7, 8 };
    public static readonly Parity[] Parities = Enum.GetValues<Parity>();
    public static readonly StopBits[] StopBits = Enum.GetValues<StopBits>();
    public static readonly Handshake[] Handshakes = Enum.GetValues<Handshake>();
    public static readonly Encoding[] Encodings = { Encoding.ASCII, Encoding.UTF8 };
    public static readonly string[] NewLines = { @"\n", @"\r", @"\r\n", @"\0" };

    static SerialPortHelper() {
        var list = new List<int>();
        for (var i = 1; i < 1 << 8; i <<= 1) {
            list.Add(i * 900);
            list.Add(i * 1200);
        }
        list.Sort();
        BaudRates = list.ToArray();
    }
}
