namespace TraktNet.Modules.Tests.TraktShowsModule
{
    using System;
    using Trakt.NET.Tests.Utility;
    using TraktNet.Enums;
    using TraktNet.Objects.Post.Shows;
    using TraktNet.Parameters;
    using Xunit.Abstractions;

    public partial class TraktShowsModule_Tests
    {
        private const string SHOW_ID = "1390";
        private const int ITEM_COUNT = 2;
        private const int LISTS_ITEM_COUNT = 10;
        private const int USER_COUNT = 300;
        private const uint PAGE = 2;
        private const uint LIMIT = 4;
        private const uint RELATED_SHOWS_LIMIT = 10;
        private readonly TraktExtendedInfo EXTENDED_INFO = new TraktExtendedInfo { Full = true };
        private readonly TraktTimePeriod TIME_PERIOD = TraktTimePeriod.Monthly;
        private readonly DateTime TODAY = DateTime.UtcNow;
        private readonly DateTime START_DATE = DateTime.UtcNow;
        private const bool PROGRESS_HIDDEN = true;
        private const bool PROGRESS_SPECIALS = true;
        private const bool PROGRESS_COUNT_SPECIALS = true;
        private readonly TraktCommentSortOrder COMMENT_SORT_ORDER = TraktCommentSortOrder.Likes;
        private readonly TraktListType LIST_ITEM_TYPE = TraktListType.Official;
        private readonly TraktListSortOrder LIST_SORT_ORDER = TraktListSortOrder.Comments;
        private const string LANGUAGE_CODE = "en";
        private readonly TraktLastActivity LAST_ACTIVITY = TraktLastActivity.Collected;
        private readonly DateTime RESET_WATCHED_PROGRESS_AT = DateTime.UtcNow;
        private const int UPDATED_IDS_COUNT = 4;

        private string ProgressHidden { get; }
        private string ProgressSpecials { get; }
        private string ProgressCountSpecials { get; }
        private string LastActivity { get; }

        private ITraktShowResetWatchedProgressPost ResetWatchedProgressPostEmpty { get; }
        private ITraktShowResetWatchedProgressPost ResetWatchedProgressPost { get; }

        private readonly TestLogWriter _logWriter;

        public TraktShowsModule_Tests(ITestOutputHelper testOutputHelper)
        {
            _logWriter = new TestLogWriter(testOutputHelper);
            ProgressHidden = PROGRESS_HIDDEN.ToString().ToLower();
            ProgressSpecials = PROGRESS_SPECIALS.ToString().ToLower();
            ProgressCountSpecials = PROGRESS_COUNT_SPECIALS.ToString().ToLower();
            LastActivity = LAST_ACTIVITY.UriName.ToLower();
            ResetWatchedProgressPostEmpty = SetupEmptyShowResetWatchedProgressPost();
            ResetWatchedProgressPost = SetupShowResetWatchedProgressPost();
        }

        private ITraktShowResetWatchedProgressPost SetupShowResetWatchedProgressPost() => new TraktShowResetWatchedProgressPost
        {
            ResetAt = RESET_WATCHED_PROGRESS_AT
        };

        private ITraktShowResetWatchedProgressPost SetupEmptyShowResetWatchedProgressPost() => new TraktShowResetWatchedProgressPost();

        private readonly ITraktShowFilter FILTER = TraktFilter.NewShowFilter()
                .WithCertifications("TV-MA")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction)
                .WithQuery("most anticipated show")
                .WithYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .Build();

        private const string RECENTLY_UPDATED_SHOW_IDS_JSON =
            @"[
                1,
                20,
                34,
                50
              ]";

        private const string RESET_WATCHED_PROGRESS_POST_RESPONSE_JSON =
            @"{
                ""reset_at"": ""2022-01-23T21:12:25.000Z""
              }";

        private const string MOST_ANTICIPATED_SHOWS_JSON =
            @"[
                {
                  ""list_count"": 5529,
                  ""show"": {
                    ""title"": ""Westworld"",
                    ""year"": 2016,
                    ""ids"": {
                      ""trakt"": 99718,
                      ""slug"": ""westworld"",
                      ""tvdb"": 296762,
                      ""imdb"": ""tt0475784"",
                      ""tmdb"": 63247,
                      ""tvrage"": 37537
                    }
                  }
                },
                {
                  ""list_count"": 5034,
                  ""show"": {
                    ""title"": ""Preacher"",
                    ""year"": 2016,
                    ""ids"": {
                      ""trakt"": 102034,
                      ""slug"": ""preacher"",
                      ""tvdb"": 300472,
                      ""imdb"": ""tt1316546"",
                      ""tmdb"": 64230,
                      ""tvrage"": 39033
                    }
                  }
                }
              ]";

        private const string MOST_COLLECTED_SHOWS_JSON =
            @"[
                {
                  ""watcher_count"": 32546,
                  ""play_count"": 200966,
                  ""collected_count"": 148070,
                  ""collector_count"": 9607,
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1393,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402,
                      ""tvrage"": 25056
                    }
                  }
                },
                {
                  ""watcher_count"": 21365,
                  ""play_count"": 263571,
                  ""collected_count"": 247898,
                  ""collector_count"": 7964,
                  ""show"": {
                    ""title"": ""The Big Bang Theory"",
                    ""year"": 2007,
                    ""ids"": {
                      ""trakt"": 1409,
                      ""slug"": ""the-big-bang-theory"",
                      ""tvdb"": 80379,
                      ""imdb"": ""tt0898266"",
                      ""tmdb"": 1418,
                      ""tvrage"": 8511
                    }
                  }
                }
              ]";

        private const string MOST_PLAYED_SHOWS_JSON =
            @"[
                {
                  ""watcher_count"": 21365,
                  ""play_count"": 263571,
                  ""collected_count"": 247898,
                  ""collector_count"": 7964,
                  ""show"": {
                    ""title"": ""The Big Bang Theory"",
                    ""year"": 2007,
                    ""ids"": {
                      ""trakt"": 1409,
                      ""slug"": ""the-big-bang-theory"",
                      ""tvdb"": 80379,
                      ""imdb"": ""tt0898266"",
                      ""tmdb"": 1418,
                      ""tvrage"": 8511
                    }
                  }
                },
                {
                  ""watcher_count"": 32546,
                  ""play_count"": 200966,
                  ""collected_count"": 148070,
                  ""collector_count"": 9607,
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1393,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402,
                      ""tvrage"": 25056
                    }
                  }
                }
              ]";

        private const string MOST_WATCHED_SHOWS_JSON =
            @"[
                {
                  ""watcher_count"": 32546,
                  ""play_count"": 200966,
                  ""collected_count"": 148070,
                  ""collector_count"": 9607,
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1393,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402,
                      ""tvrage"": 25056
                    }
                  }
                },
                {
                  ""watcher_count"": 21365,
                  ""play_count"": 263571,
                  ""collected_count"": 247898,
                  ""collector_count"": 7964,
                  ""show"": {
                    ""title"": ""The Big Bang Theory"",
                    ""year"": 2007,
                    ""ids"": {
                      ""trakt"": 1409,
                      ""slug"": ""the-big-bang-theory"",
                      ""tvdb"": 80379,
                      ""imdb"": ""tt0898266"",
                      ""tmdb"": 1418,
                      ""tvrage"": 8511
                    }
                  }
                }
              ]";

        private const string POPULAR_SHOWS_JSON =
            @"[
                {
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
                },
                {
                  ""title"": ""Breaking Bad"",
                  ""year"": 2008,
                  ""ids"": {
                    ""trakt"": 1388,
                    ""slug"": ""breaking-bad"",
                    ""tvdb"": 81189,
                    ""imdb"": ""tt0903747"",
                    ""tmdb"": 1396,
                    ""tvrage"": 18164
                  }
                }
              ]";

        private const string RECENTLY_UPDATED_SHOWS_JSON =
            @"[
                {
                  ""updated_at"": ""2016-04-07T15:24:24Z"",
                  ""show"": {
                    ""title"": ""Sailor Moon"",
                    ""year"": 1992,
                    ""ids"": {
                      ""trakt"": 3548,
                      ""slug"": ""sailor-moon"",
                      ""tvdb"": 78500,
                      ""imdb"": ""tt0114327"",
                      ""tmdb"": 3570,
                      ""tvrage"": null
                    }
                  }
                },
                {
                  ""updated_at"": ""2016-04-07T15:31:48Z"",
                  ""show"": {
                    ""title"": ""The Vikings Uncovered"",
                    ""year"": 2016,
                    ""ids"": {
                      ""trakt"": 106831,
                      ""slug"": ""the-vikings-uncovered"",
                      ""tvdb"": 309745,
                      ""imdb"": null,
                      ""tmdb"": null,
                      ""tvrage"": null
                    }
                  }
                }
              ]";

        private const string SHOW_JSON =
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

        private const string SHOW_ALIASES_JSON =
            @"[
                {
                  ""title"": ""冰與火之歌：權力遊戲"",
                  ""country"": ""tw""
                },
                {
                  ""title"": ""A Guerra dos Tronos"",
                  ""country"": ""pt""
                },
                {
                  ""title"": ""Game of Thrones"",
                  ""country"": ""ru""
                },
                {
                  ""title"": ""بازی تاج و تخت"",
                  ""country"": ""aq""
                },
                {
                  ""title"": ""Igra prijestolja"",
                  ""country"": ""hr""
                },
                {
                  ""title"": ""Το Παιχνίδι του θρόνου"",
                  ""country"": ""gr""
                },
                {
                  ""title"": ""Game of Thrones- Das Lied von Eis und Feuer"",
                  ""country"": ""de""
                },
                {
                  ""title"": ""Παιχνίδι Του Στέμματος"",
                  ""country"": ""gr""
                }
              ]";

        private const string SHOW_COLLECTION_PROGRESS_JSON =
            @"{
                ""aired"": 6,
                ""completed"": 6,
                ""last_collected_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 6,
                    ""completed"": 6,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""collected_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""collected_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 3,
                        ""completed"": true,
                        ""collected_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 4,
                        ""completed"": true,
                        ""collected_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 5,
                        ""completed"": true,
                        ""collected_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 6,
                        ""completed"": true,
                        ""collected_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": null
                    }
                  }
                ],
                ""next_episode"": null
              }";

        private const string SHOW_COMMENTS_JSON =
            @"[
                {
                  ""id"": 8,
                  ""parent_id"": 0,
                  ""created_at"": ""2011-03-25T22:35:17.000Z"",
                  ""updated_at"": ""2011-03-25T22:35:17.000Z"",
                  ""comment"": ""Great episode!"",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 0,
                  ""user_rating"": 8,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false
                  }
                },
                {
                  ""id"": 9,
                  ""parent_id"": 0,
                  ""created_at"": ""2011-03-25T22:35:17.000Z"",
                  ""updated_at"": ""2011-03-25T22:35:17.000Z"",
                  ""comment"": ""Great episode!"",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 0,
                  ""user_rating"": 8,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false
                  }
                }
              ]";

        private const string SHOW_EPISODE_JSON =
            @"{
                ""season"": 1,
                ""number"": 1,
                ""title"": ""Winter Is Coming"",
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                },
                ""number_abs"": 50,
                ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                ""first_aired"": ""2011-04-18T01:00:00.000Z"",
                ""updated_at"": ""2014-08-29T23:16:39.000Z"",
                ""rating"": 9,
                ""votes"": 111,
                ""available_translations"": [
                  ""en""
                ],
                ""runtime"": 55
              }";

        private const string SHOW_LISTS_JSON =
            @"[
                {
                  ""name"": ""Binge Tee Vee"",
                  ""description"": ""Lists will be updated with new series  and episodes or movies or suggested by anyone as they are released or if you have an idea for a list email me at: bingeflixs@gmail.com"",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""title"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-09-24T14:22:34.000Z"",
                  ""updated_at"": ""2017-01-23T06:06:43.000Z"",
                  ""item_count"": 983,
                  ""comment_count"": 0,
                  ""likes"": 31,
                  ""ids"": {
                    ""trakt"": 2708842,
                    ""slug"": ""binge-tee-vee""
                  },
                  ""user"": {
                    ""username"": ""Binge Flixs"",
                    ""private"": false,
                    ""name"": ""Binge Flixs"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""binge-flixs""
                    }
                  }
                },
                {
                  ""name"": ""IMDB: Popular TV Shows"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-04-11T23:10:32.000Z"",
                  ""updated_at"": ""2017-01-23T09:40:27.000Z"",
                  ""item_count"": 100,
                  ""comment_count"": 1,
                  ""likes"": 43,
                  ""ids"": {
                    ""trakt"": 2143362,
                    ""slug"": ""imdb-popular-tv-shows""
                  },
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""justin""
                    }
                  }
                },
                {
                  ""name"": ""MARVEL'S CINEMATIC UNIVERSE - TV Series"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-07-07T21:42:48.000Z"",
                  ""updated_at"": ""2017-01-07T05:52:38.000Z"",
                  ""item_count"": 9,
                  ""comment_count"": 0,
                  ""likes"": 6,
                  ""ids"": {
                    ""trakt"": 2447176,
                    ""slug"": ""marvel-s-cinematic-universe-tv-series""
                  },
                  ""user"": {
                    ""username"": ""TheObscureKing"",
                    ""private"": false,
                    ""name"": """",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""theobscureking""
                    }
                  }
                },
                {
                  ""name"": ""TVShows"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-01-26T20:23:19.000Z"",
                  ""updated_at"": ""2016-12-27T12:00:08.000Z"",
                  ""item_count"": 762,
                  ""comment_count"": 0,
                  ""likes"": 18,
                  ""ids"": {
                    ""trakt"": 1789300,
                    ""slug"": ""tvshows""
                  },
                  ""user"": {
                    ""username"": ""estrobien"",
                    ""private"": false,
                    ""name"": null,
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""estrobien""
                    }
                  }
                },
                {
                  ""name"": ""Movies"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": false,
                  ""sort_by"": ""title"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-07-13T03:50:20.000Z"",
                  ""updated_at"": ""2017-01-10T01:39:56.000Z"",
                  ""item_count"": 3323,
                  ""comment_count"": 0,
                  ""likes"": 9,
                  ""ids"": {
                    ""trakt"": 2465950,
                    ""slug"": ""movies""
                  },
                  ""user"": {
                    ""username"": ""KodiMasterAccount"",
                    ""private"": false,
                    ""name"": """",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""kodimasteraccount""
                    }
                  }
                },
                {
                  ""name"": ""My Tv shows"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-12-21T00:44:51.000Z"",
                  ""updated_at"": ""2017-01-19T03:19:11.000Z"",
                  ""item_count"": 81,
                  ""comment_count"": 0,
                  ""likes"": 3,
                  ""ids"": {
                    ""trakt"": 3046866,
                    ""slug"": ""my-tv-shows""
                  },
                  ""user"": {
                    ""username"": ""0541415141m7md"",
                    ""private"": false,
                    ""name"": ""Mohammed Qahtanie"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""0541415141m7md""
                    }
                  }
                },
                {
                  ""name"": ""Popular TV"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-01-25T19:04:51.000Z"",
                  ""updated_at"": ""2016-12-28T01:34:39.000Z"",
                  ""item_count"": 522,
                  ""comment_count"": 0,
                  ""likes"": 7,
                  ""ids"": {
                    ""trakt"": 1785272,
                    ""slug"": ""popular-tv""
                  },
                  ""user"": {
                    ""username"": ""deegan000"",
                    ""private"": false,
                    ""name"": null,
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""deegan000""
                    }
                  }
                },
                {
                  ""name"": ""Marvel/DC/Comic Adaptations"",
                  ""description"": ""Marvel rocks!!!"",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2012-05-03T10:35:30.000Z"",
                  ""updated_at"": ""2017-01-22T00:32:13.000Z"",
                  ""item_count"": 88,
                  ""comment_count"": 14,
                  ""likes"": 233,
                  ""ids"": {
                    ""trakt"": 799403,
                    ""slug"": ""marvel-dc-comic-adaptations""
                  },
                  ""user"": {
                    ""username"": ""BenFranklin"",
                    ""private"": false,
                    ""name"": ""Ben"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""benfranklin""
                    }
                  }
                },
                {
                  ""name"": ""TV Shows"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""title"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-10-07T17:27:41.000Z"",
                  ""updated_at"": ""2017-01-05T03:35:24.000Z"",
                  ""item_count"": 2220,
                  ""comment_count"": 0,
                  ""likes"": 3,
                  ""ids"": {
                    ""trakt"": 2759844,
                    ""slug"": ""tv-shows""
                  },
                  ""user"": {
                    ""username"": ""pizzaguy300"",
                    ""private"": false,
                    ""name"": null,
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""pizzaguy300""
                    }
                  }
                },
                {
                  ""name"": ""Marvel Cinematic Universe"",
                  ""description"": ""Marvel Cinematic Universe films & television series"",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2015-08-17T01:22:23.000Z"",
                  ""updated_at"": ""2017-01-19T23:22:06.000Z"",
                  ""item_count"": 28,
                  ""comment_count"": 0,
                  ""likes"": 3,
                  ""ids"": {
                    ""trakt"": 1325765,
                    ""slug"": ""marvel-cinematic-universe""
                  },
                  ""user"": {
                    ""username"": ""_nto1ne"",
                    ""private"": false,
                    ""name"": ""Antoine Boulanger"",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""_nto1ne""
                    }
                  }
                }
              ]";

        private const string SHOW_PEOPLE_JSON =
            @"{
                ""cast"": [
                  {
                    ""character"": ""Rick Grimes"",
                    ""person"": {
                      ""name"": ""Andrew Lincoln"",
                      ""ids"": {
                        ""trakt"": 413156,
                        ""slug"": ""andrew-lincoln"",
                        ""imdb"": ""nm0511088"",
                        ""tmdb"": 7062,
                        ""tvrage"": 61194
                      }
                    }
                  },
                  {
                    ""character"": ""Daryl Dixon"",
                    ""person"": {
                      ""name"": ""Norman Reedus"",
                      ""ids"": {
                        ""trakt"": 5158,
                        ""slug"": ""norman-reedus"",
                        ""imdb"": ""nm0005342"",
                        ""tmdb"": 4886,
                        ""tvrage"": 26542
                      }
                    }
                  },
                  {
                    ""character"": ""Glenn Rhee"",
                    ""person"": {
                      ""name"": ""Steven Yeun"",
                      ""ids"": {
                        ""trakt"": 436936,
                        ""slug"": ""steven-yeun"",
                        ""imdb"": ""nm3081796"",
                        ""tmdb"": 215055,
                        ""tvrage"": null
                      }
                    }
                  }
                ],
                ""crew"": {
                  ""production"": [
                    {
                      ""job"": ""Casting"",
                      ""person"": {
                        ""name"": ""Sharon Bialy"",
                        ""ids"": {
                          ""trakt"": 3025,
                          ""slug"": ""sharon-bialy"",
                          ""imdb"": ""nm0080544"",
                          ""tmdb"": 6479,
                          ""tvrage"": null
                        }
                      }
                    },
                    {
                      ""job"": ""Executive Producer"",
                      ""person"": {
                        ""name"": ""Gregory Nicotero"",
                        ""ids"": {
                          ""trakt"": 6779,
                          ""slug"": ""gregory-nicotero"",
                          ""imdb"": ""nm0630524"",
                          ""tmdb"": 59287,
                          ""tvrage"": null
                        }
                      }
                    }
                  ],
                  ""crew"": [
                    {
                      ""job"": ""Makeup Effects"",
                      ""person"": {
                        ""name"": ""Gregory Nicotero"",
                        ""ids"": {
                          ""trakt"": 6779,
                          ""slug"": ""gregory-nicotero"",
                          ""imdb"": ""nm0630524"",
                          ""tmdb"": 59287,
                          ""tvrage"": null
                        }
                      }
                    }
                  ],
                  ""art"": [
                    {
                      ""job"": ""Production Design"",
                      ""person"": {
                        ""name"": ""Graham 'Grace' Walker"",
                        ""ids"": {
                          ""trakt"": 42993,
                          ""slug"": ""graham-grace-walker"",
                          ""imdb"": ""nm0907767"",
                          ""tmdb"": 62743,
                          ""tvrage"": null
                        }
                      }
                    }
                  ],
                  ""sound"": [
                    {
                      ""job"": ""Music"",
                      ""person"": {
                        ""name"": ""Bear McCreary"",
                        ""ids"": {
                          ""trakt"": 45352,
                          ""slug"": ""bear-mccreary"",
                          ""imdb"": ""nm0566970"",
                          ""tmdb"": 59811,
                          ""tvrage"": null
                        }
                      }
                    }
                  ],
                  ""writing"": [
                    {
                      ""job"": ""Comic Book"",
                      ""person"": {
                        ""name"": ""Robert Kirkman"",
                        ""ids"": {
                          ""trakt"": 214252,
                          ""slug"": ""robert-kirkman"",
                          ""imdb"": ""nm3079117"",
                          ""tmdb"": 1223867,
                          ""tvrage"": 330021
                        }
                      }
                    },
                    {
                      ""job"": ""Comic Book"",
                      ""person"": {
                        ""name"": ""Charlie Adlard"",
                        ""ids"": {
                          ""trakt"": 466776,
                          ""slug"": ""charlie-adlard"",
                          ""imdb"": ""nm1891501"",
                          ""tmdb"": 1223881,
                          ""tvrage"": null
                        }
                      }
                    },
                    {
                      ""job"": ""Comic Book"",
                      ""person"": {
                        ""name"": ""Tony Moore"",
                        ""ids"": {
                          ""trakt"": 570113,
                          ""slug"": ""tony-moore"",
                          ""imdb"": ""nm3877885"",
                          ""tmdb"": 1223882,
                          ""tvrage"": null
                        }
                      }
                    }
                  ]
                }
              }";

        private const string SHOW_RATINGS_JSON =
            @"{
                ""rating"": 9.38231,
                ""votes"": 44590,
                ""distribution"": {
                  ""1"": 258,
                  ""2"": 57,
                  ""3"": 59,
                  ""4"": 116,
                  ""5"": 262,
                  ""6"": 448,
                  ""7"": 1427,
                  ""8"": 3893,
                  ""9"": 8467,
                  ""10"": 29590
                }
              }";

        private const string SHOW_RELATED_SHOWS_JSON =
            @"[
                {
                  ""title"": ""Sherlock"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 19792,
                    ""slug"": ""sherlock"",
                    ""tvdb"": 176941,
                    ""imdb"": ""tt1475582"",
                    ""tmdb"": 19885,
                    ""tvrage"": 23433
                  },
                  ""overview"": ""Sherlock is a British television crime drama that presents a contemporary adaptation of Sir Arthur Conan Doyle's Sherlock Holmes detective stories. Created by Steven Moffat and Mark Gatiss, it stars Benedict Cumberbatch as Sherlock Holmes and Martin Freeman as Doctor John Watson."",
                  ""first_aired"": ""2010-07-25T07:00:00Z"",
                  ""airs"": {
                    ""day"": ""Sunday"",
                    ""time"": ""20:30"",
                    ""timezone"": ""Europe/London""
                  },
                  ""runtime"": 90,
                  ""certification"": ""TV-14"",
                  ""network"": ""BBC One"",
                  ""country"": ""gb"",
                  ""trailer"": ""http://youtube.com/watch?v=JP5Dr63TbSU"",
                  ""homepage"": ""http://www.bbc.co.uk/programmes/b018ttws"",
                  ""status"": ""returning series"",
                  ""rating"": 9.26159,
                  ""votes"": 22268,
                  ""updated_at"": ""2016-04-07T19:31:38Z"",
                  ""language"": ""en"",
                  ""available_translations"": [
                    ""en"",
                    ""ru"",
                    ""zh"",
                    ""hu""
                  ],
                  ""genres"": [
                    ""drama"",
                    ""crime"",
                    ""mystery"",
                    ""adventure"",
                    ""thriller""
                  ],
                  ""aired_episodes"": 9
                },
                {
                  ""title"": ""11.22.63"",
                  ""year"": 2016,
                  ""ids"": {
                    ""trakt"": 102771,
                    ""slug"": ""11-22-63"",
                    ""tvdb"": 301824,
                    ""imdb"": ""tt2879552"",
                    ""tmdb"": 64464,
                    ""tvrage"": 45210
                  },
                  ""overview"": ""Imagine having the power to change history. Would you journey down the \""rabbit hole\""? This event series follows Jake Epping, an ordinary high school teacher, presented with the unthinkable mission of traveling back in time to prevent the assassination of John F. Kennedy on November 22, 1963. Jake travels to the past in order to solve the most enduring mystery of the 20th century: who killed JFK, and could it have been stopped? But as Jake will learn, the past does not want to be changed. And trying to divert the course of history may prove fatal."",
                  ""first_aired"": ""2016-02-15T08:00:00Z"",
                  ""airs"": {
                    ""day"": ""Monday"",
                    ""time"": ""00:01"",
                    ""timezone"": ""America/New_York""
                  },
                  ""runtime"": 60,
                  ""certification"": ""TV-MA"",
                  ""network"": ""Hulu"",
                  ""country"": ""us"",
                  ""trailer"": ""http://youtube.com/watch?v=NXUx__qQGew"",
                  ""homepage"": ""http://www.hulu.com/112263"",
                  ""status"": """",
                  ""rating"": 8.26689,
                  ""votes"": 607,
                  ""updated_at"": ""2016-04-07T19:47:40Z"",
                  ""language"": ""en"",
                  ""available_translations"": [
                    ""en"",
                    ""fr"",
                    ""bs"",
                    ""he""
                  ],
                  ""genres"": [
                    ""science-fiction"",
                    ""drama"",
                    ""fantasy""
                  ],
                  ""aired_episodes"": 8
                }
              ]";

        private const string SHOW_STATISTICS_JSON =
            @"{
                ""watchers"": 265955,
                ""plays"": 12491168,
                ""collectors"": 106028,
                ""collected_episodes"": 4092901,
                ""comments"": 233,
                ""lists"": 103943,
                ""votes"": 44590
              }";

        private const string SHOW_TRANSLATIONS_JSON =
            @"[
                {
                  ""title"": ""Game of Thrones"",
                  ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and icy horrors beyond.\n\n"",
                  ""language"": ""en""
                },
                {
                  ""title"": ""Le Trône de fer"",
                  ""overview"": ""Il y a très longtemps, à une époque oubliée, une force a détruit l'équilibre des saisons. Dans un pays où l'été peut durer plusieurs années et l'hiver toute une vie, des forces sinistres et surnaturelles se pressent aux portes du Royaume des Sept Couronnes. La confrérie de la Garde de Nuit, protégeant le Royaume de toute créature pouvant provenir d'au-delà du Mur protecteur, n'a plus les ressources nécessaires pour assurer la sécurité de tous. Après un été de dix années, un hiver rigoureux s'abat sur le Royaume avec la promesse d'un avenir des plus sombres. Pendant ce temps, complots et rivalités se jouent sur le continent pour s'emparer du Trône de fer, le symbole du pouvoir absolu."",
                  ""language"": ""fr""
                },
                {
                  ""title"": ""Il Trono di Spade"",
                  ""overview"": ""Il Trono di Spade (Game of Thrones) è una serie televisiva statunitense di genere fantasy creata da David Benioff e D.B. Weiss, che ha debuttato il 17 aprile 2011 sul canale via cavo HBO. È nata come trasposizione televisiva del ciclo di romanzi Cronache del ghiaccio e del fuoco (A Song of Ice and Fire) di George R. R. Martin.\n\nLa serie racconta le avventure di molti personaggi che vivono in un grande mondo immaginario costituito principalmente da due continenti. Il centro più grande e civilizzato del continente occidentale è la città capitale Approdo del Re, dove risiede il Trono di Spade. La lotta per la conquista del trono porta le più grandi famiglie del continente a scontrarsi o allearsi tra loro in un contorto gioco del potere. Ma oltre agli uomini, emergono anche altre forze oscure e magiche."",
                  ""language"": ""it""
                },
                {
                  ""title"": ""Game of Thrones"",
                  ""overview"": ""Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion."",
                  ""language"": ""de""
                }
              ]";

        private const string SHOW_WATCHED_PROGRESS_JSON =
            @"{
                ""aired"": 6,
                ""completed"": 6,
                ""last_watched_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 6,
                    ""completed"": 6,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 3,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 4,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 5,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 6,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": null
                    }
                  }
                ],
                ""next_episode"": null
              }";

        private const string SHOW_WATCHING_USERS_JSON =
            @"[
                {
                  ""username"": ""peoplearemusic"",
                  ""private"": false,
                  ""name"": ""peoplearemusic"",
                  ""vip"": false,
                  ""vip_ep"": false
                },
                {
                  ""username"": ""alvarogb19"",
                  ""private"": true,
                  ""name"": null,
                  ""vip"": false,
                  ""vip_ep"": true
                },
                {
                  ""username"": ""Crunchi"",
                  ""private"": false,
                  ""name"": ""Crunch"",
                  ""vip"": false,
                  ""vip_ep"": false
                }
              ]";

        private const string TRENDING_SHOWS_JSON =
            @"[
                {
                  ""watchers"": 175,
                  ""show"": {
                    ""title"": ""Arrow"",
                    ""year"": 2012,
                    ""ids"": {
                      ""trakt"": 1403,
                      ""slug"": ""arrow"",
                      ""tvdb"": 257655,
                      ""imdb"": ""tt2193021"",
                      ""tmdb"": 1412,
                      ""tvrage"": 30715
                    }
                  }
                },
                {
                  ""watchers"": 137,
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1393,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402,
                      ""tvrage"": 25056
                    }
                  }
                }
              ]";
    }
}
