namespace TraktNet.Objects.Tests.Get.Movies.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class MovieReleaseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            var traktMovieRelease = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktMovieRelease.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieReleaseObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new MovieReleaseObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktMovieRelease = await traktJsonReader.ReadObjectAsync(stream);
                traktMovieRelease.Should().BeNull();
            }
        }
    }
}
