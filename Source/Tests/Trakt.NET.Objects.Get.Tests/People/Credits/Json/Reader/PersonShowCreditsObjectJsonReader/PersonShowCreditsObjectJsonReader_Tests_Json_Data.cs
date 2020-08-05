namespace TraktNet.Objects.Get.Tests.People.Credits.Json.Reader
{
    public partial class PersonShowCreditsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""cast"": [
                  {
                    ""characters"": [
                      ""Jon Snow""
                    ],
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""characters"": [
                      ""Iris West""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
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
                      ""show"": {
                        ""title"": ""Game of Thrones"",
                        ""year"": 2011,
                        ""ids"": {
                          ""trakt"": 1390,
                          ""slug"": ""game-of-thrones"",
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
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""cast"": [
                  {
                    ""characters"": [
                      ""Jon Snow""
                    ],
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""characters"": [
                      ""Iris West""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
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
                    ""characters"": [
                      ""Jon Snow""
                    ],
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""characters"": [
                      ""Iris West""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
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
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""cast"": [
                  {
                    ""characters"": [
                      ""Jon Snow""
                    ],
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""characters"": [
                      ""Iris West""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
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
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""ca"": [
                  {
                    ""characters"": [
                      ""Jon Snow""
                    ],
                    ""show"": {
                      ""title"": ""Game of Thrones"",
                      ""year"": 2011,
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    }
                  },
                  {
                    ""characters"": [
                      ""Iris West""
                    ],
                    ""show"": {
                      ""title"": ""The Flash"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 60300,
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
                }
              }";
    }
}
