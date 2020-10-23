namespace TraktNet.Objects.Get.Tests.People.Credits.Json.Reader
{
    public partial class PersonMovieCreditsCrewObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_13 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_14 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_15 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_16 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_17 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_18 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_19 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_20 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_21 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_22 =
            @"{
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
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""prod"": [
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
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
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
                ""a"": [
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
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
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
                ""cr"": [
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
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
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
                ""cos &"": [
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
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
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
                ""dir"": [
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
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
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
                ""writ"": [
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
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
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
                ""so"": [
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
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
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
                ""cam"": [
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
              }";

        private const string JSON_NOT_VALID_9 =
            @"{
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
                ""light"": [
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
              }";

        private const string JSON_NOT_VALID_10 =
            @"{
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
                ""vfx"": [
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
              }";

        private const string JSON_NOT_VALID_11 =
            @"{
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
                ""edit"": [
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
              }";

        private const string JSON_NOT_VALID_12 =
            @"{
                ""prod"": [
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
                ""a"": [
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
                ""cr"": [
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
                ""cos &"": [
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
                ""dir"": [
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
                ""writ"": [
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
                ""so"": [
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
                ""cam"": [
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
                ""light"": [
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
                ""vfx"": [
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
                ""edit"": [
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
              }";
    }
}
