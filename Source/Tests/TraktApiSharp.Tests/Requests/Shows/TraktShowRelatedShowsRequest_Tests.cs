namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class TraktShowRelatedShowsRequest_Tests
    {
        [Fact]
        public void Test_TraktShowRelatedShowsRequest_Is_Not_Abstract()
        {
            typeof(TraktShowRelatedShowsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowRelatedShowsRequest_Is_Sealed()
        {
            typeof(TraktShowRelatedShowsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowRelatedShowsRequest_Inherits_ATraktShowRequest_1()
        {
            typeof(TraktShowRelatedShowsRequest).IsSubclassOf(typeof(ATraktShowRequest<ITraktShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowRelatedShowsRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktShowRelatedShowsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktShowRelatedShowsRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(TraktShowRelatedShowsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_TraktShowRelatedShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowRelatedShowsRequest();
            request.UriTemplate.Should().Be("shows/{id}/related{?extended,page,limit}");
        }

        [Fact]
        public void Test_TraktShowRelatedShowsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktShowRelatedShowsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktShowRelatedShowsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktShowRelatedShowsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktShowRelatedShowsRequest_TestData))]
        public void Test_TraktShowRelatedShowsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                      IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktShowRelatedShowsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktShowRelatedShowsRequest _request1 = new TraktShowRelatedShowsRequest
            {
                Id = _id
            };

            private static readonly TraktShowRelatedShowsRequest _request2 = new TraktShowRelatedShowsRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktShowRelatedShowsRequest _request3 = new TraktShowRelatedShowsRequest
            {
                Id = _id,
                Page = _page
            };

            private static readonly TraktShowRelatedShowsRequest _request4 = new TraktShowRelatedShowsRequest
            {
                Id = _id,
                Limit = _limit
            };

            private static readonly TraktShowRelatedShowsRequest _request5 = new TraktShowRelatedShowsRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktShowRelatedShowsRequest _request6 = new TraktShowRelatedShowsRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktShowRelatedShowsRequest _request7 = new TraktShowRelatedShowsRequest
            {
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowRelatedShowsRequest _request8 = new TraktShowRelatedShowsRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktShowRelatedShowsRequest_TestData()
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
