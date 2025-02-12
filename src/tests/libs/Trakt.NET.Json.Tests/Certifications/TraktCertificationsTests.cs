namespace TraktNET.Json.Certifications
{
    public sealed class TraktCertificationsTests
    {
        [Fact]
        public void TestTraktCertificationsConstructor()
        {
            var certifications = new TraktCertifications();

            certifications.US.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktCertificationsFromJson()
        {
            TraktCertifications? certifications = await TraktTestUtility.DeserializeJsonAsync<TraktCertifications>("Certifications\\certifications.json");

            certifications.ShouldNotBeNull();

            certifications!.US.ShouldNotBeNull();
            certifications!.US!.Count.ShouldBe(2);

            TraktCertification certification = certifications!.US![0];

            certification.ShouldNotBeNull();
            certification.Name.ShouldBe("G");
            certification.Slug.ShouldBe("g");
            certification.Description.ShouldBe("All Ages");

            certification = certifications!.US![1];

            certification.ShouldNotBeNull();
            certification.Name.ShouldBe("PG");
            certification.Slug.ShouldBe("pg");
            certification.Description.ShouldBe("Parental Guidance Suggested");
        }
    }
}
