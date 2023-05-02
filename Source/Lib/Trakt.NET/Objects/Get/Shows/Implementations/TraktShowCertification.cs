namespace TraktNet.Objects.Get.Shows
{
    /// <summary>A certification of a Trakt show.</summary>
    public class TraktShowCertification : ITraktShowCertification
    {
        /// <summary>Gets or sets the certification name.<para>Nullable</para></summary>
        public string Certification { get; set; }

        /// <summary>Gets or sets the country code.<para>Nullable</para></summary>
        public string CountryCode { get; set; }
    }
}
