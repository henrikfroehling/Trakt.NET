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
    public class SeasonsAllRequest_Tests
    {
        [Fact]
        public void Test_SeasonsAllRequest_IsNotAbstract()
        {
            typeof(SeasonsAllRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SeasonsAllRequest_IsSealed()
        {
            typeof(SeasonsAllRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SeasonsAllRequest_Inherits_AGetRequest_1()
        {
            typeof(SeasonsAllRequest).IsSubclassOf(typeof(AGetRequest<ITraktSeason>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SeasonsAllRequest_Implements_IHasId_Interface()
        {
            typeof(SeasonsAllRequest).GetInterfaces().Should().Contain(typeof(IHasId));
        }

        [Fact]
        public void Test_SeasonsAllRequest_Implements_ISupportsExtendedInfo_Interface()
        {
            typeof(SeasonsAllRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_SeasonsAllRequest_Has_Valid_UriTemplate()
        {
            var request = new SeasonsAllRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons{?extended,translations}");
        }

        [Fact]
        public void Test_SeasonsAllRequest_Has_TranslationLanguageCode_Property()
        {
            var propertyInfo = typeof(SeasonsAllRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "TranslationLanguageCode")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_SeasonsAllRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new SeasonsAllRequest();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_SeasonsAllRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new SeasonsAllRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Shows);
        }

        [Fact]
        public void Test_SeasonsAllRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new SeasonsAllRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new SeasonsAllRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new SeasonsAllRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // wrong translation language code format
            request = new SeasonsAllRequest { Id = "123", TranslationLanguageCode = "eng" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentOutOfRangeException>();

            request = new SeasonsAllRequest { Id = "123", TranslationLanguageCode = "e" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentOutOfRangeException>();

            request = new SeasonsAllRequest { Id = "123", TranslationLanguageCode = "all" };

            act = () => request.Validate();
            act.ShouldNotThrow();
        }

        [Theory, ClassData(typeof(SeasonsAllRequest_TestData))]
        public void Test_SeasonsAllRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                           IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class SeasonsAllRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const string _languageCode = "en";

            private static readonly SeasonsAllRequest _request1 = new SeasonsAllRequest
            {
                Id = _id
            };

            private static readonly SeasonsAllRequest _request2 = new SeasonsAllRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SeasonsAllRequest _request3 = new SeasonsAllRequest
            {
                Id = _id,
                TranslationLanguageCode = _languageCode
            };

            private static readonly SeasonsAllRequest _request4 = new SeasonsAllRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                TranslationLanguageCode = _languageCode
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public SeasonsAllRequest_TestData()
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
