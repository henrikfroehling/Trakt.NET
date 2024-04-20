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
    public class TraktNote_Tests
    {
        [Fact]
        public void Test_TraktUserNote_Default_Constructor()
        {
            var userNote = new TraktNote();

            userNote.Id.Should().Be(0);
            userNote.Notes.Should().BeNullOrEmpty();
            userNote.Privacy.Should().BeNull();
            userNote.Spoiler.Should().BeNull();
            userNote.CreatedAt.Should().BeNull();
            userNote.UpdatedAt.Should().BeNull();
            userNote.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserNote_From_Json()
        {
            var jsonReader = new NoteObjectJsonReader();
            var userNote = await jsonReader.ReadObjectAsync(JSON) as TraktNote;

            userNote.Should().NotBeNull();
            userNote.Id.Should().Be(49);
            userNote.Notes.Should().Be("Only watch the extended edition.");
            userNote.Privacy.Should().Be(TraktListPrivacy.Private);
            userNote.Spoiler.Should().BeFalse();
            userNote.CreatedAt.Should().Be(DateTime.Parse("2023-09-07T20:10:18.000Z").ToUniversalTime());
            userNote.UpdatedAt.Should().Be(DateTime.Parse("2023-09-07T20:10:56.000Z").ToUniversalTime());
            userNote.User.Should().NotBeNull();
            userNote.User.Username.Should().Be("justin");
            userNote.User.IsPrivate.Should().BeFalse();
            userNote.User.Name.Should().Be("Justin Nemeth");
            userNote.User.IsVIP.Should().BeTrue();
            userNote.User.IsVIP_EP.Should().BeTrue();
            userNote.User.Ids.Should().NotBeNull();
            userNote.User.Ids.Slug.Should().Be("justin");
        }

        private const string JSON =
            @"{
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
              }";
    }
}
