namespace TraktApiSharp.Tests.Objects.Get.People.Credits.Json
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits.Json;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonShowCreditsCastItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var showCreditsCastItem = await jsonReader.ReadObjectAsync(stream);

                showCreditsCastItem.Should().NotBeNull();
                showCreditsCastItem.Character.Should().Be("Joe Brody");
                showCreditsCastItem.Show.Should().NotBeNull();
                showCreditsCastItem.Show.Title.Should().Be("Game of Thrones");
                showCreditsCastItem.Show.Year.Should().Be(2011);
                showCreditsCastItem.Show.Ids.Should().NotBeNull();
                showCreditsCastItem.Show.Ids.Trakt.Should().Be(1390U);
                showCreditsCastItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                showCreditsCastItem.Show.Ids.Tvdb.Should().Be(121361U);
                showCreditsCastItem.Show.Ids.Imdb.Should().Be("tt0944947");
                showCreditsCastItem.Show.Ids.Tmdb.Should().Be(1399U);
                showCreditsCastItem.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var showCreditsCastItem = await jsonReader.ReadObjectAsync(stream);

                showCreditsCastItem.Should().NotBeNull();
                showCreditsCastItem.Character.Should().BeNull();
                showCreditsCastItem.Show.Should().NotBeNull();
                showCreditsCastItem.Show.Title.Should().Be("Game of Thrones");
                showCreditsCastItem.Show.Year.Should().Be(2011);
                showCreditsCastItem.Show.Ids.Should().NotBeNull();
                showCreditsCastItem.Show.Ids.Trakt.Should().Be(1390U);
                showCreditsCastItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                showCreditsCastItem.Show.Ids.Tvdb.Should().Be(121361U);
                showCreditsCastItem.Show.Ids.Imdb.Should().Be("tt0944947");
                showCreditsCastItem.Show.Ids.Tmdb.Should().Be(1399U);
                showCreditsCastItem.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var showCreditsCastItem = await jsonReader.ReadObjectAsync(stream);

                showCreditsCastItem.Should().NotBeNull();
                showCreditsCastItem.Character.Should().Be("Joe Brody");
                showCreditsCastItem.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var showCreditsCastItem = await jsonReader.ReadObjectAsync(stream);

                showCreditsCastItem.Should().NotBeNull();
                showCreditsCastItem.Character.Should().BeNull();
                showCreditsCastItem.Show.Should().NotBeNull();
                showCreditsCastItem.Show.Title.Should().Be("Game of Thrones");
                showCreditsCastItem.Show.Year.Should().Be(2011);
                showCreditsCastItem.Show.Ids.Should().NotBeNull();
                showCreditsCastItem.Show.Ids.Trakt.Should().Be(1390U);
                showCreditsCastItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                showCreditsCastItem.Show.Ids.Tvdb.Should().Be(121361U);
                showCreditsCastItem.Show.Ids.Imdb.Should().Be("tt0944947");
                showCreditsCastItem.Show.Ids.Tmdb.Should().Be(1399U);
                showCreditsCastItem.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var showCreditsCastItem = await jsonReader.ReadObjectAsync(stream);

                showCreditsCastItem.Should().NotBeNull();
                showCreditsCastItem.Character.Should().Be("Joe Brody");
                showCreditsCastItem.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var showCreditsCastItem = await jsonReader.ReadObjectAsync(stream);

                showCreditsCastItem.Should().NotBeNull();
                showCreditsCastItem.Character.Should().BeNull();
                showCreditsCastItem.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            var showCreditsCastItem = await jsonReader.ReadObjectAsync(default(Stream));
            showCreditsCastItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var showCreditsCastItem = await jsonReader.ReadObjectAsync(stream);
                showCreditsCastItem.Should().BeNull();
            }
        }
    }
}
