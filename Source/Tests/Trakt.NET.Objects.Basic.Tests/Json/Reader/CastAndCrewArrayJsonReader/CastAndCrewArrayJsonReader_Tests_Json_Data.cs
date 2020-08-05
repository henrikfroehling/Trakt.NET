namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class CastAndCrewArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""cast"": [
                    {
                      ""characters"": [
                        ""Joe Brody""
                      ],
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
                  ""cast"": [
                    {
                      ""characters"": [
                        ""Joe Brody""
                      ],
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
                  ""cast"": [
                    {
                      ""characters"": [
                        ""Joe Brody""
                      ],
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
                  ""cast"": [
                    {
                      ""characters"": [
                        ""Joe Brody""
                      ]
                    }
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""cast"": [
                    {
                      ""characters"": [
                        ""Joe Brody""
                      ]
                    }
                  ]
                },
                {
                  ""cast"": [
                    {
                      ""characters"": [
                        ""Joe Brody""
                      ],
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
                  ""ca"": [
                    {
                      ""characters"": [
                        ""Joe Brody""
                      ],
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
                  ""cast"": [
                    {
                      ""characters"": [
                        ""Joe Brody""
                      ],
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
                  ""cast"": [
                    {
                      ""characters"": [
                        ""Joe Brody""
                      ],
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
                  ""ca"": [
                    {
                      ""characters"": [
                        ""Joe Brody""
                      ],
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
                  ""ca"": [
                    {
                      ""characters"": [
                        ""Joe Brody""
                      ],
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
                  ""ca"": [
                    {
                      ""characters"": [
                        ""Joe Brody""
                      ],
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
