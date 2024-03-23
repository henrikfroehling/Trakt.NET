namespace TraktNET.Json.People
{
    public sealed class TraktPersonTests
    {
        [Fact]
        public void TestTraktPersonConstructor()
        {
            var person = new TraktPerson();

            person.Name.Should().BeNull();
            person.Ids.Should().BeNull();
            person.SocialIds.Should().BeNull();
            person.Biography.Should().BeNull();
            person.Birthday.Should().BeNull();
            person.Death.Should().BeNull();
            person.Birthplace.Should().BeNull();
            person.Homepage.Should().BeNull();
            person.KnownForDepartment.Should().BeNull();
            person.Gender.Should().BeNull();
            person.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktPersonFromJsonMinimal()
        {
            TraktPerson? person = await TestUtility.DeserializeJsonAsync<TraktPerson>("People\\person_minimal.json");

            person.Should().NotBeNull();

            person!.Name.Should().Be("Bryan Cranston");

            person!.Ids.Should().NotBeNull();
            person!.Ids!.Trakt.Should().Be(297737U);
            person!.Ids!.Slug.Should().Be("bryan-cranston");
            person!.Ids!.IMDB.Should().Be("nm0186505");
            person!.Ids!.TMDB.Should().Be(17419U);
            person!.Ids!.HasAnyID.Should().BeTrue();
            person!.Ids!.BestID.Should().Be("297737");

            person!.SocialIds.Should().BeNull();
            person!.Biography.Should().BeNull();
            person!.Birthday.Should().BeNull();
            person!.Death.Should().BeNull();
            person!.Birthplace.Should().BeNull();
            person!.Homepage.Should().BeNull();
            person!.KnownForDepartment.Should().BeNull();
            person!.Gender.Should().BeNull();
            person!.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktPersonFromJson()
        {
            TraktPerson? person = await TestUtility.DeserializeJsonAsync<TraktPerson>("People\\person.json");

            person.Should().NotBeNull();

            person!.Name.Should().Be("Bryan Cranston");

            person!.Ids.Should().NotBeNull();
            person!.Ids!.Trakt.Should().Be(297737U);
            person!.Ids!.Slug.Should().Be("bryan-cranston");
            person!.Ids!.IMDB.Should().Be("nm0186505");
            person!.Ids!.TMDB.Should().Be(17419U);
            person!.Ids!.HasAnyID.Should().BeTrue();
            person!.Ids!.BestID.Should().Be("297737");

            person!.SocialIds.Should().NotBeNull();
            person!.SocialIds!.Twitter.Should().Be("BryanCranston");
            person!.SocialIds!.Facebook.Should().Be("thebryancranston");
            person!.SocialIds!.Instagram.Should().Be("bryancranston");
            person!.SocialIds!.Wikipedia.Should().BeNull();

            person!.Biography.Should().Be("Bryan Lee Cranston (born March 7, 1956) is an American actor, director, and producer who "
                + "is mainly known for portraying Walter White in the AMC crime drama series Breaking Bad (2008–2013) and Hal in "
                + "the Fox sitcom Malcolm in the Middle (2000–2006).");

            person!.Birthday.Should().Be(TestUtility.ParseDate("1956-03-07"));
            person!.Death.Should().BeNull();
            person!.Birthplace.Should().Be("Hollywood, Los Angeles, California, USA");
            person!.Homepage.Should().BeNull();
            person!.KnownForDepartment.Should().Be(TraktKnownForDepartment.Acting);
            person!.Gender.Should().Be(TraktGender.Male);
            person!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-03-22T08:01:24.000Z"));
        }
    }
}
