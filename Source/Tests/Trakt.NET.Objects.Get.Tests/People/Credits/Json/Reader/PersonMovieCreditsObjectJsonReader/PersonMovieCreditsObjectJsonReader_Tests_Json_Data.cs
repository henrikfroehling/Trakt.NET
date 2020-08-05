namespace TraktNet.Objects.Get.Tests.People.Credits.Json.Reader
{
    public partial class PersonMovieCreditsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""cast"": [
                  {
                    ""characters"": [
                      ""Rey""
                    ],
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
                    ""characters"": [
                      ""Sam Flynn""
                    ],
                    ""movie"": {
                      ""title"": ""TRON: Legacy"",
                      ""year"": 2010,
                      ""ids"": {
                        ""trakt"": 12601,
                        ""slug"": ""tron-legacy-2010"",
                        ""imdb"": ""tt1104001"",
                        ""tmdb"": 20526
                      }
                    }
                  }
                ],
                ""crew"": {
                  ""production"": [
                    {
                      ""jobs"": [
                        ""Producer""
                      ],
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
                      ""jobs"": [
                        ""Producer""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""art"": [
                    {
                      ""jobs"": [
                        ""Artist""
                      ],
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
                      ""jobs"": [
                        ""Artist""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""crew"": [
                    {
                      ""jobs"": [
                        ""Crew Member""
                      ],
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
                      ""jobs"": [
                        ""Crew Member""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""costume & make-up"": [
                    {
                      ""jobs"": [
                        ""Make-Up Artist""
                      ],
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
                      ""jobs"": [
                        ""Make-Up Artist""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""directing"": [
                    {
                      ""jobs"": [
                        ""Director""
                      ],
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
                      ""jobs"": [
                        ""Director""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""writing"": [
                    {
                      ""jobs"": [
                        ""Writer""
                      ],
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
                      ""jobs"": [
                        ""Writer""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""sound"": [
                    {
                      ""jobs"": [
                        ""Sound Designer""
                      ],
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
                      ""jobs"": [
                        ""Sound Designer""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""camera"": [
                    {
                      ""jobs"": [
                        ""Camera""
                      ],
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
                      ""jobs"": [
                        ""Camera""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""lighting"": [
                    {
                      ""jobs"": [
                        ""Light Technician""
                      ],
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
                      ""jobs"": [
                        ""Light Technician""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""visual effects"": [
                    {
                      ""jobs"": [
                        ""VFX Artist""
                      ],
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
                      ""jobs"": [
                        ""VFX Artist""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""editing"": [
                    {
                      ""jobs"": [
                        ""Editor""
                      ],
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
                      ""jobs"": [
                        ""Editor""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ]
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""crew"": {
                  ""production"": [
                    {
                      ""jobs"": [
                        ""Producer""
                      ],
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
                      ""jobs"": [
                        ""Producer""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""art"": [
                    {
                      ""jobs"": [
                        ""Artist""
                      ],
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
                      ""jobs"": [
                        ""Artist""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""crew"": [
                    {
                      ""jobs"": [
                        ""Crew Member""
                      ],
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
                      ""jobs"": [
                        ""Crew Member""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""costume & make-up"": [
                    {
                      ""jobs"": [
                        ""Make-Up Artist""
                      ],
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
                      ""jobs"": [
                        ""Make-Up Artist""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""directing"": [
                    {
                      ""jobs"": [
                        ""Director""
                      ],
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
                      ""jobs"": [
                        ""Director""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""writing"": [
                    {
                      ""jobs"": [
                        ""Writer""
                      ],
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
                      ""jobs"": [
                        ""Writer""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""sound"": [
                    {
                      ""jobs"": [
                        ""Sound Designer""
                      ],
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
                      ""jobs"": [
                        ""Sound Designer""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""camera"": [
                    {
                      ""jobs"": [
                        ""Camera""
                      ],
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
                      ""jobs"": [
                        ""Camera""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""lighting"": [
                    {
                      ""jobs"": [
                        ""Light Technician""
                      ],
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
                      ""jobs"": [
                        ""Light Technician""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""visual effects"": [
                    {
                      ""jobs"": [
                        ""VFX Artist""
                      ],
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
                      ""jobs"": [
                        ""VFX Artist""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""editing"": [
                    {
                      ""jobs"": [
                        ""Editor""
                      ],
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
                      ""jobs"": [
                        ""Editor""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ]
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""cast"": [
                  {
                    ""characters"": [
                      ""Rey""
                    ],
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
                    ""characters"": [
                      ""Sam Flynn""
                    ],
                    ""movie"": {
                      ""title"": ""TRON: Legacy"",
                      ""year"": 2010,
                      ""ids"": {
                        ""trakt"": 12601,
                        ""slug"": ""tron-legacy-2010"",
                        ""imdb"": ""tt1104001"",
                        ""tmdb"": 20526
                      }
                    }
                  }
                ]
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ca"": [
                  {
                    ""characters"": [
                      ""Rey""
                    ],
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
                    ""characters"": [
                      ""Sam Flynn""
                    ],
                    ""movie"": {
                      ""title"": ""TRON: Legacy"",
                      ""year"": 2010,
                      ""ids"": {
                        ""trakt"": 12601,
                        ""slug"": ""tron-legacy-2010"",
                        ""imdb"": ""tt1104001"",
                        ""tmdb"": 20526
                      }
                    }
                  }
                ],
                ""crew"": {
                  ""production"": [
                    {
                      ""jobs"": [
                        ""Producer""
                      ],
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
                      ""jobs"": [
                        ""Producer""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""art"": [
                    {
                      ""jobs"": [
                        ""Artist""
                      ],
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
                      ""jobs"": [
                        ""Artist""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""crew"": [
                    {
                      ""jobs"": [
                        ""Crew Member""
                      ],
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
                      ""jobs"": [
                        ""Crew Member""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""costume & make-up"": [
                    {
                      ""jobs"": [
                        ""Make-Up Artist""
                      ],
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
                      ""jobs"": [
                        ""Make-Up Artist""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""directing"": [
                    {
                      ""jobs"": [
                        ""Director""
                      ],
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
                      ""jobs"": [
                        ""Director""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""writing"": [
                    {
                      ""jobs"": [
                        ""Writer""
                      ],
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
                      ""jobs"": [
                        ""Writer""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""sound"": [
                    {
                      ""jobs"": [
                        ""Sound Designer""
                      ],
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
                      ""jobs"": [
                        ""Sound Designer""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""camera"": [
                    {
                      ""jobs"": [
                        ""Camera""
                      ],
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
                      ""jobs"": [
                        ""Camera""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""lighting"": [
                    {
                      ""jobs"": [
                        ""Light Technician""
                      ],
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
                      ""jobs"": [
                        ""Light Technician""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""visual effects"": [
                    {
                      ""jobs"": [
                        ""VFX Artist""
                      ],
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
                      ""jobs"": [
                        ""VFX Artist""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""editing"": [
                    {
                      ""jobs"": [
                        ""Editor""
                      ],
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
                      ""jobs"": [
                        ""Editor""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ]
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""cast"": [
                  {
                    ""characters"": [
                      ""Rey""
                    ],
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
                    ""characters"": [
                      ""Sam Flynn""
                    ],
                    ""movie"": {
                      ""title"": ""TRON: Legacy"",
                      ""year"": 2010,
                      ""ids"": {
                        ""trakt"": 12601,
                        ""slug"": ""tron-legacy-2010"",
                        ""imdb"": ""tt1104001"",
                        ""tmdb"": 20526
                      }
                    }
                  }
                ],
                ""cr"": {
                  ""production"": [
                    {
                      ""jobs"": [
                        ""Producer""
                      ],
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
                      ""jobs"": [
                        ""Producer""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""art"": [
                    {
                      ""jobs"": [
                        ""Artist""
                      ],
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
                      ""jobs"": [
                        ""Artist""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""crew"": [
                    {
                      ""jobs"": [
                        ""Crew Member""
                      ],
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
                      ""jobs"": [
                        ""Crew Member""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""costume & make-up"": [
                    {
                      ""jobs"": [
                        ""Make-Up Artist""
                      ],
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
                      ""jobs"": [
                        ""Make-Up Artist""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""directing"": [
                    {
                      ""jobs"": [
                        ""Director""
                      ],
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
                      ""jobs"": [
                        ""Director""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""writing"": [
                    {
                      ""jobs"": [
                        ""Writer""
                      ],
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
                      ""jobs"": [
                        ""Writer""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""sound"": [
                    {
                      ""jobs"": [
                        ""Sound Designer""
                      ],
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
                      ""jobs"": [
                        ""Sound Designer""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""camera"": [
                    {
                      ""jobs"": [
                        ""Camera""
                      ],
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
                      ""jobs"": [
                        ""Camera""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""lighting"": [
                    {
                      ""jobs"": [
                        ""Light Technician""
                      ],
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
                      ""jobs"": [
                        ""Light Technician""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""visual effects"": [
                    {
                      ""jobs"": [
                        ""VFX Artist""
                      ],
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
                      ""jobs"": [
                        ""VFX Artist""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""editing"": [
                    {
                      ""jobs"": [
                        ""Editor""
                      ],
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
                      ""jobs"": [
                        ""Editor""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ]
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""ca"": [
                  {
                    ""characters"": [
                      ""Rey""
                    ],
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
                    ""characters"": [
                      ""Sam Flynn""
                    ],
                    ""movie"": {
                      ""title"": ""TRON: Legacy"",
                      ""year"": 2010,
                      ""ids"": {
                        ""trakt"": 12601,
                        ""slug"": ""tron-legacy-2010"",
                        ""imdb"": ""tt1104001"",
                        ""tmdb"": 20526
                      }
                    }
                  }
                ],
                ""cr"": {
                  ""production"": [
                    {
                      ""jobs"": [
                        ""Producer""
                      ],
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
                      ""jobs"": [
                        ""Producer""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""art"": [
                    {
                      ""jobs"": [
                        ""Artist""
                      ],
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
                      ""jobs"": [
                        ""Artist""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""crew"": [
                    {
                      ""jobs"": [
                        ""Crew Member""
                      ],
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
                      ""jobs"": [
                        ""Crew Member""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""costume & make-up"": [
                    {
                      ""jobs"": [
                        ""Make-Up Artist""
                      ],
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
                      ""jobs"": [
                        ""Make-Up Artist""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""directing"": [
                    {
                      ""jobs"": [
                        ""Director""
                      ],
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
                      ""jobs"": [
                        ""Director""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""writing"": [
                    {
                      ""jobs"": [
                        ""Writer""
                      ],
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
                      ""jobs"": [
                        ""Writer""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""sound"": [
                    {
                      ""jobs"": [
                        ""Sound Designer""
                      ],
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
                      ""jobs"": [
                        ""Sound Designer""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""camera"": [
                    {
                      ""jobs"": [
                        ""Camera""
                      ],
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
                      ""jobs"": [
                        ""Camera""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""lighting"": [
                    {
                      ""jobs"": [
                        ""Light Technician""
                      ],
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
                      ""jobs"": [
                        ""Light Technician""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""visual effects"": [
                    {
                      ""jobs"": [
                        ""VFX Artist""
                      ],
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
                      ""jobs"": [
                        ""VFX Artist""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ],
                  ""editing"": [
                    {
                      ""jobs"": [
                        ""Editor""
                      ],
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
                      ""jobs"": [
                        ""Editor""
                      ],
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
                        ""ids"": {
                          ""trakt"": 12601,
                          ""slug"": ""tron-legacy-2010"",
                          ""imdb"": ""tt1104001"",
                          ""tmdb"": 20526
                        }
                      }
                    }
                  ]
                }
              }";
    }
}
