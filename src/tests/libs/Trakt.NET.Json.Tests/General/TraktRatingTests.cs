namespace TraktNET.Json.General
{
    public sealed class TraktRatingTests
    {
        [Fact]
        public void TestTraktRatingConstructor()
        {
            var rating = new TraktRating();

            rating.Rating.ShouldBeNull();
            rating.Votes.ShouldBeNull();
            rating.Distribution.ShouldBeNull();
            rating.ToString().ShouldBe("Empty");
        }

        [Fact]
        public async Task TestTraktRatingFromJson()
        {
            TraktRating? rating = await TraktTestUtility.DeserializeJsonAsync<TraktRating>("General\\rating.json");

            rating.ShouldNotBeNull();

            rating!.Rating.ShouldBe(7.96017f);
            rating!.Votes.ShouldBe(18906U);
            rating!.Distribution.ShouldNotBeNull();
            rating!.Distribution!.Count.ShouldBe(10);

            rating!.Distribution!.ShouldBe(new Dictionary<string, uint>
            {
                { "1", 91 },
                { "2", 55 },
                { "3", 66 },
                { "4", 142 },
                { "5", 421 },
                { "6", 1598 },
                { "7", 3699 },
                { "8", 6286 },
                { "9", 3805 },
                { "10", 2734 }
            });

            rating!.ToString().ShouldBe("7.96017, 18906");
        }
    }
}
