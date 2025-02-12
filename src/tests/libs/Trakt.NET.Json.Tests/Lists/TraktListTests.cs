namespace TraktNET.Json.Lists
{
    public sealed class TraktListTests
    {
        [Fact]
        public void TestTraktListConstructor()
        {
            var list = new TraktList();

            list.Name.ShouldBeNull();
            list.Description.ShouldBeNull();
            list.Privacy.ShouldBeNull();
            list.ShareLink.ShouldBeNull();
            list.Type.ShouldBeNull();
            list.DisplayNumbers.ShouldBeNull();
            list.AllowComments.ShouldBeNull();
            list.SortBy.ShouldBeNull();
            list.SortHow.ShouldBeNull();
            list.CreatedAt.ShouldBeNull();
            list.UpdatedAt.ShouldBeNull();
            list.ItemCount.ShouldBeNull();
            list.CommentCount.ShouldBeNull();
            list.Likes.ShouldBeNull();
            list.IDs.ShouldBeNull();
            list.User.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktListFromJson()
        {
            TraktList? list = await TraktTestUtility.DeserializeJsonAsync<TraktList>("Lists\\list.json");

            list.ShouldNotBeNull();

            list!.Name.ShouldBe("MARVEL Cinematic Universe");
            list!.Description.ShouldBe("MCU Shows and Movies in chronological order.");
            list!.Privacy.ShouldBe(TraktListPrivacy.Public);
            list!.ShareLink.ShouldBe("https://trakt.tv/lists/1248149");
            list!.Type.ShouldBe(TraktListType.Personal);
            list!.DisplayNumbers.ShouldBe(true);
            list!.AllowComments.ShouldBe(true);
            list!.SortBy.ShouldBe(TraktSortBy.Rank);
            list!.SortHow.ShouldBe(TraktSortHow.Ascending);
            list!.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-07-16T14:59:57.000Z"));
            list!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-10-04T06:47:38.000Z"));
            list!.ItemCount.ShouldBe(218U);
            list!.CommentCount.ShouldBe(33U);
            list!.Likes.ShouldBe(4668U);

            list!.IDs.ShouldNotBeNull();
            list!.IDs!.Trakt.ShouldBe(1248149U);
            list!.IDs!.Slug.ShouldBe("marvel-cinematic-universe");
            list!.IDs!.HasAnyID.ShouldBe(true);
            list!.IDs!.BestID.ShouldBe("marvel-cinematic-universe");

            list!.User.ShouldNotBeNull();
            list!.User!.Username.ShouldBe("Donxy");
            list!.User!.Name.ShouldBe("Donxy");
            list!.User!.Private.ShouldBe(false);
            list!.User!.VIP.ShouldBe(false);
            list!.User!.VIPEP.ShouldBe(true);
            list!.User!.IDs.ShouldNotBeNull();
            list!.User!.IDs!.Slug.ShouldBe("donxy");
        }
    }
}
