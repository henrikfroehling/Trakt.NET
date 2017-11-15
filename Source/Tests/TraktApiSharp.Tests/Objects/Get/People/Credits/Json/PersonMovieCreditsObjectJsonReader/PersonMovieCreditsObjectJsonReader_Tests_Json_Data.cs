namespace TraktApiSharp.Tests.Objects.Get.People.Credits.Json
{
    public partial class PersonMovieCreditsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""cast"": [
                  {
                    ""character"": ""Rey"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""character"": ""Sam Flynn"",
                    ""movie"": {
                      ""title"": ""TRON: Legacy"",
                      ""year"": 2010,
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
                      ""job"": ""Producer"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Producer"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Artist"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Artist"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Crew Member"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Crew Member"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Make-Up Artist"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Make-Up Artist"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Director"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Director"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Writer"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Writer"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Sound Designer"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Sound Designer"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Camera"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Camera"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Light Technician"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Light Technician"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""VFX Artist"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""VFX Artist"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Editor"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Editor"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
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
                      ""job"": ""Producer"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Producer"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Artist"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Artist"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Crew Member"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Crew Member"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Make-Up Artist"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Make-Up Artist"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Director"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Director"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Writer"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Writer"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Sound Designer"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Sound Designer"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Camera"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Camera"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Light Technician"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Light Technician"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""VFX Artist"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""VFX Artist"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Editor"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Editor"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
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
                    ""character"": ""Rey"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""character"": ""Sam Flynn"",
                    ""movie"": {
                      ""title"": ""TRON: Legacy"",
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
                    ""character"": ""Rey"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""character"": ""Sam Flynn"",
                    ""movie"": {
                      ""title"": ""TRON: Legacy"",
                      ""year"": 2010,
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
                      ""job"": ""Producer"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Producer"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Artist"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Artist"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Crew Member"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Crew Member"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Make-Up Artist"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Make-Up Artist"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Director"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Director"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Writer"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Writer"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Sound Designer"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Sound Designer"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Camera"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Camera"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Light Technician"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Light Technician"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""VFX Artist"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""VFX Artist"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Editor"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Editor"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
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
                    ""character"": ""Rey"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""character"": ""Sam Flynn"",
                    ""movie"": {
                      ""title"": ""TRON: Legacy"",
                      ""year"": 2010,
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
                      ""job"": ""Producer"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Producer"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Artist"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Artist"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Crew Member"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Crew Member"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Make-Up Artist"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Make-Up Artist"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Director"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Director"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Writer"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Writer"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Sound Designer"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Sound Designer"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Camera"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Camera"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Light Technician"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Light Technician"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""VFX Artist"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""VFX Artist"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Editor"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Editor"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
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
                    ""character"": ""Rey"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    }
                  },
                  {
                    ""character"": ""Sam Flynn"",
                    ""movie"": {
                      ""title"": ""TRON: Legacy"",
                      ""year"": 2010,
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
                      ""job"": ""Producer"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Producer"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Artist"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Artist"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Crew Member"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Crew Member"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Make-Up Artist"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Make-Up Artist"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Director"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Director"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Writer"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Writer"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Sound Designer"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Sound Designer"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Camera"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Camera"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Light Technician"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Light Technician"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""VFX Artist"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""VFX Artist"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
                        ""year"": 2010,
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
                      ""job"": ""Editor"",
                      ""movie"": {
                        ""title"": ""Star Wars: The Force Awakens"",
                        ""year"": 2015,
                        ""ids"": {
                          ""trakt"": 94024,
                          ""slug"": ""star-wars-the-force-awakens-2015"",
                          ""imdb"": ""tt2488496"",
                          ""tmdb"": 140607
                        }
                      }
                    },
                    {
                      ""job"": ""Editor"",
                      ""movie"": {
                        ""title"": ""TRON: Legacy"",
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
