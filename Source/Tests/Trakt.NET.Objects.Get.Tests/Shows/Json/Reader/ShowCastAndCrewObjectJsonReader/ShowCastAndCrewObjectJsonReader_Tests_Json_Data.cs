namespace TraktNet.Objects.Get.Tests.Shows.Json.Reader
{
    public partial class ShowCastAndCrewObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
              ""cast"": [
                {
                  ""character"": ""Daenerys Targaryen"",
                  ""characters"": [
                    ""Daenerys Targaryen""
                  ],
                  ""person"": {
                    ""name"": ""Emilia Clarke"",
                    ""ids"": {
                      ""trakt"": 436511,
                      ""slug"": ""emilia-clarke"",
                      ""imdb"": ""nm3592338"",
                      ""tmdb"": 1223786,
                      ""tvrage"": null
                    }
                  }
                }
              ],
              ""guest_stars"": [
                {
                  ""character"": ""Samwell Tarly"",
                  ""characters"": [
                    ""Samwell Tarly""
                  ],
                  ""person"": {
                    ""name"": ""John Bradley"",
                    ""ids"": {
                      ""trakt"": 413734,
                      ""slug"": ""john-bradley-ff703964-4593-4530-a7f6-c83a7f367e88"",
                      ""imdb"": ""nm4263213"",
                      ""tmdb"": 1010135,
                      ""tvrage"": null
                    }
                  }
                }
              ],
              ""crew"": {
                ""editing"": [
                  {
                    ""job"": ""Editor"",
                    ""jobs"": [
                      ""Editor""
                    ],
                    ""person"": {
                      ""name"": ""Martin Nicholson"",
                      ""ids"": {
                        ""trakt"": 66119,
                        ""slug"": ""martin-nicholson"",
                        ""imdb"": ""nm0629882"",
                        ""tmdb"": 81827,
                        ""tvrage"": null
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
                      ""name"": ""Daniel Minahan"",
                      ""ids"": {
                        ""trakt"": 77501,
                        ""slug"": ""daniel-minahan"",
                        ""imdb"": ""nm0590889"",
                        ""tmdb"": 88743,
                        ""tvrage"": 28917
                      }
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""job"": ""Director of Photography"",
                    ""jobs"": [
                      ""Director of Photography""
                    ],
                    ""person"": {
                      ""name"": ""Matthew Jensen"",
                      ""ids"": {
                        ""trakt"": 90466,
                        ""slug"": ""matthew-jensen"",
                        ""imdb"": ""nm0421608"",
                        ""tmdb"": 94545,
                        ""tvrage"": null
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
                      ""name"": ""George R. R. Martin"",
                      ""ids"": {
                        ""trakt"": 448663,
                        ""slug"": ""george-r-r-martin-448663"",
                        ""imdb"": ""nm0552333"",
                        ""tmdb"": 237053,
                        ""tvrage"": 79951
                      }
                    }
                  }
                ]
              }
            }";
    }
}
