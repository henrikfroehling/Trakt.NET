namespace TraktApiSharp.Tests.Objects.Get.Shows.Json
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.Json;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ShowAirsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ShowAirsObjectJsonReader();

            var traktShowAirs = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().Be("Sunday");
            traktShowAirs.Time.Should().Be("21:00");
            traktShowAirs.TimeZoneId.Should().Be("America/New_York");
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ShowAirsObjectJsonReader();

            var traktShowAirs = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().BeNull();
            traktShowAirs.Time.Should().Be("21:00");
            traktShowAirs.TimeZoneId.Should().Be("America/New_York");
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ShowAirsObjectJsonReader();

            var traktShowAirs = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().Be("Sunday");
            traktShowAirs.Time.Should().BeNull();
            traktShowAirs.TimeZoneId.Should().Be("America/New_York");
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ShowAirsObjectJsonReader();

            var traktShowAirs = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().Be("Sunday");
            traktShowAirs.Time.Should().Be("21:00");
            traktShowAirs.TimeZoneId.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ShowAirsObjectJsonReader();

            var traktShowAirs = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().Be("Sunday");
            traktShowAirs.Time.Should().BeNull();
            traktShowAirs.TimeZoneId.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ShowAirsObjectJsonReader();

            var traktShowAirs = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().BeNull();
            traktShowAirs.Time.Should().Be("21:00");
            traktShowAirs.TimeZoneId.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ShowAirsObjectJsonReader();

            var traktShowAirs = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().BeNull();
            traktShowAirs.Time.Should().BeNull();
            traktShowAirs.TimeZoneId.Should().Be("America/New_York");
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ShowAirsObjectJsonReader();

            var traktShowAirs = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().BeNull();
            traktShowAirs.Time.Should().Be("21:00");
            traktShowAirs.TimeZoneId.Should().Be("America/New_York");
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ShowAirsObjectJsonReader();

            var traktShowAirs = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().Be("Sunday");
            traktShowAirs.Time.Should().BeNull();
            traktShowAirs.TimeZoneId.Should().Be("America/New_York");
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ShowAirsObjectJsonReader();

            var traktShowAirs = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().Be("Sunday");
            traktShowAirs.Time.Should().Be("21:00");
            traktShowAirs.TimeZoneId.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ShowAirsObjectJsonReader();

            var traktShowAirs = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktShowAirs.Should().NotBeNull();
            traktShowAirs.Day.Should().BeNull();
            traktShowAirs.Time.Should().BeNull();
            traktShowAirs.TimeZoneId.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ShowAirsObjectJsonReader();

            var traktShowAirs = await jsonReader.ReadObjectAsync(default(string));
            traktShowAirs.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ShowAirsObjectJsonReader();

            var traktShowAirs = await jsonReader.ReadObjectAsync(string.Empty);
            traktShowAirs.Should().BeNull();
        }
    }
}
