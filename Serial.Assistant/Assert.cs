namespace Serial.Assistant;

public static class Assert {
    public static void RequireTrue(bool expression) {
        if (!expression) {
            throw new ArgumentException(null, nameof(expression));
        }
    }

    public static void RequireAscend(params int[] args) {
        for (var i = 1; i < args.Length; i++) {
            if (args[i - 1] > args[i]) {
                throw new ArgumentOutOfRangeException(nameof(args), args[i - 1], null);
            }
        }
    }
}
