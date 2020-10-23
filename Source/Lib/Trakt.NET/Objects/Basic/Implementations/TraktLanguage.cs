namespace TraktNet.Objects.Basic
{
    /// <summary>A Trakt language.</summary>
    public class TraktLanguage : ITraktLanguage
    {
        /// <summary>Gets or sets the name of the language.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the code of the language.</summary>
        public string Code { get; set; }
    }
}
