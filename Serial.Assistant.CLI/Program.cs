namespace Serial.Assistant.CLI;

using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;

internal class Program {
    private static void Main(string[] args) {
        using var sp = new SerialPort();
        if (!SetProperties(sp, args)) {
            ShowHelp();
            return;
        }

        var height = Console.WindowHeight;
        var width = Console.WindowWidth;
        var isHexMode = false;
        var receiveArea = new ConsoleView(top: 0, bottom: height - 6, handler: Handler);
        var lineArea = new ConsoleView(top: height - 6, bottom: height - 5);
        var sendArea = new ConsoleView(top: height - 5, bottom: height - 1, handler: Handler);
        var inputArea = new ConsoleView(top: height - 1, bottom: height);
        var sb = new StringBuilder();

        sp.DataReceived += (_, _) => {
            receiveArea.EnqueueDequeue(sp.ReadLine());
            UpdateView();
        };

        lineArea.EnqueueDequeue(string.Concat(Enumerable.Repeat('-', width)));
        UpdateView();

        sp.Open();
        while (true) {
            ConsoleKeyInfo r;
            while ((r = Console.ReadKey(true)).KeyChar != '\r') {
                if (r.Key == ConsoleKey.F2) {
                    isHexMode = !isHexMode;
                } else if (r.Key == ConsoleKey.Backspace) {
                    if (r.Modifiers == ConsoleModifiers.Control) {
                        sb.Clear();
                    } else if (sb.Length != 0) {
                        sb.Remove(sb.Length - 1, 1);
                    }
                } else if (!isHexMode || StringHelper.IsHexChar(r.KeyChar) || r.KeyChar == ' ') {
                    sb.Append(r.KeyChar);
                }
                inputArea.EnqueueDequeue(sb.ToString());
                UpdateView();
            }

            var str = sb.ToString();
            sb.Clear();
            str = isHexMode ? StringHelper.HexStringToByteString(str) : Regex.Unescape(str);
            sendArea.EnqueueDequeue(str);
            inputArea.EnqueueDequeue("");
            UpdateView();
            sp.WriteLine(str);
        }

        char[] Handler(string str) {
            return (isHexMode ? StringHelper.ByteStringToHexString(str, " ") : Regex.Unescape(str)).ToCharArray();
        }

        void UpdateView() {
            Console.Clear();
            Console.Title = isHexMode ? "Hex Mode" : "Text Mode";
            receiveArea.Update();
            lineArea.Update();
            sendArea.Update();
            inputArea.Update();
        }
    }

    private static bool SetProperties(SerialPort sp, params string[] args) {
        try {
            foreach (var item in args) {
                var param = item[2..];
                switch (item[..2]) {
                    case "-P": {
                        sp.PortName = param;
                        break;
                    }
                    case "-b": {
                        sp.BaudRate = int.Parse(param);
                        break;
                    }
                    case "-d": {
                        sp.DataBits = int.Parse(param);
                        break;
                    }
                    case "-p": {
                        sp.Parity = Enum.Parse<Parity>(value: param, true);
                        break;
                    }
                    case "-s": {
                        sp.StopBits = Enum.Parse<StopBits>(value: param, true);
                        break;
                    }
                    case "-h": {
                        sp.Handshake = Enum.Parse<Handshake>(value: param, true);
                        break;
                    }
                    case "-e": {
                        sp.Encoding = Encoding.GetEncoding(param);
                        break;
                    }
                    case "-n": {
                        sp.NewLine = Regex.Unescape(param);
                        break;
                    }
                    default: {
                        return false;
                    }
                }
            }
        } catch (Exception) {
            return false;
        }
        return args.Length != 0;
    }

    private static void ShowHelp() {
        Console.WriteLine(@"Usage: Serial.Assistant.CLI.exe -PCOMx [option...]");
        Console.WriteLine();
        Console.WriteLine(@"Options:");
        Console.WriteLine(@"    -P      Serial Port require             " + ToString(SerialPortHelper.PortNames));
        Console.WriteLine(@"    -b      Baud Rate   default: 9600       " + ToString(SerialPortHelper.BaudRates.Select(StringHelper.ToString), 8, "..."));
        Console.WriteLine(@"    -d      Data Bits   default: 8          " + ToString(SerialPortHelper.DataBits.Select(StringHelper.ToString)));
        Console.WriteLine(@"    -p      Parity      default: None       " + ToString(SerialPortHelper.Parities.Select(StringHelper.ToString)));
        Console.WriteLine(@"    -s      Stop Bits   default: 1          " + ToString(SerialPortHelper.StopBits.Select(StringHelper.ToString)));
        Console.WriteLine(@"    -h      Handshake   default: None       " + ToString(SerialPortHelper.Handshakes.Select(StringHelper.ToString)));
        Console.WriteLine(@"    -e      Encoding    default: ASCII      " + ToString(SerialPortHelper.Encodings.Select(x => x.BodyName), args: "..."));
        Console.WriteLine(@"    -n      New Line    default: \n         " + ToString(SerialPortHelper.NewLines, args: "..."));
        Console.WriteLine();
        Console.WriteLine(@"Examples:");
        Console.WriteLine(@"    Serial.Assistant.CLI.exe -PCOM1");
        Console.WriteLine(@"    Serial.Assistant.CLI.exe -PCOM1 -pEven -eASCII -n\0");
        Console.WriteLine();
        Console.WriteLine(@"KeyMap:");
        Console.WriteLine(@"    F2              Hex | Text Mode");
        Console.WriteLine(@"    Enter           Send (Use \ for special characters, such as \n)");
        Console.WriteLine(@"    Backspace       Delete one char");
        Console.WriteLine(@"    Ctrl+Backspace  Delete line");
        Console.WriteLine(@"    Ctrl+C          Exit");
        return;

        static string ToString(IEnumerable<string> items, int? count = null, params string[] args) {
            var array = items.ToArray();
            return array.Take(count ?? array.Length).Concat(args).ToString("|", "{", "}");
        }
    }
}

public class ConsoleView {
    private readonly int left;
    private readonly int right;
    private readonly int top;
    private readonly int bottom;

    private readonly Func<string, char[]> handler;
    private readonly Queue<string> queue;

    public ConsoleView(int left = 0, int top = 0, int? right = null, int? bottom = null, Func<string, char[]>? handler = null) {
        this.left = left;
        this.top = top;
        this.right = right ?? Console.WindowWidth;
        this.bottom = bottom ?? Console.WindowHeight;
        Assert.RequireAscend(0, this.left, this.right, Console.WindowWidth);
        Assert.RequireAscend(0, this.top, this.bottom, Console.WindowHeight);
        queue = new Queue<string>(Enumerable.Repeat("", this.bottom - this.top));
        this.handler = handler ?? DefaultHandler;
        return;

        static char[] DefaultHandler(string s) {
            return s.ToCharArray();
        }
    }

    public void EnqueueDequeue(string value) {
        lock (typeof(ConsoleView)) {
            queue.Enqueue(value);
            queue.Dequeue();
        }
    }

    public void Update() {
        lock (typeof(ConsoleView)) {
            var i = top;
            queue.TakeWhile(_ => i < bottom).Select(handler).ForEach(item => {
                Console.SetCursorPosition(left, i++);
                Console.Write(item, 0, Math.Min(item.Length, right));
            });
        }
    }
}
