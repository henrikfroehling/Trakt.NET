namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class MovieReleaseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktMovieRelease.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktMovieRelease.Should().BeNull();
            }
        }
    }
}
