namespace TraktApiSharp.Tests.Objects.Basic.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktSharing_Tests
    {
        [Fact]
        public void Test_ITraktSharing_Is_Interface()
        {
            typeof(ITraktSharing).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSharing_Has_Facebook_Property()
        {
            var propertyInfo = typeof(ITraktSharing).GetProperties().FirstOrDefault(p => p.Name == "Facebook");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }

        [Fact]
        public void Test_ITraktSharing_Has_Twitter_Property()
        {
            var propertyInfo = typeof(ITraktSharing).GetProperties().FirstOrDefault(p => p.Name == "Twitter");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }

        [Fact]
        public void Test_ITraktSharing_Has_Google_Property()
        {
            var propertyInfo = typeof(ITraktSharing).GetProperties().FirstOrDefault(p => p.Name == "Google");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }

        [Fact]
        public void Test_ITraktSharing_Has_Tumblr_Property()
        {
            var propertyInfo = typeof(ITraktSharing).GetProperties().FirstOrDefault(p => p.Name == "Tumblr");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }

        [Fact]
        public void Test_ITraktSharing_Has_Medium_Property()
        {
            var propertyInfo = typeof(ITraktSharing).GetProperties().FirstOrDefault(p => p.Name == "Medium");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }

        [Fact]
        public void Test_ITraktSharing_Has_Slack_Property()
        {
            var propertyInfo = typeof(ITraktSharing).GetProperties().FirstOrDefault(p => p.Name == "Slack");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }
    }
}
