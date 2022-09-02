namespace TraktNet.Objects.Get.Tests.Lists.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Get.Lists.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Lists.Implementations")]
    public class TraktList_Tests
    {
        [Fact]
        public void Test_TraktList_Default_Constructor()
        {
            var list = new TraktList();

            list.Should().NotBeNull();
            list.Name.Should().BeNull();
            list.Description.Should().BeNull();
            list.Privacy.Should().BeNull();
            list.DisplayNumbers.Should().BeNull();
            list.AllowComments.Should().BeNull();
            list.SortBy.Should().BeNull();
            list.SortHow.Should().BeNull();
            list.CreatedAt.Should().BeNull();
            list.UpdatedAt.Should().BeNull();
            list.ItemCount.Should().BeNull();
            list.CommentCount.Should().BeNull();
            list.Likes.Should().BeNull();
            list.Ids.Should().BeNull();
            list.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktList_From_Json()
        {
            var jsonReader = new ListObjectJsonReader();
            var list = await jsonReader.ReadObjectAsync(JSON) as TraktList;

            list.Should().NotBeNull();
            list.Name.Should().Be("Star Wars in machete order");
            list.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            list.Privacy.Should().Be(TraktAccessScope.Public);
            list.DisplayNumbers.Should().BeTrue();
            list.AllowComments.Should().BeFalse();
            list.SortBy.Should().Be("rank");
            list.SortHow.Should().Be("asc");
            list.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            list.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            list.ItemCount.Should().Be(5);
            list.CommentCount.Should().Be(1);
            list.Likes.Should().Be(2);

            list.Ids.Should().NotBeNull();
            list.Ids.Trakt.Should().Be(55);
            list.Ids.Slug.Should().Be("star-wars-in-machete-order");

            list.User.Should().NotBeNull();
            list.User.Username.Should().Be("sean");
            list.User.IsPrivate.Should().BeFalse();
            list.User.Name.Should().Be("Sean Rudford");
            list.User.IsVIP.Should().BeTrue();
            list.User.IsVIP_EP.Should().BeFalse();
            list.User.Ids.Should().NotBeNull();
            list.User.Ids.Slug.Should().Be("sean");
        }

        private const string JSON =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""privacy"": ""public"",
                ""display_numbers"": true,
                ""allow_comments"": false,
                ""sort_by"": ""rank"",
                ""sort_how"": ""asc"",
                ""created_at"": ""2014-10-11T17:00:54.000Z"",
                ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                ""item_count"": 5,
                ""comment_count"": 1,
                ""likes"": 2,
                ""ids"": {
                  ""trakt"": 55,
                  ""slug"": ""star-wars-in-machete-order""
                },
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": false,
                  ""ids"": {
                    ""slug"": ""sean""
                  }
                }
              }";
    }
}
