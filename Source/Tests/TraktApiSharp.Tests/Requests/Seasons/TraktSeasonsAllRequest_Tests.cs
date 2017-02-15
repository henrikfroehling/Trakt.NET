namespace TraktApiSharp.Tests.Requests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Seasons;
    using Xunit;

    [Category("Requests.Seasons")]
    public class TraktSeasonsAllRequest_Tests
    {
        [Fact]
        public void Test_TraktSeasonsAllRequest_IsNotAbstract()
        {
            typeof(TraktSeasonsAllRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_IsSealed()
        {
            typeof(TraktSeasonsAllRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(TraktSeasonsAllRequest).IsSubclassOf(typeof(ATraktGetRequest<TraktSeason>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktSeasonsAllRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktSeasonsAllRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSeasonsAllRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons{?extended,translations}");
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Has_TranslationLanguageCode_Property()
        {
            var propertyInfo = typeof(TraktSeasonsAllRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "TranslationLanguageCode")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new TraktSeasonsAllRequest();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktSeasonsAllRequest();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.Shows);
        }

        [Fact]
        public void Test_TraktSeasonsAllRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktSeasonsAllRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktSeasonsAllRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktSeasonsAllRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // wrong translation language code format
            request = new TraktSeasonsAllRequest { Id = "123", TranslationLanguageCode = "eng" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentOutOfRangeException>();

            request = new TraktSeasonsAllRequest { Id = "123", TranslationLanguageCode = "e" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentOutOfRangeException>();

            request = new TraktSeasonsAllRequest { Id = "123", TranslationLanguageCode = "all" };

            act = () => request.Validate();
            act.ShouldNotThrow();
        }

        [Theory, ClassData(typeof(TraktSeasonsAllRequest_TestData))]
        public void Test_TraktSeasonsAllRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktSeasonsAllRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const string _languageCode = "en";

            private static readonly TraktSeasonsAllRequest _request1 = new TraktSeasonsAllRequest
            {
                Id = _id
            };

            private static readonly TraktSeasonsAllRequest _request2 = new TraktSeasonsAllRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktSeasonsAllRequest _request3 = new TraktSeasonsAllRequest
            {
                Id = _id,
                TranslationLanguageCode = _languageCode
            };

            private static readonly TraktSeasonsAllRequest _request4 = new TraktSeasonsAllRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                TranslationLanguageCode = _languageCode
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktSeasonsAllRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strExtendedInfo = _extendedInfo.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["translations"] = _languageCode
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo,
                        ["translations"] = _languageCode
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
