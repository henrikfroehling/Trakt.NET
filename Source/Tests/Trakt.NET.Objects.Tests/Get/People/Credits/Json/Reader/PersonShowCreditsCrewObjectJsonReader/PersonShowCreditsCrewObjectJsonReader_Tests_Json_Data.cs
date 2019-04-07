namespace TraktNet.Objects.Tests.Get.People.Credits.Json.Reader
{
    public partial class PersonShowCreditsCrewObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""production"": [
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Producer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Crew Member"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Make-Up Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Director"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Writer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Sound Designer"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Camera"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Light Technician"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""VFX Artist"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""job"": ""Editor"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
