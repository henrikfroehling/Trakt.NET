namespace TraktNet.Objects.Basic
{
    /// <summary>Represents a Trakt error response.</summary>
    public interface ITraktError
    {
        /// <summary>Gets or sets the error name.<para>Nullable</para></summary>
        string Error { get; set; }

        /// <summary>Gets or sets the error description.<para>Nullable</para></summary>
        string Description { get; set; }
    }
}
