namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktGender_Tests
    {
        [Fact]
        public void Test_TraktGender_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktGender>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktGender>() { TraktGender.Unspecified, TraktGender.Male,
                                                                 TraktGender.Female, TraktGender.NonBinary });
        }

        [Fact]
        public void Test_TraktGender_Properties()
        {
            TraktGender.Male.Value.Should().Be(1);
            TraktGender.Male.ObjectName.Should().Be("male");
            TraktGender.Male.UriName.Should().Be("male");
            TraktGender.Male.DisplayName.Should().Be("Male");

            TraktGender.Female.Value.Should().Be(2);
            TraktGender.Female.ObjectName.Should().Be("female");
            TraktGender.Female.UriName.Should().Be("female");
            TraktGender.Female.DisplayName.Should().Be("Female");

            TraktGender.NonBinary.Value.Should().Be(4);
            TraktGender.NonBinary.ObjectName.Should().Be("non_binary");
            TraktGender.NonBinary.UriName.Should().Be("non_binary");
            TraktGender.NonBinary.DisplayName.Should().Be("Non Binary");
        }
    }
}
