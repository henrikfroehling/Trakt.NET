namespace TraktNet.Objects.Get.Tests.Collections.Json.Reader
{
    public partial class CollectionMovieObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                ""updated_at"": ""2014-09-01T09:10:11.000Z"",
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
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""updated_at"": ""2014-09-01T09:10:11.000Z"",
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
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                ""updated_at"": ""2014-09-01T09:10:11.000Z"",
                ""metadata"": {
                  ""media_type"": ""bluray"",
                  ""resolution"": ""hd_1080p"",
                  ""audio"": ""dts"",
                  ""audio_channels"": ""6.1"",
                  ""3d"": false
                }
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                ""updated_at"": ""2014-09-01T09:10:11.000Z"",
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
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""collected_at"": ""2014-09-01T09:10:11.000Z""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""updated_at"": ""2014-09-01T09:10:11.000Z""
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""metadata"": {
                  ""media_type"": ""bluray"",
                  ""resolution"": ""hd_1080p"",
                  ""audio"": ""dts"",
                  ""audio_channels"": ""6.1"",
                  ""3d"": false
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ca"": ""2014-09-01T09:10:11.000Z"",
                ""updated_at"": ""2014-09-01T09:10:11.000Z"",
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
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                ""ua"": ""2014-09-01T09:10:11.000Z"",
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
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                ""updated_at"": ""2014-09-01T09:10:11.000Z"",
                ""mov"": {
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
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                ""updated_at"": ""2014-09-01T09:10:11.000Z"",
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
                ""meta"": {
                  ""media_type"": ""bluray"",
                  ""resolution"": ""hd_1080p"",
                  ""audio"": ""dts"",
                  ""audio_channels"": ""6.1"",
                  ""3d"": false
                }
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""ca"": ""2014-09-01T09:10:11.000Z"",
                ""ua"": ""2014-09-01T09:10:11.000Z"",
                ""mov"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                },
                ""meta"": {
                  ""media_type"": ""bluray"",
                  ""resolution"": ""hd_1080p"",
                  ""audio"": ""dts"",
                  ""audio_channels"": ""6.1"",
                  ""3d"": false
                }
              }";
    }
}
