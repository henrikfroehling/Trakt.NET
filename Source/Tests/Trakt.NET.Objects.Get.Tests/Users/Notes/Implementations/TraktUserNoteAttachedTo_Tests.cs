namespace TraktNet.Objects.Get.Tests.Users.Notes.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users.Notes;
    using TraktNet.Objects.Get.Users.Notes.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.Notes.Implementations")]
    public class TraktUserNoteAttachedTo_Tests
    {
        [Fact]
        public void Test_TraktUserNoteAttachedTo_Default_Constructor()
        {
            var userNoteAttachedTo = new TraktUserNoteAttachedTo();

            userNoteAttachedTo.Type.Should().BeNull();
            userNoteAttachedTo.Id.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserNoteAttachedTo_From_Json()
        {
            var jsonReader = new UserNoteAttachedToObjectJsonReader();
            var userNoteAttachedTo = await jsonReader.ReadObjectAsync(JSON) as TraktUserNoteAttachedTo;

            userNoteAttachedTo.Should().NotBeNull();
            userNoteAttachedTo.Type.Should().Be(TraktNotesObjectType.Movie);
            userNoteAttachedTo.Id.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserNoteAttachedTo_From_Json_History()
        {
            var jsonReader = new UserNoteAttachedToObjectJsonReader();
            var userNoteAttachedTo = await jsonReader.ReadObjectAsync(JSON_HISTORY) as TraktUserNoteAttachedTo;

            userNoteAttachedTo.Should().NotBeNull();
            userNoteAttachedTo.Type.Should().Be(TraktNotesObjectType.History);
            userNoteAttachedTo.Id.Should().Be(5224U);
        }

        private const string JSON =
            @"{
                ""type"": ""movie""
              }";

        private const string JSON_HISTORY =
            @"{
                ""type"": ""history"",
                ""id"": 5224
              }";
    }
}
