namespace TraktApiSharp.Tests.Requests.Search
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Search;
    using Xunit;

    [Category("Requests.Search")]
    public class ATraktSearchRequest_Tests
    {
        internal class TraktSearchRequestMock : ATraktSearchRequest
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }

            public override void Validate()
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Test_ATraktSearchRequest_IsAbstract()
        {
            typeof(ATraktSearchRequest).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktSearchRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(ATraktSearchRequest).IsSubclassOf(typeof(ATraktGetRequest<TraktSearchResult>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktSearchRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(ATraktSearchRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_ATraktSearchRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(ATraktSearchRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_ATraktSearchRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new TraktSearchRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ATraktSearchRequest_Has_ResultTypes_Property()
        {
            var propertyInfo = typeof(ATraktSearchRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "ResultTypes")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktSearchResultType));
        }
        
        [Theory, ClassData(typeof(TraktSearchRequestMock_TestData))]
        public void Test_ATraktSearchRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
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

            private static readonly TraktSearchRequestMock _request1 = new TraktSearchRequestMock();

            private static readonly TraktSearchRequestMock _request2 = new TraktSearchRequestMock
            { ExtendedInfo = _extendedInfo };

            private static readonly TraktSearchRequestMock _request3 = new TraktSearchRequestMock
            { Page = _page };

            private static readonly TraktSearchRequestMock _request4 = new TraktSearchRequestMock
            { Limit = _limit };
            
            private static readonly TraktSearchRequestMock _request5 = new TraktSearchRequestMock
            { ExtendedInfo = _extendedInfo, Page = _page };

            private static readonly TraktSearchRequestMock _request6 = new TraktSearchRequestMock
            { ExtendedInfo = _extendedInfo, Limit = _limit };

            private static readonly TraktSearchRequestMock _request7 = new TraktSearchRequestMock
            { ExtendedInfo = _extendedInfo, Page = _page, Limit = _limit };

            private static readonly TraktSearchRequestMock _request8 = new TraktSearchRequestMock
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

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object> { } });

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
