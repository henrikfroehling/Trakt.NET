namespace TraktNet.Objects.Post.Tests.Notes.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Notes;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Notes;
    using TraktNet.Objects.Post.Notes.Json.Reader;
    using TraktNet.Objects.Post.Notes.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Post.Notes.Implementations")]
    public class TraktNotePost_Tests
    {
        [Fact]
        public void Test_TraktNotePost_Validate()
        {
            ITraktNotePost notePost = new TraktNotePost();

            // no media object and no notes
            Action act = () => notePost.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // no media object
            notePost.Notes = "notes test";
            act.Should().Throw<TraktPostValidationException>();
        }

        [Fact]
        public async Task Test_TraktNotePost_From_Json_Movie()
        {
            var jsonReader = new NotePostObjectJsonReader();
            var notePost = await jsonReader.ReadObjectAsync(JSON_MOVIE) as TraktNotePost;

            notePost.Should().NotBeNull();
            notePost.Notes.Should().Be("Watch this in IMAX!");
            notePost.Movie.Should().NotBeNull();
            notePost.Movie.Title.Should().Be("Guardians of the Galaxy");
            notePost.Movie.Year.Should().Be(2014);
            notePost.Movie.Ids.Should().NotBeNull();
            notePost.Movie.Ids.Trakt.Should().Be(28U);
            notePost.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            notePost.Movie.Ids.Imdb.Should().Be("tt2015381");
            notePost.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktNotePost_To_Json_Movie()
        {
            var notePost = new TraktNotePost
            {
                Notes = "Watch this in IMAX!",
                Movie = new TraktMovie
                {
                    Title = "Guardians of the Galaxy",
                    Year = 2014,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 28,
                        Slug = "guardians-of-the-galaxy-2014",
                        Imdb = "tt2015381",
                        Tmdb = 118340
                    }
                }
            };

            var jsonWriter = new NotePostObjectJsonWriter();

            string json = await jsonWriter.WriteObjectAsync(notePost);
            json.Should().Be(@"{""notes"":""Watch this in IMAX!""," +
                             @"""movie"":{""title"":""Guardians of the Galaxy"",""year"":2014," +
                             @"""ids"":{""trakt"":28,""slug"":""guardians-of-the-galaxy-2014""," +
                             @"""imdb"":""tt2015381"",""tmdb"":118340}}}");
        }

        [Fact]
        public async Task Test_TraktNotePost_From_Json_Show()
        {
            var jsonReader = new NotePostObjectJsonReader();
            var notePost = await jsonReader.ReadObjectAsync(JSON_SHOW) as TraktNotePost;

            notePost.Should().NotBeNull();
            notePost.Notes.Should().Be("Welcome to Pollos Hermanos!");
            notePost.Show.Should().NotBeNull();
            notePost.Show.Title.Should().Be("Breaking Bad");
            notePost.Show.Ids.Should().NotBeNull();
            notePost.Show.Ids.Trakt.Should().Be(1U);
            notePost.Show.Ids.Slug.Should().Be("breaking-bad");
        }

        [Fact]
        public async Task Test_TraktNotePost_To_Json_Show()
        {
            var notePost = new TraktNotePost
            {
                Notes = "Welcome to Pollos Hermanos!",
                Show = new TraktShow
                {
                    Title = "Breaking Bad",
                    Ids = new TraktShowIds
                    {
                        Trakt = 1,
                        Slug = "breaking-bad"
                    }
                }
            };

            var jsonWriter = new NotePostObjectJsonWriter();

            string json = await jsonWriter.WriteObjectAsync(notePost);
            json.Should().Be(@"{""notes"":""Welcome to Pollos Hermanos!""," +
                             @"""show"":{""title"":""Breaking Bad""," +
                             @"""ids"":{""trakt"":1,""slug"":""breaking-bad""}}}");
        }

        [Fact]
        public async Task Test_TraktNotePost_From_Json_Season()
        {
            var jsonReader = new NotePostObjectJsonReader();
            var notePost = await jsonReader.ReadObjectAsync(JSON_SEASON) as TraktNotePost;

            notePost.Should().NotBeNull();
            notePost.Notes.Should().Be("Hello Gus.");
            notePost.Season.Should().NotBeNull();
            notePost.Season.Ids.Should().NotBeNull();
            notePost.Season.Ids.Trakt.Should().Be(16U);
        }

        [Fact]
        public async Task Test_TraktNotePost_To_Json_Season()
        {
            var notePost = new TraktNotePost
            {
                Notes = "Hello Gus.",
                Season = new TraktSeason
                {
                    Ids = new TraktSeasonIds
                    {
                        Trakt = 16
                    }
                }
            };

            var jsonWriter = new NotePostObjectJsonWriter();

            string json = await jsonWriter.WriteObjectAsync(notePost);
            json.Should().Be(@"{""notes"":""Hello Gus.""," +
                             @"""season"":{""ids"":{""trakt"":16}}}");
        }

        [Fact]
        public async Task Test_TraktNotePost_From_Json_Episode()
        {
            var jsonReader = new NotePostObjectJsonReader();
            var notePost = await jsonReader.ReadObjectAsync(JSON_EPISODE) as TraktNotePost;

            notePost.Should().NotBeNull();
            notePost.Notes.Should().Be("I am the danger!");
            notePost.Episode.Should().NotBeNull();
            notePost.Episode.Ids.Should().NotBeNull();
            notePost.Episode.Ids.Trakt.Should().Be(16U);
        }

        [Fact]
        public async Task Test_TraktNotePost_To_Json_Episode()
        {
            var notePost = new TraktNotePost
            {
                Notes = "I am the danger!",
                Episode = new TraktEpisode
                {
                    Ids = new TraktEpisodeIds
                    {
                        Trakt = 16
                    }
                }
            };

            var jsonWriter = new NotePostObjectJsonWriter();

            string json = await jsonWriter.WriteObjectAsync(notePost);
            json.Should().Be(@"{""notes"":""I am the danger!""," +
                             @"""episode"":{""ids"":{""trakt"":16}}}");
        }

        [Fact]
        public async Task Test_TraktNotePost_From_Json_Person()
        {
            var jsonReader = new NotePostObjectJsonReader();
            var notePost = await jsonReader.ReadObjectAsync(JSON_PERSON) as TraktNotePost;

            notePost.Should().NotBeNull();
            notePost.Notes.Should().Be("Every movie they direct is a masterpiece.");
            notePost.Person.Should().NotBeNull();
            notePost.Person.Ids.Should().NotBeNull();
            notePost.Person.Ids.Trakt.Should().Be(16U);
        }

        [Fact]
        public async Task Test_TraktNotePost_To_Json_Person()
        {
            var notePost = new TraktNotePost
            {
                Notes = "Every movie they direct is a masterpiece.",
                Person = new TraktPerson
                {
                    Ids = new TraktPersonIds
                    {
                        Trakt = 16
                    }
                }
            };

            var jsonWriter = new NotePostObjectJsonWriter();

            string json = await jsonWriter.WriteObjectAsync(notePost);
            json.Should().Be(@"{""notes"":""Every movie they direct is a masterpiece.""," +
                             @"""person"":{""ids"":{""trakt"":16}}}");
        }

        [Fact]
        public async Task Test_TraktNotePost_From_Json_History_Movie()
        {
            var jsonReader = new NotePostObjectJsonReader();
            var notePost = await jsonReader.ReadObjectAsync(JSON_HISTORY_MOVIE) as TraktNotePost;

            notePost.Should().NotBeNull();
            notePost.Notes.Should().Be("Saw this in Dolby Cinema!");
            notePost.AttachedTo.Should().NotBeNull();
            notePost.AttachedTo.Type.Should().Be(TraktNotesObjectType.History);
            notePost.AttachedTo.Id.Should().Be(43453489U);
            notePost.Privacy.Should().Be(TraktListPrivacy.Public);
        }

        [Fact]
        public async Task Test_TraktNotePost_To_Json_History_Movie()
        {
            var notePost = new TraktNotePost
            {
                Notes = "Saw this in Dolby Cinema!",
                AttachedTo = new TraktNoteAttachedTo
                {
                    Type = TraktNotesObjectType.History,
                    Id = 43453489
                },
                Privacy = TraktListPrivacy.Public
            };

            var jsonWriter = new NotePostObjectJsonWriter();

            string json = await jsonWriter.WriteObjectAsync(notePost);
            json.Should().Be(@"{""attached_to"":{""type"":""history"",""id"":43453489}," +
                             @"""privacy"":""public"",""notes"":""Saw this in Dolby Cinema!""}");
        }

        [Fact]
        public async Task Test_TraktNotePost_From_Json_Collection_Movie()
        {
            var jsonReader = new NotePostObjectJsonReader();
            var notePost = await jsonReader.ReadObjectAsync(JSON_COLLECTION_MOVIE) as TraktNotePost;

            notePost.Should().NotBeNull();
            notePost.Notes.Should().Be("Owned on 4K Blu-ray, DVD, VHS, and LaserDisc.");
            notePost.AttachedTo.Should().NotBeNull();
            notePost.AttachedTo.Type.Should().Be(TraktNotesObjectType.Collection);
            notePost.Privacy.Should().Be(TraktListPrivacy.Public);
            notePost.Movie.Should().NotBeNull();
            notePost.Movie.Title.Should().Be("The Goonies");
            notePost.Movie.Year.Should().Be(1985);
            notePost.Movie.Ids.Should().NotBeNull();
            notePost.Movie.Ids.Trakt.Should().Be(4633U);
            notePost.Movie.Ids.Slug.Should().Be("the-goonies-1985");
            notePost.Movie.Ids.Imdb.Should().Be("tt0089218");
            notePost.Movie.Ids.Tmdb.Should().Be(9340U);
        }

        [Fact]
        public async Task Test_TraktNotePost_To_Json_Collection_Movie()
        {
            var notePost = new TraktNotePost
            {
                Notes = "Owned on 4K Blu-ray, DVD, VHS, and LaserDisc.",
                AttachedTo = new TraktNoteAttachedTo
                {
                    Type = TraktNotesObjectType.Collection
                },
                Privacy = TraktListPrivacy.Public,
                Movie = new TraktMovie
                {
                    Title = "The Goonies",
                    Year = 1985,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 4633,
                        Slug = "the-goonies-1985",
                        Imdb = "tt0089218",
                        Tmdb = 9340
                    }
                }
            };

            var jsonWriter = new NotePostObjectJsonWriter();

            string json = await jsonWriter.WriteObjectAsync(notePost);
            json.Should().Be(@"{""attached_to"":{""type"":""collection""}," +
                             @"""privacy"":""public"",""notes"":""Owned on 4K Blu-ray, DVD, VHS, and LaserDisc.""," +
                             @"""movie"":{""title"":""The Goonies"",""year"":1985," +
                             @"""ids"":{""trakt"":4633,""slug"":""the-goonies-1985""," +
                             @"""imdb"":""tt0089218"",""tmdb"":9340}}}");
        }

        [Fact]
        public async Task Test_TraktNotePost_From_Json_Rating_Movie()
        {
            var jsonReader = new NotePostObjectJsonReader();
            var notePost = await jsonReader.ReadObjectAsync(JSON_RATING_MOVIE) as TraktNotePost;

            notePost.Should().NotBeNull();
            notePost.Notes.Should().Be("Cinemetography: 10/10 Acting: 10/10 Soundtrack: 10/10 Overall: 10/10");
            notePost.AttachedTo.Should().NotBeNull();
            notePost.AttachedTo.Type.Should().Be(TraktNotesObjectType.Rating);
            notePost.Privacy.Should().Be(TraktListPrivacy.Public);
            notePost.Movie.Should().NotBeNull();
            notePost.Movie.Title.Should().Be("The Goonies");
            notePost.Movie.Year.Should().Be(1985);
            notePost.Movie.Ids.Should().NotBeNull();
            notePost.Movie.Ids.Trakt.Should().Be(4633U);
            notePost.Movie.Ids.Slug.Should().Be("the-goonies-1985");
            notePost.Movie.Ids.Imdb.Should().Be("tt0089218");
            notePost.Movie.Ids.Tmdb.Should().Be(9340U);
        }

        [Fact]
        public async Task Test_TraktNotePost_To_Json_Rating_Movie()
        {
            var notePost = new TraktNotePost
            {
                Notes = "Cinemetography: 10/10 Acting: 10/10 Soundtrack: 10/10 Overall: 10/10",
                AttachedTo = new TraktNoteAttachedTo
                {
                    Type = TraktNotesObjectType.Rating
                },
                Privacy = TraktListPrivacy.Public,
                Movie = new TraktMovie
                {
                    Title = "The Goonies",
                    Year = 1985,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 4633,
                        Slug = "the-goonies-1985",
                        Imdb = "tt0089218",
                        Tmdb = 9340
                    }
                }
            };

            var jsonWriter = new NotePostObjectJsonWriter();

            string json = await jsonWriter.WriteObjectAsync(notePost);
            json.Should().Be(@"{""attached_to"":{""type"":""rating""}," +
                             @"""privacy"":""public"",""notes"":""Cinemetography: 10/10 Acting: 10/10 Soundtrack: 10/10 Overall: 10/10""," +
                             @"""movie"":{""title"":""The Goonies"",""year"":1985," +
                             @"""ids"":{""trakt"":4633,""slug"":""the-goonies-1985""," +
                             @"""imdb"":""tt0089218"",""tmdb"":9340}}}");
        }

        private const string JSON_MOVIE =
            @"{
                ""movie"": {
                  ""title"": ""Guardians of the Galaxy"",
                  ""year"": 2014,
                  ""ids"": {
                    ""trakt"": 28,
                    ""slug"": ""guardians-of-the-galaxy-2014"",
                    ""imdb"": ""tt2015381"",
                    ""tmdb"": 118340
                  }
                },
                ""notes"": ""Watch this in IMAX!""
              }";

        private const string JSON_SHOW =
            @"{
                ""show"": {
                  ""title"": ""Breaking Bad"",
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""breaking-bad""
                  }
                },
                ""notes"": ""Welcome to Pollos Hermanos!""
              }";

        private const string JSON_SEASON =
            @"{
                ""season"": {
                  ""ids"": {
                    ""trakt"": 16
                  }
                },
                ""notes"": ""Hello Gus.""
              }";

        private const string JSON_EPISODE =
            @"{
                ""episode"": {
                  ""ids"": {
                    ""trakt"": 16
                  }
                },
                ""notes"": ""I am the danger!""
              }";

        private const string JSON_PERSON =
            @"{
                ""person"": {
                  ""ids"": {
                    ""trakt"": 16
                  }
                },
                ""notes"": ""Every movie they direct is a masterpiece.""
              }";

        private const string JSON_HISTORY_MOVIE =
            @"{
                ""attached_to"": {
                  ""type"": ""history"",
                  ""id"": 43453489
                },
                ""privacy"": ""public"",
                ""notes"": ""Saw this in Dolby Cinema!""
              }";

        private const string JSON_COLLECTION_MOVIE =
            @"{
                ""attached_to"": {
                  ""type"": ""collection""
                },
                ""privacy"": ""public"",
                ""movie"": {
                  ""title"": ""The Goonies"",
                  ""year"": 1985,
                  ""ids"": {
                    ""trakt"": 4633,
                    ""slug"": ""the-goonies-1985"",
                    ""imdb"": ""tt0089218"",
                    ""tmdb"": 9340
                  }
                },
                ""notes"": ""Owned on 4K Blu-ray, DVD, VHS, and LaserDisc.""
              }";

        private const string JSON_RATING_MOVIE =
            @"{
                ""attached_to"": {
                  ""type"": ""rating""
                },
                ""privacy"": ""public"",
                ""movie"": {
                  ""title"": ""The Goonies"",
                  ""year"": 1985,
                  ""ids"": {
                    ""trakt"": 4633,
                    ""slug"": ""the-goonies-1985"",
                    ""imdb"": ""tt0089218"",
                    ""tmdb"": 9340
                  }
                },
                ""notes"": ""Cinemetography: 10/10 Acting: 10/10 Soundtrack: 10/10 Overall: 10/10""
              }";
    }
}
