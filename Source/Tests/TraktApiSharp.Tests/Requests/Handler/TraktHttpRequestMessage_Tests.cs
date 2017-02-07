namespace TraktApiSharp.Tests.Requests.Handler
{
    using FluentAssertions;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Handler;
    using Xunit;

    [Category("Requests.Handler")]
    public class TraktHttpRequestMessage_Tests
    {
        [Fact]
        public void Test_TraktHttpRequestMessage_Is_Not_Abstract()
        {
            typeof(TraktHttpRequestMessage).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktHttpRequestMessage_Is_Sealed()
        {
            typeof(TraktHttpRequestMessage).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktHttpRequestMessage_Inherits_HttpRequestMessage()
        {
            typeof(TraktHttpRequestMessage).IsSubclassOf(typeof(HttpRequestMessage)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktHttpRequestMessage_Has_ObjectId_Property()
        {
            var propertyInfo = typeof(TraktHttpRequestMessage)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "ObjectId")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktHttpRequestMessage_Has_SeasonNumber_Property()
        {
            var propertyInfo = typeof(TraktHttpRequestMessage)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SeasonNumber")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_TraktHttpRequestMessage_Has_EpisodeNumber_Property()
        {
            var propertyInfo = typeof(TraktHttpRequestMessage)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "EpisodeNumber")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_TraktHttpRequestMessage_Has_Url_Property()
        {
            var propertyInfo = typeof(TraktHttpRequestMessage)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Url")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktHttpRequestMessage_Has_RequestObjectType_Property()
        {
            var propertyInfo = typeof(TraktHttpRequestMessage)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "RequestObjectType")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktRequestObjectType?));
        }

        [Fact]
        public void Test_TraktHttpRequestMessage_Has_RequestBodyJson_Property()
        {
            var propertyInfo = typeof(TraktHttpRequestMessage)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "RequestBodyJson")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
