namespace TraktNet.Objects.Get.Shows
{
    /// <summary>An alias for a Trakt show.</summary>
    public interface ITraktShowAlias
    {
        /// <summary>Gets or sets the title of the show alias.<para>Nullable</para></summary>
        string Title { get; set; }

        /// <summary>Gets or sets the two letter country code for the show alias.<para>Nullable</para></summary>
        string CountryCode { get; set; }
    }
}
