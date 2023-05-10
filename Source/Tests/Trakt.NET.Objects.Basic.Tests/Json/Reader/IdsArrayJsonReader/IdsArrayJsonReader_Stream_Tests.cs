namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class IdsArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktIds>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IList<ITraktIds> multipleTraktIds = await jsonReader.ReadArrayAsync(stream);
                multipleTraktIds.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktIds>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IList<ITraktIds> multipleTraktIds = await jsonReader.ReadArrayAsync(stream);

                multipleTraktIds.Should().NotBeNull();
                ITraktIds[] ids = multipleTraktIds.ToArray();

                ids[0].Should().NotBeNull();
                ids[0].Trakt.Should().Be(1390);
                ids[0].Slug.Should().Be("game-of-thrones");
                ids[0].Tvdb.Should().Be(121361U);
                ids[0].Imdb.Should().Be("tt0944947");
                ids[0].Tmdb.Should().Be(1399U);
                ids[0].TvRage.Should().Be(24493U);

                ids[1].Should().NotBeNull();
                ids[1].Trakt.Should().Be(1390);
                ids[1].Slug.Should().Be("game-of-thrones");
                ids[1].Tvdb.Should().Be(121361U);
                ids[1].Imdb.Should().Be("tt0944947");
                ids[1].Tmdb.Should().Be(1399U);
                ids[1].TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktIds>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IList<ITraktIds> multipleTraktIds = await jsonReader.ReadArrayAsync(stream);

                multipleTraktIds.Should().NotBeNull();
                ITraktIds[] ids = multipleTraktIds.ToArray();

                ids[0].Should().NotBeNull();
                ids[0].Trakt.Should().Be(1390);
                ids[0].Slug.Should().Be("game-of-thrones");
                ids[0].Tvdb.Should().Be(121361U);
                ids[0].Imdb.Should().Be("tt0944947");
                ids[0].Tmdb.Should().Be(1399U);
                ids[0].TvRage.Should().Be(24493U);

                ids[1].Should().NotBeNull();
                ids[1].Trakt.Should().Be(0);
                ids[1].Slug.Should().Be("game-of-thrones");
                ids[1].Tvdb.Should().Be(121361U);
                ids[1].Imdb.Should().Be("tt0944947");
                ids[1].Tmdb.Should().Be(1399U);
                ids[1].TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktIds>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IList<ITraktIds> multipleTraktIds = await jsonReader.ReadArrayAsync(stream);

                multipleTraktIds.Should().NotBeNull();
                ITraktIds[] ids = multipleTraktIds.ToArray();

                ids[0].Should().NotBeNull();
                ids[0].Trakt.Should().Be(0);
                ids[0].Slug.Should().Be("game-of-thrones");
                ids[0].Tvdb.Should().Be(121361U);
                ids[0].Imdb.Should().Be("tt0944947");
                ids[0].Tmdb.Should().Be(1399U);
                ids[0].TvRage.Should().Be(24493U);

                ids[1].Should().NotBeNull();
                ids[1].Trakt.Should().Be(1390);
                ids[1].Slug.Should().Be("game-of-thrones");
                ids[1].Tvdb.Should().Be(121361U);
                ids[1].Imdb.Should().Be("tt0944947");
                ids[1].Tmdb.Should().Be(1399U);
                ids[1].TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktIds>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IList<ITraktIds> multipleTraktIds = await jsonReader.ReadArrayAsync(stream);

                multipleTraktIds.Should().NotBeNull();
                ITraktIds[] ids = multipleTraktIds.ToArray();

                ids[0].Should().NotBeNull();
                ids[0].Trakt.Should().Be(0);
                ids[0].Slug.Should().Be("game-of-thrones");
                ids[0].Tvdb.Should().Be(121361U);
                ids[0].Imdb.Should().Be("tt0944947");
                ids[0].Tmdb.Should().Be(1399U);
                ids[0].TvRage.Should().Be(24493U);

                ids[1].Should().NotBeNull();
                ids[1].Trakt.Should().Be(1390);
                ids[1].Slug.Should().Be("game-of-thrones");
                ids[1].Tvdb.Should().Be(121361U);
                ids[1].Imdb.Should().Be("tt0944947");
                ids[1].Tmdb.Should().Be(1399U);
                ids[1].TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktIds>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IList<ITraktIds> multipleTraktIds = await jsonReader.ReadArrayAsync(stream);

                multipleTraktIds.Should().NotBeNull();
                ITraktIds[] ids = multipleTraktIds.ToArray();

                ids[0].Should().NotBeNull();
                ids[0].Trakt.Should().Be(1390);
                ids[0].Slug.Should().Be("game-of-thrones");
                ids[0].Tvdb.Should().Be(121361U);
                ids[0].Imdb.Should().Be("tt0944947");
                ids[0].Tmdb.Should().Be(1399U);
                ids[0].TvRage.Should().Be(24493U);

                ids[1].Should().NotBeNull();
                ids[1].Trakt.Should().Be(0);
                ids[1].Slug.Should().Be("game-of-thrones");
                ids[1].Tvdb.Should().Be(121361U);
                ids[1].Imdb.Should().Be("tt0944947");
                ids[1].Tmdb.Should().Be(1399U);
                ids[1].TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktIds>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IList<ITraktIds> multipleTraktIds = await jsonReader.ReadArrayAsync(stream);

                multipleTraktIds.Should().NotBeNull();
                ITraktIds[] ids = multipleTraktIds.ToArray();

                ids[0].Should().NotBeNull();
                ids[0].Trakt.Should().Be(0);
                ids[0].Slug.Should().Be("game-of-thrones");
                ids[0].Tvdb.Should().Be(121361U);
                ids[0].Imdb.Should().Be("tt0944947");
                ids[0].Tmdb.Should().Be(1399U);
                ids[0].TvRage.Should().Be(24493U);

                ids[1].Should().NotBeNull();
                ids[1].Trakt.Should().Be(0);
                ids[1].Slug.Should().Be("game-of-thrones");
                ids[1].Tvdb.Should().Be(121361U);
                ids[1].Imdb.Should().Be("tt0944947");
                ids[1].Tmdb.Should().Be(1399U);
                ids[1].TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktIds>();
            Func<Task<IList<ITraktIds>>> multipleTraktIds = () => jsonReader.ReadArrayAsync(default(Stream));
            await multipleTraktIds.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktIds>();

            using (var stream = string.Empty.ToStream())
            {
                IList<ITraktIds> multipleTraktIds = await jsonReader.ReadArrayAsync(stream);
                multipleTraktIds.Should().BeNull();
            }
        }
    }
}
