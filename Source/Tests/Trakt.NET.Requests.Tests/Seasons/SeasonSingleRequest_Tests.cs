﻿namespace TraktNet.Requests.Tests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Seasons;
    using Xunit;

    [Category("Requests.Seasons")]
    public class SeasonSingleRequest_Tests
    {
        [Fact]
        public void Test_SeasonSingleRequest_Has_Valid_UriTemplate()
        {
            var request = new SeasonSingleRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}{?extended,translations}");
        }

        [Fact]
        public void Test_SeasonSingleRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new SeasonSingleRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new SeasonSingleRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new SeasonSingleRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // wrong translation language code format
            request = new SeasonSingleRequest { Id = "123", TranslationLanguageCode = "eng" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentOutOfRangeException>();

            request = new SeasonSingleRequest { Id = "123", TranslationLanguageCode = "e" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentOutOfRangeException>();

            request = new SeasonSingleRequest { Id = "123", TranslationLanguageCode = "all" };

            act = () => request.Validate();
            act.Should().NotThrow();
        }

        [Theory, ClassData(typeof(SeasonSingleRequest_TestData))]
        public void Test_SeasonSingleRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                             IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class SeasonSingleRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const uint _seasonNumber = 1;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const string _languageCode = "en";

            private static readonly SeasonSingleRequest _request1 = new SeasonSingleRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber
            };

            private static readonly SeasonSingleRequest _request2 = new SeasonSingleRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SeasonSingleRequest _request3 = new SeasonSingleRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                TranslationLanguageCode = _languageCode
            };

            private static readonly SeasonSingleRequest _request4 = new SeasonSingleRequest
            {
                Id = _id,
                SeasonNumber = _seasonNumber,
                ExtendedInfo = _extendedInfo,
                TranslationLanguageCode = _languageCode
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public SeasonSingleRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strSeasonNumber = _seasonNumber.ToString();
                var strExtendedInfo = _extendedInfo.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["translations"] = _languageCode
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["season"] = strSeasonNumber,
                        ["extended"] = strExtendedInfo,
                        ["translations"] = _languageCode
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
