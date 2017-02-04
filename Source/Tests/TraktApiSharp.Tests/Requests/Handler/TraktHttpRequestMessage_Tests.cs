namespace TraktApiSharp.Tests.Requests.Handler
{
    using FluentAssertions;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Handler;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
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
        public void Test_TraktHttpRequestMessage_Has_Id_Property()
        {
            var sortingPropertyInfo = typeof(TraktHttpRequestMessage)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Id")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktHttpRequestMessage_Has_SeasonNumber_Property()
        {
            var sortingPropertyInfo = typeof(TraktHttpRequestMessage)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SeasonNumber")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_TraktHttpRequestMessage_Has_EpisodeNumber_Property()
        {
            var sortingPropertyInfo = typeof(TraktHttpRequestMessage)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "EpisodeNumber")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_TraktHttpRequestMessage_Has_Url_Property()
        {
            var sortingPropertyInfo = typeof(TraktHttpRequestMessage)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Url")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktHttpRequestMessage_Has_RequestObjectType_Property()
        {
            var sortingPropertyInfo = typeof(TraktHttpRequestMessage)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "RequestObjectType")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktRequestObjectType?));
        }

        [Fact]
        public void Test_TraktHttpRequestMessage_Has_RequestBodyJson_Property()
        {
            var sortingPropertyInfo = typeof(TraktHttpRequestMessage)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "RequestBodyJson")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
