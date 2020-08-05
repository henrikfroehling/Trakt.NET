namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class CastAndCrewObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""cast"": [
                  {
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
                      ""person"": {
                        ""name"": ""Bryan Cranston"",
                        ""ids"": {
                          ""trakt"": 297737,
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
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""cast"": [
                  {
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
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""cast"": [
                  {
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
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""ca"": [
                  {
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
                }
              }";
    }
}
