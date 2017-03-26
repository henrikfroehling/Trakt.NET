namespace TraktApiSharp.Objects.Basic
{
    public interface ITraktTranslation
    {
        string Title { get; set; }

        string Overview { get; set; }

        string LanguageCode { get; set; }
    }
}
