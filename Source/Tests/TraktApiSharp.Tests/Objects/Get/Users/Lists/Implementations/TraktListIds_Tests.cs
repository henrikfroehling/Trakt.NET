namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Get.Users.Lists.Implementations;
    using TraktApiSharp.Objects.Get.Users.Lists.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.Implementations")]
    public class TraktListIds_Tests
    {
        [Fact]
        public void Test_TraktListIds_Implements_ITraktListIds_Interface()
        {
            typeof(TraktListIds).GetInterfaces().Should().Contain(typeof(ITraktListIds));
        }

        [Fact]
        public void Test_TraktListIds_Default_Constructor()
        {
            var listIds = new TraktListIds();

            listIds.Trakt.Should().Be(0);
            listIds.Slug.Should().BeNull();
            listIds.HasAnyId.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktListIds_HasAnyId()
        {
            var listIds = new TraktListIds { Trakt = 1 };
            listIds.HasAnyId.Should().BeTrue();

            listIds = new TraktListIds { Slug = "slug" };
            listIds.HasAnyId.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktListIds_GetBestId()
        {
            var listIds = new TraktListIds();

            var bestId = listIds.GetBestId();
            bestId.Should().NotBeNull().And.BeEmpty();

            listIds = new TraktListIds { Trakt = 1 };

            bestId = listIds.GetBestId();
            bestId.Should().Be("1");

            listIds = new TraktListIds { Slug = "slug" };

            bestId = listIds.GetBestId();
            bestId.Should().Be("slug");

            listIds = new TraktListIds
            {
                Trakt = 1,
                Slug = "slug"
            };

            bestId = listIds.GetBestId();
            bestId.Should().Be("1");

            new TraktListIds().GetBestId().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_TraktListIds_From_Json()
        {
            var jsonReader = new ListIdsObjectJsonReader();
            var listIds = await jsonReader.ReadObjectAsync(JSON) as TraktListIds;

            listIds.Should().NotBeNull();
            listIds.Trakt.Should().Be(55);
            listIds.Slug.Should().Be("star-wars-in-machete-order");
            listIds.HasAnyId.Should().BeTrue();
            listIds.GetBestId().Should().Be("55");
        }

        private const string JSON =
            @"{
                ""trakt"": 55,
                ""slug"": ""star-wars-in-machete-order""
              }";
    }
}
