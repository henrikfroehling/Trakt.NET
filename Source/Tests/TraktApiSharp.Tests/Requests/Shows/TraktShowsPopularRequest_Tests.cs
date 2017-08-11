namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows.Lists")]
    public class TraktShowsPopularRequest_Tests
    {
        [Fact]
        public void Test_TraktShowsPopularRequest_Is_Not_Abstract()
        {
            typeof(TraktShowsPopularRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowsPopularRequest_Is_Sealed()
        {
            typeof(TraktShowsPopularRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowsPopularRequest_Inherits_ATraktShowsRequest_1()
        {
            typeof(TraktShowsPopularRequest).IsSubclassOf(typeof(ATraktShowsRequest<ITraktShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowsPopularRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowsPopularRequest();
            request.UriTemplate.Should().Be("shows/popular{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}");
        }

        [Theory, ClassData(typeof(TraktShowsPopularRequest_TestData))]
        public void Test_TraktShowsPopularRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                  IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktShowsPopularRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktShowFilter _filter = new TraktShowFilter().WithYears(2005, 2016);
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktShowsPopularRequest _request1 = new TraktShowsPopularRequest();

            private static readonly TraktShowsPopularRequest _request2 = new TraktShowsPopularRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktShowsPopularRequest _request3 = new TraktShowsPopularRequest
            {
                Filter = _filter
            };

            private static readonly TraktShowsPopularRequest _request4 = new TraktShowsPopularRequest
            {
                Page = _page
            };

            private static readonly TraktShowsPopularRequest _request5 = new TraktShowsPopularRequest
            {
                Limit = _limit
            };

            private static readonly TraktShowsPopularRequest _request6 = new TraktShowsPopularRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly TraktShowsPopularRequest _request7 = new TraktShowsPopularRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktShowsPopularRequest _request8 = new TraktShowsPopularRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktShowsPopularRequest _request9 = new TraktShowsPopularRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsPopularRequest _request10 = new TraktShowsPopularRequest
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly TraktShowsPopularRequest _request11 = new TraktShowsPopularRequest
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly TraktShowsPopularRequest _request12 = new TraktShowsPopularRequest
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsPopularRequest _request13 = new TraktShowsPopularRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsPopularRequest _request14 = new TraktShowsPopularRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktShowsPopularRequest_TestData()
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
