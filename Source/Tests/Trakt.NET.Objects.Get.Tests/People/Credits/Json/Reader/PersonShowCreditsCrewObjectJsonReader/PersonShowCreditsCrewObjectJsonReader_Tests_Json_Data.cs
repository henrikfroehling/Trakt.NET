namespace TraktNet.Objects.Get.Tests.People.Credits.Json.Reader
{
    public partial class PersonShowCreditsCrewObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""production"": [
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""a"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""cr"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""cos &"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""dir"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writ"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""so"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""cam"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""light"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""vfx"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""edit"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
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
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""a"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
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
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""cr"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
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
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""cos &"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
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
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""dir"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
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
                    ""jobs"": [
                      ""Director""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""writ"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
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
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""so"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
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
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""cam"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
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
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""light"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
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
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""vfx"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
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
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""edit"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
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
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ]
              }";
    }
}
