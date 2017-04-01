namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader.Basic")]
    public class ITraktSharingObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktSharingObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktSharingObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<TraktSharing>));
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_COMPLETE);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_INCOMPLETE_3);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_INCOMPLETE_4);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_INCOMPLETE_5);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_INCOMPLETE_6);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_INCOMPLETE_7);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_INCOMPLETE_8);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_INCOMPLETE_9);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_INCOMPLETE_10);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_INCOMPLETE_11);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_INCOMPLETE_12);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_NOT_VALID_4);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_NOT_VALID_5);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_NOT_VALID_6);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeTrue();
            traktSharing.Twitter.Should().BeTrue();
            traktSharing.Google.Should().BeTrue();
            traktSharing.Tumblr.Should().BeTrue();
            traktSharing.Medium.Should().BeTrue();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(JSON_NOT_VALID_7);

            traktSharing.Should().NotBeNull();
            traktSharing.Facebook.Should().BeNull();
            traktSharing.Twitter.Should().BeNull();
            traktSharing.Google.Should().BeNull();
            traktSharing.Tumblr.Should().BeNull();
            traktSharing.Medium.Should().BeNull();
            traktSharing.Slack.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(default(string));
            traktSharing.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(string.Empty);
            traktSharing.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktSharingObjectJsonReader();

            var traktSharing = jsonReader.ReadObject(default(JsonTextReader));
            traktSharing.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSharingObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktSharingObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = traktJsonReader.ReadObject(jsonReader);
                traktSharing.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""facebook"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""google"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""facebook"": true
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""twitter"": true
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""google"": true
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""tumblr"": true
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""medium"": true
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""fb"": true,
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""facebook"": true,
                ""tw"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""go"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""google"": true,
                ""tb"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""md"": true,
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""sl"": true
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""fb"": true,
                ""tw"": true,
                ""go"": true,
                ""tb"": true,
                ""md"": true,
                ""sl"": true
              }";
    }
}
