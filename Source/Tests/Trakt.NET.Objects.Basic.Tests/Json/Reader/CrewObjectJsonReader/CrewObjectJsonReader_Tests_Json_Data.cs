namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class CrewObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""production"": [
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""a"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""cr"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""cos &"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""dir"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writ"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""so"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""cam"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""light"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""vfx"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""art"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""edit"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
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
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Producer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""a"": [
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""cr"": [
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Crew Member""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""cos &"": [
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Make-Up Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""dir"": [
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Director""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""writ"": [
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Writer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""so"": [
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Sound Designer""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""cam"": [
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Camera""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""light"": [
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Light Technician""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""vfx"": [
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""VFX Artist""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ],
                ""edit"": [
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  }
                ]
              }";
    }
}
