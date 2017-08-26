namespace TraktApiSharp.Tests.Requests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Seasons;
    using Xunit;

    [Category("Requests.Seasons")]
    public class ATraktSeasonRequest_1_Tests
    {
        internal class TraktSeasonRequestMock : ATraktSeasonRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ATraktSeasonRequest_1_IsAbstract()
        {
            typeof(ATraktSeasonRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktSeasonRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktSeasonRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSeasonRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktSeasonRequest_1_Inherits_ATraktGetRequest_1()
        {
            typeof(ATraktSeasonRequest<int>).IsSubclassOf(typeof(AGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktSeasonRequest_1_Implements_ITraktHasId_Interface()
        {
            typeof(ATraktSeasonRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_ATraktSeasonRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new TraktSeasonRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ATraktSeasonRequest_1_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktSeasonRequestMock();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Seasons);
        }

        [Fact]
        public void Test_ATraktSeasonRequest_1_Has_SeasonNumber_Property()
        {
            var propertyInfo = typeof(ATraktSeasonRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SeasonNumber")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [Fact]
        public void Test_ATraktSeasonRequest_1_Returns_Valid_UriPathParameters()
        {
            // with implicit season number
            var requestMock = new TraktSeasonRequestMock { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(2)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123",
                                                           ["season"] = "0"
                                                       });

            // with explicit season number
            requestMock = new TraktSeasonRequestMock { Id = "123", SeasonNumber = 2 };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(2)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123",
                                                           ["season"] = "2"
                                                       });
        }

        [Fact]
        public void Test_ATraktSeasonRequest_1_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new TraktSeasonRequestMock();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            requestMock = new TraktSeasonRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            requestMock = new TraktSeasonRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
