namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    public partial class TraktUserCommentObjectJsonReader_Tests
    {
        private const string TYPE_MOVIE_JSON_COMPLETE =
            @"{
                ""type"": ""movie"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
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

        private const string TYPE_MOVIE_JSON_INCOMPLETE_1 =
            @"{
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
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

        private const string TYPE_MOVIE_JSON_INCOMPLETE_2 =
            @"{
                ""type"": ""movie"",
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

        private const string TYPE_MOVIE_JSON_INCOMPLETE_3 =
            @"{
                ""type"": ""movie"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_MOVIE_JSON_INCOMPLETE_4 =
            @"{
                ""type"": ""movie""
              }";

        private const string TYPE_MOVIE_JSON_INCOMPLETE_5 =
            @"{
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_MOVIE_JSON_INCOMPLETE_6 =
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

        private const string TYPE_MOVIE_JSON_NOT_VALID_1 =
            @"{
                ""ty"": ""movie"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
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

        private const string TYPE_MOVIE_JSON_NOT_VALID_2 =
            @"{
                ""type"": ""movie"",
                ""com"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
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

        private const string TYPE_MOVIE_JSON_NOT_VALID_3 =
            @"{
                ""type"": ""movie"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""mov"": {
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

        private const string TYPE_MOVIE_JSON_NOT_VALID_4 =
            @"{
                ""ty"": ""movie"",
                ""com"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""mov"": {
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

        // ===================================================================================

        private const string TYPE_SHOW_JSON_COMPLETE =
            @"{
                ""type"": ""show"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""show"": {
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
                }
              }";

        private const string TYPE_SHOW_JSON_INCOMPLETE_1 =
            @"{
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""show"": {
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
                }
              }";

        private const string TYPE_SHOW_JSON_INCOMPLETE_2 =
            @"{
                ""type"": ""show"",
                ""show"": {
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
                }
              }";

        private const string TYPE_SHOW_JSON_INCOMPLETE_3 =
            @"{
                ""type"": ""show"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_SHOW_JSON_INCOMPLETE_4 =
            @"{
                ""type"": ""show""
              }";

        private const string TYPE_SHOW_JSON_INCOMPLETE_5 =
            @"{
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_SHOW_JSON_INCOMPLETE_6 =
            @"{
                ""show"": {
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
                }
              }";

        private const string TYPE_SHOW_JSON_NOT_VALID_1 =
            @"{
                ""ty"": ""show"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""show"": {
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
                }
              }";

        private const string TYPE_SHOW_JSON_NOT_VALID_2 =
            @"{
                ""type"": ""show"",
                ""com"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""show"": {
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
                }
              }";

        private const string TYPE_SHOW_JSON_NOT_VALID_3 =
            @"{
                ""type"": ""show"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""sh"": {
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
                }
              }";

        private const string TYPE_SHOW_JSON_NOT_VALID_4 =
            @"{
                ""ty"": ""show"",
                ""com"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""sh"": {
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
                }
              }";

        // ===================================================================================

        private const string TYPE_SEASON_JSON_COMPLETE =
            @"{
                ""type"": ""season"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_INCOMPLETE_1 =
            @"{
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_INCOMPLETE_2 =
            @"{
                ""type"": ""season"",
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_INCOMPLETE_3 =
            @"{
                ""type"": ""season"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_INCOMPLETE_4 =
            @"{
                ""type"": ""season""
              }";

        private const string TYPE_SEASON_JSON_INCOMPLETE_5 =
            @"{
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_INCOMPLETE_6 =
            @"{
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_NOT_VALID_1 =
            @"{
                ""ty"": ""season"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_NOT_VALID_2 =
            @"{
                ""type"": ""season"",
                ""com"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_NOT_VALID_3 =
            @"{
                ""type"": ""season"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""sea"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_NOT_VALID_4 =
            @"{
                ""ty"": ""season"",
                ""com"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""sea"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        // ===================================================================================

        private const string TYPE_EPISODE_JSON_COMPLETE =
            @"{
                ""type"": ""episode"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""episode"": {
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
                ""show"": {
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
                }
              }";

        private const string TYPE_EPISODE_JSON_INCOMPLETE_1 =
            @"{
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""episode"": {
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
                ""show"": {
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
                }
              }";

        private const string TYPE_EPISODE_JSON_INCOMPLETE_2 =
            @"{
                ""type"": ""episode"",
                ""episode"": {
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
                ""show"": {
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
                }
              }";

        private const string TYPE_EPISODE_JSON_INCOMPLETE_3 =
            @"{
                ""type"": ""episode"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""show"": {
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
                }
              }";

        private const string TYPE_EPISODE_JSON_INCOMPLETE_4 =
            @"{
                ""type"": ""episode"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""episode"": {
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
                }
              }";

        private const string TYPE_EPISODE_JSON_INCOMPLETE_5 =
            @"{
                ""type"": ""episode""
              }";

        private const string TYPE_EPISODE_JSON_INCOMPLETE_6 =
            @"{
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_EPISODE_JSON_INCOMPLETE_7 =
            @"{
                ""episode"": {
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
                }
              }";

        private const string TYPE_EPISODE_JSON_INCOMPLETE_8 =
            @"{
                ""show"": {
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
                }
              }";

        private const string TYPE_EPISODE_JSON_NOT_VALID_1 =
            @"{
                ""ty"": ""episode"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""episode"": {
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
                ""show"": {
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
                }
              }";

        private const string TYPE_EPISODE_JSON_NOT_VALID_2 =
            @"{
                ""type"": ""episode"",
                ""com"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""episode"": {
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
                ""show"": {
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
                }
              }";

        private const string TYPE_EPISODE_JSON_NOT_VALID_3 =
            @"{
                ""type"": ""episode"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""ep"": {
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
                ""show"": {
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
                }
              }";

        private const string TYPE_EPISODE_JSON_NOT_VALID_4 =
            @"{
                ""type"": ""episode"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""episode"": {
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
                ""sh"": {
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
                }
              }";

        private const string TYPE_EPISODE_JSON_NOT_VALID_5 =
            @"{
                ""ty"": ""episode"",
                ""com"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""ep"": {
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
                ""sh"": {
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
                }
              }";

        // ===================================================================================

        private const string TYPE_LIST_JSON_COMPLETE =
            @"{
                ""type"": ""list"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""list"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
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
                }
              }";

        private const string TYPE_LIST_JSON_INCOMPLETE_1 =
            @"{
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""list"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
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
                }
              }";

        private const string TYPE_LIST_JSON_INCOMPLETE_2 =
            @"{
                ""type"": ""list"",
                ""list"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
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
                }
              }";

        private const string TYPE_LIST_JSON_INCOMPLETE_3 =
            @"{
                ""type"": ""list"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_LIST_JSON_INCOMPLETE_4 =
            @"{
                ""type"": ""list""
              }";

        private const string TYPE_LIST_JSON_INCOMPLETE_5 =
            @"{
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_LIST_JSON_INCOMPLETE_6 =
            @"{
                ""list"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
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
                }
              }";

        private const string TYPE_LIST_JSON_NOT_VALID_1 =
            @"{
                ""ty"": ""list"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""list"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
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
                }
              }";

        private const string TYPE_LIST_JSON_NOT_VALID_2 =
            @"{
                ""type"": ""list"",
                ""com"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""list"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
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
                }
              }";

        private const string TYPE_LIST_JSON_NOT_VALID_3 =
            @"{
                ""type"": ""list"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""li"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
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
                }
              }";

        private const string TYPE_LIST_JSON_NOT_VALID_4 =
            @"{
                ""ty"": ""list"",
                ""com"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""li"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
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
                }
              }";
    }
}
