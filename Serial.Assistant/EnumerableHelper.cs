namespace Serial.Assistant;

using System.Collections;

public static class EnumerableHelper {
    public static string ToString<T>(this IEnumerable @this, string separator = ", ", string prefix = "[", string suffix = "]") {
        return ToString(@this.Cast<T>(), separator, prefix, suffix);
    }

    public static string ToString<T>(this IEnumerable<T> @this, string separator = ", ", string prefix = "[", string suffix = "]") {
        return prefix + string.Join(separator, @this) + suffix;
    }

    public static void ForEach<T>(this IEnumerable @this, Action<T> action) {
        ForEach(@this.Cast<T>(), action);
    }

    public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action) {
        foreach (var item in @this) {
            action(item);
        }
    }
}
