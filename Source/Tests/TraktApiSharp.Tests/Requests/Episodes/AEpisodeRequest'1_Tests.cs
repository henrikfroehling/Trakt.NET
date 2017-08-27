namespace TraktApiSharp.Tests.Requests.Episodes
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Episodes;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Episodes")]
    public class AEpisodeRequest_1_Tests
    {
        internal class TraktEpisodeRequestMock : AEpisodeRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_AEpisodeRequest_1_IsAbstract()
        {
            typeof(AEpisodeRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_AEpisodeRequest_1_Has_GenericTypeParameter()
        {
            typeof(AEpisodeRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(AEpisodeRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_AEpisodeRequest_1_Inherits_AGetRequest_1()
        {
            typeof(AEpisodeRequest<int>).IsSubclassOf(typeof(AGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_AEpisodeRequest_1_Implements_IHasId_Interface()
        {
            typeof(AEpisodeRequest<>).GetInterfaces().Should().Contain(typeof(IHasId));
        }

        [Fact]
        public void Test_AEpisodeRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new TraktEpisodeRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_AEpisodeRequest_1_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktEpisodeRequestMock();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Episodes);
        }

        [Fact]
        public void Test_AEpisodeRequest_1_Has_SeasonNumber_Property()
        {
            var propertyInfo = typeof(AEpisodeRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SeasonNumber")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [Fact]
        public void Test_AEpisodeRequest_1_Has_EpisodeNumber_Property()
        {
            var propertyInfo = typeof(AEpisodeRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "EpisodeNumber")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [Fact]
        public void Test_AEpisodeRequest_1_Returns_Valid_UriPathParameters()
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
        public void Test_AEpisodeRequest_1_Validate_Throws_Exceptions()
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
            requestMock = new TraktEpisodeRequestMock { Id = "123", EpisodeNumber = 0 };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}
