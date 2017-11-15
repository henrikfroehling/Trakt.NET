namespace TraktApiSharp.Tests.Objects.Get.Seasons.Json
{
    public partial class SeasonObjectJsonReader_Tests
    {
        private const string MINIMAL_JSON_COMPLETE =
            @"{
                ""number"": 1,
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_1 =
            @"{
                ""number"": 1
              }";

        private const string MINIMAL_JSON_INCOMPLETE_2 =
            @"{
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_1 =
            @"{
                ""nu"": 1,
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_2 =
            @"{
                ""number"": 1,
                ""id"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_3 =
            @"{
                ""nu"": 1,
                ""id"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";

        private const string FULL_JSON_COMPLETE =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_INCOMPLETE_1 =
            @"{
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_INCOMPLETE_2 =
            @"{
                ""number"": 1,
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_INCOMPLETE_3 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_INCOMPLETE_4 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_INCOMPLETE_5 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_INCOMPLETE_6 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_INCOMPLETE_7 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_INCOMPLETE_8 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_INCOMPLETE_9 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
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
              }";

        private const string FULL_JSON_INCOMPLETE_10 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_INCOMPLETE_11 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""network"": ""The CW""
              }";

        private const string FULL_JSON_INCOMPLETE_12 =
            @"{
                ""number"": 1
              }";

        private const string FULL_JSON_INCOMPLETE_13 =
            @"{
                ""title"": ""Season 1""
              }";

        private const string FULL_JSON_INCOMPLETE_14 =
            @"{
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";

        private const string FULL_JSON_INCOMPLETE_15 =
            @"{
                ""rating"": 8.57053
              }";

        private const string FULL_JSON_INCOMPLETE_16 =
            @"{
                ""votes"": 794
              }";

        private const string FULL_JSON_INCOMPLETE_17 =
            @"{
                ""episode_count"": 23
              }";

        private const string FULL_JSON_INCOMPLETE_18 =
            @"{
                ""aired_episodes"": 23
              }";

        private const string FULL_JSON_INCOMPLETE_19 =
            @"{
                ""overview"": ""Text text text""
              }";

        private const string FULL_JSON_INCOMPLETE_20 =
            @"{
                ""first_aired"": ""2014-10-08T00:00:00.000Z""
              }";

        private const string FULL_JSON_INCOMPLETE_21 =
            @"{
                ""network"": ""The CW""
              }";

        private const string FULL_JSON_INCOMPLETE_22 =
            @"{
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
              }";

        private const string FULL_JSON_NOT_VALID_1 =
            @"{
                ""nu"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_NOT_VALID_2 =
            @"{
                ""number"": 1,
                ""ti"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_NOT_VALID_3 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""id"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_NOT_VALID_4 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""ra"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_NOT_VALID_5 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""vo"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_NOT_VALID_6 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""epsc"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_NOT_VALID_7 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aireps"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_NOT_VALID_8 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""ov"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_NOT_VALID_9 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""fa"": ""2014-10-08T00:00:00.000Z"",
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
              }";

        private const string FULL_JSON_NOT_VALID_10 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""nw"": ""The CW"",
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
              }";

        private const string FULL_JSON_NOT_VALID_11 =
            @"{
                ""number"": 1,
                ""title"": ""Season 1"",
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""network"": ""The CW"",
                ""eps"": [
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
              }";

        private const string FULL_JSON_NOT_VALID_12 =
            @"{
                ""nu"": 1,
                ""ti"": ""Season 1"",
                ""id"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""ra"": 8.57053,
                ""vo"": 794,
                ""epsc"": 23,
                ""aireps"": 23,
                ""ov"": ""Text text text"",
                ""fa"": ""2014-10-08T00:00:00.000Z"",
                ""nw"": ""The CW"",
                ""eps"": [
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
              }";
    }
}
