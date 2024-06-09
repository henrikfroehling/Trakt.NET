namespace TraktNET.Enums
{
    public sealed class TraktGenderTests
    {
        [Fact]
        public void TestTraktGenderToJson()
        {
            TraktGender.Unspecified.ToJson().Should().BeNull();
            TraktGender.Male.ToJson().Should().Be("male");
            TraktGender.Female.ToJson().Should().Be("female");
            TraktGender.NonBinary.ToJson().Should().Be("non_binary");
        }

        [Fact]
        public void TestTraktGenderFromJson()
        {
            "unspecified".ToTraktGender().Should().Be(TraktGender.Unspecified);
            "male".ToTraktGender().Should().Be(TraktGender.Male);
            "female".ToTraktGender().Should().Be(TraktGender.Female);
            "non_binary".ToTraktGender().Should().Be(TraktGender.NonBinary);

            string? nullValue = null;
            nullValue.ToTraktGender().Should().Be(TraktGender.Unspecified);
        }

        [Fact]
        public void TestTraktGenderDisplayName()
        {
            TraktGender.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktGender.Male.DisplayName().Should().Be("Male");
            TraktGender.Female.DisplayName().Should().Be("Female");
            TraktGender.NonBinary.DisplayName().Should().Be("Non Binary");
        }
    }
}
