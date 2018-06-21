namespace TraktNet.Tests.Objects.Get.People.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Objects.Get.People.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.JsonReader")]
    public partial class PersonIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktPersonIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);
                traktPersonIds.Should().BeNull();
            }
        }
    }
}
