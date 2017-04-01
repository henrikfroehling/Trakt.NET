namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader.Get.Shows")]
    public class ITraktShowAirsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktShowAirsObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktShowAirs>));
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktShowAirsObjectJsonReader();

            var traktShowAirs = jsonReader.ReadObject(JSON_COMPLETE);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().Be("Sunday");
            traktShowAirs.Time.Should().Be("21:00");
            traktShowAirs.TimeZoneId.Should().Be("America/New_York");
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktShowAirsObjectJsonReader();

            var traktShowAirs = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().BeNull();
            traktShowAirs.Time.Should().Be("21:00");
            traktShowAirs.TimeZoneId.Should().Be("America/New_York");
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktShowAirsObjectJsonReader();

            var traktShowAirs = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().Be("Sunday");
            traktShowAirs.Time.Should().BeNull();
            traktShowAirs.TimeZoneId.Should().Be("America/New_York");
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktShowAirsObjectJsonReader();

            var traktShowAirs = jsonReader.ReadObject(JSON_INCOMPLETE_3);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().Be("Sunday");
            traktShowAirs.Time.Should().Be("21:00");
            traktShowAirs.TimeZoneId.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktShowAirsObjectJsonReader();

            var traktShowAirs = jsonReader.ReadObject(JSON_INCOMPLETE_4);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().Be("Sunday");
            traktShowAirs.Time.Should().BeNull();
            traktShowAirs.TimeZoneId.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktShowAirsObjectJsonReader();

            var traktShowAirs = jsonReader.ReadObject(JSON_INCOMPLETE_5);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().BeNull();
            traktShowAirs.Time.Should().Be("21:00");
            traktShowAirs.TimeZoneId.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktShowAirsObjectJsonReader();

            var traktShowAirs = jsonReader.ReadObject(JSON_INCOMPLETE_6);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().BeNull();
            traktShowAirs.Time.Should().BeNull();
            traktShowAirs.TimeZoneId.Should().Be("America/New_York");
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktShowAirsObjectJsonReader();

            var traktShowAirs = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().BeNull();
            traktShowAirs.Time.Should().Be("21:00");
            traktShowAirs.TimeZoneId.Should().Be("America/New_York");
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktShowAirsObjectJsonReader();

            var traktShowAirs = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().Be("Sunday");
            traktShowAirs.Time.Should().BeNull();
            traktShowAirs.TimeZoneId.Should().Be("America/New_York");
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktShowAirsObjectJsonReader();

            var traktShowAirs = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().Be("Sunday");
            traktShowAirs.Time.Should().Be("21:00");
            traktShowAirs.TimeZoneId.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktShowAirsObjectJsonReader();

            var traktShowAirs = jsonReader.ReadObject(JSON_NOT_VALID_4);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().BeNull();
            traktShowAirs.Time.Should().BeNull();
            traktShowAirs.TimeZoneId.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktShowAirsObjectJsonReader();

            var traktShowAirs = jsonReader.ReadObject(default(string));
            traktShowAirs.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktShowAirsObjectJsonReader();

            var traktShowAirs = jsonReader.ReadObject(string.Empty);
            traktShowAirs.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = traktJsonReader.ReadObject(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = traktJsonReader.ReadObject(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().BeNull();
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = traktJsonReader.ReadObject(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().BeNull();
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = traktJsonReader.ReadObject(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = traktJsonReader.ReadObject(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().BeNull();
                traktShowAirs.TimeZoneId.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = traktJsonReader.ReadObject(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().BeNull();
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = traktJsonReader.ReadObject(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().BeNull();
                traktShowAirs.Time.Should().BeNull();
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = traktJsonReader.ReadObject(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().BeNull();
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = traktJsonReader.ReadObject(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().BeNull();
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = traktJsonReader.ReadObject(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = traktJsonReader.ReadObject(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().BeNull();
                traktShowAirs.Time.Should().BeNull();
                traktShowAirs.TimeZoneId.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktShowAirsObjectJsonReader();

            var traktShowAirs = jsonReader.ReadObject(default(JsonTextReader));
            traktShowAirs.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktShowAirsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = traktJsonReader.ReadObject(jsonReader);
                traktShowAirs.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""day"": ""Sunday"",
                ""timezone"": ""America/New_York""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""day"": ""Sunday"",
                ""time"": ""21:00""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""day"": ""Sunday""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""time"": ""21:00""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""timezone"": ""America/New_York""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""d"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""day"": ""Sunday"",
                ""t"": ""21:00"",
                ""timezone"": ""America/New_York""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""tz"": ""America/New_York""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""d"": ""Sunday"",
                ""t"": ""21:00"",
                ""tz"": ""America/New_York""
              }";
    }
}
