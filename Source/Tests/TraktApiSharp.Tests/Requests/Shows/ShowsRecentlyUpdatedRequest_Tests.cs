namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows.Lists")]
    public class ShowsRecentlyUpdatedRequest_Tests
    {
        [Fact]
        public void Test_ShowsRecentlyUpdatedRequest_Is_Not_Abstract()
        {
            typeof(ShowsRecentlyUpdatedRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_ShowsRecentlyUpdatedRequest_Is_Sealed()
        {
            typeof(ShowsRecentlyUpdatedRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_ShowsRecentlyUpdatedRequest_Inherits_AGetRequest_1()
        {
            typeof(ShowsRecentlyUpdatedRequest).IsSubclassOf(typeof(AGetRequest<ITraktRecentlyUpdatedShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ShowsRecentlyUpdatedRequest_Implements_ISupportsExtendedInfo_Interface()
        {
            typeof(ShowsRecentlyUpdatedRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_ShowsRecentlyUpdatedRequest_Implements_ISupportsPagination_Interface()
        {
            typeof(ShowsRecentlyUpdatedRequest).GetInterfaces().Should().Contain(typeof(ISupportsPagination));
        }

        [Fact]
        public void Test_ShowsRecentlyUpdatedRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new ShowsRecentlyUpdatedRequest();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ShowsRecentlyUpdatedRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowsRecentlyUpdatedRequest();
            request.UriTemplate.Should().Be("shows/updates{/start_date}{?extended,page,limit}");
        }

        [Fact]
        public void Test_ShowsRecentlyUpdatedRequest_Has_StartDate_Property()
        {
            var propertyInfo = typeof(ShowsRecentlyUpdatedRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "StartDate")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Theory, ClassData(typeof(ShowsRecentlyUpdatedRequest_TestData))]
        public void Test_ShowsRecentlyUpdatedRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                     IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class ShowsRecentlyUpdatedRequest_TestData : IEnumerable<object[]>
        {
            private static readonly DateTime _startDate = DateTime.Now;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly ShowsRecentlyUpdatedRequest _request1 = new ShowsRecentlyUpdatedRequest();

            private static readonly ShowsRecentlyUpdatedRequest _request2 = new ShowsRecentlyUpdatedRequest
            {
                StartDate = _startDate
            };

            private static readonly ShowsRecentlyUpdatedRequest _request3 = new ShowsRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly ShowsRecentlyUpdatedRequest _request4 = new ShowsRecentlyUpdatedRequest
            {
                Page = _page
            };

            private static readonly ShowsRecentlyUpdatedRequest _request5 = new ShowsRecentlyUpdatedRequest
            {
                Limit = _limit
            };

            private static readonly ShowsRecentlyUpdatedRequest _request6 = new ShowsRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                ExtendedInfo = _extendedInfo
            };

            private static readonly ShowsRecentlyUpdatedRequest _request7 = new ShowsRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                Page = _page
            };

            private static readonly ShowsRecentlyUpdatedRequest _request8 = new ShowsRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                Limit = _limit
            };

            private static readonly ShowsRecentlyUpdatedRequest _request9 = new ShowsRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                Page = _page,
                Limit = _limit
            };

            private static readonly ShowsRecentlyUpdatedRequest _request10 = new ShowsRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly ShowsRecentlyUpdatedRequest _request11 = new ShowsRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly ShowsRecentlyUpdatedRequest _request12 = new ShowsRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly ShowsRecentlyUpdatedRequest _request13 = new ShowsRecentlyUpdatedRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly ShowsRecentlyUpdatedRequest _request14 = new ShowsRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public ShowsRecentlyUpdatedRequest_TestData()
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
