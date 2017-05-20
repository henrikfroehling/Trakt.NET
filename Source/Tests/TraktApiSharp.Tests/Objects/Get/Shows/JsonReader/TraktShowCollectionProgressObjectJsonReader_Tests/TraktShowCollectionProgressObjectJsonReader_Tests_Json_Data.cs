namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    public partial class TraktShowCollectionProgressObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""last_collected_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""completed"": 2,
                ""last_collected_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""aired"": 2,
                ""last_collected_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""last_collected_at"": ""2015-03-21T19:03:58.000Z"",
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""last_collected_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""last_collected_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""aired"": 2
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""completed"": 2
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""last_collected_at"": ""2015-03-21T19:03:58.000Z""
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ai"": 2,
                ""completed"": 2,
                ""last_collected_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""aired"": 2,
                ""com"": 2,
                ""last_collected_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""lca"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""last_collected_at"": ""2015-03-21T19:03:58.000Z"",
                ""sea"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""last_collected_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  }
                ],
                ""hid_sea"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""last_collected_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""nextep"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""ai"": 2,
                ""com"": 2,
                ""lca"": ""2015-03-21T19:03:58.000Z"",
                ""sea"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
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
                      }
                    ]
                  }
                ],
                ""hid_sea"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""nextep"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";
    }
}
