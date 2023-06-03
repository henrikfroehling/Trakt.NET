namespace TraktNet.Objects.Basic
{
    /// <summary>A Trakt translation.</summary>
    public interface ITraktTranslation
    {
        /// <summary>Gets or sets the title of the translation.<para>Nullable</para></summary>
        string Title { get; set; }

        /// <summary>Gets or sets the synopsis of the release.<para>Nullable</para></summary>
        string Overview { get; set; }

        /// <summary>Gets or sets the two letter language code for the translation.<para>Nullable</para></summary>
        string LanguageCode { get; set; }

        /// <summary>Gets or sets the two letter country code for the translation.<para>Nullable</para></summary>
        string CountryCode { get; set; }
    }
}
