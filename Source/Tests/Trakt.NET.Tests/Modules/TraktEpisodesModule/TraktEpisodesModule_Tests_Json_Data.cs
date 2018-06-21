namespace TraktNet.Tests.Modules.TraktEpisodesModule
{
    using TraktNet.Enums;
    using TraktNet.Requests.Parameters;

    public partial class TraktEpisodesModule_Tests
    {
        private const string SHOW_ID = "1390";
        private const uint SEASON_NR = 1;
        private const uint EPISODE_NR = 1;
        private const uint PAGE = 2;
        private const uint LIMIT = 4;
        private const int COMMENTS_ITEM_COUNT = 4;
        private const int LISTS_ITEM_COUNT = 10;
        private readonly TraktExtendedInfo EXTENDED_INFO = new TraktExtendedInfo { Full = true };
        private readonly TraktCommentSortOrder COMMENT_SORT_ORDER = TraktCommentSortOrder.Likes;
        private readonly TraktListSortOrder LIST_SORT_ORDER = TraktListSortOrder.Comments;
        private readonly TraktListType LIST_TYPE = TraktListType.Official;

        private const string EPISODE_SUMMARY_FULL_JSON =
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

        private const string EPISODE_COMMENTS_JSON =
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
                },
                {
                  ""id"": 11,
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

        private const string EPISODE_LISTS_JSON =
            @"[
                {
                  ""name"": ""Serie TV 2014"",
                  ""description"": ""Serie viste nel 2014."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-01-12T17:11:27.000Z"",
                  ""updated_at"": ""2016-10-18T17:03:24.000Z"",
                  ""item_count"": 1121,
                  ""comment_count"": 0,
                  ""likes"": 0,
                  ""ids"": {
                    ""trakt"": 832366,
                    ""slug"": ""serie-tv-2014""
                  },
                  ""user"": {
                    ""username"": ""ChiccoHD"",
                    ""private"": false,
                    ""name"": ""Francesco Di Maria"",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""chiccohd""
                    }
                  }
                },
                {
                  ""name"": ""2016 (series)"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2015-12-15T18:55:52.000Z"",
                  ""updated_at"": ""2017-01-03T11:29:39.000Z"",
                  ""item_count"": 656,
                  ""comment_count"": 0,
                  ""likes"": 0,
                  ""ids"": {
                    ""trakt"": 1635661,
                    ""slug"": ""2016-series""
                  },
                  ""user"": {
                    ""username"": ""Kolett"",
                    ""private"": false,
                    ""name"": """",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""kolett""
                    }
                  }
                },
                {
                  ""name"": ""Comic Book Films"",
                  ""description"": ""Marvel and DC films and series listed by air date. Also include are other related comic book films."",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""released"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-01-04T22:50:09.000Z"",
                  ""updated_at"": ""2016-10-12T23:12:47.000Z"",
                  ""item_count"": 561,
                  ""comment_count"": 0,
                  ""likes"": 4,
                  ""ids"": {
                    ""trakt"": 1701842,
                    ""slug"": ""comic-book-films""
                  },
                  ""user"": {
                    ""username"": ""rasslingrob"",
                    ""private"": false,
                    ""name"": ""Robert Beardsley"",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""rasslingrob""
                    }
                  }
                },
                {
                  ""name"": ""MY MOVIE BOX (TV SHOWS)"",
                  ""description"": ""12 MONKEYS SEASON 1\r\n12 MONKEYS SEASON 2\r\nAGENTS OF SHIELD SEASON 1\r\nAGENTS OF SHIELD SEASON 2\r\nAGENTS OF SHIELD SEASON 3\r\nALMOST HUMAN SEASON 1\r\nAMERICAN HORROR STORY SEASON 1\r\nAMERICAN HORROR STORY SEASON 2\r\nAMERICAN HORROR STORY SEASON 3\r\nAMERICAN HORROR STORY SEASON 4\r\nAMERICAN HORROR STORY SEASON 5\r\nARCHER SEASON 6\r\nARCHER SEASON 7\r\n\r\nONGOING\r\n\r\nAGENTS OF SHIELD SEASON 4\r\nAMERICAN HORROR STORY SEASON 6"",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-10-04T05:09:13.000Z"",
                  ""updated_at"": ""2016-12-26T21:38:33.000Z"",
                  ""item_count"": 283,
                  ""comment_count"": 0,
                  ""likes"": 0,
                  ""ids"": {
                    ""trakt"": 2747659,
                    ""slug"": ""my-movie-box-tv-shows""
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
                  ""name"": ""Marvel Cinematic Universe"",
                  ""description"": ""Feature films, television series and shorts by Marvel Studios sharing the same universe.\r\n\r\nhttp://en.wikipedia.org/wiki/Marvel_Cinematic_Universe"",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""released"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2012-08-25T09:54:38.000Z"",
                  ""updated_at"": ""2017-01-01T14:44:31.000Z"",
                  ""item_count"": 191,
                  ""comment_count"": 0,
                  ""likes"": 9,
                  ""ids"": {
                    ""trakt"": 801243,
                    ""slug"": ""marvel-cinematic-universe""
                  },
                  ""user"": {
                    ""username"": ""Draackje"",
                    ""private"": false,
                    ""name"": ""Draackje"",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""draackje""
                    }
                  }
                },
                {
                  ""name"": ""Marvel Cinematic Universe"",
                  ""description"": ""Chronological Order"",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2015-08-27T19:58:37.000Z"",
                  ""updated_at"": ""2016-12-08T11:56:23.000Z"",
                  ""item_count"": 167,
                  ""comment_count"": 0,
                  ""likes"": 1,
                  ""ids"": {
                    ""trakt"": 1349231,
                    ""slug"": ""marvel-cinematic-universe""
                  },
                  ""user"": {
                    ""username"": ""oblogdamari"",
                    ""private"": false,
                    ""name"": ""Mariana Garcia"",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""oblogdamari""
                    }
                  }
                },
                {
                  ""name"": ""Marvel Cinematic Universe"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""released"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-04-03T19:04:12.000Z"",
                  ""updated_at"": ""2016-04-16T21:14:54.000Z"",
                  ""item_count"": 154,
                  ""comment_count"": 0,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 2110835,
                    ""slug"": ""marvel-cinematic-universe""
                  },
                  ""user"": {
                    ""username"": ""Demon10"",
                    ""private"": false,
                    ""name"": ""Dominic F."",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""demon10""
                    }
                  }
                },
                {
                  ""name"": ""Marvel Universe"",
                  ""description"": ""A list of all the films in the \""Marvel library\"". Starts at Blade and translates to the current MCU. The FOX/Sony owned X-Men, Spider-Man, and Fantastic Four are added by release date to tie in the MCU timeframe. I also added the animated TV series from my childhood."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2015-10-05T11:51:42.000Z"",
                  ""updated_at"": ""2016-11-25T05:35:29.000Z"",
                  ""item_count"": 154,
                  ""comment_count"": 0,
                  ""likes"": 1,
                  ""ids"": {
                    ""trakt"": 1452530,
                    ""slug"": ""marvel-universe""
                  },
                  ""user"": {
                    ""username"": ""rasslingrob"",
                    ""private"": false,
                    ""name"": ""Robert Beardsley"",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""rasslingrob""
                    }
                  }
                },
                {
                  ""name"": ""Marvel Cinematic Universe"",
                  ""description"": ""A marvel cinematic universe list with the correct watch order and grades for each movie and series episode(WIP)"",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-05-01T22:32:54.000Z"",
                  ""updated_at"": ""2016-09-26T21:53:45.000Z"",
                  ""item_count"": 142,
                  ""comment_count"": 0,
                  ""likes"": 0,
                  ""ids"": {
                    ""trakt"": 2221752,
                    ""slug"": ""marvel-cinematic-universe""
                  },
                  ""user"": {
                    ""username"": ""gpj252"",
                    ""private"": false,
                    ""name"": null,
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""gpj252""
                    }
                  }
                },
                {
                  ""name"": ""Accurate Marvel Cinematic Universe Release Order"",
                  ""description"": """",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""added"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2016-01-04T18:56:00.000Z"",
                  ""updated_at"": ""2016-07-06T02:14:38.000Z"",
                  ""item_count"": 141,
                  ""comment_count"": 0,
                  ""likes"": 1,
                  ""ids"": {
                    ""trakt"": 1700888,
                    ""slug"": ""accurate-marvel-cinematic-universe-release-order""
                  },
                  ""user"": {
                    ""username"": ""billowillo"",
                    ""private"": false,
                    ""name"": ""billowillo"",
                    ""vip"": false,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""billowillo""
                    }
                  }
                }
              ]";

        private const string EPISODE_RATINGS_JSON =
            @"{
                ""rating"": 8.54044,
                ""votes"": 3919,
                ""distribution"": {
                  ""1"": 59,
                  ""2"": 11,
                  ""3"": 2,
                  ""4"": 14,
                  ""5"": 58,
                  ""6"": 233,
                  ""7"": 492,
                  ""8"": 835,
                  ""9"": 635,
                  ""10"": 1580
                }
              }";

        private const string EPISODE_STATISTICS_JSON =
            @"{
                ""watchers"": 233273,
                ""plays"": 303464,
                ""collectors"": 92759,
                ""comments"": 4,
                ""lists"": 418,
                ""votes"": 3919
              }";

        private const string EPISODE_TRANSLATIONS_JSON =
            @"[
                {
                  ""title"": ""Winter Is Coming"",
                  ""overview"": ""Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army."",
                  ""language"": ""en""
                },
                {
                  ""title"": ""Se acerca el invierno"",
                  ""overview"": ""El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza."",
                  ""language"": ""es""
                },
                {
                  ""title"": ""凛冬将至"",
                  ""overview"": ""一名守夜人军团的逃兵在临冬城外被抓获，领主艾德（奈德）·史塔克下令将其处斩。奈德对绝境长城之外的形势忧心忡忡。行刑结束后，奈德回到城中，他的夫人凯特琳带来一个令人震惊的消息：奈德的良师益友、现任首相琼恩·艾林在都城离奇死亡，罗伯特国王正启程赶往北方，希望奈德接替琼恩·艾林出任国王之手。与此同时，在狭海对岸的潘托斯，韦赛里斯·坦格利安正计划与多斯拉克游牧民族的一位重要首领卓戈卡奥结盟，凭借多斯拉克人的力量夺回本属于他的铁王座。他妹妹丹妮莉斯的终身幸福成了他手中最重要的筹码。罗伯特国王带着瑟曦·兰尼斯特王后及兰尼斯特家族的重要成员抵达临冬城。他的随行人员包括：王后的弟弟詹姆和提力昂，他们一个英俊潇洒，一个却是侏儒；12岁的乔佛里王子，王位的继承人。奈德无法拒绝国王的盛情邀请，决定南下君临城帮助国王稳定国内局势。就在罗伯特和奈德动身之前，奈德的私生子琼恩·雪诺决定北上黑城堡加盟守夜人军团，对守夜人颇为好奇的提力昂打算和雪诺一同前往。厄运突然降临到奈德的次子布兰身上，奈德和琼恩都被迫推迟了行程。"",
                  ""language"": ""zh""
                }
              ]";

        private const string EPISODE_WATCHING_USERS_JSON =
            @"[
                {
                  ""username"": ""Horaces"",
                  ""private"": false,
                  ""name"": null,
                  ""vip"": false,
                  ""vip_ep"": false
                },
                {
                  ""username"": ""stannyowl"",
                  ""private"": true,
                  ""name"": ""stanny"",
                  ""vip"": false,
                  ""vip_ep"": true
                }
              ]";
    }
}
