namespace TraktApiSharp.Tests.Requests.Episodes
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Episodes;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Episodes")]
    public class ATraktEpisodeRequest_1_Tests
    {
        internal class TraktEpisodeRequestMock : ATraktEpisodeRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ATraktEpisodeRequest_1_IsAbstract()
        {
            typeof(ATraktEpisodeRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktEpisodeRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktEpisodeRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktEpisodeRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktEpisodeRequest_1_Inherits_ATraktGetRequest_1()
        {
            typeof(ATraktEpisodeRequest<int>).IsSubclassOf(typeof(ATraktGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktEpisodeRequest_1_Implements_ITraktHasId_Interface()
        {
            typeof(ATraktEpisodeRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_ATraktEpisodeRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new TraktEpisodeRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ATraktEpisodeRequest_1_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktEpisodeRequestMock();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.Episodes);
        }

        [Fact]
        public void Test_ATraktEpisodeRequest_1_Has_SeasonNumber_Property()
        {
            var sortingPropertyInfo = typeof(ATraktEpisodeRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SeasonNumber")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [Fact]
        public void Test_ATraktEpisodeRequest_1_Has_EpisodeNumber_Property()
        {
            var sortingPropertyInfo = typeof(ATraktEpisodeRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "EpisodeNumber")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [Fact]
        public void Test_ATraktEpisodeRequest_1_Returns_Valid_UriPathParameters()
        {
            // with implicit season number
            var requestMock = new TraktEpisodeRequestMock { Id = "123", EpisodeNumber = 1 };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(3)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123",
                                                           ["season"] = "0",
                                                           ["episode"] = "1"
                                                       });

            // with explicit season number
            requestMock = new TraktEpisodeRequestMock { Id = "123", SeasonNumber = 2, EpisodeNumber = 1 };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(3)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123",
                                                           ["season"] = "2",
                                                           ["episode"] = "1"
                                                       });
        }

        [Fact]
        public void Test_ATraktEpisodeRequest_1_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new TraktEpisodeRequestMock { EpisodeNumber = 1 };

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            requestMock = new TraktEpisodeRequestMock { Id = string.Empty, EpisodeNumber = 1 };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            requestMock = new TraktEpisodeRequestMock { Id = "invalid id", EpisodeNumber = 1 };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // episode number == 0
            requestMock = new TraktEpisodeRequestMock { EpisodeNumber = 0 };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
