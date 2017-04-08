namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ITraktSharingObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_11);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_12);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_7);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(default(string));
            traktSharing.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = await jsonReader.ReadObjectAsync(string.Empty);
            traktSharing.Should().BeNull();
        }
    }
}
