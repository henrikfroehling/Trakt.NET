namespace TraktNet.Tests.Objects.Get.Seasons.Json.Reader
{
    public partial class SeasonArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string MINIMAL_JSON_COMPLETE =
            @"[
                {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                },
                {
                  ""number"": 2,
                  ""ids"": {
                    ""trakt"": 3964,
                    ""tvdb"": 473271,
                    ""tmdb"": 3625,
                    ""tvrage"": 36940
                  }
                }
              ]";

        private const string FULL_JSON_COMPLETE =
            @"[
                {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  },
                  ""rating"": 8.57053,
                  ""votes"": 794,
                  ""episode_count"": 10,
                  ""aired_episodes"": 10,
                  ""overview"": ""Trouble is brewing in the Seven Kingdoms of Westeros. For the driven inhabitants of this visionary world, control of Westeros' Iron Throne holds the lure of great power. But in a land where the seasons can last a lifetime, winter is coming...and beyond the Great Wall that protects them, an ancient evil has returned. In Season One, the story centers on three primary areas: the Stark and the Lannister families, whose designs on controlling the throne threaten a tenuous peace; the dragon princess Daenerys, heir to the former dynasty, who waits just over the Narrow Sea with her malevolent brother Viserys; and the Great Wall--a massive barrier of ice where a forgotten danger is stirring."",
                  ""first_aired"": ""2011-04-18T01:00:00.000Z"",
                  ""network"": ""The CW"",
                  ""episodes"": [
                    {
                      ""season"": 1,
                      ""number"": 1,
                      ""title"": ""Winter Is Coming"",
                      ""ids"": {
                        ""trakt"": 73640,
                        ""tvdb"": 3254641,
                        ""imdb"": ""tt1480055"",
                        ""tmdb"": 63056,
                        ""tvrage"": 1065008299
                      }
                    },
                    {
                      ""season"": 1,
                      ""number"": 2,
                      ""title"": ""The Kingsroad"",
                      ""ids"": {
                        ""trakt"": 74138,
                        ""tvdb"": 3436411,
                        ""imdb"": ""tt1668746"",
                        ""tmdb"": 63141,
                        ""tvrage"": 1325718577
                      }
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""ids"": {
                    ""trakt"": 3964,
                    ""tvdb"": 473271,
                    ""tmdb"": 3625,
                    ""tvrage"": 36940
                  },
                  ""rating"": 9.10629,
                  ""votes"": 1590,
                  ""episode_count"": 10,
                  ""aired_episodes"": 10,
                  ""overview"": ""The cold winds of winter are rising in Westeros...war is coming...and five kings continue their savage quest for control of the all-powerful Iron Throne. With winter fast approaching, the coveted Iron Throne is occupied by the cruel Joffrey, counseled by his conniving mother Cersei and uncle Tyrion. But the Lannister hold on the Throne is under assault on many fronts. Meanwhile, a new leader is rising among the wildings outside the Great Wall, adding new perils for Jon Snow and the order of the Night's Watch."",
                  ""first_aired"": ""2012-04-02T01:00:00.000Z"",
                  ""network"": ""The CW"",
                  ""episodes"": [
                    {
                      ""season"": 2,
                      ""number"": 1,
                      ""title"": ""The North Remembers"",
                      ""ids"": {
                        ""trakt"": 73650,
                        ""tvdb"": 4161693,
                        ""imdb"": ""tt1971833"",
                        ""tmdb"": 63066,
                        ""tvrage"": 1065074755
                      }
                    },
                    {
                      ""season"": 2,
                      ""number"": 2,
                      ""title"": ""The Night Lands"",
                      ""ids"": {
                        ""trakt"": 73651,
                        ""tvdb"": 4245771,
                        ""imdb"": ""tt2069318"",
                        ""tmdb"": 974430,
                        ""tvrage"": 1065150289
                      }
                    }
                  ]
                }
              ]";
    }
}
