namespace TraktNET
{
    internal static class ArgumentValidator
    {
        internal static void ThrowIfNullOrWhiteSpace(string? value, string message, bool checkSpaces = false)
        {
#if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            if (checkSpaces && value!.ContainsSpace())
                throw new ArgumentException(message, nameof(value));
#else
            if (string.IsNullOrWhiteSpace(value) || (checkSpaces && value!.ContainsSpace()))
                throw new ArgumentException(message, nameof(value));
#endif
        }

        internal static void ThrowIfNull(object? argument)
        {
#if NETSTANDARD2_0 || NETSTANDARD2_1 || NET5_0
            if (argument == null)
                throw new ArgumentNullException(nameof(argument));
#else
            ArgumentNullException.ThrowIfNull(argument);
#endif
        }
    }
}
