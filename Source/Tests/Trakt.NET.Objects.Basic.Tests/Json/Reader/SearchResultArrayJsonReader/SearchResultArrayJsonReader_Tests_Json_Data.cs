namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class SearchResultArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        // ===================================================================================

        private const string TYPE_MOVIE_JSON_COMPLETE =
            @"[
                {
                  ""type"": ""movie"",
                  ""score"": 46.29501,
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
                  ""score"": 46.29501,
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

        private const string TYPE_MOVIE_JSON_INCOMPLETE_1 =
            @"[
                {
                  ""type"": ""movie"",
                  ""score"": 46.29501,
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
                  }
                }
              ]";

        private const string TYPE_MOVIE_JSON_INCOMPLETE_2 =
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
                  ""score"": 46.29501,
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

        private const string TYPE_MOVIE_JSON_NOT_VALID_1 =
            @"[
                {
                  ""type"": ""movie"",
                  ""sc"": 46.29501,
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
                  ""score"": 46.29501,
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

        private const string TYPE_MOVIE_JSON_NOT_VALID_2 =
            @"[
                {
                  ""type"": ""movie"",
                  ""score"": 46.29501,
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
                  ""scoore"": 46.29501,
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

        private const string TYPE_MOVIE_JSON_NOT_VALID_3 =
            @"[
                {
                  ""type"": ""movie"",
                  ""sc"": 46.29501,
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
                  ""scoore"": 46.29501,
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

        // ===================================================================================

        private const string TYPE_SHOW_JSON_COMPLETE =
            @"[
                {
                  ""type"": ""show"",
                  ""score"": 46.29501,
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
                },
                {
                  ""type"": ""show"",
                  ""score"": 46.29501,
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
                }
              ]";

        private const string TYPE_SHOW_JSON_INCOMPLETE_1 =
            @"[
                {
                  ""type"": ""show"",
                  ""score"": 46.29501,
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
                },
                {
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
                }
              ]";

        private const string TYPE_SHOW_JSON_INCOMPLETE_2 =
            @"[
                {
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
                },
                {
                  ""type"": ""show"",
                  ""score"": 46.29501,
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
                }
              ]";

        private const string TYPE_SHOW_JSON_NOT_VALID_1 =
            @"[
                {
                  ""type"": ""show"",
                  ""sc"": 46.29501,
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
                },
                {
                  ""type"": ""show"",
                  ""score"": 46.29501,
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
                }
              ]";

        private const string TYPE_SHOW_JSON_NOT_VALID_2 =
            @"[
                {
                  ""type"": ""show"",
                  ""score"": 46.29501,
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
                },
                {
                  ""type"": ""show"",
                  ""scoore"": 46.29501,
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
                }
              ]";

        private const string TYPE_SHOW_JSON_NOT_VALID_3 =
            @"[
                {
                  ""type"": ""show"",
                  ""sc"": 46.29501,
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
                },
                {
                  ""type"": ""show"",
                  ""scoore"": 46.29501,
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
                }
              ]";

        // ===================================================================================

        private const string TYPE_EPISODE_JSON_COMPLETE =
            @"[
                {
                  ""type"": ""episode"",
                  ""score"": 46.29501,
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
                },
                {
                  ""type"": ""episode"",
                  ""score"": 46.29501,
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
                }
              ]";

        private const string TYPE_EPISODE_JSON_INCOMPLETE_1 =
            @"[
                {
                  ""type"": ""episode"",
                  ""score"": 46.29501,
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
                },
                {
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
                }
              ]";

        private const string TYPE_EPISODE_JSON_INCOMPLETE_2 =
            @"[
                {
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
                },
                {
                  ""type"": ""episode"",
                  ""score"": 46.29501,
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
                }
              ]";

        private const string TYPE_EPISODE_JSON_NOT_VALID_1 =
            @"[
                {
                  ""type"": ""episode"",
                  ""sc"": 46.29501,
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
                },
                {
                  ""type"": ""episode"",
                  ""score"": 46.29501,
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
                }
              ]";

        private const string TYPE_EPISODE_JSON_NOT_VALID_2 =
            @"[
                {
                  ""type"": ""episode"",
                  ""score"": 46.29501,
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
                },
                {
                  ""type"": ""episode"",
                  ""scoore"": 46.29501,
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
                }
              ]";

        private const string TYPE_EPISODE_JSON_NOT_VALID_3 =
            @"[
                {
                  ""type"": ""episode"",
                  ""sc"": 46.29501,
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
                },
                {
                  ""type"": ""episode"",
                  ""scoore"": 46.29501,
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
                }
              ]";

        // ===================================================================================

        private const string TYPE_PERSON_JSON_COMPLETE =
            @"[
                {
                  ""type"": ""person"",
                  ""score"": 46.29501,
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""type"": ""person"",
                  ""score"": 46.29501,
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                }
              ]";

        private const string TYPE_PERSON_JSON_INCOMPLETE_1 =
            @"[
                {
                  ""type"": ""person"",
                  ""score"": 46.29501,
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""type"": ""person"",
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                }
              ]";

        private const string TYPE_PERSON_JSON_INCOMPLETE_2 =
            @"[
                {
                  ""type"": ""person"",
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""type"": ""person"",
                  ""score"": 46.29501,
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                }
              ]";

        private const string TYPE_PERSON_JSON_NOT_VALID_1 =
            @"[
                {
                  ""type"": ""person"",
                  ""sc"": 46.29501,
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""type"": ""person"",
                  ""score"": 46.29501,
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                }
              ]";

        private const string TYPE_PERSON_JSON_NOT_VALID_2 =
            @"[
                {
                  ""type"": ""person"",
                  ""score"": 46.29501,
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""type"": ""person"",
                  ""scoore"": 46.29501,
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                }
              ]";

        private const string TYPE_PERSON_JSON_NOT_VALID_3 =
            @"[
                {
                  ""type"": ""person"",
                  ""sc"": 46.29501,
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""type"": ""person"",
                  ""scoore"": 46.29501,
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                }
              ]";

        // ===================================================================================

        private const string TYPE_LIST_JSON_COMPLETE =
            @"[
                {
                  ""type"": ""list"",
                  ""score"": 46.29501,
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
                  ""type"": ""list"",
                  ""score"": 46.29501,
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

        private const string TYPE_LIST_JSON_INCOMPLETE_1 =
            @"[
                {
                  ""type"": ""list"",
                  ""score"": 46.29501,
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
                }
              ]";

        private const string TYPE_LIST_JSON_INCOMPLETE_2 =
            @"[
                {
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
                },
                {
                  ""type"": ""list"",
                  ""score"": 46.29501,
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

        private const string TYPE_LIST_JSON_NOT_VALID_1 =
            @"[
                {
                  ""type"": ""list"",
                  ""sc"": 46.29501,
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
                  ""type"": ""list"",
                  ""score"": 46.29501,
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

        private const string TYPE_LIST_JSON_NOT_VALID_2 =
            @"[
                {
                  ""type"": ""list"",
                  ""score"": 46.29501,
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
                  ""type"": ""list"",
                  ""scoore"": 46.29501,
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

        private const string TYPE_LIST_JSON_NOT_VALID_3 =
            @"[
                {
                  ""type"": ""list"",
                  ""sc"": 46.29501,
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
                  ""type"": ""list"",
                  ""scoore"": 46.29501,
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
