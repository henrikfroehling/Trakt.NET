namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    public partial class CrewArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""production"": [
                    {
                      ""job"": ""Producer"",
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
                    }
                  ]
                },
                {
                  ""production"": [
                    {
                      ""job"": ""Producer"",
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
                    }
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""production"": [
                    {
                      ""job"": ""Producer"",
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
                    }
                  ]
                },
                {
                  ""production"": [
                    {
                      ""job"": ""Producer""
                    }
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""production"": [
                    {
                      ""job"": ""Producer""
                    }
                  ]
                },
                {
                  ""production"": [
                    {
                      ""job"": ""Producer"",
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
                    }
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""production"": [
                    {
                      ""jb"": ""Producer"",
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
                    }
                  ]
                },
                {
                  ""production"": [
                    {
                      ""job"": ""Producer"",
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
                    }
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""production"": [
                    {
                      ""job"": ""Producer"",
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
                    }
                  ]
                },
                {
                  ""production"": [
                    {
                      ""joob"": ""Producer"",
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
                    }
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""production"": [
                    {
                      ""jb"": ""Producer"",
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
                    }
                  ]
                },
                {
                  ""production"": [
                    {
                      ""joob"": ""Producer"",
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
                    }
                  ]
                }
              ]";
    }
}
