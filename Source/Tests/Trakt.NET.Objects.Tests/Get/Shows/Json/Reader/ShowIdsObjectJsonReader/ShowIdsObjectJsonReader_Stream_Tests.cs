namespace TraktNet.Objects.Tests.Get.Shows.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ShowIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktShowIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(stream);
                traktShowIds.Should().BeNull();
            }
        }
    }
}
