namespace TraktApiSharp.Tests.Modules.TraktCommentsModule
{
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests.Parameters;

    public partial class TraktCommentsModule_Tests
    {
        private const uint COMMENT_ID = 190U;
        private const uint GET_COMMENT_ID = 76957U;
        private const uint GET_COMMENT_REPLIES_ID = 190U;
        private const int COMMENT_REPLIES_ITEM_COUNT = 2;
        private const int ITEM_COUNT = 2;
        private const int UPDATES_ITEM_COUNT = 5;
        private const uint PAGE = 2;
        private const uint LIMIT = 4;
        private const string COMMENT_TEXT = "one two three four five reply";
        private const bool SPOILER = false;
        private readonly TraktExtendedInfo EXTENDED_INFO = new TraktExtendedInfo { Full = true };
        private readonly TraktCommentType COMMENT_TYPE = TraktCommentType.Shout;
        private readonly TraktObjectType OBJECT_TYPE = TraktObjectType.Episode;

        private readonly ITraktSharing SHARING = new TraktSharing
        {
            Facebook = true,
            Google = false,
            Twitter = true
        };

        private ITraktMovie Movie { get; }
        private ITraktShow Show { get; }
        private ITraktSeason Season { get; }
        private ITraktEpisode Episode { get; }
        private ITraktList List { get; }

        public TraktCommentsModule_Tests()
        {
            Movie = new TraktMovie
            {
                Title = "Guardians of the Galaxy",
                Year = 2014,
                Ids = new TraktMovieIds
                {
                    Trakt = 28,
                    Slug = "guardians-of-the-galaxy-2014",
                    Imdb = "tt2015381",
                    Tmdb = 118340
                }
            };

            Show = new TraktShow
            {
                Title = "Breaking Bad",
                Ids = new TraktShowIds
                {
                    Trakt = 1388,
                    Slug = "breaking bad",
                    Tvdb = 81189,
                    Imdb = "tt0903747",
                    Tmdb = 1396,
                    TvRage = 18164
                }
            };

            Season = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 3950,
                    Tvdb = 30272,
                    Tmdb = 3572
                }
            };

            Episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 73482,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            List = new TraktList
            {
                Ids = new TraktListIds
                {
                    Trakt = 2228577,
                    Slug = "oscars-2016"
                }
            };
        }

        private const string COMMENT_JSON =
            @"{
                ""id"": 76957,
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""parent_id"": 0,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""replies"": 1,
                ""likes"": 2,
                ""user_rating"": 7.3,
                ""user"": {
                  ""username"": ""WalterBishopj"",
                  ""private"": false,
                  ""name"": ""Walter"",
                  ""vip"": false,
                  ""vip_ep"": false
                }
              }";

        private const string COMMENT_ITEM_JSON =
            @"{
                ""type"": ""show"",
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
              }";

        private const string COMMENT_LIKES_JSON =
            @"[
                {
                  ""liked_at"": ""2014-09-01T09:10:11.000Z"",
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                {
                  ""liked_at"": ""2014-09-01T09:10:11.000Z"",
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""justin""
                    }
                  }
                }
              ]";

        private const string COMMENT_REPLIES_JSON =
            @"[
                {
                  ""id"": 76957,
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""parent_id"": 0,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""WalterBishopj"",
                    ""private"": false,
                    ""name"": ""Walter"",
                    ""vip"": false,
                    ""vip_ep"": false
                  }
                },
                {
                  ""id"": 76957,
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""parent_id"": 0,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""WalterBishopj"",
                    ""private"": false,
                    ""name"": ""Walter"",
                    ""vip"": false,
                    ""vip_ep"": false
                  }
                }
              ]";

        private const string COMMENT_POST_RESPONSE_JSON =
            @"{
                ""id"": 190,
                ""parent_id"": 0,
                ""created_at"": ""2014-08-04T06:46:01.996Z"",
                ""comment"": ""Oh, I wasn't really listening."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 0,
                ""likes"": 0,
                ""user_rating"": null,
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": false
                },
                ""sharing"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""tumblr"": false,
                  ""medium"": true
                }
              }";

        private const string COMMENTS_UPDATES_JSON =
            @"[
                {
                  ""type"": ""movie"",
                  ""movie"": {
                    ""title"": ""Batman Begins"",
                    ""year"": 2005,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""batman-begins-2005"",
                      ""imdb"": ""tt0372784"",
                      ""tmdb"": 272
                    }
                  },
                  ""comment"": {
                    ""id"": 267,
                    ""comment"": ""Great kickoff to a new Batman trilogy!"",
                    ""spoiler"": false,
                    ""review"": false,
                    ""parent_id"": 0,
                    ""created_at"": ""2015-04-25T00:14:57.000Z"",
                    ""updated_at"": ""2015-04-25T00:14:57.000Z"",
                    ""replies"": 0,
                    ""likes"": 0,
                    ""user_rating"": 10,
                    ""user"": {
                      ""username"": ""justin"",
                      ""private"": false,
                      ""name"": ""Justin N."",
                      ""vip"": true,
                      ""vip_ep"": false,
                      ""ids"": {
                        ""slug"": ""justin""
                      }
                    }
                  }
                },
                {
                  ""type"": ""show"",
                  ""show"": {
                    ""title"": ""Breaking Bad"",
                    ""year"": 2008,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""breaking-bad"",
                      ""tvdb"": 81189,
                      ""imdb"": ""tt0903747"",
                      ""tmdb"": 1396
                    }
                  },
                  ""comment"": {
                    ""id"": 199,
                    ""comment"": ""Skyler, I AM THE DANGER."",
                    ""spoiler"": false,
                    ""review"": false,
                    ""parent_id"": 0,
                    ""created_at"": ""2015-02-18T06:02:30.000Z"",
                    ""updated_at"": ""2015-02-18T06:02:30.000Z"",
                    ""replies"": 0,
                    ""likes"": 0,
                    ""user_rating"": 10,
                    ""user"": {
                      ""username"": ""justin"",
                      ""private"": false,
                      ""name"": ""Justin N."",
                      ""vip"": true,
                      ""vip_ep"": false,
                      ""ids"": {
                        ""slug"": ""justin""
                      }
                    }
                  }
                },
                {
                  ""type"": ""season"",
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 3958,
                      ""tvdb"": 274431,
                      ""tmdb"": 60394
                    }
                  },
                  ""show"": {
                    ""title"": ""Gotham"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 869,
                      ""slug"": ""gotham"",
                      ""tvdb"": 274431,
                      ""imdb"": ""tt3749900"",
                      ""tmdb"": 60708
                    }
                  },
                  ""comment"": {
                    ""id"": 220,
                    ""comment"": ""Kicking off season 1 for a new Batman show."",
                    ""spoiler"": false,
                    ""review"": false,
                    ""parent_id"": 0,
                    ""created_at"": ""2015-04-21T06:53:25.000Z"",
                    ""updated_at"": ""2015-04-21T06:53:25.000Z"",
                    ""replies"": 0,
                    ""likes"": 0,
                    ""user_rating"": 8,
                    ""user"": {
                      ""username"": ""justin"",
                      ""private"": false,
                      ""name"": ""Justin N."",
                      ""vip"": true,
                      ""vip_ep"": false,
                      ""ids"": {
                        ""slug"": ""justin""
                      }
                    }
                  }
                },
                {
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Jim Gordon"",
                    ""ids"": {
                      ""trakt"": 63958,
                      ""tvdb"": 4768720,
                      ""imdb"": ""tt3216414"",
                      ""tmdb"": 975968
                    }
                  },
                  ""show"": {
                    ""title"": ""Gotham"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 869,
                      ""slug"": ""gotham"",
                      ""tvdb"": 274431,
                      ""imdb"": ""tt3749900"",
                      ""tmdb"": 60708
                    }
                  },
                  ""comment"": {
                    ""id"": 229,
                    ""comment"": ""Is this the OC?"",
                    ""spoiler"": false,
                    ""review"": false,
                    ""parent_id"": 0,
                    ""created_at"": ""2015-04-21T15:42:31.000Z"",
                    ""updated_at"": ""2015-04-21T15:42:31.000Z"",
                    ""replies"": 1,
                    ""likes"": 0,
                    ""user_rating"": 7,
                    ""user"": {
                      ""username"": ""justin"",
                      ""private"": false,
                      ""name"": ""Justin N."",
                      ""vip"": true,
                      ""vip_ep"": false,
                      ""ids"": {
                        ""slug"": ""justin""
                      }
                    }
                  }
                },
                {
                  ""type"": ""list"",
                  ""list"": {
                    ""name"": ""Star Wars"",
                    ""description"": ""The complete Star Wars saga!"",
                    ""privacy"": ""public"",
                    ""display_numbers"": false,
                    ""allow_comments"": true,
                    ""updated_at"": ""2015-04-22T22:01:39.000Z"",
                    ""item_count"": 8,
                    ""comment_count"": 0,
                    ""likes"": 0,
                    ""ids"": {
                      ""trakt"": 51,
                      ""slug"": ""star-wars""
                    }
                  },
                  ""comment"": {
                    ""id"": 268,
                    ""comment"": ""May the 4th be with you!"",
                    ""spoiler"": false,
                    ""review"": false,
                    ""parent_id"": 0,
                    ""created_at"": ""2014-12-08T17:34:51.000Z"",
                    ""updated_at"": ""2014-12-08T17:34:51.000Z"",
                    ""replies"": 0,
                    ""likes"": 0,
                    ""user_rating"": null,
                    ""user"": {
                      ""username"": ""justin"",
                      ""private"": false,
                      ""name"": ""Justin N."",
                      ""vip"": true,
                      ""vip_ep"": false,
                      ""ids"": {
                        ""slug"": ""justin""
                      }
                    }
                  }
                }
              ]";
    }
}
