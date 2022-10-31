namespace TraktNet.Requests.Tests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Parameters.Filter;
    using TraktNet.Requests.Shows;
    using Xunit;

    [TestCategory("Requests.Shows.Lists")]
    public class AShowsMostPWCRequest_1_Tests
    {
        internal class ShowsMostPWCRequestMock : AShowsMostPWCRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
            public override void Validate() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_AShowsMostPWCRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new ShowsMostPWCRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Theory, ClassData(typeof(ShowsMostPWCRequestMock_TestData))]
        public void Test_AShowsMostPWCRequest_1_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class ShowsMostPWCRequestMock_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly ITraktShowFilter _filter = TraktFilterDirectory.ShowFilter.WithYears(2005, 2016).Build();
            private static readonly TraktTimePeriod _timePeriod = TraktTimePeriod.Monthly;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly ShowsMostPWCRequestMock _request1 = new ShowsMostPWCRequestMock();

            private static readonly ShowsMostPWCRequestMock _request2 = new ShowsMostPWCRequestMock
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly ShowsMostPWCRequestMock _request3 = new ShowsMostPWCRequestMock
            {
                Filter = _filter
            };

            private static readonly ShowsMostPWCRequestMock _request4 = new ShowsMostPWCRequestMock
            {
                Period = _timePeriod
            };

            private static readonly ShowsMostPWCRequestMock _request5 = new ShowsMostPWCRequestMock
            {
                Page = _page
            };

            private static readonly ShowsMostPWCRequestMock _request6 = new ShowsMostPWCRequestMock
            {
                Limit = _limit
            };

            private static readonly ShowsMostPWCRequestMock _request7 = new ShowsMostPWCRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly ShowsMostPWCRequestMock _request8 = new ShowsMostPWCRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Period = _timePeriod
            };

            private static readonly ShowsMostPWCRequestMock _request9 = new ShowsMostPWCRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly ShowsMostPWCRequestMock _request10 = new ShowsMostPWCRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly ShowsMostPWCRequestMock _request11 = new ShowsMostPWCRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly ShowsMostPWCRequestMock _request12 = new ShowsMostPWCRequestMock
            {
                Filter = _filter,
                Period = _timePeriod
            };

            private static readonly ShowsMostPWCRequestMock _request13 = new ShowsMostPWCRequestMock
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly ShowsMostPWCRequestMock _request14 = new ShowsMostPWCRequestMock
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly ShowsMostPWCRequestMock _request15 = new ShowsMostPWCRequestMock
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly ShowsMostPWCRequestMock _request16 = new ShowsMostPWCRequestMock
            {
                Period = _timePeriod,
                Page = _page
            };

            private static readonly ShowsMostPWCRequestMock _request17 = new ShowsMostPWCRequestMock
            {
                Period = _timePeriod,
                Limit = _limit
            };

            private static readonly ShowsMostPWCRequestMock _request18 = new ShowsMostPWCRequestMock
            {
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly ShowsMostPWCRequestMock _request19 = new ShowsMostPWCRequestMock
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly ShowsMostPWCRequestMock _request20 = new ShowsMostPWCRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public ShowsMostPWCRequestMock_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strExtendedInfo = _extendedInfo.ToString();
                var filterParameters = _filter.GetParameters();
                var strTimePeriod = _timePeriod.UriName;
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
                        ["period"] = strTimePeriod
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["period"] = strTimePeriod
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["period"] = strTimePeriod
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["period"] = strTimePeriod,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request17.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["period"] = strTimePeriod,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request18.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["period"] = strTimePeriod,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request19.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request20.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["extended"] = strExtendedInfo,
                        ["period"] = strTimePeriod,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
