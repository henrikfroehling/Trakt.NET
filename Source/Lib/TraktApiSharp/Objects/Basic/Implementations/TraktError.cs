namespace TraktApiSharp.Objects.Basic
{
    /// <summary>Represents a Trakt error response.</summary>
    public class TraktError : ITraktError
    {
        /// <summary>Gets or sets the error name.<para>Nullable</para></summary>
        public string Error { get; set; }

        /// <summary>Gets or sets the error description.<para>Nullable</para></summary>
        public string Description { get; set; }
    }
}
