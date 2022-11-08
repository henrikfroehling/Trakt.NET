namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class IdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(1390);
                traktIds.Slug.Should().Be("game-of-thrones");
                traktIds.Tvdb.Should().Be(121361U);
                traktIds.Imdb.Should().Be("tt0944947");
                traktIds.Tmdb.Should().Be(1399U);
                traktIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(0);
                traktIds.Slug.Should().Be("game-of-thrones");
                traktIds.Tvdb.Should().Be(121361U);
                traktIds.Imdb.Should().Be("tt0944947");
                traktIds.Tmdb.Should().Be(1399U);
                traktIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(1390);
                traktIds.Slug.Should().BeNull();
                traktIds.Tvdb.Should().Be(121361U);
                traktIds.Imdb.Should().Be("tt0944947");
                traktIds.Tmdb.Should().Be(1399U);
                traktIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(1390);
                traktIds.Slug.Should().Be("game-of-thrones");
                traktIds.Tvdb.Should().BeNull();
                traktIds.Imdb.Should().Be("tt0944947");
                traktIds.Tmdb.Should().Be(1399U);
                traktIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(1390);
                traktIds.Slug.Should().Be("game-of-thrones");
                traktIds.Tvdb.Should().Be(121361U);
                traktIds.Imdb.Should().BeNull();
                traktIds.Tmdb.Should().Be(1399U);
                traktIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(1390);
                traktIds.Slug.Should().Be("game-of-thrones");
                traktIds.Tvdb.Should().Be(121361U);
                traktIds.Imdb.Should().Be("tt0944947");
                traktIds.Tmdb.Should().BeNull();
                traktIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(1390);
                traktIds.Slug.Should().Be("game-of-thrones");
                traktIds.Tvdb.Should().Be(121361U);
                traktIds.Imdb.Should().Be("tt0944947");
                traktIds.Tmdb.Should().Be(1399U);
                traktIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(1390);
                traktIds.Slug.Should().BeNull();
                traktIds.Tvdb.Should().BeNull();
                traktIds.Imdb.Should().BeNull();
                traktIds.Tmdb.Should().BeNull();
                traktIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(0);
                traktIds.Slug.Should().Be("game-of-thrones");
                traktIds.Tvdb.Should().BeNull();
                traktIds.Imdb.Should().BeNull();
                traktIds.Tmdb.Should().BeNull();
                traktIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(0);
                traktIds.Slug.Should().BeNull();
                traktIds.Tvdb.Should().Be(121361U);
                traktIds.Imdb.Should().BeNull();
                traktIds.Tmdb.Should().BeNull();
                traktIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(0);
                traktIds.Slug.Should().BeNull();
                traktIds.Tvdb.Should().BeNull();
                traktIds.Imdb.Should().Be("tt0944947");
                traktIds.Tmdb.Should().BeNull();
                traktIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(0);
                traktIds.Slug.Should().BeNull();
                traktIds.Tvdb.Should().BeNull();
                traktIds.Imdb.Should().BeNull();
                traktIds.Tmdb.Should().Be(1399U);
                traktIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(0);
                traktIds.Slug.Should().BeNull();
                traktIds.Tvdb.Should().BeNull();
                traktIds.Imdb.Should().BeNull();
                traktIds.Tmdb.Should().BeNull();
                traktIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(0);
                traktIds.Slug.Should().Be("game-of-thrones");
                traktIds.Tvdb.Should().Be(121361U);
                traktIds.Imdb.Should().Be("tt0944947");
                traktIds.Tmdb.Should().Be(1399U);
                traktIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(1390);
                traktIds.Slug.Should().BeNull();
                traktIds.Tvdb.Should().Be(121361U);
                traktIds.Imdb.Should().Be("tt0944947");
                traktIds.Tmdb.Should().Be(1399U);
                traktIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(1390);
                traktIds.Slug.Should().Be("game-of-thrones");
                traktIds.Tvdb.Should().BeNull();
                traktIds.Imdb.Should().Be("tt0944947");
                traktIds.Tmdb.Should().Be(1399U);
                traktIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(1390);
                traktIds.Slug.Should().Be("game-of-thrones");
                traktIds.Tvdb.Should().Be(121361U);
                traktIds.Imdb.Should().BeNull();
                traktIds.Tmdb.Should().Be(1399U);
                traktIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(1390);
                traktIds.Slug.Should().Be("game-of-thrones");
                traktIds.Tvdb.Should().Be(121361U);
                traktIds.Imdb.Should().Be("tt0944947");
                traktIds.Tmdb.Should().BeNull();
                traktIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(1390);
                traktIds.Slug.Should().Be("game-of-thrones");
                traktIds.Tvdb.Should().Be(121361U);
                traktIds.Imdb.Should().Be("tt0944947");
                traktIds.Tmdb.Should().Be(1399U);
                traktIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);

                traktIds.Should().NotBeNull();
                traktIds.Trakt.Should().Be(0);
                traktIds.Slug.Should().BeNull();
                traktIds.Tvdb.Should().BeNull();
                traktIds.Imdb.Should().BeNull();
                traktIds.Tmdb.Should().BeNull();
                traktIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new IdsObjectJsonReader();
            Func<Task<ITraktIds>> traktIds = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await traktIds.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new IdsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktIds = await traktJsonReader.ReadObjectAsync(stream);
                traktIds.Should().BeNull();
            }
        }
    }
}
