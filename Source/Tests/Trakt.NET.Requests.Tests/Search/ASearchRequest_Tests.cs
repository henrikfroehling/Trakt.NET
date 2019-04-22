namespace TraktNet.Requests.Tests.Search
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Search;
    using Xunit;

    [Category("Requests.Search")]
    public class ASearchRequest_Tests
    {
        internal class SearchRequestMock : ASearchRequest
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
            public override void Validate() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_ASearchRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new SearchRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Theory, ClassData(typeof(TraktSearchRequestMock_TestData))]
        public void Test_ASearchRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                        IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktSearchRequestMock_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly SearchRequestMock _request1 = new SearchRequestMock();

            private static readonly SearchRequestMock _request2 = new SearchRequestMock
            { ExtendedInfo = _extendedInfo };

            private static readonly SearchRequestMock _request3 = new SearchRequestMock
            { Page = _page };

            private static readonly SearchRequestMock _request4 = new SearchRequestMock
            { Limit = _limit };

            private static readonly SearchRequestMock _request5 = new SearchRequestMock
            { ExtendedInfo = _extendedInfo, Page = _page };

            private static readonly SearchRequestMock _request6 = new SearchRequestMock
            { ExtendedInfo = _extendedInfo, Limit = _limit };

            private static readonly SearchRequestMock _request7 = new SearchRequestMock
            { ExtendedInfo = _extendedInfo, Page = _page, Limit = _limit };

            private static readonly SearchRequestMock _request8 = new SearchRequestMock
            { Page = _page, Limit = _limit };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktSearchRequestMock_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strExtendedInfo = _extendedInfo.ToString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
