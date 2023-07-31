namespace TraktNet.Modules.Tests.TraktRecommendationsModule
{
    using TraktNet.Parameters;

    public partial class TraktRecommendationsModule_Tests
    {
        private const string MOVIE_ID = "94024";
        private const uint TRAKT_MOVIE_ID = 94024;
        private const string MOVIE_SLUG = "tron-legacy-2010";
        private const string SHOW_ID = "1390";
        private const uint TRAKT_SHOW_ID = 1390;
        private const string SHOW_SLUG = "game-of-thrones";
        private const uint LIMIT = 4U;
        private readonly TraktExtendedInfo EXTENDED_INFO = new TraktExtendedInfo { Full = true };

        private const string MOVIE_RECOMMENDATIONS_JSON =
            @"[
                {
                  ""title"": ""Blackfish"",
                  ""year"": 2013,
                  ""ids"": {
                    ""trakt"": 58,
                    ""slug"": ""blackfish-2013"",
                    ""imdb"": ""tt2545118"",
                    ""tmdb"": 158999
                  },
                  ""favorited_by"": [
                    {
                      ""user"": {
                        ""username"": ""sean"",
                        ""private"": false,
                        ""name"": ""Sean Rudford"",
                        ""vip"": true,
                        ""vip_ep"": true,
                        ""ids"": {
                          ""slug"": ""sean"",
                          ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                        },
                        ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                        ""location"": ""SF"",
                        ""about"": ""I have all your cassette tapes."",
                        ""gender"": ""male"",
                        ""age"": 35,
                        ""images"": {
                          ""avatar"": {
                            ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                          }
                        },
                        ""vip_og"": true,
                        ""vip_years"": 5,
                        ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                      },
                      ""notes"": ""Favorited because ...""
                    }
                  ]
                },
                {
                  ""title"": ""Waiting for Superman"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 289,
                    ""slug"": ""waiting-for-superman-2010"",
                    ""imdb"": ""tt1566648"",
                    ""tmdb"": 39440
                  },
                  ""favorited_by"": [
                    {
                      ""user"": {
                        ""username"": ""sean"",
                        ""private"": false,
                        ""name"": ""Sean Rudford"",
                        ""vip"": true,
                        ""vip_ep"": true,
                        ""ids"": {
                          ""slug"": ""sean"",
                          ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                        },
                        ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                        ""location"": ""SF"",
                        ""about"": ""I have all your cassette tapes."",
                        ""gender"": ""male"",
                        ""age"": 35,
                        ""images"": {
                          ""avatar"": {
                            ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                          }
                        },
                        ""vip_og"": true,
                        ""vip_years"": 5,
                        ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                      },
                      ""notes"": ""Favorited because ...""
                    }
                  ]
                },
                {
                  ""title"": ""Inside Job"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 329,
                    ""slug"": ""inside-job-2010"",
                    ""imdb"": ""tt1645089"",
                    ""tmdb"": 44639
                  },
                  ""favorited_by"": [
                    {
                      ""user"": {
                        ""username"": ""sean"",
                        ""private"": false,
                        ""name"": ""Sean Rudford"",
                        ""vip"": true,
                        ""vip_ep"": true,
                        ""ids"": {
                          ""slug"": ""sean"",
                          ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                        },
                        ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                        ""location"": ""SF"",
                        ""about"": ""I have all your cassette tapes."",
                        ""gender"": ""male"",
                        ""age"": 35,
                        ""images"": {
                          ""avatar"": {
                            ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                          }
                        },
                        ""vip_og"": true,
                        ""vip_years"": 5,
                        ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                      },
                      ""notes"": ""Favorited because ...""
                    }
                  ]
                }
              ]";

        private const string SHOW_RECOMMENDATIONS_JSON =
            @"[
                {
                  ""title"": ""The Biggest Loser"",
                  ""year"": 2004,
                  ""ids"": {
                    ""trakt"": 9,
                    ""slug"": ""the-biggest-loser"",
                    ""tvdb"": 75166,
                    ""imdb"": ""tt0429318"",
                    ""tmdb"": 579,
                    ""tvrage"": null
                  },
                  ""favorited_by"": [
                    {
                      ""user"": {
                        ""username"": ""sean"",
                        ""private"": false,
                        ""name"": ""Sean Rudford"",
                        ""vip"": true,
                        ""vip_ep"": true,
                        ""ids"": {
                          ""slug"": ""sean"",
                          ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                        },
                        ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                        ""location"": ""SF"",
                        ""about"": ""I have all your cassette tapes."",
                        ""gender"": ""male"",
                        ""age"": 35,
                        ""images"": {
                          ""avatar"": {
                            ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                          }
                        },
                        ""vip_og"": true,
                        ""vip_years"": 5,
                        ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                      },
                      ""notes"": ""Favorited because ...""
                    }
                  ]
                },
                {
                  ""title"": ""Shark Tank"",
                  ""year"": 2009,
                  ""ids"": {
                    ""trakt"": 36,
                    ""slug"": ""shark-tank"",
                    ""tvdb"": 100981,
                    ""imdb"": ""tt1442550"",
                    ""tmdb"": 30703,
                    ""tvrage"": 22610
                  },
                  ""favorited_by"": [
                    {
                      ""user"": {
                        ""username"": ""sean"",
                        ""private"": false,
                        ""name"": ""Sean Rudford"",
                        ""vip"": true,
                        ""vip_ep"": true,
                        ""ids"": {
                          ""slug"": ""sean"",
                          ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                        },
                        ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                        ""location"": ""SF"",
                        ""about"": ""I have all your cassette tapes."",
                        ""gender"": ""male"",
                        ""age"": 35,
                        ""images"": {
                          ""avatar"": {
                            ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                          }
                        },
                        ""vip_og"": true,
                        ""vip_years"": 5,
                        ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                      },
                      ""notes"": ""Favorited because ...""
                    }
                  ]
                },
                {
                  ""title"": ""Hell's Kitchen"",
                  ""year"": 2005,
                  ""ids"": {
                    ""trakt"": 40,
                    ""slug"": ""hell-s-kitchen"",
                    ""tvdb"": 74897,
                    ""imdb"": ""tt0437005"",
                    ""tmdb"": 2370,
                    ""tvrage"": null
                  },
                  ""favorited_by"": [
                    {
                      ""user"": {
                        ""username"": ""sean"",
                        ""private"": false,
                        ""name"": ""Sean Rudford"",
                        ""vip"": true,
                        ""vip_ep"": true,
                        ""ids"": {
                          ""slug"": ""sean"",
                          ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                        },
                        ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                        ""location"": ""SF"",
                        ""about"": ""I have all your cassette tapes."",
                        ""gender"": ""male"",
                        ""age"": 35,
                        ""images"": {
                          ""avatar"": {
                            ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                          }
                        },
                        ""vip_og"": true,
                        ""vip_years"": 5,
                        ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                      },
                      ""notes"": ""Favorited because ...""
                    }
                  ]
                }
              ]";
    }
}
