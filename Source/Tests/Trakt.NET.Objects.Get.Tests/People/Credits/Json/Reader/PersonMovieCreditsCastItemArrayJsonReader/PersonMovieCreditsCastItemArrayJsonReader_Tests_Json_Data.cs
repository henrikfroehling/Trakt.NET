namespace TraktNet.Objects.Get.Tests.People.Credits.Json.Reader
{
    public partial class PersonMovieCreditsCastItemArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""characters"": [
                    ""Joe Brody""
                  ],
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  }
                },
                {
                  ""characters"": [
                    ""Sam Flynn""
                  ],
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 12601,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  }
                },
                {
                  ""characters"": [
                    ""Sam Flynn""
                  ],
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 12601,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""characters"": [
                    ""Joe Brody""
                  ],
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  }
                },
                {
                  ""characters"": [
                    ""Sam Flynn""
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""ch"": ""Joe Brody"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  }
                },
                {
                  ""characters"": [
                    ""Sam Flynn""
                  ],
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 12601,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""characters"": [
                    ""Joe Brody""
                  ],
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  }
                },
                {
                  ""characters"": [
                    ""Sam Flynn""
                  ],
                  ""mov"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 12601,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""ch"": ""Joe Brody"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  }
                },
                {
                  ""characters"": [
                    ""Sam Flynn""
                  ],
                  ""mov"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 12601,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                }
              ]";
    }
}
