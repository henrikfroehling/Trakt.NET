namespace TraktNET.Json.Persons
{
    public sealed class TraktPersonImagesTests
    {
        [Fact]
        public void TestTraktPersonImagesConstructor()
        {
            var personImages = new TraktPersonImages();

            personImages.Headshot.ShouldBeNull();
            personImages.Fanart.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPersonImagesFromJson()
        {
            TraktPersonImages? personImages = await TestUtility.DeserializeJsonAsync<TraktPersonImages>("People\\personimages.json");

            personImages.ShouldNotBeNull();

            personImages!.Headshot.ShouldNotBeNull();
            personImages!.Headshot!.Count.ShouldBe(1);
            personImages!.Headshot!.ShouldBe([ "walter-r2.trakt.tv/images/people/000/297/737/headshots/thumb/ef96a1e565.jpg.webp" ]);

            personImages!.Fanart.ShouldNotBeNull();
            personImages!.Fanart!.Count.ShouldBe(1);
            personImages!.Fanart!.ShouldBe([ "walter-r2.trakt.tv/images/people/000/297/737/fanarts/medium/ec609f5bcc.jpg.webp" ]);
        }
    }
}
