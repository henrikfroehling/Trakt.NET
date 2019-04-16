namespace TraktNet.Objects.Tests.Get.Shows.Json.Reader
{
    public partial class ShowObjectJsonReader_Tests
    {
        private const string MINIMAL_JSON_COMPLETE =
            @"{
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
              }";

        private const string MINIMAL_JSON_INCOMPLETE_1 =
            @"{
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_2 =
            @"{
                ""title"": ""Game of Thrones"",
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_3 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011
              }";

        private const string MINIMAL_JSON_INCOMPLETE_4 =
            @"{
                ""title"": ""Game of Thrones""
              }";

        private const string MINIMAL_JSON_INCOMPLETE_5 =
            @"{
                ""year"": 2011
              }";

        private const string MINIMAL_JSON_INCOMPLETE_6 =
            @"{
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Game of Thrones"",
                ""ye"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_3 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""id"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_4 =
            @"{
                ""ti"": ""Game of Thrones"",
                ""ye"": 2011,
                ""id"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string FULL_JSON_COMPLETE =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_1 =
            @"{
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_2 =
            @"{
                ""title"": ""Game of Thrones"",
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_3 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_4 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_5 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_6 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_7 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_8 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_9 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_10 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_11 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_12 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_13 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_14 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_15 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_16 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_17 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_18 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_19 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_20 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_21 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50
              }";

        private const string FULL_JSON_INCOMPLETE_22 =
            @"{
                ""title"": ""Game of Thrones""
              }";

        private const string FULL_JSON_INCOMPLETE_23 =
            @"{
                ""year"": 2011
              }";

        private const string FULL_JSON_INCOMPLETE_24 =
            @"{
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string FULL_JSON_INCOMPLETE_25 =
            @"{
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.""
              }";

        private const string FULL_JSON_INCOMPLETE_26 =
            @"{
                ""first_aired"": ""2011-04-17T07:00:00Z""
              }";

        private const string FULL_JSON_INCOMPLETE_27 =
            @"{
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                }
              }";

        private const string FULL_JSON_INCOMPLETE_28 =
            @"{
                ""runtime"": 60
              }";

        private const string FULL_JSON_INCOMPLETE_29 =
            @"{
                ""certification"": ""TV-MA""
              }";

        private const string FULL_JSON_INCOMPLETE_30 =
            @"{
                ""network"": ""HBO""
              }";

        private const string FULL_JSON_INCOMPLETE_31 =
            @"{
                ""country"": ""us""
              }";

        private const string FULL_JSON_INCOMPLETE_32 =
            @"{
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g""
              }";

        private const string FULL_JSON_INCOMPLETE_33 =
            @"{
                ""homepage"": ""http://www.hbo.com/game-of-thrones""
              }";

        private const string FULL_JSON_INCOMPLETE_34 =
            @"{
                ""status"": ""returning series""
              }";

        private const string FULL_JSON_INCOMPLETE_35 =
            @"{
                ""rating"": 9.38327
              }";

        private const string FULL_JSON_INCOMPLETE_36 =
            @"{
                ""votes"": 44773
              }";

        private const string FULL_JSON_INCOMPLETE_37 =
            @"{
                ""updated_at"": ""2016-04-06T10:39:11Z""
              }";

        private const string FULL_JSON_INCOMPLETE_38 =
            @"{
                ""language"": ""en""
              }";

        private const string FULL_JSON_INCOMPLETE_39 =
            @"{
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_40 =
            @"{
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_41 =
            @"{
                ""aired_episodes"": 50
              }";

        private const string FULL_JSON_INCOMPLETE_42 =
            @"{
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Game of Thrones"",
                ""ye"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_3 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""id"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_4 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""ov"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_5 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""fa"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_6 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""ai"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_7 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""ru"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_8 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""cert"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_9 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""net"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_10 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""co"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_11 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""tr"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_12 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""hp"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_13 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""st"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_14 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""ra"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_15 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""vo"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_16 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""ua"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_17 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""la"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_18 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""availtr"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_19 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""ge"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_20 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aireps"": 50,
                ""seasons"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_21 =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""sea"": [
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
                ]
              }";

        private const string FULL_JSON_NOT_VALID_22 =
            @"{
                ""ti"": ""Game of Thrones"",
                ""ye"": 2011,
                ""id"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""ov"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                ""fa"": ""2011-04-17T07:00:00Z"",
                ""ai"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""ru"": 60,
                ""cert"": ""TV-MA"",
                ""net"": ""HBO"",
                ""co"": ""us"",
                ""tr"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""hp"": ""http://www.hbo.com/game-of-thrones"",
                ""st"": ""returning series"",
                ""ra"": 9.38327,
                ""vo"": 44773,
                ""ua"": ""2016-04-06T10:39:11Z"",
                ""la"": ""en"",
                ""availtr"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""ge"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aireps"": 50,
                ""sea"": [
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
                ]
              }";
    }
}
