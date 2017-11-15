namespace TraktApiSharp.Tests.Objects.Post.Users.CustomListItems.Responses.Json
{
    public partial class UserCustomListItemsPostResponseObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""added"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                },
                ""existing"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                },
                ""not_found"": {
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
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""existing"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                },
                ""not_found"": {
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
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""added"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                },
                ""not_found"": {
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
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""added"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                },
                ""existing"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                }
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""added"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                }
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""existing"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                }
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""not_found"": {
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
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""add"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                },
                ""existing"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                },
                ""not_found"": {
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
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""added"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                },
                ""exist"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                },
                ""not_found"": {
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
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""added"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                },
                ""existing"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                },
                ""nf"": {
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
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""add"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                },
                ""exist"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                },
                ""nf"": {
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
                }
              }";
    }
}
