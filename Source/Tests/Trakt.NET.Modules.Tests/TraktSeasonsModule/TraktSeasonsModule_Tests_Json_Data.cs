namespace TraktNet.Modules.Tests.TraktSeasonsModule
{
    using TraktNet.Enums;
    using TraktNet.Parameters;

    public partial class TraktSeasonsModule_Tests
    {
        private const string SHOW_ID = "1390";
        private const uint TRAKT_SHOD_ID = 1390;
        private const string SHOW_SLUG = "game-of-thrones";
        private const uint SEASON_NR = 1U;
        private const string TRANSLATION_LANGUAGE_CODE = "en";
        private const string TRANSLATION_LANGUAGE_CODE_All = "all";
        private const uint PAGE = 2;
        private const uint LIMIT = 4;
        private const int ITEM_COUNT = 3;
        private const int LIST_ITEM_COUNT = 10;
        private readonly TraktExtendedInfo EXTENDED_INFO = new TraktExtendedInfo { Full = true };
        private readonly TraktShowsCommentSortOrder COMMENT_SORT_ORDER = TraktShowsCommentSortOrder.Likes;
        private readonly TraktListType LIST_TYPE = TraktListType.Official;
        private readonly TraktListSortOrder LIST_SORT_ORDER = TraktListSortOrder.Comments;
        private const string LANGUAGE_CODE = "en";

        private const string SEASON_TRANSLATIONS_JSON =
            @"[
                {
                  ""title"": ""시즌 1"",
                  ""overview"": ""웨스테로스 북부 지방 윈터펠을 다스리는 에다드 스타크. 스타크 가문은 '겨울이 오고 있다'를 가언으"",
                  ""language"": ""ko""
                },
                {
                  ""title"": ""Seizoen 1"",
                  ""overview"": ""Het eerste seizoen van de epische fantasy tv- drama-serie Game of Thrones ging in premi"",
                  ""language"": ""nl""
                },
                {
                  ""title"": ""Sesong 1"",
                  ""overview"": ""Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011."",
                  ""language"": ""no""
                }
              ]";

        private const string SEASONS_ALL_FULL_JSON =
            @"[
                {
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
                  ""overview"": null,
                  ""first_aired"": ""2014-10-08T00:00:00Z""
                },
                {
                  ""number"": 2,
                  ""title"": ""Season 2"",
                  ""ids"": {
                    ""trakt"": 110984,
                    ""tvdb"": null,
                    ""tmdb"": 66922,
                    ""tvrage"": null
                  },
                  ""rating"": 8.61539,
                  ""votes"": 325,
                  ""episode_count"": 23,
                  ""aired_episodes"": 17,
                  ""overview"": ""Following the defeat of Barry Allen's arch-nemesis Eobard Thawne (aka Reverse Flash), Team Flash quickly turned their attention to the singularity swirling high above Central City, which fans last saw consuming everything in its path. Armed with the heart of a hero and the ability to move at super speeds, Barry charged into the eye of the singularity, but will he actually be able to save his city from impending doom?"",
                  ""first_aired"": ""2015-10-07T00:00:00Z""
                }
              ]";

        private const string SEASON_EPISODES_JSON =
            @"[
                {
                  ""season"": 1,
                  ""number"": 1,
                  ""title"": ""Winter Is Coming"",
                  ""ids"": {
                    ""trakt"": 456,
                    ""tvdb"": 3254641,
                    ""imdb"": ""tt1480055"",
                    ""tmdb"": 63056,
                    ""tvrage"": null
                  }
                },
                {
                  ""season"": 1,
                  ""number"": 2,
                  ""title"": ""The Kingsroad"",
                  ""ids"": {
                    ""trakt"": 457,
                    ""tvdb"": 3436411,
                    ""imdb"": ""tt1668746"",
                    ""tmdb"": 63057,
                    ""tvrage"": null
                  }
                },
                {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Lord Snow"",
                  ""ids"": {
                    ""trakt"": 458,
                    ""tvdb"": 3436421,
                    ""imdb"": ""tt1829962"",
                    ""tmdb"": 63058,
                    ""tvrage"": null
                  }
                },
                {
                  ""season"": 1,
                  ""number"": 4,
                  ""title"": ""Cripples, Bastards, and Broken Things"",
                  ""ids"": {
                    ""trakt"": 459,
                    ""tvdb"": 3436431,
                    ""imdb"": ""tt1829963"",
                    ""tmdb"": 63059,
                    ""tvrage"": null
                  }
                },
                {
                  ""season"": 1,
                  ""number"": 5,
                  ""title"": ""The Wolf and the Lion"",
                  ""ids"": {
                    ""trakt"": 460,
                    ""tvdb"": 3436441,
                    ""imdb"": ""tt1829964"",
                    ""tmdb"": 63060,
                    ""tvrage"": null
                  }
                },
                {
                  ""season"": 1,
                  ""number"": 6,
                  ""title"": ""A Golden Crown"",
                  ""ids"": {
                    ""trakt"": 461,
                    ""tvdb"": 3436451,
                    ""imdb"": ""tt1837862"",
                    ""tmdb"": 63061,
                    ""tvrage"": null
                  }
                },
                {
                  ""season"": 1,
                  ""number"": 7,
                  ""title"": ""You Win or You Die"",
                  ""ids"": {
                    ""trakt"": 462,
                    ""tvdb"": 3436461,
                    ""imdb"": ""tt1837863"",
                    ""tmdb"": 63062,
                    ""tvrage"": null
                  }
                },
                {
                  ""season"": 1,
                  ""number"": 8,
                  ""title"": ""The Pointy End"",
                  ""ids"": {
                    ""trakt"": 463,
                    ""tvdb"": 3360391,
                    ""imdb"": ""tt1837864"",
                    ""tmdb"": 63063,
                    ""tvrage"": null
                  }
                },
                {
                  ""season"": 1,
                  ""number"": 9,
                  ""title"": ""Baelor"",
                  ""ids"": {
                    ""trakt"": 464,
                    ""tvdb"": 4063481,
                    ""imdb"": ""tt1851398"",
                    ""tmdb"": 63064,
                    ""tvrage"": null
                  }
                },
                {
                  ""season"": 1,
                  ""number"": 10,
                  ""title"": ""Fire and Blood"",
                  ""ids"": {
                    ""trakt"": 465,
                    ""tvdb"": 4063491,
                    ""imdb"": ""tt1851397"",
                    ""tmdb"": 63065,
                    ""tvrage"": null
                  }
                }
              ]";

        private const string SEASON_COMMENTS_JSON =
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
                },
                {
                  ""id"": 10,
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

        private const string SEASON_LISTS_JSON =
            @"[
                {
                  ""name"": ""TV Seasons Finished"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""title"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2017-01-19T22:21:47.000Z"",
                  ""updated_at"": ""2017-01-23T21:19:06.000Z"",
                  ""item_count"": 298,
                  ""comment_count"": 0,
                  ""likes"": 1,
                  ""ids"": {
                    ""trakt"": 3218299,
                    ""slug"": ""tv-seasons-finished""
                  },
                  ""user"": {
                    ""username"": ""Milo123"",
                    ""private"": false,
                    ""name"": """",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""milo123""
                    }
                  }
                },
                {
                  ""name"": ""MARVEL Cinematic Universe"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-07-20T14:05:03.000Z"",
                  ""updated_at"": ""2016-10-13T02:05:40.000Z"",
                  ""item_count"": 30,
                  ""comment_count"": 0,
                  ""likes"": 1,
                  ""ids"": {
                    ""trakt"": 2489693,
                    ""slug"": ""marvel-cinematic-universe""
                  },
                  ""user"": {
                    ""username"": ""SrCAPnCDLvl99"",
                    ""private"": false,
                    ""name"": ""Robin Abrahamsson"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""srcapncdlvl99""
                    }
                  }
                },
                {
                  ""name"": ""TV SHOWS WATCHED"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-06-05T03:18:14.000Z"",
                  ""updated_at"": ""2016-08-06T12:31:24.000Z"",
                  ""item_count"": 395,
                  ""comment_count"": 0,
                  ""likes"": 1,
                  ""ids"": {
                    ""trakt"": 2341085,
                    ""slug"": ""tv-shows-watched""
                  },
                  ""user"": {
                    ""username"": ""indeed2015"",
                    ""private"": false,
                    ""name"": """",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""indeed2015""
                    }
                  }
                },
                {
                  ""name"": ""MCU Ranked"",
                  ""description"": ""Movies and Television shows. "",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-11-25T05:33:44.000Z"",
                  ""updated_at"": ""2016-11-30T11:48:33.000Z"",
                  ""item_count"": 23,
                  ""comment_count"": 0,
                  ""likes"": 0,
                  ""ids"": {
                    ""trakt"": 2942742,
                    ""slug"": ""mcu-ranked""
                  },
                  ""user"": {
                    ""username"": ""Jordyep"",
                    ""private"": false,
                    ""name"": ""Jordy Krijgsman"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""jordyep""
                    }
                  }
                },
                {
                  ""name"": ""TV"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""title"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-11-20T16:08:03.000Z"",
                  ""updated_at"": ""2016-12-30T10:43:50.000Z"",
                  ""item_count"": 21,
                  ""comment_count"": 0,
                  ""likes"": 0,
                  ""ids"": {
                    ""trakt"": 2925521,
                    ""slug"": ""tv""
                  },
                  ""user"": {
                    ""username"": ""bigfatfat"",
                    ""private"": false,
                    ""name"": null,
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""bigfatfat""
                    }
                  }
                },
                {
                  ""name"": ""TV SHOWS WATCHED"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""title"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-11-14T16:41:07.000Z"",
                  ""updated_at"": ""2016-11-18T15:59:19.000Z"",
                  ""item_count"": 532,
                  ""comment_count"": 0,
                  ""likes"": 0,
                  ""ids"": {
                    ""trakt"": 2904829,
                    ""slug"": ""tv-shows-watched""
                  },
                  ""user"": {
                    ""username"": ""ZSV"",
                    ""private"": false,
                    ""name"": """",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""zsv""
                    }
                  }
                },
                {
                  ""name"": ""Marvel"",
                  ""description"": ""Героите на комиксите MARVEL"",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""released"",
                  ""sort_how"": ""desc"",
                  ""created_at"": ""2016-11-13T18:34:30.000Z"",
                  ""updated_at"": ""2016-11-13T19:02:20.000Z"",
                  ""item_count"": 30,
                  ""comment_count"": 0,
                  ""likes"": 0,
                  ""ids"": {
                    ""trakt"": 2901353,
                    ""slug"": ""marvel""
                  },
                  ""user"": {
                    ""username"": ""Udi80_29"",
                    ""private"": false,
                    ""name"": ""Udi"",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""udi80_29""
                    }
                  }
                },
                {
                  ""name"": ""Watched."",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-11-02T16:36:11.000Z"",
                  ""updated_at"": ""2016-11-02T16:42:08.000Z"",
                  ""item_count"": 12,
                  ""comment_count"": 0,
                  ""likes"": 0,
                  ""ids"": {
                    ""trakt"": 2862073,
                    ""slug"": ""watched""
                  },
                  ""user"": {
                    ""username"": ""Vaitelavicius"",
                    ""private"": false,
                    ""name"": null,
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""vaitelavicius""
                    }
                  }
                },
                {
                  ""name"": ""Marvel Cinematic Universe"",
                  ""description"": ""Movies and series are sorted by the story timeline."",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-09-11T01:25:39.000Z"",
                  ""updated_at"": ""2016-12-17T14:25:03.000Z"",
                  ""item_count"": 44,
                  ""comment_count"": 0,
                  ""likes"": 0,
                  ""ids"": {
                    ""trakt"": 2661847,
                    ""slug"": ""marvel-cinematic-universe""
                  },
                  ""user"": {
                    ""username"": ""hermajan"",
                    ""private"": false,
                    ""name"": ""Jan Hermann"",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""hermajan""
                    }
                  }
                },
                {
                  ""name"": ""Marvels Cinematic Universe"",
                  ""description"": ""According to: http://bit.ly/1SUgzFD"",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-08-11T10:41:45.000Z"",
                  ""updated_at"": ""2016-08-11T12:11:38.000Z"",
                  ""item_count"": 39,
                  ""comment_count"": 0,
                  ""likes"": 0,
                  ""ids"": {
                    ""trakt"": 2559828,
                    ""slug"": ""marvels-cinematic-universe""
                  },
                  ""user"": {
                    ""username"": ""co2p"",
                    ""private"": false,
                    ""name"": """",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""co2p""
                    }
                  }
                }
              ]";

        private const string SEASON_RATINGS_JSON =
            @"{
                ""rating"": 9.12881,
                ""votes"": 1149,
                ""distribution"": {
                  ""1"": 7,
                  ""2"": 5,
                  ""3"": 4,
                  ""4"": 2,
                  ""5"": 9,
                  ""6"": 23,
                  ""7"": 45,
                  ""8"": 152,
                  ""9"": 282,
                  ""10"": 620
                }
              }";

        private const string SEASON_STATISTICS_JSON =
            @"{
                ""watchers"": 232215,
                ""plays"": 2719701,
                ""collectors"": 91770,
                ""collected_episodes"": 907358,
                ""comments"": 6,
                ""lists"": 250,
                ""votes"": 1149
              }";

        private const string SEASON_WATCHING_USERS_JSON =
            @"[
                {
                  ""username"": ""TheBossWithE"",
                  ""private"": false,
                  ""name"": """",
                  ""vip"": false,
                  ""vip_ep"": false
                },
                {
                  ""username"": ""spazatabc"",
                  ""private"": false,
                  ""name"": ""Daniel Lake"",
                  ""vip"": false,
                  ""vip_ep"": false
                },
                {
                  ""username"": ""TiMoose"",
                  ""private"": false,
                  ""name"": """",
                  ""vip"": false,
                  ""vip_ep"": false
                }
              ]";

        private const string SEASON_PEOPLE_JSON =
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
    }
}
