namespace TraktNET.Json
{
    public sealed class TMDBPersonImagesTests
    {
        [Fact]
        public void TestTMDBPersonImagesConstructor()
        {
            var personImages = new TMDBPersonImages();

            personImages.Id.ShouldBeNull();
            personImages.Profiles.ShouldBeNull();
        }

        [Fact]
        public async Task TestTMDBPersonImagesFromJson()
        {
            TMDBPersonImages? personImages = await TMDBTestUtility.DeserializeJsonAsync<TMDBPersonImages>("personimages.json");

            personImages.ShouldNotBeNull();

            personImages!.Id.ShouldBe(3U);
            personImages!.Profiles.ShouldNotBeNull();
            personImages!.Profiles!.Count.ShouldBe(2);

            personImages!.Profiles[0].ShouldNotBeNull();

            personImages!.Profiles[0]!.FilePath.ShouldBe("/zVnHagUvXkR2StdOtquEwsiwSVt.jpg");
            personImages!.Profiles[0]!.Width.ShouldBe(559U);
            personImages!.Profiles[0]!.Height.ShouldBe(838U);
            personImages!.Profiles[0]!.AspectRatio.ShouldBe(0.667f);
            personImages!.Profiles[0]!.VoteCount.ShouldBe(15U);
            personImages!.Profiles[0]!.VoteAverage.ShouldBe(6.2f);
            personImages!.Profiles[0]!.ISO6391.ShouldBeNull();

            personImages!.Profiles[1].ShouldNotBeNull();

            personImages!.Profiles[1]!.FilePath.ShouldBe("/n4dwIg6NbQzeMaS1yEKKlfNJH7a.jpg");
            personImages!.Profiles[1]!.Width.ShouldBe(1282U);
            personImages!.Profiles[1]!.Height.ShouldBe(1923U);
            personImages!.Profiles[1]!.AspectRatio.ShouldBe(0.667f);
            personImages!.Profiles[1]!.VoteCount.ShouldBe(15U);
            personImages!.Profiles[1]!.VoteAverage.ShouldBe(5.566f);
            personImages!.Profiles[1]!.ISO6391.ShouldBeNull();
        }
    }
}
