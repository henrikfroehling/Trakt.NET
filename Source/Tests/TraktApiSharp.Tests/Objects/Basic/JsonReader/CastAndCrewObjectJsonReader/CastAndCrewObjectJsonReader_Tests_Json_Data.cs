namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    public partial class CastAndCrewObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""cast"": [
                  {
                    ""character"": ""Joe Brody"",
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""character"": ""Jules Winfield"",
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
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
                ""crew"": {
                  ""production"": [
                    {
                      ""job"": ""Producer"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Producer"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Artist"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Artist"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Crew Member"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Crew Member"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Make-Up Artist"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Make-Up Artist"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Director"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Director"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Writer"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Writer"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Sound Designer"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Sound Designer"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Camera"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Camera"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Light Technician"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Light Technician"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""VFX Artist"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""VFX Artist"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Editor"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Editor"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""crew"": {
                  ""production"": [
                    {
                      ""job"": ""Producer"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Producer"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Artist"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Artist"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Crew Member"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Crew Member"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Make-Up Artist"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Make-Up Artist"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Director"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Director"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Writer"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Writer"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Sound Designer"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Sound Designer"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Camera"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Camera"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Light Technician"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Light Technician"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""VFX Artist"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""VFX Artist"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Editor"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Editor"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""cast"": [
                  {
                    ""character"": ""Joe Brody"",
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""character"": ""Jules Winfield"",
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
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
                ""ca"": [
                  {
                    ""character"": ""Joe Brody"",
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""character"": ""Jules Winfield"",
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
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
                ""crew"": {
                  ""production"": [
                    {
                      ""job"": ""Producer"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Producer"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Artist"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Artist"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Crew Member"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Crew Member"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Make-Up Artist"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Make-Up Artist"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Director"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Director"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Writer"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Writer"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Sound Designer"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Sound Designer"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Camera"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Camera"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Light Technician"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Light Technician"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""VFX Artist"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""VFX Artist"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Editor"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Editor"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""cast"": [
                  {
                    ""character"": ""Joe Brody"",
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""character"": ""Jules Winfield"",
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
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
                ""cr"": {
                  ""production"": [
                    {
                      ""job"": ""Producer"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Producer"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Artist"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Artist"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Crew Member"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Crew Member"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Make-Up Artist"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Make-Up Artist"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Director"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Director"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Writer"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Writer"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Sound Designer"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Sound Designer"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Camera"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Camera"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Light Technician"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Light Technician"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""VFX Artist"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""VFX Artist"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Editor"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Editor"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""ca"": [
                  {
                    ""character"": ""Joe Brody"",
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    }
                  },
                  {
                    ""character"": ""Jules Winfield"",
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
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
                ""cr"": {
                  ""production"": [
                    {
                      ""job"": ""Producer"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Producer"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Artist"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Artist"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Crew Member"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Crew Member"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Make-Up Artist"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Make-Up Artist"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Director"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Director"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Writer"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Writer"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Sound Designer"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Sound Designer"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Camera"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Camera"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Light Technician"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Light Technician"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""VFX Artist"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""VFX Artist"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                      ""job"": ""Editor"",
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
                          ""slug"": ""bryan-cranston"",
                          ""imdb"": ""nm0186505"",
                          ""tmdb"": 17419,
                          ""tvrage"": 1797
                        }
                      }
                    },
                    {
                      ""job"": ""Editor"",
                      ""person"": {
                        ""name"": ""Samuel L.Jackson"",
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
                }
              }";
    }
}
