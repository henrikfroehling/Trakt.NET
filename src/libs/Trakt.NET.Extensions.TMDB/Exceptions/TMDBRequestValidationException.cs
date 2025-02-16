namespace TraktNET
{
    public sealed partial class TMDBRequestValidationException : Exception
    {
        /// <summary>The name of the proeprty that caused the current exception.</summary>
        public string? PropertyName { get; }
    }
}
