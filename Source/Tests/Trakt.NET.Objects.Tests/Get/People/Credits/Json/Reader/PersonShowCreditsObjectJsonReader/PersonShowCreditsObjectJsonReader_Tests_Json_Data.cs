namespace TraktNet.Objects.Tests.Get.People.Credits.Json.Reader
{
    public partial class PersonShowCreditsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""cast"": [
                  {
                    ""character"": ""Jon Snow"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""character"": ""Iris West"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": {
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
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""crew"": {
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
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""cast"": [
                  {
                    ""character"": ""Jon Snow"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""character"": ""Iris West"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                ""ca"": [
                  {
                    ""character"": ""Jon Snow"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""character"": ""Iris West"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""crew"": {
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
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""cast"": [
                  {
                    ""character"": ""Jon Snow"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""character"": ""Iris West"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""cr"": {
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
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""ca"": [
                  {
                    ""character"": ""Jon Snow"",
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""character"": ""Iris West"",
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  }
                ],
                ""cr"": {
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
                }
              }";
    }
}
