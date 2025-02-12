namespace TraktNET.Json.Certifications
{
    public sealed class TraktCertificationTests
    {
        [Fact]
        public void TestTraktCertificationConstructor()
        {
            var certification = new TraktCertification();

            certification.Name.ShouldBeNull();
            certification.Slug.ShouldBeNull();
            certification.Description.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktCertificationFromJson()
        {
            TraktCertification? certification = await TraktTestUtility.DeserializeJsonAsync<TraktCertification>("Certifications\\certification.json");

            certification.ShouldNotBeNull();

            certification!.Name.ShouldBe("G");
            certification!.Slug.ShouldBe("g");
            certification!.Description.ShouldBe("All Ages");
        }
    }
}
