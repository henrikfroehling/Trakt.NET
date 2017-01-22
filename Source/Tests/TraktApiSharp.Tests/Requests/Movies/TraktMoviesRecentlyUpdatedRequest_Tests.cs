namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Movies.Common;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Movies.Lists")]
    public class TraktMoviesRecentlyUpdatedRequest_Tests
    {
        [Fact]
        public void Test_TraktMoviesRecentlyUpdatedRequest_IsNotAbstract()
        {
            typeof(TraktMoviesRecentlyUpdatedRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMoviesRecentlyUpdatedRequest_IsSealed()
        {
            typeof(TraktMoviesRecentlyUpdatedRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviesRecentlyUpdatedRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(TraktMoviesRecentlyUpdatedRequest).IsSubclassOf(typeof(ATraktGetRequest<TraktRecentlyUpdatedMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviesRecentlyUpdatedRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktMoviesRecentlyUpdatedRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktMoviesRecentlyUpdatedRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(TraktMoviesRecentlyUpdatedRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_TraktMoviesRecentlyUpdatedRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new TraktMoviesRecentlyUpdatedRequest();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_TraktMoviesRecentlyUpdatedRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMoviesRecentlyUpdatedRequest();
            request.UriTemplate.Should().Be("movies/updates{/start_date}{?extended,page,limit}");
        }

        [Fact]
        public void Test_TraktMoviesRecentlyUpdatedRequest_Has_StartDate_Property()
        {
            var periodPropertyInfo = typeof(TraktMoviesRecentlyUpdatedRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "StartDate")
                    .FirstOrDefault();

            periodPropertyInfo.CanRead.Should().BeTrue();
            periodPropertyInfo.CanWrite.Should().BeTrue();
            periodPropertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Theory, ClassData(typeof(TraktMoviesRecentlyUpdatedRequest_TestData))]
        public void Test_TraktMoviesRecentlyUpdatedRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                           IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktMoviesRecentlyUpdatedRequest_TestData : IEnumerable<object[]>
        {
            private static readonly DateTime _startDate = DateTime.Now;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktMoviesRecentlyUpdatedRequest _request1 = new TraktMoviesRecentlyUpdatedRequest();

            private static readonly TraktMoviesRecentlyUpdatedRequest _request2 = new TraktMoviesRecentlyUpdatedRequest
            {
                StartDate = _startDate
            };

            private static readonly TraktMoviesRecentlyUpdatedRequest _request3 = new TraktMoviesRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktMoviesRecentlyUpdatedRequest _request4 = new TraktMoviesRecentlyUpdatedRequest
            {
                Page = _page
            };

            private static readonly TraktMoviesRecentlyUpdatedRequest _request5 = new TraktMoviesRecentlyUpdatedRequest
            {
                Limit = _limit
            };

            private static readonly TraktMoviesRecentlyUpdatedRequest _request6 = new TraktMoviesRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktMoviesRecentlyUpdatedRequest _request7 = new TraktMoviesRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                Page = _page
            };

            private static readonly TraktMoviesRecentlyUpdatedRequest _request8 = new TraktMoviesRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                Limit = _limit
            };

            private static readonly TraktMoviesRecentlyUpdatedRequest _request9 = new TraktMoviesRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesRecentlyUpdatedRequest _request10 = new TraktMoviesRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktMoviesRecentlyUpdatedRequest _request11 = new TraktMoviesRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktMoviesRecentlyUpdatedRequest _request12 = new TraktMoviesRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesRecentlyUpdatedRequest _request13 = new TraktMoviesRecentlyUpdatedRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesRecentlyUpdatedRequest _request14 = new TraktMoviesRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktMoviesRecentlyUpdatedRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strStartDate = _startDate.ToTraktDateString();
                var strExtendedInfo = _extendedInfo.ToString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
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
