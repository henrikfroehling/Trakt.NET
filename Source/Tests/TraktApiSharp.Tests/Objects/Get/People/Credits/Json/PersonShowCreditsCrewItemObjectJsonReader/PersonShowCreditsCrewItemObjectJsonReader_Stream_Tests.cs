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
    public partial class PersonShowCreditsCrewItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var showCreditsCrewItem = await jsonReader.ReadObjectAsync(stream);

                showCreditsCrewItem.Should().NotBeNull();
                showCreditsCrewItem.Job.Should().Be("Director");
                showCreditsCrewItem.Show.Should().NotBeNull();
                showCreditsCrewItem.Show.Title.Should().Be("Game of Thrones");
                showCreditsCrewItem.Show.Year.Should().Be(2011);
                showCreditsCrewItem.Show.Ids.Should().NotBeNull();
                showCreditsCrewItem.Show.Ids.Trakt.Should().Be(1390U);
                showCreditsCrewItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                showCreditsCrewItem.Show.Ids.Tvdb.Should().Be(121361U);
                showCreditsCrewItem.Show.Ids.Imdb.Should().Be("tt0944947");
                showCreditsCrewItem.Show.Ids.Tmdb.Should().Be(1399U);
                showCreditsCrewItem.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var showCreditsCrewItem = await jsonReader.ReadObjectAsync(stream);

                showCreditsCrewItem.Should().NotBeNull();
                showCreditsCrewItem.Job.Should().BeNull();
                showCreditsCrewItem.Show.Should().NotBeNull();
                showCreditsCrewItem.Show.Title.Should().Be("Game of Thrones");
                showCreditsCrewItem.Show.Year.Should().Be(2011);
                showCreditsCrewItem.Show.Ids.Should().NotBeNull();
                showCreditsCrewItem.Show.Ids.Trakt.Should().Be(1390U);
                showCreditsCrewItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                showCreditsCrewItem.Show.Ids.Tvdb.Should().Be(121361U);
                showCreditsCrewItem.Show.Ids.Imdb.Should().Be("tt0944947");
                showCreditsCrewItem.Show.Ids.Tmdb.Should().Be(1399U);
                showCreditsCrewItem.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var showCreditsCrewItem = await jsonReader.ReadObjectAsync(stream);

                showCreditsCrewItem.Should().NotBeNull();
                showCreditsCrewItem.Job.Should().Be("Director");
                showCreditsCrewItem.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var showCreditsCrewItem = await jsonReader.ReadObjectAsync(stream);

                showCreditsCrewItem.Should().NotBeNull();
                showCreditsCrewItem.Job.Should().BeNull();
                showCreditsCrewItem.Show.Should().NotBeNull();
                showCreditsCrewItem.Show.Title.Should().Be("Game of Thrones");
                showCreditsCrewItem.Show.Year.Should().Be(2011);
                showCreditsCrewItem.Show.Ids.Should().NotBeNull();
                showCreditsCrewItem.Show.Ids.Trakt.Should().Be(1390U);
                showCreditsCrewItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                showCreditsCrewItem.Show.Ids.Tvdb.Should().Be(121361U);
                showCreditsCrewItem.Show.Ids.Imdb.Should().Be("tt0944947");
                showCreditsCrewItem.Show.Ids.Tmdb.Should().Be(1399U);
                showCreditsCrewItem.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var showCreditsCrewItem = await jsonReader.ReadObjectAsync(stream);

                showCreditsCrewItem.Should().NotBeNull();
                showCreditsCrewItem.Job.Should().Be("Director");
                showCreditsCrewItem.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var showCreditsCrewItem = await jsonReader.ReadObjectAsync(stream);

                showCreditsCrewItem.Should().NotBeNull();
                showCreditsCrewItem.Job.Should().BeNull();
                showCreditsCrewItem.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            var showCreditsCrewItem = await jsonReader.ReadObjectAsync(default(Stream));
            showCreditsCrewItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var showCreditsCrewItem = await jsonReader.ReadObjectAsync(stream);
                showCreditsCrewItem.Should().BeNull();
            }
        }
    }
}
