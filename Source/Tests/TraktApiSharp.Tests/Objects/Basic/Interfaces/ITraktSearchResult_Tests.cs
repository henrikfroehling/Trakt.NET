namespace TraktApiSharp.Tests.Objects.Basic.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktSearchResult_Tests
    {
        [Fact]
        public void Test_ITraktSearchResult_Is_Interface()
        {
            typeof(ITraktSearchResult).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSearchResult_Has_Type_Property()
        {
            var propertyInfo = typeof(ITraktSearchResult).GetProperties().FirstOrDefault(p => p.Name == "Type");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktSearchResultType));
        }

        [Fact]
        public void Test_ITraktSearchResult_Has_Score_Property()
        {
            var propertyInfo = typeof(ITraktSearchResult).GetProperties().FirstOrDefault(p => p.Name == "Score");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(float?));
        }

        [Fact]
        public void Test_ITraktSearchResult_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktSearchResult).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktSearchResult_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktSearchResult).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }

        [Fact]
        public void Test_ITraktSearchResult_Has_Episode_Property()
        {
            var propertyInfo = typeof(ITraktSearchResult).GetProperties().FirstOrDefault(p => p.Name == "Episode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktEpisode));
        }

        [Fact]
        public void Test_ITraktSearchResult_Has_Person_Property()
        {
            var propertyInfo = typeof(ITraktSearchResult).GetProperties().FirstOrDefault(p => p.Name == "Person");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktPerson));
        }

        [Fact]
        public void Test_ITraktSearchResult_Has_List_Property()
        {
            var propertyInfo = typeof(ITraktSearchResult).GetProperties().FirstOrDefault(p => p.Name == "List");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktList));
        }
    }
}
