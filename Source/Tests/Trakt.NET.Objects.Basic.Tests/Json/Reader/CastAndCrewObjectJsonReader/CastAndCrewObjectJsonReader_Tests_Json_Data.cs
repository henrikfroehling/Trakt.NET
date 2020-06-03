namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class CastAndCrewObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""cast"": [
                  {
                    ""character"": ""Joe Brody"",
                    ""characters"": [
                      ""Joe Brody""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
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
                    ""characters"": [
                      ""Jules Winfield""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
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
                      ""job"": ""Producer"",
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
                      ""job"": ""Artist"",
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
                      ""job"": ""Artist"",
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
                      ""job"": ""Crew Member"",
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
                      ""job"": ""Crew Member"",
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
                      ""job"": ""Make-Up Artist"",
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
                      ""job"": ""Make-Up Artist"",
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
                      ""job"": ""Director"",
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
                      ""job"": ""Director"",
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
                      ""job"": ""Writer"",
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
                      ""job"": ""Writer"",
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
                      ""job"": ""Sound Designer"",
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
                      ""job"": ""Sound Designer"",
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
                      ""job"": ""Camera"",
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
                      ""job"": ""Camera"",
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
                      ""job"": ""Light Technician"",
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
                      ""job"": ""Light Technician"",
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
                      ""job"": ""VFX Artist"",
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
                      ""job"": ""VFX Artist"",
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
                      ""job"": ""Editor"",
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
                      ""job"": ""Editor"",
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
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""crew"": {
                  ""production"": [
                    {
                      ""job"": ""Producer"",
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
                      ""job"": ""Producer"",
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
                      ""job"": ""Artist"",
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
                      ""job"": ""Artist"",
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
                      ""job"": ""Crew Member"",
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
                      ""job"": ""Crew Member"",
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
                      ""job"": ""Make-Up Artist"",
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
                      ""job"": ""Make-Up Artist"",
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
                      ""job"": ""Director"",
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
                      ""job"": ""Director"",
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
                      ""job"": ""Writer"",
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
                      ""job"": ""Writer"",
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
                      ""job"": ""Sound Designer"",
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
                      ""job"": ""Sound Designer"",
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
                      ""job"": ""Camera"",
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
                      ""job"": ""Camera"",
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
                      ""job"": ""Light Technician"",
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
                      ""job"": ""Light Technician"",
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
                      ""job"": ""VFX Artist"",
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
                      ""job"": ""VFX Artist"",
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
                      ""job"": ""Editor"",
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
                      ""job"": ""Editor"",
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
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""cast"": [
                  {
                    ""character"": ""Joe Brody"",
                    ""characters"": [
                      ""Joe Brody""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
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
                    ""characters"": [
                      ""Jules Winfield""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
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
                    ""characters"": [
                      ""Joe Brody""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
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
                    ""characters"": [
                      ""Jules Winfield""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
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
                      ""job"": ""Producer"",
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
                      ""job"": ""Artist"",
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
                      ""job"": ""Artist"",
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
                      ""job"": ""Crew Member"",
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
                      ""job"": ""Crew Member"",
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
                      ""job"": ""Make-Up Artist"",
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
                      ""job"": ""Make-Up Artist"",
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
                      ""job"": ""Director"",
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
                      ""job"": ""Director"",
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
                      ""job"": ""Writer"",
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
                      ""job"": ""Writer"",
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
                      ""job"": ""Sound Designer"",
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
                      ""job"": ""Sound Designer"",
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
                      ""job"": ""Camera"",
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
                      ""job"": ""Camera"",
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
                      ""job"": ""Light Technician"",
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
                      ""job"": ""Light Technician"",
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
                      ""job"": ""VFX Artist"",
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
                      ""job"": ""VFX Artist"",
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
                      ""job"": ""Editor"",
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
                      ""job"": ""Editor"",
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
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""cast"": [
                  {
                    ""character"": ""Joe Brody"",
                    ""characters"": [
                      ""Joe Brody""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
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
                    ""characters"": [
                      ""Jules Winfield""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
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
                      ""job"": ""Producer"",
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
                      ""job"": ""Artist"",
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
                      ""job"": ""Artist"",
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
                      ""job"": ""Crew Member"",
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
                      ""job"": ""Crew Member"",
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
                      ""job"": ""Make-Up Artist"",
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
                      ""job"": ""Make-Up Artist"",
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
                      ""job"": ""Director"",
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
                      ""job"": ""Director"",
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
                      ""job"": ""Writer"",
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
                      ""job"": ""Writer"",
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
                      ""job"": ""Sound Designer"",
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
                      ""job"": ""Sound Designer"",
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
                      ""job"": ""Camera"",
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
                      ""job"": ""Camera"",
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
                      ""job"": ""Light Technician"",
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
                      ""job"": ""Light Technician"",
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
                      ""job"": ""VFX Artist"",
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
                      ""job"": ""VFX Artist"",
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
                      ""job"": ""Editor"",
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
                      ""job"": ""Editor"",
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
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""ca"": [
                  {
                    ""character"": ""Joe Brody"",
                    ""characters"": [
                      ""Joe Brody""
                    ],
                    ""person"": {
                      ""name"": ""Bryan Cranston"",
                      ""ids"": {
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
                    ""characters"": [
                      ""Jules Winfield""
                    ],
                    ""person"": {
                      ""name"": ""Samuel L.Jackson"",
                      ""ids"": {
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
                      ""job"": ""Producer"",
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
                      ""job"": ""Artist"",
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
                      ""job"": ""Artist"",
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
                      ""job"": ""Crew Member"",
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
                      ""job"": ""Crew Member"",
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
                      ""job"": ""Make-Up Artist"",
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
                      ""job"": ""Make-Up Artist"",
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
                      ""job"": ""Director"",
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
                      ""job"": ""Director"",
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
                      ""job"": ""Writer"",
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
                      ""job"": ""Writer"",
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
                      ""job"": ""Sound Designer"",
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
                      ""job"": ""Sound Designer"",
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
                      ""job"": ""Camera"",
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
                      ""job"": ""Camera"",
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
                      ""job"": ""Light Technician"",
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
                      ""job"": ""Light Technician"",
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
                      ""job"": ""VFX Artist"",
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
                      ""job"": ""VFX Artist"",
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
                      ""job"": ""Editor"",
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
                      ""job"": ""Editor"",
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
                }
              }";
    }
}
