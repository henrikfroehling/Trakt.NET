namespace TraktNET.Json
{
    public sealed class TMDBImageTests
    {
        [Fact]
        public void TestTMDBImageConstructor()
        {
            var image = new TMDBImage();

            image.FilePath.ShouldBeNull();
            image.Width.ShouldBeNull();
            image.Height.ShouldBeNull();
            image.AspectRatio.ShouldBeNull();
            image.VoteCount.ShouldBeNull();
            image.VoteAverage.ShouldBeNull();
            image.ISO6391.ShouldBeNull();
        }

        [Fact]
        public async Task TestTMDBImageFromJson()
        {
            TMDBImage? image = await TMDBTestUtility.DeserializeJsonAsync<TMDBImage>("image.json");

            image.ShouldNotBeNull();

            image!.FilePath.ShouldBe("/ueDw7djPgKPZfph0vC43aD2EMyF.jpg");
            image!.Width.ShouldBe(3840U);
            image!.Height.ShouldBe(2160U);
            image!.AspectRatio.ShouldBe(1.778f);
            image!.VoteCount.ShouldBe(13U);
            image!.VoteAverage.ShouldBe(6.346f);
            image!.ISO6391.ShouldBe("en");
        }
    }
}
