namespace TraktNet.Objects.Get.Tests.Lists.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Get.Lists.Json.Writer;
    using TraktNet.Objects.Get.Users;
    using Xunit;

    [TestCategory("Objects.Get.Lists.JsonWriter")]
    public partial class ListObjectJsonWriter_Tests
    {
        private readonly DateTime CREATED_AT = DateTime.UtcNow;
        private readonly DateTime UPDATED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new ListObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_Name_Property()
        {
            ITraktList traktList = new TraktList
            {
                Name = "Star Wars in machete order"
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be(@"{""name"":""Star Wars in machete order""}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_Description_Property()
        {
            ITraktList traktList = new TraktList
            {
                Description = "Next time you want to introduce someone to Star Wars..."
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be(@"{""description"":""Next time you want to introduce someone to Star Wars...""}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_Privacy_Property()
        {
            ITraktList traktList = new TraktList
            {
                Privacy = TraktListPrivacy.Public
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be(@"{""privacy"":""public""}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_ShareLink_Property()
        {
            ITraktList traktList = new TraktList
            {
                ShareLink = "https://trakt.tv/lists/55"
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be(@"{""share_link"":""https://trakt.tv/lists/55""}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_Type_Property()
        {
            ITraktList traktList = new TraktList
            {
                Type = TraktListType.Personal
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be(@"{""type"":""personal""}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_DisplayNumbers_Property()
        {
            ITraktList traktList = new TraktList
            {
                DisplayNumbers = true
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be(@"{""display_numbers"":true}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_AllowComments_Property()
        {
            ITraktList traktList = new TraktList
            {
                AllowComments = false
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be(@"{""allow_comments"":false}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_SortBy_Property()
        {
            ITraktList traktList = new TraktList
            {
                SortBy = TraktSortBy.Rank
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be(@"{""sort_by"":""rank""}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_SortHow_Property()
        {
            ITraktList traktList = new TraktList
            {
                SortHow = TraktSortHow.Ascending
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be(@"{""sort_how"":""asc""}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_CreatedAt_Property()
        {
            ITraktList traktList = new TraktList
            {
                CreatedAt = CREATED_AT
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be($"{{\"created_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_UpdatedAt_Property()
        {
            ITraktList traktList = new TraktList
            {
                UpdatedAt = UPDATED_AT
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be($"{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_ItemCount_Property()
        {
            ITraktList traktList = new TraktList
            {
                ItemCount = 5
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be(@"{""item_count"":5}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_CommentCount_Property()
        {
            ITraktList traktList = new TraktList
            {
                CommentCount = 1
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be(@"{""comment_count"":1}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_Likes_Property()
        {
            ITraktList traktList = new TraktList
            {
                Likes = 2
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be(@"{""likes"":2}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_Ids_Property()
        {
            ITraktList traktList = new TraktList
            {
                Ids = new TraktListIds
                {
                    Trakt = 55,
                    Slug = "star-wars-in-machete-order"
                }
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be(@"{""ids"":{""trakt"":55,""slug"":""star-wars-in-machete-order""}}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Only_User_Property()
        {
            ITraktList traktList = new TraktList
            {
                User = new TraktUser
                {
                    Username = "sean",
                    IsPrivate = false,
                    Name = "Sean Rudford",
                    IsVIP = true,
                    IsVIP_EP = false,
                    Ids = new TraktUserIds
                    {
                        Slug = "sean"
                    }
                }
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be(@"{""user"":{""username"":""sean"",""private"":false," +
                             @"""ids"":{""slug"":""sean""},""name"":""Sean Rudford""," +
                             @"""vip"":true,""vip_ep"":false}}");
        }

        [Fact]
        public async Task Test_ListObjectJsonWriter_WriteObject_Complete()
        {
            ITraktList traktList = new TraktList
            {
                Name = "Star Wars in machete order",
                Description = "Next time you want to introduce someone to Star Wars...",
                Privacy = TraktListPrivacy.Public,
                ShareLink = "https://trakt.tv/lists/55",
                Type = TraktListType.Personal,
                DisplayNumbers = true,
                AllowComments = false,
                SortBy = TraktSortBy.Rank,
                SortHow = TraktSortHow.Ascending,
                CreatedAt = CREATED_AT,
                UpdatedAt = UPDATED_AT,
                ItemCount = 5,
                CommentCount = 1,
                Likes = 2,
                Ids = new TraktListIds
                {
                    Trakt = 55,
                    Slug = "star-wars-in-machete-order"
                },
                User = new TraktUser
                {
                    Username = "sean",
                    IsPrivate = false,
                    Name = "Sean Rudford",
                    IsVIP = true,
                    IsVIP_EP = false,
                    Ids = new TraktUserIds
                    {
                        Slug = "sean"
                    }
                }
            };

            var traktJsonWriter = new ListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktList);
            json.Should().Be(@"{""name"":""Star Wars in machete order""," +
                             @"""description"":""Next time you want to introduce someone to Star Wars...""," +
                             @"""privacy"":""public"",""share_link"":""https://trakt.tv/lists/55""," +
                             @"""type"":""personal"",""display_numbers"":true," +
                             @"""allow_comments"":false,""sort_by"":""rank"",""sort_how"":""asc""," +
                             $"\"created_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""item_count"":5,""comment_count"":1,""likes"":2," +
                             @"""ids"":{""trakt"":55,""slug"":""star-wars-in-machete-order""}," +
                             @"""user"":{""username"":""sean"",""private"":false," +
                             @"""ids"":{""slug"":""sean""},""name"":""Sean Rudford""," +
                             @"""vip"":true,""vip_ep"":false}}");
        }
    }
}
