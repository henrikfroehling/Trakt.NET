namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows.Common;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Shows.Lists")]
    public class TraktShowsMostAnticipatedRequest_Tests
    {
        [Fact]
        public void Test_TraktShowsMostAnticipatedRequest_Is_Not_Abstract()
        {
            typeof(TraktShowsMostAnticipatedRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowsMostAnticipatedRequest_Is_Sealed()
        {
            typeof(TraktShowsMostAnticipatedRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowsMostAnticipatedRequest_Inherits_ATraktShowsRequest_1()
        {
            typeof(TraktShowsMostAnticipatedRequest).IsSubclassOf(typeof(ATraktShowsRequest<TraktMostAnticipatedShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowsMostAnticipatedRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowsMostAnticipatedRequest();
            request.UriTemplate.Should().Be("shows/anticipated{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}");
        }

        [Theory, ClassData(typeof(TraktShowsMostAnticipatedRequest_TestData))]
        public void Test_TraktShowsMostAnticipatedRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                          IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktShowsMostAnticipatedRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktShowFilter _filter = new TraktShowFilter().WithYears(2005, 2016);
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktShowsMostAnticipatedRequest _request1 = new TraktShowsMostAnticipatedRequest();

            private static readonly TraktShowsMostAnticipatedRequest _request2 = new TraktShowsMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktShowsMostAnticipatedRequest _request3 = new TraktShowsMostAnticipatedRequest
            {
                Filter = _filter
            };

            private static readonly TraktShowsMostAnticipatedRequest _request4 = new TraktShowsMostAnticipatedRequest
            {
                Page = _page
            };

            private static readonly TraktShowsMostAnticipatedRequest _request5 = new TraktShowsMostAnticipatedRequest
            {
                Limit = _limit
            };

            private static readonly TraktShowsMostAnticipatedRequest _request6 = new TraktShowsMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly TraktShowsMostAnticipatedRequest _request7 = new TraktShowsMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktShowsMostAnticipatedRequest _request8 = new TraktShowsMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktShowsMostAnticipatedRequest _request9 = new TraktShowsMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsMostAnticipatedRequest _request10 = new TraktShowsMostAnticipatedRequest
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly TraktShowsMostAnticipatedRequest _request11 = new TraktShowsMostAnticipatedRequest
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly TraktShowsMostAnticipatedRequest _request12 = new TraktShowsMostAnticipatedRequest
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsMostAnticipatedRequest _request13 = new TraktShowsMostAnticipatedRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsMostAnticipatedRequest _request14 = new TraktShowsMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktShowsMostAnticipatedRequest_TestData()
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
