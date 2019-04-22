namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    public partial class CommentItemArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
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
                  },
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
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
                },
                {
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
                  },
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
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
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
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
                  },
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
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
                },
                {
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
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
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
                },
                {
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
                  },
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
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
                }
              ]";
        
        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""type"": ""movie"",
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
                  },
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
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
                },
                {
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
                  },
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
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
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
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
                  },
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
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
                },
                {
                  ""type"": ""movie"",
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
                  },
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
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
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""type"": ""movie"",
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
                  },
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
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
                },
                {
                  ""type"": ""movie"",
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
                  },
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
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
                }
              ]";
    }
}
