namespace TraktNet.Objects.Get.Tests.Notes.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Notes;
    using TraktNet.Objects.Get.Notes.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Notes.Implementations")]
    public class TraktNoteItem_Tests
    {
        [Fact]
        public void Test_TraktUserNoteItem_Default_Constructor()
        {
            var userNoteItem = new TraktNoteItem();

            userNoteItem.AttachedTo.Should().BeNull();
            userNoteItem.Type.Should().BeNull();
            userNoteItem.Movie.Should().BeNull();
            userNoteItem.Show.Should().BeNull();
            userNoteItem.Season.Should().BeNull();
            userNoteItem.Episode.Should().BeNull();
            userNoteItem.Person.Should().BeNull();
            userNoteItem.Note.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserNoteItem_From_Json_Movie()
        {
            var jsonReader = new NoteItemObjectJsonReader();
            var userNoteItem = await jsonReader.ReadObjectAsync(JSON_MOVIE) as TraktNoteItem;

            userNoteItem.Should().NotBeNull();

            userNoteItem.AttachedTo.Should().NotBeNull();
            userNoteItem.AttachedTo.Type.Should().Be(TraktNotesObjectType.Movie);
            userNoteItem.AttachedTo.Id.Should().BeNull();

            userNoteItem.Type.Should().Be(TraktListItemType.Movie);

            userNoteItem.Movie.Should().NotBeNull();
            userNoteItem.Movie.Title.Should().Be("Batman Begins");
            userNoteItem.Movie.Year.Should().Be(2005);
            userNoteItem.Movie.Ids.Should().NotBeNull();
            userNoteItem.Movie.Ids.Trakt.Should().Be(1);
            userNoteItem.Movie.Ids.Slug.Should().Be("batman-begins-2005");
            userNoteItem.Movie.Ids.Imdb.Should().Be("tt0372784");
            userNoteItem.Movie.Ids.Tmdb.Should().Be(272);

            userNoteItem.Show.Should().BeNull();
            userNoteItem.Season.Should().BeNull();
            userNoteItem.Episode.Should().BeNull();
            userNoteItem.Person.Should().BeNull();

            userNoteItem.Note.Should().NotBeNull();
            userNoteItem.Note.Id.Should().Be(49);
            userNoteItem.Note.Notes.Should().Be("Only watch the extended edition.");
            userNoteItem.Note.Privacy.Should().Be(TraktListPrivacy.Private);
            userNoteItem.Note.Spoiler.Should().BeFalse();
            userNoteItem.Note.CreatedAt.Should().Be(DateTime.Parse("2023-09-07T20:10:18.000Z").ToUniversalTime());
            userNoteItem.Note.UpdatedAt.Should().Be(DateTime.Parse("2023-09-07T20:10:56.000Z").ToUniversalTime());
            userNoteItem.Note.User.Should().NotBeNull();
            userNoteItem.Note.User.Username.Should().Be("justin");
            userNoteItem.Note.User.IsPrivate.Should().BeFalse();
            userNoteItem.Note.User.Name.Should().Be("Justin Nemeth");
            userNoteItem.Note.User.IsVIP.Should().BeTrue();
            userNoteItem.Note.User.IsVIP_EP.Should().BeTrue();
            userNoteItem.Note.User.Ids.Should().NotBeNull();
            userNoteItem.Note.User.Ids.Slug.Should().Be("justin");
        }

        [Fact]
        public async Task Test_TraktUserNoteItem_From_Json_Movie_History()
        {
            var jsonReader = new NoteItemObjectJsonReader();
            var userNoteItem = await jsonReader.ReadObjectAsync(JSON_MOVIE_HISTORY) as TraktNoteItem;

            userNoteItem.Should().NotBeNull();

            userNoteItem.AttachedTo.Should().NotBeNull();
            userNoteItem.AttachedTo.Type.Should().Be(TraktNotesObjectType.History);
            userNoteItem.AttachedTo.Id.Should().Be(3253454U);

            userNoteItem.Type.Should().Be(TraktListItemType.Movie);

            userNoteItem.Movie.Should().NotBeNull();
            userNoteItem.Movie.Title.Should().Be("Batman Begins");
            userNoteItem.Movie.Year.Should().Be(2005);
            userNoteItem.Movie.Ids.Should().NotBeNull();
            userNoteItem.Movie.Ids.Trakt.Should().Be(1);
            userNoteItem.Movie.Ids.Slug.Should().Be("batman-begins-2005");
            userNoteItem.Movie.Ids.Imdb.Should().Be("tt0372784");
            userNoteItem.Movie.Ids.Tmdb.Should().Be(272);

            userNoteItem.Show.Should().BeNull();
            userNoteItem.Season.Should().BeNull();
            userNoteItem.Episode.Should().BeNull();
            userNoteItem.Person.Should().BeNull();

            userNoteItem.Note.Should().NotBeNull();
            userNoteItem.Note.Id.Should().Be(49);
            userNoteItem.Note.Notes.Should().Be("Only watch the extended edition.");
            userNoteItem.Note.Privacy.Should().Be(TraktListPrivacy.Private);
            userNoteItem.Note.Spoiler.Should().BeFalse();
            userNoteItem.Note.CreatedAt.Should().Be(DateTime.Parse("2023-09-07T20:10:18.000Z").ToUniversalTime());
            userNoteItem.Note.UpdatedAt.Should().Be(DateTime.Parse("2023-09-07T20:10:56.000Z").ToUniversalTime());
            userNoteItem.Note.User.Should().NotBeNull();
            userNoteItem.Note.User.Username.Should().Be("justin");
            userNoteItem.Note.User.IsPrivate.Should().BeFalse();
            userNoteItem.Note.User.Name.Should().Be("Justin Nemeth");
            userNoteItem.Note.User.IsVIP.Should().BeTrue();
            userNoteItem.Note.User.IsVIP_EP.Should().BeTrue();
            userNoteItem.Note.User.Ids.Should().NotBeNull();
            userNoteItem.Note.User.Ids.Slug.Should().Be("justin");
        }

        private const string JSON_MOVIE =
            @"{
                ""attached_to"": {
                  ""type"": ""movie""
                },
                ""type"": ""movie"",
                ""movie"": {
                  ""title"": ""Batman Begins"",
                  ""year"": 2005,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""batman-begins-2005"",
                    ""imdb"": ""tt0372784"",
                    ""tmdb"": 272
                  }
                },
                ""note"": {
                  ""id"": 49,
                  ""notes"": ""Only watch the extended edition."",
                  ""privacy"": ""private"",
                  ""spoiler"": false,
                  ""created_at"": ""2023-09-07T20:10:18.000Z"",
                  ""updated_at"": ""2023-09-07T20:10:56.000Z"",
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""justin""
                    }
                  }
                }
              }";

        private const string JSON_MOVIE_HISTORY =
            @"{
                ""attached_to"": {
                  ""type"": ""history"",
                  ""id"": 3253454
                },
                ""type"": ""movie"",
                ""movie"": {
                  ""title"": ""Batman Begins"",
                  ""year"": 2005,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""batman-begins-2005"",
                    ""imdb"": ""tt0372784"",
                    ""tmdb"": 272
                  }
                },
                ""note"": {
                  ""id"": 49,
                  ""notes"": ""Only watch the extended edition."",
                  ""privacy"": ""private"",
                  ""spoiler"": false,
                  ""created_at"": ""2023-09-07T20:10:18.000Z"",
                  ""updated_at"": ""2023-09-07T20:10:56.000Z"",
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""justin""
                    }
                  }
                }
              }";
    }
}
