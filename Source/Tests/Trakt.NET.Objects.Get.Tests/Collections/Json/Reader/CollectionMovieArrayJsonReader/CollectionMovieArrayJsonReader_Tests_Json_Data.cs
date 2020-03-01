namespace TraktNet.Objects.Get.Tests.Collections.Json.Reader
{
    public partial class CollectionMovieArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  ""metadata"": {
                    ""media_type"": ""bluray"",
                    ""resolution"": ""hd_1080p"",
                    ""audio"": ""dts"",
                    ""audio_channels"": ""6.1"",
                    ""3d"": false
                  }
                },
                {
                  ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  ""metadata"": {
                    ""media_type"": ""bluray"",
                    ""resolution"": ""hd_1080p"",
                    ""audio"": ""dts"",
                    ""audio_channels"": ""6.1"",
                    ""3d"": false
                  }
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  ""metadata"": {
                    ""media_type"": ""bluray"",
                    ""resolution"": ""hd_1080p"",
                    ""audio"": ""dts"",
                    ""audio_channels"": ""6.1"",
                    ""3d"": false
                  }
                },
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
                  },
                  ""metadata"": {
                    ""media_type"": ""bluray"",
                    ""resolution"": ""hd_1080p"",
                    ""audio"": ""dts"",
                    ""audio_channels"": ""6.1"",
                    ""3d"": false
                  }
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
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
                  },
                  ""metadata"": {
                    ""media_type"": ""bluray"",
                    ""resolution"": ""hd_1080p"",
                    ""audio"": ""dts"",
                    ""audio_channels"": ""6.1"",
                    ""3d"": false
                  }
                },
                {
                  ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  ""metadata"": {
                    ""media_type"": ""bluray"",
                    ""resolution"": ""hd_1080p"",
                    ""audio"": ""dts"",
                    ""audio_channels"": ""6.1"",
                    ""3d"": false
                  }
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  ""metadata"": {
                    ""media_type"": ""bluray"",
                    ""resolution"": ""hd_1080p"",
                    ""audio"": ""dts"",
                    ""audio_channels"": ""6.1"",
                    ""3d"": false
                  }
                },
                {
                  ""ca"": ""2014-09-01T09:10:11.000Z"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  ""metadata"": {
                    ""media_type"": ""bluray"",
                    ""resolution"": ""hd_1080p"",
                    ""audio"": ""dts"",
                    ""audio_channels"": ""6.1"",
                    ""3d"": false
                  }
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""ca"": ""2014-09-01T09:10:11.000Z"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  ""metadata"": {
                    ""media_type"": ""bluray"",
                    ""resolution"": ""hd_1080p"",
                    ""audio"": ""dts"",
                    ""audio_channels"": ""6.1"",
                    ""3d"": false
                  }
                },
                {
                  ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  ""metadata"": {
                    ""media_type"": ""bluray"",
                    ""resolution"": ""hd_1080p"",
                    ""audio"": ""dts"",
                    ""audio_channels"": ""6.1"",
                    ""3d"": false
                  }
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""ca"": ""2014-09-01T09:10:11.000Z"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  ""metadata"": {
                    ""media_type"": ""bluray"",
                    ""resolution"": ""hd_1080p"",
                    ""audio"": ""dts"",
                    ""audio_channels"": ""6.1"",
                    ""3d"": false
                  }
                },
                {
                  ""ca"": ""2014-09-01T09:10:11.000Z"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  ""metadata"": {
                    ""media_type"": ""bluray"",
                    ""resolution"": ""hd_1080p"",
                    ""audio"": ""dts"",
                    ""audio_channels"": ""6.1"",
                    ""3d"": false
                  }
                }
              ]";
    }
}
