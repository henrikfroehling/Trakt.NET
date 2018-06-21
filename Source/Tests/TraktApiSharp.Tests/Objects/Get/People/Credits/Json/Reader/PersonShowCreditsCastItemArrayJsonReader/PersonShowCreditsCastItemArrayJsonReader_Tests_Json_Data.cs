namespace TraktNet.Tests.Objects.Get.People.Credits.Json.Reader
{
    public partial class PersonShowCreditsCastItemArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""character"": ""Joe Brody"",
                  ""show"": {
                    ""title"": ""Game of Thrones"",
                    ""year"": 2011,
                    ""ids"": {
                      ""trakt"": 1390,
                      ""slug"": ""game-of-thrones"",
                      ""tvdb"": 121361,
                      ""imdb"": ""tt0944947"",
                      ""tmdb"": 1399,
                      ""tvrage"": 24493
                    }
                  }
                },
                {
                  ""character"": ""Iris West"",
                  ""show"": {
                    ""title"": ""The Flash"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""show"": {
                    ""title"": ""Game of Thrones"",
                    ""year"": 2011,
                    ""ids"": {
                      ""trakt"": 1390,
                      ""slug"": ""game-of-thrones"",
                      ""tvdb"": 121361,
                      ""imdb"": ""tt0944947"",
                      ""tmdb"": 1399,
                      ""tvrage"": 24493
                    }
                  }
                },
                {
                  ""character"": ""Iris West"",
                  ""show"": {
                    ""title"": ""The Flash"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""character"": ""Joe Brody"",
                  ""show"": {
                    ""title"": ""Game of Thrones"",
                    ""year"": 2011,
                    ""ids"": {
                      ""trakt"": 1390,
                      ""slug"": ""game-of-thrones"",
                      ""tvdb"": 121361,
                      ""imdb"": ""tt0944947"",
                      ""tmdb"": 1399,
                      ""tvrage"": 24493
                    }
                  }
                },
                {
                  ""character"": ""Iris West""
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""ch"": ""Joe Brody"",
                  ""show"": {
                    ""title"": ""Game of Thrones"",
                    ""year"": 2011,
                    ""ids"": {
                      ""trakt"": 1390,
                      ""slug"": ""game-of-thrones"",
                      ""tvdb"": 121361,
                      ""imdb"": ""tt0944947"",
                      ""tmdb"": 1399,
                      ""tvrage"": 24493
                    }
                  }
                },
                {
                  ""character"": ""Iris West"",
                  ""show"": {
                    ""title"": ""The Flash"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""character"": ""Joe Brody"",
                  ""show"": {
                    ""title"": ""Game of Thrones"",
                    ""year"": 2011,
                    ""ids"": {
                      ""trakt"": 1390,
                      ""slug"": ""game-of-thrones"",
                      ""tvdb"": 121361,
                      ""imdb"": ""tt0944947"",
                      ""tmdb"": 1399,
                      ""tvrage"": 24493
                    }
                  }
                },
                {
                  ""character"": ""Iris West"",
                  ""sh"": {
                    ""title"": ""The Flash"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""ch"": ""Joe Brody"",
                  ""show"": {
                    ""title"": ""Game of Thrones"",
                    ""year"": 2011,
                    ""ids"": {
                      ""trakt"": 1390,
                      ""slug"": ""game-of-thrones"",
                      ""tvdb"": 121361,
                      ""imdb"": ""tt0944947"",
                      ""tmdb"": 1399,
                      ""tvrage"": 24493
                    }
                  }
                },
                {
                  ""character"": ""Iris West"",
                  ""sh"": {
                    ""title"": ""The Flash"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                }
              ]";
    }
}
