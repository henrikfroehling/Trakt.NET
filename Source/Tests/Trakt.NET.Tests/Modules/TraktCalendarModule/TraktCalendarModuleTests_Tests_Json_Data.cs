namespace TraktNet.Tests.Modules.TraktCalendarModule
{
    using System;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Parameters.Filter;

    public partial class TraktCalendarModule_Tests
    {
        private const string START_DATE = "Tue, 08 Mar 2016 00:00:00 GMT";
        private const string END_DATE = "Mon, 14 Mar 2016 23:59:59 GMT";
        private const int DAYS = 14;
        private readonly DateTime TODAY = DateTime.UtcNow;
        private readonly TraktExtendedInfo EXTENDED_INFO = new TraktExtendedInfo { Full = true };

        private readonly ITraktCalendarFilter FILTER = TraktFilterDirectory.CalendarFilter
            .WithQuery("calendar movie")
            .WithYear(2016)
            .WithGenres("drama", "fantasy")
            .WithLanguages("en", "de")
            .WithCountries("us")
            .WithRuntimes(30, 60)
            .WithRatings(80, 95)
            .Build();

        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }

        public TraktCalendarModule_Tests()
        {
            if (DateTime.TryParse(START_DATE, out DateTime startDateTime))
                StartDateTime = startDateTime.ToUniversalTime();

            if (DateTime.TryParse(END_DATE, out DateTime endDateTime))
                EndDateTime = endDateTime.ToUniversalTime();
        }

        private const string CALENDAR_ALL_MOVIES_JSON =
            @"[
                {
                  ""released"": ""2014-08-01"",
                  ""movie"": {
                    ""title"": ""Guardians of the Galaxy"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 28,
                      ""slug"": ""guardians-of-the-galaxy-2014"",
                      ""imdb"": ""tt2015381"",
                      ""tmdb"": 118340
                    }
                  }
                },
                {
                  ""released"": ""2014-08-01"",
                  ""movie"": {
                    ""title"": ""Get On Up"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 29,
                      ""slug"": ""get-on-up-2014"",
                      ""imdb"": ""tt2473602"",
                      ""tmdb"": 239566
                    }
                  }
                },
                {
                  ""released"": ""2014-08-08"",
                  ""movie"": {
                    ""title"": ""Teenage Mutant Ninja Turtles"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 30,
                      ""slug"": ""teenage-mutant-ninja-turtles-2014"",
                      ""imdb"": ""tt1291150"",
                      ""tmdb"": 98566
                    }
                  }
                }
              ]";

        private const string CALENDAR_ALL_SHOWS_JSON =
            @"[
                {
                  ""first_aired"": ""2014-07-14T01:00:00.000Z"",
                  ""episode"": {
                    ""season"": 7,
                    ""number"": 4,
                    ""title"": ""Death is Not the End"",
                    ""ids"": {
                      ""trakt"": 443,
                      ""tvdb"": 4851180,
                      ""imdb"": ""tt3500614"",
                      ""tmdb"": 988123,
                      ""tvrage"": null
                    }
                  },
                  ""show"": {
                    ""title"": ""True Blood"",
                    ""year"": 2008,
                    ""ids"": {
                      ""trakt"": 5,
                      ""slug"": ""true-blood"",
                      ""tvdb"": 82283,
                      ""imdb"": ""tt0844441"",
                      ""tmdb"": 10545,
                      ""tvrage"": 12662
                    }
                  }
                },
                {
                  ""first_aired"": ""2014-07-14T02:00:00.000Z"",
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 3,
                    ""title"": ""Two Boats and a Helicopter"",
                    ""ids"": {
                      ""trakt"": 499,
                      ""tvdb"": 4854797,
                      ""imdb"": ""tt3631218"",
                      ""tmdb"": 988346,
                      ""tvrage"": null
                    }
                  },
                  ""show"": {
                    ""title"": ""The Leftovers"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 7,
                      ""slug"": ""the-leftovers"",
                      ""tvdb"": 269689,
                      ""imdb"": ""tt2699128"",
                      ""tmdb"": 54344,
                      ""tvrage"": null
                    }
                  }
                }
              ]";

        private const string CALENDAR_DVD_MOVIES_JSON =
            @"[
                {
                  ""released"": ""2014-08-01"",
                  ""movie"": {
                    ""title"": ""Guardians of the Galaxy"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 28,
                      ""slug"": ""guardians-of-the-galaxy-2014"",
                      ""imdb"": ""tt2015381"",
                      ""tmdb"": 118340
                    }
                  }
                },
                {
                  ""released"": ""2014-08-01"",
                  ""movie"": {
                    ""title"": ""Get On Up"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 29,
                      ""slug"": ""get-on-up-2014"",
                      ""imdb"": ""tt2473602"",
                      ""tmdb"": 239566
                    }
                  }
                },
                {
                  ""released"": ""2014-08-08"",
                  ""movie"": {
                    ""title"": ""Teenage Mutant Ninja Turtles"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 30,
                      ""slug"": ""teenage-mutant-ninja-turtles-2014"",
                      ""imdb"": ""tt1291150"",
                      ""tmdb"": 98566
                    }
                  }
                }
              ]";
    }
}
