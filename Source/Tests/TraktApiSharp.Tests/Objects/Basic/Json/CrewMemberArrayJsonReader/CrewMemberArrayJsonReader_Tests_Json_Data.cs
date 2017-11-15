namespace TraktApiSharp.Tests.Objects.Basic.Json
{
    public partial class CrewMemberArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""job"": ""Director"",
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""job"": ""Director"",
                  ""person"": {
                    ""name"": ""Samuel L.Jackson"",
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""job"": ""Director"",
                  ""person"": {
                    ""name"": ""Samuel L.Jackson"",
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""job"": ""Director"",
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""job"": ""Director""
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""j"": ""Director"",
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""job"": ""Director"",
                  ""person"": {
                    ""name"": ""Samuel L.Jackson"",
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""job"": ""Director"",
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""job"": ""Director"",
                  ""pers"": {
                    ""name"": ""Samuel L.Jackson"",
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""j"": ""Director"",
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""job"": ""Director"",
                  ""pers"": {
                    ""name"": ""Samuel L.Jackson"",
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                }
              ]";
    }
}
