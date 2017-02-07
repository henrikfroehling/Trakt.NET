namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows.Lists")]
    public class ATraktShowsRequest_1_Tests
    {
        internal class TraktShowsRequestMock : ATraktShowsRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }

            public override void Validate()
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Test_ATraktShowsRequest_1_Is_Abstract()
        {
            typeof(ATraktShowsRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktShowsRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktShowsRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktShowsRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktShowsRequest_1_Inherits_ATraktGetRequest_1()
        {
            typeof(ATraktShowsRequest<int>).IsSubclassOf(typeof(ATraktGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktShowsRequest_1_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(ATraktShowsRequest<>).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_ATraktShowsRequest_1_Implements_ITraktSupportsFilter_Interface()
        {
            typeof(ATraktShowsRequest<>).GetInterfaces().Should().Contain(typeof(ITraktSupportsFilter));
        }

        [Fact]
        public void Test_ATraktShowsRequest_1_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(ATraktShowsRequest<>).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_ATraktShowsRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new TraktShowsRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Theory, ClassData(typeof(TraktShowsRequestMock_TestData))]
        public void Test_ATraktShowsRequest_1_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                              IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktShowsRequestMock_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktShowFilter _filter = new TraktShowFilter().WithYears(2005, 2016);
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktShowsRequestMock _request1 = new TraktShowsRequestMock();

            private static readonly TraktShowsRequestMock _request2 = new TraktShowsRequestMock
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktShowsRequestMock _request3 = new TraktShowsRequestMock
            {
                Filter = _filter
            };

            private static readonly TraktShowsRequestMock _request4 = new TraktShowsRequestMock
            {
                Page = _page
            };

            private static readonly TraktShowsRequestMock _request5 = new TraktShowsRequestMock
            {
                Limit = _limit
            };

            private static readonly TraktShowsRequestMock _request6 = new TraktShowsRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly TraktShowsRequestMock _request7 = new TraktShowsRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktShowsRequestMock _request8 = new TraktShowsRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktShowsRequestMock _request9 = new TraktShowsRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsRequestMock _request10 = new TraktShowsRequestMock
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly TraktShowsRequestMock _request11 = new TraktShowsRequestMock
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly TraktShowsRequestMock _request12 = new TraktShowsRequestMock
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsRequestMock _request13 = new TraktShowsRequestMock
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsRequestMock _request14 = new TraktShowsRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktShowsRequestMock_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strExtendedInfo = _extendedInfo.ToString();
                var filterParameters = _filter.GetParameters();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>(filterParameters) });

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
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
