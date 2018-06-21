namespace TraktNet.Tests.Objects.Get.Users.Statistics.Json.Reader
{
    public partial class UserStatisticsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""movies"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""shows"": {
                  ""watched"": 534,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""seasons"": {
                  ""ratings"": 6,
                  ""comments"": 1
                },
                ""episodes"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""network"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                },
                ""ratings"": {
                  ""total"": 9257,
                  ""distribution"": {
                    ""1"": 78,
                    ""2"": 45,
                    ""3"": 55,
                    ""4"": 96,
                    ""5"": 183,
                    ""6"": 545,
                    ""7"": 1361,
                    ""8"": 2259,
                    ""9"": 1772,
                    ""10"": 2863
                  }
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""shows"": {
                  ""watched"": 534,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""seasons"": {
                  ""ratings"": 6,
                  ""comments"": 1
                },
                ""episodes"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""network"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                },
                ""ratings"": {
                  ""total"": 9257,
                  ""distribution"": {
                    ""1"": 78,
                    ""2"": 45,
                    ""3"": 55,
                    ""4"": 96,
                    ""5"": 183,
                    ""6"": 545,
                    ""7"": 1361,
                    ""8"": 2259,
                    ""9"": 1772,
                    ""10"": 2863
                  }
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""movies"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""seasons"": {
                  ""ratings"": 6,
                  ""comments"": 1
                },
                ""episodes"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""network"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                },
                ""ratings"": {
                  ""total"": 9257,
                  ""distribution"": {
                    ""1"": 78,
                    ""2"": 45,
                    ""3"": 55,
                    ""4"": 96,
                    ""5"": 183,
                    ""6"": 545,
                    ""7"": 1361,
                    ""8"": 2259,
                    ""9"": 1772,
                    ""10"": 2863
                  }
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""movies"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""shows"": {
                  ""watched"": 534,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""episodes"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""network"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                },
                ""ratings"": {
                  ""total"": 9257,
                  ""distribution"": {
                    ""1"": 78,
                    ""2"": 45,
                    ""3"": 55,
                    ""4"": 96,
                    ""5"": 183,
                    ""6"": 545,
                    ""7"": 1361,
                    ""8"": 2259,
                    ""9"": 1772,
                    ""10"": 2863
                  }
                }
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""movies"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""shows"": {
                  ""watched"": 534,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""seasons"": {
                  ""ratings"": 6,
                  ""comments"": 1
                },
                ""network"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                },
                ""ratings"": {
                  ""total"": 9257,
                  ""distribution"": {
                    ""1"": 78,
                    ""2"": 45,
                    ""3"": 55,
                    ""4"": 96,
                    ""5"": 183,
                    ""6"": 545,
                    ""7"": 1361,
                    ""8"": 2259,
                    ""9"": 1772,
                    ""10"": 2863
                  }
                }
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""movies"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""shows"": {
                  ""watched"": 534,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""seasons"": {
                  ""ratings"": 6,
                  ""comments"": 1
                },
                ""episodes"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""ratings"": {
                  ""total"": 9257,
                  ""distribution"": {
                    ""1"": 78,
                    ""2"": 45,
                    ""3"": 55,
                    ""4"": 96,
                    ""5"": 183,
                    ""6"": 545,
                    ""7"": 1361,
                    ""8"": 2259,
                    ""9"": 1772,
                    ""10"": 2863
                  }
                }
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""movies"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""shows"": {
                  ""watched"": 534,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""seasons"": {
                  ""ratings"": 6,
                  ""comments"": 1
                },
                ""episodes"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""network"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                }
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""movies"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                }
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""shows"": {
                  ""watched"": 534,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                }
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""seasons"": {
                  ""ratings"": 6,
                  ""comments"": 1
                }
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""episodes"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                }
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""network"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                }
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
                ""ratings"": {
                  ""total"": 9257,
                  ""distribution"": {
                    ""1"": 78,
                    ""2"": 45,
                    ""3"": 55,
                    ""4"": 96,
                    ""5"": 183,
                    ""6"": 545,
                    ""7"": 1361,
                    ""8"": 2259,
                    ""9"": 1772,
                    ""10"": 2863
                  }
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""mov"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""shows"": {
                  ""watched"": 534,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""seasons"": {
                  ""ratings"": 6,
                  ""comments"": 1
                },
                ""episodes"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""network"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                },
                ""ratings"": {
                  ""total"": 9257,
                  ""distribution"": {
                    ""1"": 78,
                    ""2"": 45,
                    ""3"": 55,
                    ""4"": 96,
                    ""5"": 183,
                    ""6"": 545,
                    ""7"": 1361,
                    ""8"": 2259,
                    ""9"": 1772,
                    ""10"": 2863
                  }
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""movies"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""sho"": {
                  ""watched"": 534,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""seasons"": {
                  ""ratings"": 6,
                  ""comments"": 1
                },
                ""episodes"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""network"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                },
                ""ratings"": {
                  ""total"": 9257,
                  ""distribution"": {
                    ""1"": 78,
                    ""2"": 45,
                    ""3"": 55,
                    ""4"": 96,
                    ""5"": 183,
                    ""6"": 545,
                    ""7"": 1361,
                    ""8"": 2259,
                    ""9"": 1772,
                    ""10"": 2863
                  }
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""movies"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""shows"": {
                  ""watched"": 534,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""sea"": {
                  ""ratings"": 6,
                  ""comments"": 1
                },
                ""episodes"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""network"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                },
                ""ratings"": {
                  ""total"": 9257,
                  ""distribution"": {
                    ""1"": 78,
                    ""2"": 45,
                    ""3"": 55,
                    ""4"": 96,
                    ""5"": 183,
                    ""6"": 545,
                    ""7"": 1361,
                    ""8"": 2259,
                    ""9"": 1772,
                    ""10"": 2863
                  }
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""movies"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""shows"": {
                  ""watched"": 534,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""seasons"": {
                  ""ratings"": 6,
                  ""comments"": 1
                },
                ""eps"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""network"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                },
                ""ratings"": {
                  ""total"": 9257,
                  ""distribution"": {
                    ""1"": 78,
                    ""2"": 45,
                    ""3"": 55,
                    ""4"": 96,
                    ""5"": 183,
                    ""6"": 545,
                    ""7"": 1361,
                    ""8"": 2259,
                    ""9"": 1772,
                    ""10"": 2863
                  }
                }
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""movies"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""shows"": {
                  ""watched"": 534,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""seasons"": {
                  ""ratings"": 6,
                  ""comments"": 1
                },
                ""episodes"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""net"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                },
                ""ratings"": {
                  ""total"": 9257,
                  ""distribution"": {
                    ""1"": 78,
                    ""2"": 45,
                    ""3"": 55,
                    ""4"": 96,
                    ""5"": 183,
                    ""6"": 545,
                    ""7"": 1361,
                    ""8"": 2259,
                    ""9"": 1772,
                    ""10"": 2863
                  }
                }
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""movies"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""shows"": {
                  ""watched"": 534,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""seasons"": {
                  ""ratings"": 6,
                  ""comments"": 1
                },
                ""episodes"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""network"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                },
                ""ra"": {
                  ""total"": 9257,
                  ""distribution"": {
                    ""1"": 78,
                    ""2"": 45,
                    ""3"": 55,
                    ""4"": 96,
                    ""5"": 183,
                    ""6"": 545,
                    ""7"": 1361,
                    ""8"": 2259,
                    ""9"": 1772,
                    ""10"": 2863
                  }
                }
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""mov"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""sho"": {
                  ""watched"": 534,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""sea"": {
                  ""ratings"": 6,
                  ""comments"": 1
                },
                ""eps"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""net"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                },
                ""ra"": {
                  ""total"": 9257,
                  ""distribution"": {
                    ""1"": 78,
                    ""2"": 45,
                    ""3"": 55,
                    ""4"": 96,
                    ""5"": 183,
                    ""6"": 545,
                    ""7"": 1361,
                    ""8"": 2259,
                    ""9"": 1772,
                    ""10"": 2863
                  }
                }
              }";
    }
}
