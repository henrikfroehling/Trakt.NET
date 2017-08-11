namespace TraktApiSharp.Objects.Basic.Implementations
{
    public abstract class TraktTranslation : ITraktTranslation
    {
        /// <summary>Gets or sets the title of the translation.<para>Nullable</para></summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the synopsis of the release.<para>Nullable</para></summary>
        public string Overview { get; set; }

        /// <summary>Gets or sets the two letter language code for the translation.<para>Nullable</para></summary>
        public string LanguageCode { get; set; }

        public override string ToString() => !string.IsNullOrEmpty(Title) ? Title : "no title set";
    }
}
