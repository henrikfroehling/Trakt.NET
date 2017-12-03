namespace TraktApiSharp.Tests.Objects.Get.Movies.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class MovieReleaseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().BeNull();
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().BeNull();
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().BeNull();
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().BeNull();
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().BeNull();
            traktMovieRelease.ReleaseDate.Should().BeNull();
            traktMovieRelease.ReleaseType.Should().BeNull();
            traktMovieRelease.Note.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().BeNull();
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().BeNull();
            traktMovieRelease.ReleaseType.Should().BeNull();
            traktMovieRelease.Note.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().BeNull();
            traktMovieRelease.Certification.Should().BeNull();
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().BeNull();
            traktMovieRelease.Note.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().BeNull();
            traktMovieRelease.Certification.Should().BeNull();
            traktMovieRelease.ReleaseDate.Should().BeNull();
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().BeNull();
            traktMovieRelease.Certification.Should().BeNull();
            traktMovieRelease.ReleaseDate.Should().BeNull();
            traktMovieRelease.ReleaseType.Should().BeNull();
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().BeNull();
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().BeNull();
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().BeNull();
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().BeNull();
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().BeNull();
            traktMovieRelease.Certification.Should().BeNull();
            traktMovieRelease.ReleaseDate.Should().BeNull();
            traktMovieRelease.ReleaseType.Should().BeNull();
            traktMovieRelease.Note.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(default(string));
            traktMovieRelease.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await jsonReader.ReadObjectAsync(string.Empty);
            traktMovieRelease.Should().BeNull();
        }
    }
}
