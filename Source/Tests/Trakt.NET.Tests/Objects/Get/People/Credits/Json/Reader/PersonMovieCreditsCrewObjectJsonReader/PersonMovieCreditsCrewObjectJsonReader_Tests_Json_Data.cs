namespace TraktNet.Tests.Objects.Get.People.Credits.Json.Reader
{
    public partial class PersonMovieCreditsCrewObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_13 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_14 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_15 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_16 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_17 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_18 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_19 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_20 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_21 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_22 =
            @"{
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
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""prod"": [
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
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
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
                ""a"": [
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
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
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
                ""cr"": [
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
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
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
                ""cos &"": [
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
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
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
                ""dir"": [
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
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
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
                ""writ"": [
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
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
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
                ""so"": [
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
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
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
                ""cam"": [
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
              }";

        private const string JSON_NOT_VALID_9 =
            @"{
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
                ""light"": [
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
              }";

        private const string JSON_NOT_VALID_10 =
            @"{
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
                ""vfx"": [
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
              }";

        private const string JSON_NOT_VALID_11 =
            @"{
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
                ""edit"": [
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
              }";

        private const string JSON_NOT_VALID_12 =
            @"{
                ""prod"": [
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
                ""a"": [
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
                ""cr"": [
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
                ""cos &"": [
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
                ""dir"": [
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
                ""writ"": [
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
                ""so"": [
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
                ""cam"": [
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
                ""light"": [
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
                ""vfx"": [
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
                ""edit"": [
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
              }";
    }
}
