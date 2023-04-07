namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Reader
{
    public partial class RecommendedMovieObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_1 =
            @"{
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_2 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_3 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_4 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_5 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_6 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_7 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_8 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_9 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_10 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_11 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_12 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_13 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_14 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_15 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_16 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""country"": ""us"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_17 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""status"": ""released"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_18 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""recommended_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";

        private const string JSON_INCOMPLETE_19 =
            @"{
              ""title"": ""Star Wars: The Force Awakens"",
              ""year"": 2015,
              ""ids"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tagline"": ""Every generation has a story."",
              ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
              ""released"": ""2015-12-18"",
              ""runtime"": 136,
              ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rating"": 8.31988,
              ""votes"": 9338,
              ""updated_at"": ""2016-03-31T09:01:59Z"",
              ""language"": ""en"",
              ""available_translations"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""genres"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""certification"": ""PG-13"",
              ""country"": ""us"",
              ""status"": ""released""
            }";

        private const string JSON_NOT_VALID =
            @"{
              ""ttl"": ""Star Wars: The Force Awakens"",
              ""y"": 2015,
              ""id"": {
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              },
              ""tl"": ""Every generation has a story."",
              ""ov"": ""Thirty years after defeating the Galactic Empire,..."",
              ""rel"": ""2015-12-18"",
              ""run"": 136,
              ""tr"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
              ""hp"": ""http://www.starwars.com/films/star-wars-episode-vii"",
              ""rate"": 8.31988,
              ""vote"": 9338,
              ""ua"": ""2016-03-31T09:01:59Z"",
              ""lang"": ""en"",
              ""av_tr"": [
                ""en"",
                ""de"",
                ""en"",
                ""it""
              ],
              ""gen"": [
                ""action"",
                ""adventure"",
                ""fantasy"",
                ""science-fiction""
              ],
              ""cert"": ""PG-13"",
              ""co"": ""us"",
              ""st"": ""released"",
              ""rec_by"": [
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
                  ""notes"": ""Recommended because ...""
                }
              ]
            }";
    }
}
