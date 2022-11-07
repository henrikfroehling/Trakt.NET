namespace TraktNet.Requests.Tests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Parameters;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Seasons;
    using Xunit;

    [TestCategory("Requests.Seasons")]
    public class SeasonsAllRequest_Tests
    {
        [Fact]
        public void Test_SeasonsAllRequest_Has_Valid_UriTemplate()
        {
            var request = new SeasonsAllRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons{?extended,translations}");
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
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new SeasonsAllRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new SeasonsAllRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // wrong translation language code format
            request = new SeasonsAllRequest { Id = "123", TranslationLanguageCode = "eng" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            request = new SeasonsAllRequest { Id = "123", TranslationLanguageCode = "e" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            request = new SeasonsAllRequest { Id = "123", TranslationLanguageCode = "all" };

            act = () => request.Validate();
            act.Should().NotThrow();
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
