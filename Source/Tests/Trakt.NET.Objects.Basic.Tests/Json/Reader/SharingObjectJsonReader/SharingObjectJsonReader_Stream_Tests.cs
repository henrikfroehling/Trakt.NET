namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SharingObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeTrue();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeNull();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeTrue();
                traktSharing.Twitter.Should().BeNull();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeTrue();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeNull();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeTrue();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeNull();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeTrue();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeNull();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeTrue();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeTrue();
                traktSharing.Twitter.Should().BeNull();
                traktSharing.Google.Should().BeNull();
                traktSharing.Tumblr.Should().BeNull();
                traktSharing.Medium.Should().BeNull();
                traktSharing.Slack.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeNull();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeNull();
                traktSharing.Tumblr.Should().BeNull();
                traktSharing.Medium.Should().BeNull();
                traktSharing.Slack.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeNull();
                traktSharing.Twitter.Should().BeNull();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeNull();
                traktSharing.Medium.Should().BeNull();
                traktSharing.Slack.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeNull();
                traktSharing.Twitter.Should().BeNull();
                traktSharing.Google.Should().BeNull();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeNull();
                traktSharing.Slack.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeNull();
                traktSharing.Twitter.Should().BeNull();
                traktSharing.Google.Should().BeNull();
                traktSharing.Tumblr.Should().BeNull();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeNull();
                traktSharing.Twitter.Should().BeNull();
                traktSharing.Google.Should().BeNull();
                traktSharing.Tumblr.Should().BeNull();
                traktSharing.Medium.Should().BeNull();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeNull();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeTrue();
                traktSharing.Twitter.Should().BeNull();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeTrue();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeNull();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeTrue();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeNull();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeTrue();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeNull();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeTrue();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);

                traktSharing.Should().NotBeNull();
                traktSharing.Facebook.Should().BeNull();
                traktSharing.Twitter.Should().BeNull();
                traktSharing.Google.Should().BeNull();
                traktSharing.Tumblr.Should().BeNull();
                traktSharing.Medium.Should().BeNull();
                traktSharing.Slack.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            var traktSharing = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktSharing.Should().BeNull();
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(stream);
                traktSharing.Should().BeNull();
            }
        }
    }
}
