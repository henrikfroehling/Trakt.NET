namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    public partial class CrewObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_13 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_14 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_15 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_16 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_17 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_18 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_19 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_20 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_21 =
            @"{
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
                ]
              }";

        private const string JSON_INCOMPLETE_22 =
            @"{
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
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""prod"": [
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
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
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
                ""a"": [
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
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
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
                ""cr"": [
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
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
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
                ""cos &"": [
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
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
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
                ""dir"": [
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
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
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
                ""writ"": [
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
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
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
                ""so"": [
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
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
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
                ""cam"": [
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
              }";

        private const string JSON_NOT_VALID_9 =
            @"{
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
                ""light"": [
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
              }";

        private const string JSON_NOT_VALID_10 =
            @"{
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
                ""vfx"": [
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
              }";

        private const string JSON_NOT_VALID_11 =
            @"{
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
                ""edit"": [
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
              }";

        private const string JSON_NOT_VALID_12 =
            @"{
                ""prod"": [
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
                ""a"": [
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
                ""cr"": [
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
                ""cos &"": [
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
                ""dir"": [
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
                ""writ"": [
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
                ""so"": [
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
                ""cam"": [
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
                ""light"": [
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
                ""vfx"": [
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
                ""edit"": [
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
              }";
    }
}
