namespace TraktApiSharp.Objects.Get.Shows
{
    /// <summary>An alias for a Trakt c.</summary>
    public class TraktShowAlias : ITraktShowAlias
    {
        /// <summary>Gets or sets the title of the show alias.<para>Nullable</para></summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the two letter country code for the show alias.<para>Nullable</para></summary>
        public string CountryCode { get; set; }
    }
}
