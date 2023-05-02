namespace TraktNet.Objects.Get.Shows
{
    /// <summary>A certification of a Trakt show.</summary>
    public interface ITraktShowCertification
    {
        /// <summary>Gets or sets the certification name.<para>Nullable</para></summary>
        string Certification { get; set; }

        /// <summary>Gets or sets the country code.<para>Nullable</para></summary>
        string CountryCode { get; set; }
    }
}
