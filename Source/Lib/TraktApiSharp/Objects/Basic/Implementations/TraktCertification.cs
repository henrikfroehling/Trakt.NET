namespace TraktApiSharp.Objects.Basic
{
    public class TraktCertification : ITraktCertification
    {
        /// <summary>Gets or sets the certification name.<para>Nullable</para></summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the certification slug.<para>Nullable</para></summary>
        public string Slug { get; set; }

        /// <summary>Gets or sets the certification description.<para>Nullable</para></summary>
        public string Description { get; set; }
    }
}
