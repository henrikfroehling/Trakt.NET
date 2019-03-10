namespace TraktNet.Tests.Modules.TraktSearchModule
{
    using TraktNet.Enums;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Parameters.Filter;

    public partial class TraktSearchModule_Tests
    {
        private const string ENCODED_COMMA = "%2C";
        private const int ID_LOOKUP_ITEM_COUNT = 1;
        private const int TEXT_QUERY_ITEM_COUNT = 5;
        private const string LOOKUP_ID = "tt0848228";
        private const string TEXT_QUERY = "batman";
        private const uint PAGE = 2;
        private const uint LIMIT = 4;
        private readonly TraktSearchIdType ID_LOOKUP_TYPE = TraktSearchIdType.ImDB;
        private readonly TraktSearchResultType TEXT_QUERY_TYPE_MOVIE = TraktSearchResultType.Movie;
        private readonly TraktSearchResultType TEXT_QUERY_TYPE_SHOW = TraktSearchResultType.Show;
        private readonly TraktSearchResultType ID_LOOKUP_RESULT_TYPE = TraktSearchResultType.Movie;
        private readonly TraktSearchResultType TEXT_QUERY_RESULT_TYPE = TraktSearchResultType.Show;
        private readonly TraktExtendedInfo EXTENDED_INFO = new TraktExtendedInfo { Full = true };
        private readonly TraktSearchField TEXT_QUERY_SEARCH_FIELD_TITLE = TraktSearchField.Title;
        private readonly TraktSearchField TEXT_QUERY_SEARCH_FIELD_OVERVIEW = TraktSearchField.Overview;

        private readonly ITraktSearchFilter FILTER = TraktFilterDirectory.SearchFilter
            .WithYear(2011)
            .WithGenres("action", "thriller")
            .WithLanguages("en", "de")
            .WithCountries("us")
            .WithRuntimes(70, 140)
            .WithRatings(70, 95)
            .Build();

        private string GetIdLookupUri { get; }
        private string GetTextQueryUri { get; }
        private string GetTextQueryUriMulitpleTypes { get; }
        private TraktSearchResultType TextQueryTypes { get; }
        private string[] TextQueryTypesUriNames { get; }
        private string TextQueryTypesEncoded { get; }
        private TraktSearchField TextQuerySearchFields { get; }
        private string[] TextQuerySearchFieldsUriNames { get; }
        private string TextQuerySearchFieldsEncoded { get; }

        public TraktSearchModule_Tests()
        {
            GetIdLookupUri = $"search/{ID_LOOKUP_TYPE.UriName}/{LOOKUP_ID}";
            TextQueryTypes = TEXT_QUERY_TYPE_MOVIE | TEXT_QUERY_TYPE_SHOW;
            TextQueryTypesUriNames = new string[] { TEXT_QUERY_TYPE_MOVIE.UriName, TEXT_QUERY_TYPE_SHOW.UriName };
            TextQueryTypesEncoded = string.Join(ENCODED_COMMA, TextQueryTypesUriNames);
            TextQuerySearchFields = TEXT_QUERY_SEARCH_FIELD_TITLE | TEXT_QUERY_SEARCH_FIELD_OVERVIEW;
            TextQuerySearchFieldsUriNames = new string[] { TEXT_QUERY_SEARCH_FIELD_TITLE.UriName, TEXT_QUERY_SEARCH_FIELD_OVERVIEW.UriName };
            TextQuerySearchFieldsEncoded = string.Join(ENCODED_COMMA, TextQuerySearchFieldsUriNames);
            GetTextQueryUri = $"search/{TEXT_QUERY_TYPE_MOVIE.UriName}?query={TEXT_QUERY}";
            GetTextQueryUriMulitpleTypes = $"search/{TextQueryTypesEncoded}?query={TEXT_QUERY}";
        }

        private const string SEARCH_TEXT_QUERY_RESULTS_JSON =
            @"[
                {
                  ""type"": ""movie"",
                  ""score"": 26.019499,
                  ""movie"": {
                    ""title"": ""Batman Begins"",
                    ""overview"": ""Driven by tragedy, billionaire Bruce Wayne dedicates his life to uncovering and defeating the corruption that plagues his home, Gotham City.  Unable to work within the system, he instead creates a new identity, a symbol of fear for the criminal underworld - The Batman."",
                    ""year"": 2005,
                    ""images"": {
                      ""poster"": {
                        ""full"": ""https://walter.trakt.us/images/movies/000/000/001/posters/original/9634ffd477.jpg?1406080393"",
                        ""medium"": ""https://walter.trakt.us/images/movies/000/000/001/posters/medium/9634ffd477.jpg?1406080393"",
                        ""thumb"": ""https://walter.trakt.us/images/movies/000/000/001/posters/thumb/9634ffd477.jpg?1406080393""
                      },
                      ""fanart"": {
                        ""full"": ""https://walter.trakt.us/images/movies/000/000/001/fanarts/original/7da8cfbe9e.jpg?1406080393"",
                        ""medium"": ""https://walter.trakt.us/images/movies/000/000/001/fanarts/medium/7da8cfbe9e.jpg?1406080393"",
                        ""thumb"": ""https://walter.trakt.us/images/movies/000/000/001/fanarts/thumb/7da8cfbe9e.jpg?1406080393""
                      }
                    },
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""batman-begins-2005"",
                      ""imdb"": ""tt0372784"",
                      ""tmdb"": 272
                    }
                  }
                },
                {
                  ""type"": ""show"",
                  ""score"": 19.533358,
                  ""show"": {
                    ""title"": ""Breaking Bad"",
                    ""overview"": ""Breaking Bad is an American crime drama television series created and produced by Vince Gilligan. Set and produced in Albuquerque, New Mexico, Breaking Bad is the story of Walter White, a struggling high school chemistry teacher who is diagnosed with inoperable lung cancer at the beginning of the series. He turns to a life of crime, producing and selling methamphetamine, in order to secure his family's financial future before he dies, teaming with his former student, Jesse Pinkman. Heavily serialized, the series is known for positioning its characters in seemingly inextricable corners and has been labeled a contemporary western by its creator."",
                    ""year"": 2008,
                    ""status"": ""ended"",
                    ""images"": {
                      ""poster"": {
                        ""full"": ""https://walter.trakt.us/images/shows/000/000/001/posters/original/7217fe0ea7.jpg?1412271410"",
                        ""medium"": ""https://walter.trakt.us/images/shows/000/000/001/posters/medium/7217fe0ea7.jpg?1412271410"",
                        ""thumb"": ""https://walter.trakt.us/images/shows/000/000/001/posters/thumb/7217fe0ea7.jpg?1412271410""
                      },
                      ""fanart"": {
                        ""full"": ""https://walter.trakt.us/images/shows/000/000/001/fanarts/original/2fb47044fd.jpg?1412271412"",
                        ""medium"": ""https://walter.trakt.us/images/shows/000/000/001/fanarts/medium/2fb47044fd.jpg?1412271412"",
                        ""thumb"": ""https://walter.trakt.us/images/shows/000/000/001/fanarts/thumb/2fb47044fd.jpg?1412271412""
                      }
                    },
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
                  ""type"": ""episode"",
                  ""score"": 42.50835,
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 5,
                    ""title"": ""Gray Matter"",
                    ""overview"": ""Walter and Skyler attend a former colleague's party. Jesse tries to free himself from the drugs, while Skyler organizes an intervention."",
                    ""images"": {
                      ""screenshot"": {
                        ""full"": ""https://walter.trakt.us/images/episodes/000/000/062/screenshots/original/dbb0a11808.jpg?1412374314"",
                        ""medium"": ""https://walter.trakt.us/images/episodes/000/000/062/screenshots/medium/dbb0a11808.jpg?1412374314"",
                        ""thumb"": ""https://walter.trakt.us/images/episodes/000/000/062/screenshots/thumb/dbb0a11808.jpg?1412374314""
                      }
                    },
                    ""ids"": {
                      ""trakt"": 20,
                      ""tvdb"": 349238,
                      ""imdb"": ""tt1054727"",
                      ""tmdb"": 62089,
                      ""tvrage"": 637646
                    }
                  },
                  ""show"": {
                    ""title"": ""Breaking Bad"",
                    ""year"": 2008,
                    ""ids"": {
                      ""trakt"": 1
                    }
                  }
                },
                {
                  ""type"": ""person"",
                  ""score"": 53.421608,
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""images"": {
                      ""headshot"": {
                        ""full"": ""https://walter.trakt.us/images/people/000/000/001/headshots/original/47aebaace9.jpg?1412273271"",
                        ""medium"": ""https://walter.trakt.us/images/people/000/000/001/headshots/medium/47aebaace9.jpg?1412273271"",
                        ""thumb"": ""https://walter.trakt.us/images/people/000/000/001/headshots/thumb/47aebaace9.jpg?1412273271""
                      }
                    },
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""type"": ""list"",
                  ""score"": 38.643196,
                  ""list"": {
                    ""name"": ""Custom List"",
                    ""description"": ""desc for the custom list"",
                    ""privacy"": ""private"",
                    ""display_numbers"": true,
                    ""allow_comments"": true,
                    ""item_count"": 10,
                    ""username"": ""justin"",
                    ""ids"": {
                      ""trakt"": 77,
                      ""slug"": ""custom-list""
                    }
                  }
                }
              ]";

        private const string SEARCH_ID_LOOKUP_RESULTS_JSON =
            @"[
                {
                  ""type"": ""movie"",
                  ""score"": null,
                  ""movie"": {
                    ""title"": ""The Avengers"",
                    ""overview"": ""When an unexpected enemy emerges and threatens global safety and security, Nick Fury, director of the international peacekeeping agency known as S.H.I.E.L.D., finds himself in need of a team to pull the world back from the brink of disaster. Spanning the globe, a daring recruitment effort begins!"",
                    ""year"": 2012,
                    ""images"": {
                      ""poster"": {
                        ""full"": ""https://walter.trakt.us/images/movies/000/000/012/posters/original/293ce7103a.jpg?1406080484"",
                        ""medium"": ""https://walter.trakt.us/images/movies/000/000/012/posters/medium/293ce7103a.jpg?1406080484"",
                        ""thumb"": ""https://walter.trakt.us/images/movies/000/000/012/posters/thumb/293ce7103a.jpg?1406080484""
                      },
                      ""fanart"": {
                        ""full"": ""https://walter.trakt.us/images/movies/000/000/012/fanarts/original/7d93500475.jpg?1406080485"",
                        ""medium"": ""https://walter.trakt.us/images/movies/000/000/012/fanarts/medium/7d93500475.jpg?1406080485"",
                        ""thumb"": ""https://walter.trakt.us/images/movies/000/000/012/fanarts/thumb/7d93500475.jpg?1406080485""
                      }
                    },
                    ""ids"": {
                      ""trakt"": 12,
                      ""slug"": ""the-avengers-2012"",
                      ""imdb"": ""tt0848228"",
                      ""tmdb"": 24428
                    }
                  }
                }
              ]";
    }
}
