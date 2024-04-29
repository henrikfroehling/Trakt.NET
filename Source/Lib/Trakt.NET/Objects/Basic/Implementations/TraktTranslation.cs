namespace TraktNet.Objects.Basic
{
    /// <summary>A Trakt translation.</summary>
    public abstract class TraktTranslation : ITraktTranslation
    {
        /// <summary>Gets or sets the title of the translation.<para>Nullable</para></summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the synopsis of the release.<para>Nullable</para></summary>
        public string Overview { get; set; }

        /// <summary>Gets or sets the two letter language code for the translation.<para>Nullable</para></summary>
        public string LanguageCode { get; set; }

        /// <summary>Gets or sets the two letter country code for the translation.<para>Nullable</para></summary>
        public string CountryCode { get; set; }

        /// <summary>Gets a string representation of the translation.</summary>
        /// <returns>A string representation of the translation.</returns>
        public override string ToString() => !string.IsNullOrEmpty(Title) ? Title : "no title set";
    }
}
