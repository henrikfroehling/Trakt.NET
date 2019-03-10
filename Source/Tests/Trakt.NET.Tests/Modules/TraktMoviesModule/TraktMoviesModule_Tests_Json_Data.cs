namespace TraktNet.Tests.Modules.TraktMoviesModule
{
    using System;
    using TraktNet.Enums;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Parameters.Filter;

    public partial class TraktMoviesModule_Tests
    {
        private const string MOVIE_ID = "94024";
        private const string COUNTRY_CODE = "us";
        private const string LANGUAGE_CODE = "en";
        private const uint PAGE = 2;
        private const uint LIMIT = 4;
        private const int ITEM_COUNT = 2;
        private const int USER_COUNT = 300;
        private const int LISTS_ITEM_COUNT = 10;
        private readonly TraktExtendedInfo EXTENDED_INFO = new TraktExtendedInfo { Full = true };
        private readonly TraktTimePeriod TIME_PERIOD = TraktTimePeriod.Monthly;
        private readonly TraktCommentSortOrder COMMENT_SORT_ORDER = TraktCommentSortOrder.Likes;
        private readonly TraktListSortOrder LIST_SORT_ORDER = TraktListSortOrder.Comments;
        private readonly TraktListType LIST_TYPE = TraktListType.Official;
        private readonly DateTime TODAY = DateTime.UtcNow;

        private readonly ITraktMovieFilter FILTER = TraktFilterDirectory.MovieFilter
            .WithCertifications("TV-MA")
            .WithQuery("most anticipated movie")
            .WithYear(2016)
            .WithGenres("action", "fantasy")
            .WithLanguages("en", "de")
            .WithCountries("us")
            .WithRuntimes(90, 180)
            .WithRatings(70, 90)
            .Build();

        private const string BOX_OFFICE_MOVIES_JSON =
            @"[
                {
                  ""revenue"": 166007347,
                  ""movie"": {
                    ""title"": ""Batman v Superman: Dawn of Justice"",
                    ""year"": 2016,
                    ""ids"": {
                      ""trakt"": 129583,
                      ""slug"": ""batman-v-superman-dawn-of-justice-2016"",
                      ""imdb"": ""tt2975590"",
                      ""tmdb"": 209112
                    }
                  }
                },
                {
                  ""revenue"": 24000000,
                  ""movie"": {
                    ""title"": ""Zootopia"",
                    ""year"": 2016,
                    ""ids"": {
                      ""trakt"": 167397,
                      ""slug"": ""zootopia-2016"",
                      ""imdb"": ""tt2948356"",
                      ""tmdb"": 269149
                    }
                  }
                }
              ]";

        private const string MOST_ANTICIPATED_MOVIES_JSON =
            @"[
                {
                  ""list_count"": 12805,
                  ""movie"": {
                    ""title"": ""Captain America: Civil War"",
                    ""year"": 2016,
                    ""ids"": {
                      ""trakt"": 169105,
                      ""slug"": ""captain-america-civil-war-2016"",
                      ""imdb"": ""tt3498820"",
                      ""tmdb"": 271110
                    }
                  }
                },
                {
                  ""list_count"": 11387,
                  ""movie"": {
                    ""title"": ""X-Men: Apocalypse"",
                    ""year"": 2016,
                    ""ids"": {
                      ""trakt"": 149999,
                      ""slug"": ""x-men-apocalypse-2016"",
                      ""imdb"": ""tt3385516"",
                      ""tmdb"": 246655
                    }
                  }
                }
              ]";

        private const string MOST_COLLECTED_MOVIES_JSON =
            @"[
                {
                  ""watcher_count"": 0,
                  ""play_count"": 0,
                  ""collected_count"": 4353,
                  ""movie"": {
                    ""title"": ""Bass on Titles"",
                    ""year"": 1977,
                    ""ids"": {
                      ""trakt"": 200212,
                      ""slug"": ""bass-on-titles-1977"",
                      ""imdb"": ""tt0075731"",
                      ""tmdb"": 319497
                    }
                  }
                },
                {
                  ""watcher_count"": 4683,
                  ""play_count"": 6542,
                  ""collected_count"": 1866,
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
                }
              ]";

        private const string MOST_PLAYED_MOVIES_JSON =
            @"[
                {
                  ""watcher_count"": 4992,
                  ""play_count"": 7100,
                  ""collected_count"": 1348,
                  ""movie"": {
                    ""title"": ""Deadpool"",
                    ""year"": 2016,
                    ""ids"": {
                      ""trakt"": 190430,
                      ""slug"": ""deadpool-2016"",
                      ""imdb"": ""tt1431045"",
                      ""tmdb"": 293660
                    }
                  }
                },
                {
                  ""watcher_count"": 3962,
                  ""play_count"": 6622,
                  ""collected_count"": 1181,
                  ""movie"": {
                    ""title"": ""Batman v Superman: Dawn of Justice"",
                    ""year"": 2016,
                    ""ids"": {
                      ""trakt"": 129583,
                      ""slug"": ""batman-v-superman-dawn-of-justice-2016"",
                      ""imdb"": ""tt2975590"",
                      ""tmdb"": 209112
                    }
                  }
                }
              ]";

        private const string MOST_WATCHED_MOVIES_JSON =
            @"[
                {
                  ""watcher_count"": 4992,
                  ""play_count"": 7100,
                  ""collected_count"": 1348,
                  ""movie"": {
                    ""title"": ""Deadpool"",
                    ""year"": 2016,
                    ""ids"": {
                      ""trakt"": 190430,
                      ""slug"": ""deadpool-2016"",
                      ""imdb"": ""tt1431045"",
                      ""tmdb"": 293660
                    }
                  }
                },
                {
                  ""watcher_count"": 4683,
                  ""play_count"": 6542,
                  ""collected_count"": 1866,
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
                }
              ]";

        private const string MOVIE_JSON =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string MOVIE_ALIASES_JSON =
            @"[
                {
                  ""title"": ""Star Wars 7"",
                  ""country"": ""us""
                },
                {
                  ""title"": ""Star Wars: O Despertar da Força"",
                  ""country"": ""br""
                },
                {
                  ""title"": ""Star Wars El despertar de la Fuerza"",
                  ""country"": ""es""
                },
                {
                  ""title"": ""La guerra de las galaxias. Episodio 7. El despertar de la Fuerza."",
                  ""country"": ""es""
                }
              ]";

        private const string MOVIE_COMMENTS_JSON =
            @"[
                {
                  ""id"": 77543,
                  ""comment"": ""Fantastic excellent photography and film"",
                  ""spoiler"": false,
                  ""review"": true,
                  ""parent_id"": 1,
                  ""created_at"": ""2016-04-05T21:07:16Z"",
                  ""updated_at"": ""2016-04-06T18:01:02Z"",
                  ""replies"": 2,
                  ""likes"": 3,
                  ""user_rating"": 9,
                  ""user"": {
                    ""username"": ""saad20300"",
                    ""private"": false,
                    ""name"": ""sf3384 /saad"",
                    ""vip"": false,
                    ""vip_ep"": false
                  }
                },
                {
                  ""id"": 77164,
                  ""comment"": ""Nothing over exciting. Just a fantasy with elements of comedy. Even Ford didn't help. "",
                  ""spoiler"": false,
                  ""review"": false,
                  ""parent_id"": 0,
                  ""created_at"": ""2016-04-02T23:38:12Z"",
                  ""updated_at"": ""2016-04-04T11:45:34Z"",
                  ""replies"": 0,
                  ""likes"": 0,
                  ""user_rating"": 5,
                  ""user"": {
                    ""username"": ""SergeyZakutaylo"",
                    ""private"": false,
                    ""name"": ""Sergey Zakutaylo"",
                    ""vip"": false,
                    ""vip_ep"": false
                  }
                }
              ]";

        private const string MOVIE_LISTS_JSON =
            @"[
                {
                  ""name"": ""Underground Network"",
                  ""description"": ""Underground network, alternative communication."",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2015-07-31T16:28:39.000Z"",
                  ""updated_at"": ""2017-01-22T00:32:40.000Z"",
                  ""item_count"": 29,
                  ""comment_count"": 5,
                  ""likes"": 197,
                  ""ids"": {
                    ""trakt"": 1289835,
                    ""slug"": ""underground-network""
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
                  ""name"": ""All-Time Worldwide Box office (update 10/10/2016)"",
                  ""description"": ""The All-Time Worldwide Box office list includes movies that have grossed over $200,000,000 at the box office during their theatrical runs. Only theatrical box office receipts (movie ticket sales) are included, video rentals, television rights and other revenues are thus ignored. The total may include theatrical re-release receipts. Figures are not adjusted for inflation."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-04-23T12:09:34.000Z"",
                  ""updated_at"": ""2017-01-19T13:09:04.000Z"",
                  ""item_count"": 660,
                  ""comment_count"": 0,
                  ""likes"": 59,
                  ""ids"": {
                    ""trakt"": 2183985,
                    ""slug"": ""all-time-worldwide-box-office-update-10-10-2016""
                  },
                  ""user"": {
                    ""username"": ""dc921"",
                    ""private"": false,
                    ""name"": ""dc921"",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""dc921""
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
                  ""name"": ""Sci-Fi 1970-2013"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-04-28T13:12:38.000Z"",
                  ""updated_at"": ""2017-01-08T10:20:44.000Z"",
                  ""item_count"": 1293,
                  ""comment_count"": 1,
                  ""likes"": 31,
                  ""ids"": {
                    ""trakt"": 840022,
                    ""slug"": ""sci-fi-1970-2013""
                  },
                  ""user"": {
                    ""username"": ""batarela"",
                    ""private"": false,
                    ""name"": null,
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""batarela""
                    }
                  }
                },
                {
                  ""name"": ""Movies"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-01-26T20:23:30.000Z"",
                  ""updated_at"": ""2016-12-13T23:42:49.000Z"",
                  ""item_count"": 2182,
                  ""comment_count"": 0,
                  ""likes"": 14,
                  ""ids"": {
                    ""trakt"": 1789302,
                    ""slug"": ""movies""
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
                  ""name"": ""Hacker Movies"",
                  ""description"": ""Hack the Planet!\r\n\r\nAll the hacking movies and related."",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-05-12T19:39:07.000Z"",
                  ""updated_at"": ""2016-10-05T18:58:03.000Z"",
                  ""item_count"": 39,
                  ""comment_count"": 0,
                  ""likes"": 3,
                  ""ids"": {
                    ""trakt"": 2259437,
                    ""slug"": ""hacker-movies""
                  },
                  ""user"": {
                    ""username"": ""garyalexza"",
                    ""private"": false,
                    ""name"": ""Gary Alexander"",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""garyalexza""
                    }
                  }
                },
                {
                  ""name"": ""Movies "",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""title"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-03-16T00:06:52.000Z"",
                  ""updated_at"": ""2016-08-13T03:39:13.000Z"",
                  ""item_count"": 5619,
                  ""comment_count"": 0,
                  ""likes"": 3,
                  ""ids"": {
                    ""trakt"": 2026667,
                    ""slug"": ""movies""
                  },
                  ""user"": {
                    ""username"": ""Jayseal01 "",
                    ""private"": false,
                    ""name"": null,
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""jayseal01""
                    }
                  }
                },
                {
                  ""name"": ""All Time Favorite Movies"",
                  ""description"": ""My favorite movies throughout my entire movie watching career."",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2015-12-11T06:06:57.000Z"",
                  ""updated_at"": ""2016-09-16T04:52:57.000Z"",
                  ""item_count"": 33,
                  ""comment_count"": 0,
                  ""likes"": 11,
                  ""ids"": {
                    ""trakt"": 1625180,
                    ""slug"": ""all-time-favorite-movies""
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
                  ""name"": ""Cyberpunk"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2015-10-30T17:23:29.000Z"",
                  ""updated_at"": ""2016-09-16T04:55:33.000Z"",
                  ""item_count"": 181,
                  ""comment_count"": 0,
                  ""likes"": 5,
                  ""ids"": {
                    ""trakt"": 1528948,
                    ""slug"": ""cyberpunk""
                  },
                  ""user"": {
                    ""username"": ""Oya Kesh"",
                    ""private"": false,
                    ""name"": """",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""oya-kesh""
                    }
                  }
                },
                {
                  ""name"": ""Underground"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2015-10-30T17:19:02.000Z"",
                  ""updated_at"": ""2016-12-30T19:27:28.000Z"",
                  ""item_count"": 47,
                  ""comment_count"": 0,
                  ""likes"": 1,
                  ""ids"": {
                    ""trakt"": 1528944,
                    ""slug"": ""underground""
                  },
                  ""user"": {
                    ""username"": ""Oya Kesh"",
                    ""private"": false,
                    ""name"": """",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""oya-kesh""
                    }
                  }
                }
              ]";

        private const string MOVIE_PEOPLE_JSON =
            @"{
                ""cast"": [
                  {
                    ""character"": ""Rey"",
                    ""person"": {
                      ""name"": ""Daisy Ridley"",
                      ""ids"": {
                        ""trakt"": 262671,
                        ""slug"": ""daisy-ridley"",
                        ""imdb"": ""nm5397459"",
                        ""tmdb"": 1315036,
                        ""tvrage"": null
                      }
                    }
                  },
                  {
                    ""character"": ""Finn"",
                    ""person"": {
                      ""name"": ""John Boyega"",
                      ""ids"": {
                        ""trakt"": 447661,
                        ""slug"": ""john-boyega"",
                        ""imdb"": ""nm3915784"",
                        ""tmdb"": 236695,
                        ""tvrage"": null
                      }
                    }
                  },
                  {
                    ""character"": ""Kylo Ren"",
                    ""person"": {
                      ""name"": ""Adam Driver"",
                      ""ids"": {
                        ""trakt"": 449885,
                        ""slug"": ""adam-driver"",
                        ""imdb"": ""nm3485845"",
                        ""tmdb"": 1023139,
                        ""tvrage"": 331902
                      }
                    }
                  }
                ],
                ""crew"": {
                  ""writing"": [
                    {
                      ""job"": ""Characters"",
                      ""person"": {
                        ""name"": ""George Lucas"",
                        ""ids"": {
                          ""trakt"": 456,
                          ""slug"": ""george-lucas"",
                          ""imdb"": ""nm0000184"",
                          ""tmdb"": 1,
                          ""tvrage"": 6490
                        }
                      }
                    },
                    {
                      ""job"": ""Writer"",
                      ""person"": {
                        ""name"": ""Michael Arndt"",
                        ""ids"": {
                          ""trakt"": 9128,
                          ""slug"": ""michael-arndt"",
                          ""imdb"": ""nm1578335"",
                          ""tmdb"": 16961,
                          ""tvrage"": null
                        }
                      }
                    }
                  ],
                  ""sound"": [
                    {
                      ""job"": ""Original Music Composer"",
                      ""person"": {
                        ""name"": ""John Williams"",
                        ""ids"": {
                          ""trakt"": 471,
                          ""slug"": ""john-williams"",
                          ""imdb"": ""nm0002354"",
                          ""tmdb"": 491,
                          ""tvrage"": 311422
                        }
                      }
                    },
                    {
                      ""job"": ""Music Editor"",
                      ""person"": {
                        ""name"": ""Ramiro Belgardt"",
                        ""ids"": {
                          ""trakt"": 17808,
                          ""slug"": ""ramiro-belgardt"",
                          ""imdb"": ""nm1103834"",
                          ""tmdb"": 21122,
                          ""tvrage"": null
                        }
                      }
                    }
                  ],
                  ""art"": [
                    {
                      ""job"": ""Production Design"",
                      ""person"": {
                        ""name"": ""Rick Carter"",
                        ""ids"": {
                          ""trakt"": 916,
                          ""slug"": ""rick-carter"",
                          ""imdb"": ""nm0141437"",
                          ""tmdb"": 496,
                          ""tvrage"": null
                        }
                      }
                    },
                    {
                      ""job"": ""Art Direction"",
                      ""person"": {
                        ""name"": ""Gary Tomkins"",
                        ""ids"": {
                          ""trakt"": 6978,
                          ""slug"": ""gary-tomkins"",
                          ""imdb"": ""nm0866772"",
                          ""tmdb"": 11225,
                          ""tvrage"": null
                        }
                      }
                    }
                  ],
                  ""costume & make-up"": [
                    {
                      ""job"": ""Costume Design"",
                      ""person"": {
                        ""name"": ""Michael Kaplan"",
                        ""ids"": {
                          ""trakt"": 1000,
                          ""slug"": ""michael-kaplan"",
                          ""imdb"": ""nm0438325"",
                          ""tmdb"": 605,
                          ""tvrage"": null
                        }
                      }
                    },
                    {
                      ""job"": ""Makeup Department Head"",
                      ""person"": {
                        ""name"": ""Amanda Knight"",
                        ""ids"": {
                          ""trakt"": 8206,
                          ""slug"": ""amanda-knight"",
                          ""imdb"": ""nm0460792"",
                          ""tmdb"": 11298,
                          ""tvrage"": null
                        }
                      }
                    }
                  ],
                  ""production"": [
                    {
                      ""job"": ""Casting"",
                      ""person"": {
                        ""name"": ""April Webster"",
                        ""ids"": {
                          ""trakt"": 4577,
                          ""slug"": ""april-webster"",
                          ""imdb"": ""nm0916825"",
                          ""tmdb"": 6052,
                          ""tvrage"": null
                        }
                      }
                    },
                    {
                      ""job"": ""Associate Producer"",
                      ""person"": {
                        ""name"": ""Michael Arndt"",
                        ""ids"": {
                          ""trakt"": 9128,
                          ""slug"": ""michael-arndt"",
                          ""imdb"": ""nm1578335"",
                          ""tmdb"": 16961,
                          ""tvrage"": null
                        }
                      }
                    }
                  ],
                  ""crew"": [
                    {
                      ""job"": ""Stunt Coordinator"",
                      ""person"": {
                        ""name"": ""Rob Inch"",
                        ""ids"": {
                          ""trakt"": 8790,
                          ""slug"": ""rob-inch"",
                          ""imdb"": ""nm0408449"",
                          ""tmdb"": 40713,
                          ""tvrage"": null
                        }
                      }
                    },
                    {
                      ""job"": ""Property Master"",
                      ""person"": {
                        ""name"": ""Jamie Wilkinson"",
                        ""ids"": {
                          ""trakt"": 76042,
                          ""slug"": ""jamie-wilkinson"",
                          ""imdb"": ""nm0929409"",
                          ""tmdb"": 1335553,
                          ""tvrage"": null
                        }
                      }
                    }
                  ],
                  ""camera"": [
                    {
                      ""job"": ""Director of Photography"",
                      ""person"": {
                        ""name"": ""Daniel Mindel"",
                        ""ids"": {
                          ""trakt"": 9544,
                          ""slug"": ""daniel-mindel"",
                          ""imdb"": ""nm0591053"",
                          ""tmdb"": 15348,
                          ""tvrage"": null
                        }
                      }
                    },
                    {
                      ""job"": ""First Assistant Camera"",
                      ""person"": {
                        ""name"": ""Robert Palmer"",
                        ""ids"": {
                          ""trakt"": 206622,
                          ""slug"": ""robert-palmer-ac34bf9e-4c7d-4042-a313-c4ba19c74f70"",
                          ""imdb"": null,
                          ""tmdb"": 1020703,
                          ""tvrage"": null
                        }
                      }
                    }
                  ],
                  ""editing"": [
                    {
                      ""job"": ""Editor"",
                      ""person"": {
                        ""name"": ""Maryann Brandon"",
                        ""ids"": {
                          ""trakt"": 12215,
                          ""slug"": ""maryann-brandon"",
                          ""imdb"": ""nm0104783"",
                          ""tmdb"": 15349,
                          ""tvrage"": null
                        }
                      }
                    },
                    {
                      ""job"": ""Editor"",
                      ""person"": {
                        ""name"": ""Mary Jo Markey"",
                        ""ids"": {
                          ""trakt"": 12216,
                          ""slug"": ""mary-jo-markey"",
                          ""imdb"": ""nm0548407"",
                          ""tmdb"": 15350,
                          ""tvrage"": null
                        }
                      }
                    }
                  ],
                  ""visual effects"": [
                    {
                      ""job"": ""Visual Effects Supervisor"",
                      ""person"": {
                        ""name"": ""Roger Guyett"",
                        ""ids"": {
                          ""trakt"": 143898,
                          ""slug"": ""roger-guyett"",
                          ""imdb"": ""nm0004361"",
                          ""tmdb"": 1339450,
                          ""tvrage"": null
                        }
                      }
                    },
                    {
                      ""job"": ""Special Effects Supervisor"",
                      ""person"": {
                        ""name"": ""Chris Corbould"",
                        ""ids"": {
                          ""trakt"": 246957,
                          ""slug"": ""chris-corbould"",
                          ""imdb"": ""nm0179269"",
                          ""tmdb"": 1081073,
                          ""tvrage"": null
                        }
                      }
                    }
                  ],
                  ""directing"": [
                    {
                      ""job"": ""Director"",
                      ""person"": {
                        ""name"": ""J.J. Abrams"",
                        ""ids"": {
                          ""trakt"": 300172,
                          ""slug"": ""j-j-abrams"",
                          ""imdb"": ""nm0009190"",
                          ""tmdb"": 15344,
                          ""tvrage"": 8017
                        }
                      }
                    }
                  ],
                  ""lighting"": [
                    {
                      ""job"": ""Gaffer"",
                      ""person"": {
                        ""name"": ""Christopher Prampin"",
                        ""ids"": {
                          ""trakt"": 455570,
                          ""slug"": ""christopher-prampin"",
                          ""imdb"": ""nm0695198"",
                          ""tmdb"": 1399475,
                          ""tvrage"": null
                        }
                      }
                    },
                    {
                      ""job"": ""Gaffer"",
                      ""person"": {
                        ""name"": ""David Sinfield"",
                        ""ids"": {
                          ""trakt"": 480203,
                          ""slug"": ""david-sinfield"",
                          ""imdb"": ""nm1112621"",
                          ""tmdb"": 1405198,
                          ""tvrage"": null
                        }
                      }
                    }
                  ]
                }
              }";

        private const string MOVIE_RATINGS_JSON =
            @"{
                ""rating"": 8.31325,
                ""votes"": 10359,
                ""distribution"": {
                  ""1"": 185,
                  ""2"": 28,
                  ""3"": 34,
                  ""4"": 89,
                  ""5"": 184,
                  ""6"": 630,
                  ""7"": 1244,
                  ""8"": 2509,
                  ""9"": 2622,
                  ""10"": 2834
                }
              }";

        private const string MOVIE_RELATED_MOVIES_JSON =
            @"[
                {
                  ""title"": ""Star Wars: Episode V - The Empire Strikes Back"",
                  ""year"": 1980,
                  ""ids"": {
                    ""trakt"": 1266,
                    ""slug"": ""star-wars-episode-v-the-empire-strikes-back-1980"",
                    ""imdb"": ""tt0080684"",
                    ""tmdb"": 1891
                  },
                  ""tagline"": ""The Adventure Continues..."",
                  ""overview"": ""The epic saga continues as Luke Skywalker, in hopes of defeating the evil Galactic Empire, learns the ways of the Jedi from aging master Yoda. But Darth Vader is more determined than ever to capture Luke. Meanwhile, rebel leader Princess Leia, cocky Han Solo, Chewbacca, and droids C-3PO and R2-D2 are thrown into various stages of capture, betrayal and despair."",
                  ""released"": ""1980-05-17"",
                  ""runtime"": 124,
                  ""trailer"": null,
                  ""homepage"": ""http://www.starwars.com/films/star-wars-episode-v-the-empire-strikes-back"",
                  ""rating"": 8.77461,
                  ""votes"": 13421,
                  ""updated_at"": ""2016-04-04T08:50:42Z"",
                  ""language"": ""en"",
                  ""available_translations"": [
                    ""en"",
                    ""de"",
                    ""fr"",
                    ""it""
                  ],
                  ""genres"": [
                    ""action"",
                    ""adventure"",
                    ""science-fiction""
                  ],
                  ""certification"": ""PG""
                },
                {
                  ""title"": ""Return of the Jedi"",
                  ""year"": 1983,
                  ""ids"": {
                    ""trakt"": 1267,
                    ""slug"": ""return-of-the-jedi-1983"",
                    ""imdb"": ""tt0086190"",
                    ""tmdb"": 1892
                  },
                  ""tagline"": ""The Empire Falls..."",
                  ""overview"": ""As Rebel leaders map their strategy for an all-out attack on the Emperor's newer, bigger Death Star. Han Solo remains frozen in the cavernous desert fortress of Jabba the Hutt, the most loathsome outlaw in the universe, who is also keeping Princess Leia as a slave girl. Now a master of the Force, Luke Skywalker rescues his friends, but he cannot become a true Jedi Knight until he wages his own crucial battle against Darth Vader, who has sworn to win Luke over to the dark side of the Force."",
                  ""released"": ""1983-05-25"",
                  ""runtime"": 135,
                  ""trailer"": ""http://youtube.com/watch?v=2mqRbh7FJ0Y"",
                  ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vi-return-of-the-jedi"",
                  ""rating"": 8.61184,
                  ""votes"": 12853,
                  ""updated_at"": ""2016-04-04T08:51:42Z"",
                  ""language"": ""en"",
                  ""available_translations"": [
                    ""en"",
                    ""de"",
                    ""fr"",
                    ""it""
                  ],
                  ""genres"": [
                    ""action"",
                    ""adventure"",
                    ""science-fiction""
                  ],
                  ""certification"": ""PG""
                }
              ]";

        private const string MOVIE_RELEASES_JSON =
            @"[
                {
                  ""country"": ""us"",
                  ""certification"": ""PG-13"",
                  ""release_date"": ""2015-12-14"",
                  ""release_type"": ""premiere"",
                  ""note"": ""Los Angeles, California""
                },
                {
                  ""country"": ""ae"",
                  ""certification"": """",
                  ""release_date"": ""2015-12-15"",
                  ""release_type"": ""theatrical"",
                  ""note"": null
                },
                {
                  ""country"": ""fr"",
                  ""certification"": """",
                  ""release_date"": ""2015-12-16"",
                  ""release_type"": ""theatrical"",
                  ""note"": null
                }
              ]";

        private const string MOVIE_TRANSLATIONS_JSON =
            @"[
                {
                  ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                  ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                  ""tagline"": ""The Force Lives On..."",
                  ""language"": ""en""
                },
                {
                  ""title"": ""Star Wars: Episode VII - Das Erwachen der Macht"",
                  ""overview"": ""Erster Teil der von Walt Disney angekündigten dritten \""Star Wars\""-Trilogie, die im Jahr 2015 ihren Anfang nehmen soll."",
                  ""tagline"": """",
                  ""language"": ""de""
                },
                {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                  ""tagline"": ""Every generation has a story."",
                  ""language"": ""en""
                }
              ]";

        private const string MOVIE_STATISTICS_JSON =
            @"{
                ""watchers"": 40619,
                ""plays"": 64620,
                ""collectors"": 17519,
                ""comments"": 99,
                ""lists"": 17089,
                ""votes"": 10359
              }";

        private const string MOVIE_WATCHING_USERS_JSON =
            @"[
                {
                  ""username"": ""Levimenten"",
                  ""private"": true,
                  ""name"": ""Levi Menten"",
                  ""vip"": false,
                  ""vip_ep"": false
                },
                {
                  ""username"": ""WIllGamer"",
                  ""private"": false,
                  ""name"": ""Wilson Neves"",
                  ""vip"": false,
                  ""vip_ep"": true
                },
                {
                  ""username"": ""Linkz"",
                  ""private"": false,
                  ""name"": null,
                  ""vip"": false,
                  ""vip_ep"": false
                }
              ]";

        private const string POPULAR_MOVIES_JSON =
            @"[
                {
                  ""title"": ""The Dark Knight"",
                  ""year"": 2008,
                  ""ids"": {
                    ""trakt"": 120,
                    ""slug"": ""the-dark-knight-2008"",
                    ""imdb"": ""tt0468569"",
                    ""tmdb"": 155
                  }
                },
                {
                  ""title"": ""Inception"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 16662,
                    ""slug"": ""inception-2010"",
                    ""imdb"": ""tt1375666"",
                    ""tmdb"": 27205
                  }
                }
              ]";

        private const string RECENTLY_UPDATED_MOVIES_JSON =
            @"[
                {
                  ""updated_at"": ""2016-03-31T01:29:13Z"",
                  ""movie"": {
                    ""title"": ""Boom Bust Boom"",
                    ""year"": 2016,
                    ""ids"": {
                      ""trakt"": 232639,
                      ""slug"": ""boom-bust-boom-2016"",
                      ""imdb"": ""tt3332308"",
                      ""tmdb"": 367197
                    }
                  }
                },
                {
                  ""updated_at"": ""2016-03-31T01:32:43Z"",
                  ""movie"": {
                    ""title"": ""Crazy About Tiffany's"",
                    ""year"": 2016,
                    ""ids"": {
                      ""trakt"": 232640,
                      ""slug"": ""crazy-about-tiffany-s-2016"",
                      ""imdb"": ""tt3464290"",
                      ""tmdb"": 383267
                    }
                  }
                }
              ]";

        private const string TRENDING_MOVIES_JSON =
            @"[
                {
                  ""watchers"": 35,
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
                },
                {
                  ""watchers"": 33,
                  ""movie"": {
                    ""title"": ""Deadpool"",
                    ""year"": 2016,
                    ""ids"": {
                      ""trakt"": 190430,
                      ""slug"": ""deadpool-2016"",
                      ""imdb"": ""tt1431045"",
                      ""tmdb"": 293660
                    }
                  }
                }
              ]";
    }
}
