﻿namespace TraktNet.Objects.Get.Tests.People.Credits.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonShowCreditsCrewItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrewItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrewItem.Should().NotBeNull();
                showCreditsCrewItem.Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
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
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrewItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrewItem.Should().NotBeNull();
                showCreditsCrewItem.Jobs.Should().BeNull();
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
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrewItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrewItem.Should().NotBeNull();
                showCreditsCrewItem.Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
                showCreditsCrewItem.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrewItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrewItem.Should().NotBeNull();
                showCreditsCrewItem.Jobs.Should().BeNull();
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
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrewItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrewItem.Should().NotBeNull();
                showCreditsCrewItem.Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
                showCreditsCrewItem.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrewItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrewItem.Should().NotBeNull();
                showCreditsCrewItem.Jobs.Should().BeNull();
                showCreditsCrewItem.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemObjectJsonReader();
            Func<Task<ITraktPersonShowCreditsCrewItem>> showCreditsCrewItem = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await showCreditsCrewItem.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrewItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                showCreditsCrewItem.Should().BeNull();
            }
        }
    }
}
