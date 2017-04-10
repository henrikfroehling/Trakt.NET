namespace TraktApiSharp.Tests.Objects.Get.Users.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using Xunit;

    [Category("Objects.Get.Users.Interfaces")]
    public class ITraktUserCommentComment_Tests
    {
        [Fact]
        public void Test_ITraktUserComment_Is_Interface()
        {
            typeof(ITraktUserComment).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserComment_Has_Type_Property()
        {
            var propertyInfo = typeof(ITraktUserComment).GetProperties().FirstOrDefault(p => p.Name == "Type");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktObjectType));
        }

        [Fact]
        public void Test_ITraktUserComment_Has_Comment_Property()
        {
            var propertyInfo = typeof(ITraktUserComment).GetProperties().FirstOrDefault(p => p.Name == "Comment");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktComment));
        }

        [Fact]
        public void Test_ITraktUserComment_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktUserComment).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktUserComment_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktUserComment).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }

        [Fact]
        public void Test_ITraktUserComment_Has_Season_Property()
        {
            var propertyInfo = typeof(ITraktUserComment).GetProperties().FirstOrDefault(p => p.Name == "Season");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSeason));
        }

        [Fact]
        public void Test_ITraktUserComment_Has_Episode_Property()
        {
            var propertyInfo = typeof(ITraktUserComment).GetProperties().FirstOrDefault(p => p.Name == "Episode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktEpisode));
        }

        [Fact]
        public void Test_ITraktUserComment_Has_List_Property()
        {
            var propertyInfo = typeof(ITraktUserComment).GetProperties().FirstOrDefault(p => p.Name == "List");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktList));
        }
    }
}
