namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    public partial class UserSettingsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean"",
                    ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                  },
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""SF"",
                  ""about"": ""I have all your cassette tapes."",
                  ""gender"": ""male"",
                  ""age"": 35,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  },
                  ""vip_og"": true,
                  ""vip_years"": 5,
                  ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""date_format"": ""dmy"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042"",
                  ""token"": ""60fa34c4f5e7f093ecc5a2d16d691e24""
                },
                ""connections"": {
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true,
                  ""facebook"": true,
                  ""apple"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]"",
                  ""rated"": ""[item] [stars]""
                },
                ""limits"": {
                    ""list"": {
                        ""count"": 9999,
                        ""item_count"": 10000
                    },
                    ""watchlist"": {
                        ""item_count"": 10000
                    },
                    ""recommendations"": {
                        ""item_count"": 50
                    }
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""date_format"": ""dmy"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042"",
                  ""token"": ""60fa34c4f5e7f093ecc5a2d16d691e24""
                },
                ""connections"": {
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true,
                  ""facebook"": true,
                  ""apple"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]"",
                  ""rated"": ""[item] [stars]""
                },
                ""limits"": {
                    ""list"": {
                        ""count"": 9999,
                        ""item_count"": 10000
                    },
                    ""watchlist"": {
                        ""item_count"": 10000
                    },
                    ""recommendations"": {
                        ""item_count"": 50
                    }
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean"",
                    ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                  },
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""SF"",
                  ""about"": ""I have all your cassette tapes."",
                  ""gender"": ""male"",
                  ""age"": 35,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  },
                  ""vip_og"": true,
                  ""vip_years"": 5,
                  ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                },
                ""connections"": {
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true,
                  ""facebook"": true,
                  ""apple"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]"",
                  ""rated"": ""[item] [stars]""
                },
                ""limits"": {
                    ""list"": {
                        ""count"": 9999,
                        ""item_count"": 10000
                    },
                    ""watchlist"": {
                        ""item_count"": 10000
                    },
                    ""recommendations"": {
                        ""item_count"": 50
                    }
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean"",
                    ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                  },
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""SF"",
                  ""about"": ""I have all your cassette tapes."",
                  ""gender"": ""male"",
                  ""age"": 35,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  },
                  ""vip_og"": true,
                  ""vip_years"": 5,
                  ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""date_format"": ""dmy"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042"",
                  ""token"": ""60fa34c4f5e7f093ecc5a2d16d691e24""
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]"",
                  ""rated"": ""[item] [stars]""
                },
                ""limits"": {
                    ""list"": {
                        ""count"": 9999,
                        ""item_count"": 10000
                    },
                    ""watchlist"": {
                        ""item_count"": 10000
                    },
                    ""recommendations"": {
                        ""item_count"": 50
                    }
                }
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean"",
                    ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                  },
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""SF"",
                  ""about"": ""I have all your cassette tapes."",
                  ""gender"": ""male"",
                  ""age"": 35,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  },
                  ""vip_og"": true,
                  ""vip_years"": 5,
                  ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""date_format"": ""dmy"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042"",
                  ""token"": ""60fa34c4f5e7f093ecc5a2d16d691e24""
                },
                ""connections"": {
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true,
                  ""facebook"": true,
                  ""apple"": true
                },
                ""limits"": {
                    ""list"": {
                        ""count"": 9999,
                        ""item_count"": 10000
                    },
                    ""watchlist"": {
                        ""item_count"": 10000
                    },
                    ""recommendations"": {
                        ""item_count"": 50
                    }
                }
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean"",
                    ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                  },
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""SF"",
                  ""about"": ""I have all your cassette tapes."",
                  ""gender"": ""male"",
                  ""age"": 35,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  },
                  ""vip_og"": true,
                  ""vip_years"": 5,
                  ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""date_format"": ""dmy"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042"",
                  ""token"": ""60fa34c4f5e7f093ecc5a2d16d691e24""
                },
                ""connections"": {
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true,
                  ""facebook"": true,
                  ""apple"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]"",
                  ""rated"": ""[item] [stars]""
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""usr"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean"",
                    ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                  },
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""SF"",
                  ""about"": ""I have all your cassette tapes."",
                  ""gender"": ""male"",
                  ""age"": 35,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  },
                  ""vip_og"": true,
                  ""vip_years"": 5,
                  ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""date_format"": ""dmy"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042"",
                  ""token"": ""60fa34c4f5e7f093ecc5a2d16d691e24""
                },
                ""connections"": {
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true,
                  ""facebook"": true,
                  ""apple"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]"",
                  ""rated"": ""[item] [stars]""
                },
                ""limits"": {
                    ""list"": {
                        ""count"": 9999,
                        ""item_count"": 10000
                    },
                    ""watchlist"": {
                        ""item_count"": 10000
                    },
                    ""recommendations"": {
                        ""item_count"": 50
                    }
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean"",
                    ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                  },
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""SF"",
                  ""about"": ""I have all your cassette tapes."",
                  ""gender"": ""male"",
                  ""age"": 35,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  },
                  ""vip_og"": true,
                  ""vip_years"": 5,
                  ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                },
                ""acc"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""date_format"": ""dmy"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042"",
                  ""token"": ""60fa34c4f5e7f093ecc5a2d16d691e24""
                },
                ""connections"": {
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true,
                  ""facebook"": true,
                  ""apple"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]"",
                  ""rated"": ""[item] [stars]""
                },
                ""limits"": {
                    ""list"": {
                        ""count"": 9999,
                        ""item_count"": 10000
                    },
                    ""watchlist"": {
                        ""item_count"": 10000
                    },
                    ""recommendations"": {
                        ""item_count"": 50
                    }
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean"",
                    ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                  },
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""SF"",
                  ""about"": ""I have all your cassette tapes."",
                  ""gender"": ""male"",
                  ""age"": 35,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  },
                  ""vip_og"": true,
                  ""vip_years"": 5,
                  ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""date_format"": ""dmy"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042"",
                  ""token"": ""60fa34c4f5e7f093ecc5a2d16d691e24""
                },
                ""conn"": {
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true,
                  ""facebook"": true,
                  ""apple"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]"",
                  ""rated"": ""[item] [stars]""
                },
                ""limits"": {
                    ""list"": {
                        ""count"": 9999,
                        ""item_count"": 10000
                    },
                    ""watchlist"": {
                        ""item_count"": 10000
                    },
                    ""recommendations"": {
                        ""item_count"": 50
                    }
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean"",
                    ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                  },
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""SF"",
                  ""about"": ""I have all your cassette tapes."",
                  ""gender"": ""male"",
                  ""age"": 35,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  },
                  ""vip_og"": true,
                  ""vip_years"": 5,
                  ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""date_format"": ""dmy"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042"",
                  ""token"": ""60fa34c4f5e7f093ecc5a2d16d691e24""
                },
                ""connections"": {
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true,
                  ""facebook"": true,
                  ""apple"": true
                },
                ""share"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]"",
                  ""rated"": ""[item] [stars]""
                },
                ""limits"": {
                    ""list"": {
                        ""count"": 9999,
                        ""item_count"": 10000
                    },
                    ""watchlist"": {
                        ""item_count"": 10000
                    },
                    ""recommendations"": {
                        ""item_count"": 50
                    }
                }
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean"",
                    ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                  },
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""SF"",
                  ""about"": ""I have all your cassette tapes."",
                  ""gender"": ""male"",
                  ""age"": 35,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  },
                  ""vip_og"": true,
                  ""vip_years"": 5,
                  ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""date_format"": ""dmy"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042"",
                  ""token"": ""60fa34c4f5e7f093ecc5a2d16d691e24""
                },
                ""connections"": {
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true,
                  ""facebook"": true,
                  ""apple"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]"",
                  ""rated"": ""[item] [stars]""
                },
                ""lim"": {
                    ""list"": {
                        ""count"": 9999,
                        ""item_count"": 10000
                    },
                    ""watchlist"": {
                        ""item_count"": 10000
                    },
                    ""recommendations"": {
                        ""item_count"": 50
                    }
                }
              }";


        private const string JSON_NOT_VALID_6 =
            @"{
                ""usr"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean"",
                    ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                  },
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""SF"",
                  ""about"": ""I have all your cassette tapes."",
                  ""gender"": ""male"",
                  ""age"": 35,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  },
                  ""vip_og"": true,
                  ""vip_years"": 5,
                  ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                },
                ""acc"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""date_format"": ""dmy"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042"",
                  ""token"": ""60fa34c4f5e7f093ecc5a2d16d691e24""
                },
                ""conn"": {
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true,
                  ""facebook"": true,
                  ""apple"": true
                },
                ""share"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]"",
                  ""rated"": ""[item] [stars]""
                },
                ""lim"": {
                    ""list"": {
                        ""count"": 9999,
                        ""item_count"": 10000
                    },
                    ""watchlist"": {
                        ""item_count"": 10000
                    },
                    ""recommendations"": {
                        ""item_count"": 50
                    }
                }
              }";
    }
}
