namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Reader
{
    public partial class RecommendedShowObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_1 =
            @"{
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_2 =
            @"{
              ""title"": ""Game of Thrones"",
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_3 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_4 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_5 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_6 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_7 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_8 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_9 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_10 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_11 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_12 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_13 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_14 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_15 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_16 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_17 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_18 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_19 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""aired_episodes"": 50,
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_20 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""favorited_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_21 =
            @"{
              ""title"": ""Game of Thrones"",
              ""year"": 2011,
              ""ids"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""first_aired"": ""2011-04-17T07:00:00Z"",
              ""airs"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""runtime"": 60,
              ""certification"": ""TV-MA"",
              ""network"": ""HBO"",
              ""country"": ""us"",
              ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""homepage"": ""http://www.hbo.com/game-of-thrones"",
              ""status"": ""returning series"",
              ""rating"": 9.38327,
              ""votes"": 44773,
              ""updated_at"": ""2016-04-06T10:39:11Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""genres"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_episodes"": 50
            }";

        private const string JSON_NOT_VALID =
            @"{
              ""tlt"": ""Game of Thrones"",
              ""ye"": 2011,
              ""id"": {
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              },
              ""ov"": ""Seven noble families fight for control of the mythical land of Westeros."",
              ""fa"": ""2011-04-17T07:00:00Z"",
              ""ai"": {
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              },
              ""rt"": 60,
              ""cert"": ""TV-MA"",
              ""net"": ""HBO"",
              ""co"": ""us"",
              ""trai"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
              ""hp"": ""http://www.hbo.com/game-of-thrones"",
              ""st"": ""returning series"",
              ""rate"": 9.38327,
              ""vt"": 44773,
              ""ua"": ""2016-04-06T10:39:11Z"",
              ""lang"": ""en"",
              ""av_tr"": [
                ""en"",
                ""fr"",
                ""it"",
                ""de""
              ],
              ""gen"": [
                ""drama"",
                ""fantasy"",
                ""science-fiction"",
                ""action"",
                ""adventure""
              ],
              ""aired_eps"": 50,
              ""fav_by"": [
                {
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
                  ""notes"": ""Favorited because ...""
                }
              ]
            }";
    }
}
