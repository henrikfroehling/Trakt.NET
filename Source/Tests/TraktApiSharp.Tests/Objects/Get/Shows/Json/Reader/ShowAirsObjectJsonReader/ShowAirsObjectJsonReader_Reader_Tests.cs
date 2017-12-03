namespace TraktApiSharp.Tests.Objects.Get.Shows.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ShowAirsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().BeNull();
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().BeNull();
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().BeNull();
                traktShowAirs.TimeZoneId.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().BeNull();
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().BeNull();
                traktShowAirs.Time.Should().BeNull();
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().BeNull();
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().BeNull();
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().BeNull();
                traktShowAirs.Time.Should().BeNull();
                traktShowAirs.TimeZoneId.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            var traktShowAirs = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktShowAirs.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktShowAirs.Should().BeNull();
            }
        }
    }
}
