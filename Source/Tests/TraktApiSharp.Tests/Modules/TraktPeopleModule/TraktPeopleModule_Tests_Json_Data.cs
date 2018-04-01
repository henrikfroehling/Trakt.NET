namespace TraktApiSharp.Tests.Modules.TraktPeopleModule
{
    public partial class TraktPeopleModule_Tests
    {
        private const string PERSON_MINIMAL_JSON =
            @"{
                ""name"": ""Bryan Cranston"",
                ""ids"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                }
              }";

        private const string PERSON_FULL_JSON =
            @"{
                ""name"": ""Bryan Cranston"",
                ""ids"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                },
                ""biography"": ""Bryan Lee Cranston (born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy \""Malcolm in the Middle\"", and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia."",
                ""birthday"": ""1956-03-07"",
                ""death"": ""2016-04-06"",
                ""birthplace"": ""San Fernando Valley, California, USA"",
                ""homepage"": ""http://www.bryancranston.com/""
              }";

        private const string PERSON_MOVIE_CREDITS_JSON =
            @"{
                ""cast"": [
                  {
                    ""character"": ""Li (voice)"",
                    ""movie"": {
                      ""title"": ""Kung Fu Panda 3"",
                      ""year"": 2016,
                      ""ids"": {
                        ""trakt"": 93870,
                        ""slug"": ""kung-fu-panda-3-2016"",
                        ""imdb"": ""tt2267968"",
                        ""tmdb"": 140300
                      }
                    }
                  },
                  {
                    ""character"": ""Joe Brody"",
                    ""movie"": {
                      ""title"": ""Godzilla"",
                      ""year"": 2014,
                      ""ids"": {
                        ""trakt"": 24,
                        ""slug"": ""godzilla-2014"",
                        ""imdb"": ""tt0831387"",
                        ""tmdb"": 124905
                      }
                    }
                  }
                ],
                ""crew"": {
                  ""directing"": [
                    {
                      ""job"": ""Director"",
                      ""movie"": {
                        ""title"": ""Godzilla"",
                        ""year"": 2014,
                        ""ids"": {
                          ""trakt"": 24,
                          ""slug"": ""godzilla-2014"",
                          ""imdb"": ""tt0831387"",
                          ""tmdb"": 124905
                        }
                      }
                    }
                  ],
                  ""writing"": [
                    {
                      ""job"": ""Screenplay"",
                      ""movie"": {
                        ""title"": ""Godzilla"",
                        ""year"": 2014,
                        ""ids"": {
                          ""trakt"": 24,
                          ""slug"": ""godzilla-2014"",
                          ""imdb"": ""tt0831387"",
                          ""tmdb"": 124905
                        }
                      }
                    }
                  ],
                  ""production"": [
                    {
                      ""job"": ""Producer"",
                      ""movie"": {
                        ""title"": ""Godzilla"",
                        ""year"": 2014,
                        ""ids"": {
                          ""trakt"": 24,
                          ""slug"": ""godzilla-2014"",
                          ""imdb"": ""tt0831387"",
                          ""tmdb"": 124905
                        }
                      }
                    }
                  ]
                }
              }";

        private const string PERSON_SHOW_CREDITS_JSON =
            @"{
                ""cast"": [
                  {
                    ""character"": ""Walter White"",
                    ""show"": {
                      ""title"": ""Breaking Bad"",
                      ""year"": 2008,
                      ""ids"": {
                        ""trakt"": 1,
                        ""slug"": ""breaking-bad"",
                        ""tvdb"": 81189,
                        ""imdb"": ""tt0903747"",
                        ""tmdb"": 1396,
                        ""tvrage"": 18164
                      }
                    }
                  },
                  {
                    ""character"": ""Hal"",
                    ""show"": {
                      ""title"": ""Malcolm in the Middle"",
                      ""year"": 2000,
                      ""ids"": {
                        ""trakt"": 1991,
                        ""slug"": ""malcolm-in-the-middle"",
                        ""tvdb"": 73838,
                        ""imdb"": ""tt0212671"",
                        ""tmdb"": 2004,
                        ""tvrage"": null
                      }
                    }
                  }
                ],
                ""crew"": {
                  ""production"": [
                    {
                      ""job"": ""Producer"",
                      ""show"": {
                        ""title"": ""Breaking Bad"",
                        ""year"": 2008,
                        ""ids"": {
                          ""trakt"": 1,
                          ""slug"": ""breaking-bad"",
                          ""tvdb"": 81189,
                          ""imdb"": ""tt0903747"",
                          ""tmdb"": 1396,
                          ""tvrage"": 18164
                        }
                      }
                    }
                  ]
                }
              }";
    }
}
