namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Movies;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Movies")]
    public class TraktMovieRelatedMoviesRequest_Tests
    {
        [Fact]
        public void Test_TraktMovieRelatedMoviesRequest_IsNotAbstract()
        {
            typeof(TraktMovieRelatedMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMovieRelatedMoviesRequest_IsSealed()
        {
            typeof(TraktMovieRelatedMoviesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieRelatedMoviesRequest_Inherits_ATraktMovieRequest_1()
        {
            typeof(TraktMovieRelatedMoviesRequest).IsSubclassOf(typeof(AMovieRequest<ITraktMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieRelatedMoviesRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktMovieRelatedMoviesRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktMovieRelatedMoviesRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(TraktMovieRelatedMoviesRequest).GetInterfaces().Should().Contain(typeof(ISupportsPagination));
        }

        [Fact]
        public void Test_TraktMovieRelatedMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMovieRelatedMoviesRequest();
            request.UriTemplate.Should().Be("movies/{id}/related{?extended,page,limit}");
        }

        [Fact]
        public void Test_TraktMovieRelatedMoviesRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktMovieRelatedMoviesRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktMovieRelatedMoviesRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktMovieRelatedMoviesRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktMovieRelatedMoviesRequest_TestData))]
        public void Test_TraktMovieRelatedMoviesRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                        IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktMovieRelatedMoviesRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktMovieRelatedMoviesRequest _request1 = new TraktMovieRelatedMoviesRequest
            {
                Id = _id
            };

            private static readonly TraktMovieRelatedMoviesRequest _request2 = new TraktMovieRelatedMoviesRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktMovieRelatedMoviesRequest _request3 = new TraktMovieRelatedMoviesRequest
            {
                Id = _id,
                Page = _page
            };

            private static readonly TraktMovieRelatedMoviesRequest _request4 = new TraktMovieRelatedMoviesRequest
            {
                Id = _id,
                Limit = _limit
            };

            private static readonly TraktMovieRelatedMoviesRequest _request5 = new TraktMovieRelatedMoviesRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktMovieRelatedMoviesRequest _request6 = new TraktMovieRelatedMoviesRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktMovieRelatedMoviesRequest _request7 = new TraktMovieRelatedMoviesRequest
            {
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMovieRelatedMoviesRequest _request8 = new TraktMovieRelatedMoviesRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktMovieRelatedMoviesRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strExtendedInfo = _extendedInfo.ToString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
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
