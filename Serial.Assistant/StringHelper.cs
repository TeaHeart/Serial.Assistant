namespace Serial.Assistant;

using System.Text;

public static class StringHelper {
    public static string ToString<T>(this T? @this) {
        return @this?.ToString() ?? "null";
    }

    public static byte[] GetBytes(this string @this, Encoding? encoding = null) {
        return (encoding ?? Encoding.Default).GetBytes(@this);
    }

    public static string GetString(this byte[] @this, Encoding? encoding = null) {
        return (encoding ?? Encoding.Default).GetString(@this);
    }

    public static string ByteStringToHexString(string @this, string separator = "") {
        return string.Concat(@this.GetBytes().GetString(HexEncoding.HEX).Chunk(2).SelectMany(Concat).SkipLast(separator.Length));

        IEnumerable<char> Concat(char[] chars) {
            foreach (var c in chars) {
                yield return c;
            }
            foreach (var c in separator) {
                yield return c;
            }
        }
    }

    public static string HexStringToByteString(string @this, bool filter = true) {
        return (filter ? string.Concat(@this.Where(IsHexChar)) : @this).GetBytes(HexEncoding.HEX).GetString();
    }

    public static bool IsHexChar(char c) {
        return '0' <= c && c <= '9' || 'A' <= c && c <= 'F' || 'a' <= c && c <= 'f';
    }
}

public class HexEncoding : Encoding {
    public static readonly HexEncoding HEX = new HexEncoding();
    private const string HexCharset = "0123456789ABCDEF";

    private static int HexValue(char c) {
        return c switch {
            >= '0' and <= '9' => c - '0',
            >= 'A' and <= 'F' => c - 'A' + 10,
            >= 'a' and <= 'f' => c - 'a' + 10,
            _ => throw new ArgumentOutOfRangeException(nameof(c), c, null)
        };
    }

    static HexEncoding() {
        Encoding.RegisterProvider(new HexEncodingProvider());
    }

    public override string BodyName => "hex";

    public override int GetByteCount(char[] chars, int index, int count) {
        Assert.RequireAscend(0, index, count, chars.Length);
        return GetMaxByteCount(count - index);
    }

    public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex) {
        var count = 0;
        for (var i = charIndex - ((charCount - charIndex) & 1); i < charCount; i += 2) {
            var h = i >= charIndex ? HexValue(chars[i]) : 0;
            var l = HexValue(chars[i + 1]);
            bytes[count++] = (byte)(h << 4 | l);
        }
        return count;
    }

    public override int GetCharCount(byte[] bytes, int index, int count) {
        Assert.RequireAscend(0, index, count, bytes.Length);
        return GetMaxCharCount(count - index);
    }

    public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex) {
        var count = 0;
        for (var i = byteIndex; i < byteCount; i++) {
            var b = bytes[i];
            chars[count++] = HexCharset[b >> 4];
            chars[count++] = HexCharset[b & 0x0F];
        }
        return count;
    }

    public override int GetMaxByteCount(int charCount) {
        Assert.RequireTrue(charCount >= 0);
        return (charCount >> 1) + (charCount & 1);
    }

    public override int GetMaxCharCount(int byteCount) {
        Assert.RequireTrue(byteCount >= 0);
        return byteCount << 1;
    }

    private class HexEncodingProvider : EncodingProvider {
        public override Encoding? GetEncoding(int codepage) {
            return null;
        }

        public override Encoding? GetEncoding(string name) {
            return HEX.BodyName.Equals(name, StringComparison.InvariantCultureIgnoreCase) ? HEX : null;
        }
    }
}
