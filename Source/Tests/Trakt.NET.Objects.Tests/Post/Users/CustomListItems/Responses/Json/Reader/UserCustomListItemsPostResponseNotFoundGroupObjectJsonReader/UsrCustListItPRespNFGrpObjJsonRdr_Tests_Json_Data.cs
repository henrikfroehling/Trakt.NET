namespace TraktNet.Objects.Tests.Post.Users.CustomListItems.Responses.Json.Reader
{
    public partial class UserCustomListItemsPostResponseNotFoundGroupObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""movies"": [
                  {
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 172687,
                      ""slug"": ""king-arthur-legend-of-the-sword-2017"",
                      ""imdb"": ""tt1972591"",
                      ""tmdb"": 274857
                    }
                  }
                ],
                ""shows"": [
                  {
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
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                ],
                ""seasons"": [
                  {
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 61431,
                      ""tvdb"": 578373,
                      ""tmdb"": 60524,
                      ""tvrage"": 36940
                    }
                  }
                ],
                ""episodes"": [
                  {
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 73641,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63057,
                      ""tvrage"": 1065023912
                    }
                  }
                ],
                ""people"": [
                  {
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""shows"": [
                  {
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
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                ],
                ""seasons"": [
                  {
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 61431,
                      ""tvdb"": 578373,
                      ""tmdb"": 60524,
                      ""tvrage"": 36940
                    }
                  }
                ],
                ""episodes"": [
                  {
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 73641,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63057,
                      ""tvrage"": 1065023912
                    }
                  }
                ],
                ""people"": [
                  {
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""movies"": [
                  {
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 172687,
                      ""slug"": ""king-arthur-legend-of-the-sword-2017"",
                      ""imdb"": ""tt1972591"",
                      ""tmdb"": 274857
                    }
                  }
                ],
                ""seasons"": [
                  {
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 61431,
                      ""tvdb"": 578373,
                      ""tmdb"": 60524,
                      ""tvrage"": 36940
                    }
                  }
                ],
                ""episodes"": [
                  {
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 73641,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63057,
                      ""tvrage"": 1065023912
                    }
                  }
                ],
                ""people"": [
                  {
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""movies"": [
                  {
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 172687,
                      ""slug"": ""king-arthur-legend-of-the-sword-2017"",
                      ""imdb"": ""tt1972591"",
                      ""tmdb"": 274857
                    }
                  }
                ],
                ""shows"": [
                  {
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
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                ],
                ""episodes"": [
                  {
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 73641,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63057,
                      ""tvrage"": 1065023912
                    }
                  }
                ],
                ""people"": [
                  {
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""movies"": [
                  {
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 172687,
                      ""slug"": ""king-arthur-legend-of-the-sword-2017"",
                      ""imdb"": ""tt1972591"",
                      ""tmdb"": 274857
                    }
                  }
                ],
                ""shows"": [
                  {
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
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                ],
                ""seasons"": [
                  {
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 61431,
                      ""tvdb"": 578373,
                      ""tmdb"": 60524,
                      ""tvrage"": 36940
                    }
                  }
                ],
                ""people"": [
                  {
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""movies"": [
                  {
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 172687,
                      ""slug"": ""king-arthur-legend-of-the-sword-2017"",
                      ""imdb"": ""tt1972591"",
                      ""tmdb"": 274857
                    }
                  }
                ],
                ""shows"": [
                  {
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
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                ],
                ""seasons"": [
                  {
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 61431,
                      ""tvdb"": 578373,
                      ""tmdb"": 60524,
                      ""tvrage"": 36940
                    }
                  }
                ],
                ""episodes"": [
                  {
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 73641,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63057,
                      ""tvrage"": 1065023912
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""movies"": [
                  {
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 172687,
                      ""slug"": ""king-arthur-legend-of-the-sword-2017"",
                      ""imdb"": ""tt1972591"",
                      ""tmdb"": 274857
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""shows"": [
                  {
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
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""seasons"": [
                  {
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 61431,
                      ""tvdb"": 578373,
                      ""tmdb"": 60524,
                      ""tvrage"": 36940
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""episodes"": [
                  {
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 73641,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63057,
                      ""tvrage"": 1065023912
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""people"": [
                  {
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                ]
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""mov"": [
                  {
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 172687,
                      ""slug"": ""king-arthur-legend-of-the-sword-2017"",
                      ""imdb"": ""tt1972591"",
                      ""tmdb"": 274857
                    }
                  }
                ],
                ""shows"": [
                  {
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
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                ],
                ""seasons"": [
                  {
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 61431,
                      ""tvdb"": 578373,
                      ""tmdb"": 60524,
                      ""tvrage"": 36940
                    }
                  }
                ],
                ""episodes"": [
                  {
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 73641,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63057,
                      ""tvrage"": 1065023912
                    }
                  }
                ],
                ""people"": [
                  {
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                ]
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""movies"": [
                  {
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 172687,
                      ""slug"": ""king-arthur-legend-of-the-sword-2017"",
                      ""imdb"": ""tt1972591"",
                      ""tmdb"": 274857
                    }
                  }
                ],
                ""sh"": [
                  {
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
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                ],
                ""seasons"": [
                  {
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 61431,
                      ""tvdb"": 578373,
                      ""tmdb"": 60524,
                      ""tvrage"": 36940
                    }
                  }
                ],
                ""episodes"": [
                  {
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 73641,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63057,
                      ""tvrage"": 1065023912
                    }
                  }
                ],
                ""people"": [
                  {
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                ]
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""movies"": [
                  {
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 172687,
                      ""slug"": ""king-arthur-legend-of-the-sword-2017"",
                      ""imdb"": ""tt1972591"",
                      ""tmdb"": 274857
                    }
                  }
                ],
                ""shows"": [
                  {
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
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                ],
                ""sea"": [
                  {
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 61431,
                      ""tvdb"": 578373,
                      ""tmdb"": 60524,
                      ""tvrage"": 36940
                    }
                  }
                ],
                ""episodes"": [
                  {
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 73641,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63057,
                      ""tvrage"": 1065023912
                    }
                  }
                ],
                ""people"": [
                  {
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                ]
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""movies"": [
                  {
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 172687,
                      ""slug"": ""king-arthur-legend-of-the-sword-2017"",
                      ""imdb"": ""tt1972591"",
                      ""tmdb"": 274857
                    }
                  }
                ],
                ""shows"": [
                  {
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
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                ],
                ""seasons"": [
                  {
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 61431,
                      ""tvdb"": 578373,
                      ""tmdb"": 60524,
                      ""tvrage"": 36940
                    }
                  }
                ],
                ""eps"": [
                  {
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 73641,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63057,
                      ""tvrage"": 1065023912
                    }
                  }
                ],
                ""people"": [
                  {
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                ]
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""movies"": [
                  {
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 172687,
                      ""slug"": ""king-arthur-legend-of-the-sword-2017"",
                      ""imdb"": ""tt1972591"",
                      ""tmdb"": 274857
                    }
                  }
                ],
                ""shows"": [
                  {
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
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                ],
                ""seasons"": [
                  {
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 61431,
                      ""tvdb"": 578373,
                      ""tmdb"": 60524,
                      ""tvrage"": 36940
                    }
                  }
                ],
                ""episodes"": [
                  {
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 73641,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63057,
                      ""tvrage"": 1065023912
                    }
                  }
                ],
                ""ppl"": [
                  {
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                ]
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""mov"": [
                  {
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 172687,
                      ""slug"": ""king-arthur-legend-of-the-sword-2017"",
                      ""imdb"": ""tt1972591"",
                      ""tmdb"": 274857
                    }
                  }
                ],
                ""sh"": [
                  {
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
                    ""ids"": {
                      ""trakt"": 60300,
                      ""slug"": ""the-flash-2014"",
                      ""tvdb"": 279121,
                      ""imdb"": ""tt3107288"",
                      ""tmdb"": 60735,
                      ""tvrage"": 36939
                    }
                  }
                ],
                ""sea"": [
                  {
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 61431,
                      ""tvdb"": 578373,
                      ""tmdb"": 60524,
                      ""tvrage"": 36940
                    }
                  }
                ],
                ""eps"": [
                  {
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 73641,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63057,
                      ""tvrage"": 1065023912
                    }
                  }
                ],
                ""ppl"": [
                  {
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  },
                  {
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                ]
              }";
    }
}
