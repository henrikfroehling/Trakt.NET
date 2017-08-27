namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Movies;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Movies.Lists")]
    public class MoviesRecentlyUpdatedRequest_Tests
    {
        [Fact]
        public void Test_MoviesRecentlyUpdatedRequest_IsNotAbstract()
        {
            typeof(MoviesRecentlyUpdatedRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_MoviesRecentlyUpdatedRequest_IsSealed()
        {
            typeof(MoviesRecentlyUpdatedRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_MoviesRecentlyUpdatedRequest_Inherits_AGetRequest_1()
        {
            typeof(MoviesRecentlyUpdatedRequest).IsSubclassOf(typeof(AGetRequest<ITraktRecentlyUpdatedMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_MoviesRecentlyUpdatedRequest_Implements_ISupportsExtendedInfo_Interface()
        {
            typeof(MoviesRecentlyUpdatedRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_MoviesRecentlyUpdatedRequest_Implements_ISupportsPagination_Interface()
        {
            typeof(MoviesRecentlyUpdatedRequest).GetInterfaces().Should().Contain(typeof(ISupportsPagination));
        }

        [Fact]
        public void Test_MoviesRecentlyUpdatedRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new MoviesRecentlyUpdatedRequest();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_MoviesRecentlyUpdatedRequest_Has_Valid_UriTemplate()
        {
            var request = new MoviesRecentlyUpdatedRequest();
            request.UriTemplate.Should().Be("movies/updates{/start_date}{?extended,page,limit}");
        }

        [Fact]
        public void Test_MoviesRecentlyUpdatedRequest_Has_StartDate_Property()
        {
            var propertyInfo = typeof(MoviesRecentlyUpdatedRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "StartDate")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Theory, ClassData(typeof(MoviesRecentlyUpdatedRequest_TestData))]
        public void Test_MoviesRecentlyUpdatedRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                      IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class MoviesRecentlyUpdatedRequest_TestData : IEnumerable<object[]>
        {
            private static readonly DateTime _startDate = DateTime.Now;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly MoviesRecentlyUpdatedRequest _request1 = new MoviesRecentlyUpdatedRequest();

            private static readonly MoviesRecentlyUpdatedRequest _request2 = new MoviesRecentlyUpdatedRequest
            {
                StartDate = _startDate
            };

            private static readonly MoviesRecentlyUpdatedRequest _request3 = new MoviesRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly MoviesRecentlyUpdatedRequest _request4 = new MoviesRecentlyUpdatedRequest
            {
                Page = _page
            };

            private static readonly MoviesRecentlyUpdatedRequest _request5 = new MoviesRecentlyUpdatedRequest
            {
                Limit = _limit
            };

            private static readonly MoviesRecentlyUpdatedRequest _request6 = new MoviesRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                ExtendedInfo = _extendedInfo
            };

            private static readonly MoviesRecentlyUpdatedRequest _request7 = new MoviesRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                Page = _page
            };

            private static readonly MoviesRecentlyUpdatedRequest _request8 = new MoviesRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                Limit = _limit
            };

            private static readonly MoviesRecentlyUpdatedRequest _request9 = new MoviesRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                Page = _page,
                Limit = _limit
            };

            private static readonly MoviesRecentlyUpdatedRequest _request10 = new MoviesRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly MoviesRecentlyUpdatedRequest _request11 = new MoviesRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly MoviesRecentlyUpdatedRequest _request12 = new MoviesRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly MoviesRecentlyUpdatedRequest _request13 = new MoviesRecentlyUpdatedRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly MoviesRecentlyUpdatedRequest _request14 = new MoviesRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public MoviesRecentlyUpdatedRequest_TestData()
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
