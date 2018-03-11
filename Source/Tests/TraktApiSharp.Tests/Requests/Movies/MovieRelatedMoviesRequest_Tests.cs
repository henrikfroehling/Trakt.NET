namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Movies;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Movies")]
    public class MovieRelatedMoviesRequest_Tests
    {
        [Fact]
        public void Test_MovieRelatedMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new MovieRelatedMoviesRequest();
            request.UriTemplate.Should().Be("movies/{id}/related{?extended,page,limit}");
        }

        [Fact]
        public void Test_MovieRelatedMoviesRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new MovieRelatedMoviesRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new MovieRelatedMoviesRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new MovieRelatedMoviesRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }

        [Theory, ClassData(typeof(MovieRelatedMoviesRequest_TestData))]
        public void Test_MovieRelatedMoviesRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                   IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class MovieRelatedMoviesRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly MovieRelatedMoviesRequest _request1 = new MovieRelatedMoviesRequest
            {
                Id = _id
            };

            private static readonly MovieRelatedMoviesRequest _request2 = new MovieRelatedMoviesRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo
            };

            private static readonly MovieRelatedMoviesRequest _request3 = new MovieRelatedMoviesRequest
            {
                Id = _id,
                Page = _page
            };

            private static readonly MovieRelatedMoviesRequest _request4 = new MovieRelatedMoviesRequest
            {
                Id = _id,
                Limit = _limit
            };

            private static readonly MovieRelatedMoviesRequest _request5 = new MovieRelatedMoviesRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly MovieRelatedMoviesRequest _request6 = new MovieRelatedMoviesRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly MovieRelatedMoviesRequest _request7 = new MovieRelatedMoviesRequest
            {
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly MovieRelatedMoviesRequest _request8 = new MovieRelatedMoviesRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public MovieRelatedMoviesRequest_TestData()
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
