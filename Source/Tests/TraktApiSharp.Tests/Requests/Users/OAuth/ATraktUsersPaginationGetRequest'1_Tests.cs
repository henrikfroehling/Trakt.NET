namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class ATraktUsersPaginationGetRequest_1_Tests
    {
        internal class TraktUsersPaginationGetRequestMock : ATraktUsersPaginationGetRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }

            public override void Validate()
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Test_ATraktUsersPaginationGetRequest_1_Is_Abstract()
        {
            typeof(ATraktUsersPaginationGetRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktUsersPaginationGetRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktUsersPaginationGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktUsersPaginationGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktUsersPaginationGetRequest_1_Inherits_ATraktUsersGetRequest_1()
        {
            typeof(ATraktUsersPaginationGetRequest<int>).IsSubclassOf(typeof(ATraktUsersGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktUsersPaginationGetRequest_1_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(ATraktUsersPaginationGetRequest<>).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_ATraktUsersPaginationGetRequest_1_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUsersPaginationGetRequestMock();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_ATraktUsersPaginationGetRequest_1_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var requestMock = new TraktUsersPaginationGetRequestMock();
            requestMock.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            requestMock = new TraktUsersPaginationGetRequestMock { ExtendedInfo = extendedInfo };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["extended"] = extendedInfo.ToString()
                                                       });
        }

        [Theory, ClassData(typeof(TraktUsersPaginationGetRequestMock_TestData))]
        public void Test_ATraktUsersPaginationGetRequest_1_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                           IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktUsersPaginationGetRequestMock_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly TraktUsersPaginationGetRequestMock _request1 = new TraktUsersPaginationGetRequestMock();

            private static readonly TraktUsersPaginationGetRequestMock _request2 = new TraktUsersPaginationGetRequestMock
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUsersPaginationGetRequestMock _request3 = new TraktUsersPaginationGetRequestMock
            {
                Page = _page
            };

            private static readonly TraktUsersPaginationGetRequestMock _request4 = new TraktUsersPaginationGetRequestMock
            {
                Limit = _limit
            };

            private static readonly TraktUsersPaginationGetRequestMock _request5 = new TraktUsersPaginationGetRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktUsersPaginationGetRequestMock _request6 = new TraktUsersPaginationGetRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktUsersPaginationGetRequestMock _request7 = new TraktUsersPaginationGetRequestMock
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUsersPaginationGetRequestMock _request8 = new TraktUsersPaginationGetRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktUsersPaginationGetRequestMock_TestData()
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
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
