namespace TraktNet.Objects.Basic
{
    /// <summary>A Trakt certification.</summary>
    public interface ITraktCertification
    {
        /// <summary>Gets or sets the certification name.<para>Nullable</para></summary>
        string Name { get; set; }

        /// <summary>Gets or sets the certification slug.<para>Nullable</para></summary>
        string Slug { get; set; }

        /// <summary>Gets or sets the certification description.<para>Nullable</para></summary>
        string Description { get; set; }
    }
}
