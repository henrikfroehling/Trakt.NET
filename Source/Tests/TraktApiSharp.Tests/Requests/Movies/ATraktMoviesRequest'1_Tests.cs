namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Movies;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Movies.Lists")]
    public class ATraktMoviesRequest_1_Tests
    {
        internal class TraktMoviesRequestMock : ATraktMoviesRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }

            public override void Validate()
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Test_ATraktMoviesRequest_1_IsAbstract()
        {
            typeof(ATraktMoviesRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktMoviesRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktMoviesRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktMoviesRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktMoviesRequest_1_Inherits_ATraktGetRequest_1()
        {
            typeof(ATraktMoviesRequest<int>).IsSubclassOf(typeof(AGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktMoviesRequest_1_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(ATraktMoviesRequest<>).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_ATraktMoviesRequest_1_Implements_ITraktSupportsFilter_Interface()
        {
            typeof(ATraktMoviesRequest<>).GetInterfaces().Should().Contain(typeof(ITraktSupportsFilter));
        }

        [Fact]
        public void Test_ATraktMoviesRequest_1_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(ATraktMoviesRequest<>).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_ATraktMoviesRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new TraktMoviesRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Theory, ClassData(typeof(TraktMoviesRequestMock_TestData))]
        public void Test_ATraktMoviesRequest_1_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                               IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktMoviesRequestMock_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktMovieFilter _filter = new TraktMovieFilter().WithYears(2005, 2016);
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktMoviesRequestMock _request1 = new TraktMoviesRequestMock();

            private static readonly TraktMoviesRequestMock _request2 = new TraktMoviesRequestMock
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktMoviesRequestMock _request3 = new TraktMoviesRequestMock
            {
                Filter = _filter
            };

            private static readonly TraktMoviesRequestMock _request4 = new TraktMoviesRequestMock
            {
                Page = _page
            };

            private static readonly TraktMoviesRequestMock _request5 = new TraktMoviesRequestMock
            {
                Limit = _limit
            };

            private static readonly TraktMoviesRequestMock _request6 = new TraktMoviesRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly TraktMoviesRequestMock _request7 = new TraktMoviesRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktMoviesRequestMock _request8 = new TraktMoviesRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktMoviesRequestMock _request9 = new TraktMoviesRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesRequestMock _request10 = new TraktMoviesRequestMock
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly TraktMoviesRequestMock _request11 = new TraktMoviesRequestMock
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly TraktMoviesRequestMock _request12 = new TraktMoviesRequestMock
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesRequestMock _request13 = new TraktMoviesRequestMock
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesRequestMock _request14 = new TraktMoviesRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };
            
            private static readonly List<object[]> _data = new List<object[]>();

            public TraktMoviesRequestMock_TestData()
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
