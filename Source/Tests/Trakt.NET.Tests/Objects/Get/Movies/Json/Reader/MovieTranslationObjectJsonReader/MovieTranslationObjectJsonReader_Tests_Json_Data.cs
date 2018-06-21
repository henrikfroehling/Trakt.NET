namespace TraktNet.Tests.Objects.Get.Movies.Json.Reader
{
    public partial class MovieTranslationObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""language"": ""en""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tagline"": ""The Force Lives On...""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.""
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""tagline"": ""The Force Lives On...""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""language"": ""en""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""ov"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tl"": ""The Force Lives On..."",
                ""language"": ""en""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tagline"": ""The Force Lives On..."",
                ""la"": ""en""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""ti"": ""Star Wars: Episode VII - The Force Awakens"",
                ""ov"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tl"": ""The Force Lives On..."",
                ""la"": ""en""
              }";
    }
}
