namespace TraktApiSharp.Tests.Objects.Get.Shows.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ShowAirsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().BeNull();
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().BeNull();
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().BeNull();
                traktShowAirs.TimeZoneId.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().BeNull();
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().BeNull();
                traktShowAirs.Time.Should().BeNull();
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().BeNull();
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().BeNull();
                traktShowAirs.TimeZoneId.Should().Be("America/New_York");
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().Be("Sunday");
                traktShowAirs.Time.Should().Be("21:00");
                traktShowAirs.TimeZoneId.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAirs.Should().NotBeNull();
                traktShowAirs.Day.Should().BeNull();
                traktShowAirs.Time.Should().BeNull();
                traktShowAirs.TimeZoneId.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            var traktShowAirs = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktShowAirs.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowAirsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new ShowAirsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktShowAirs = await traktJsonReader.ReadObjectAsync(stream);
                traktShowAirs.Should().BeNull();
            }
        }
    }
}
