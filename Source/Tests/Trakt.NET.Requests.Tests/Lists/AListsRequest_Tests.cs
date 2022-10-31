namespace TraktNet.Requests.Tests.Lists
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Lists;
    using Xunit;

    [TestCategory("Requests.Lists")]
    public class AListsRequest_Tests
    {
        internal class ListsRequestMock : AListsRequest
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_AListsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new ListsRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Theory, ClassData(typeof(AListsRequest_TestData))]
        public void Test_AListsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                       IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class AListsRequest_TestData : IEnumerable<object[]>
        {
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly ListsRequestMock _request1 = new ListsRequestMock();

            private static readonly ListsRequestMock _request2 = new ListsRequestMock
            {
                Page = _page
            };

            private static readonly ListsRequestMock _request3 = new ListsRequestMock
            {
                Limit = _limit
            };

            private static readonly ListsRequestMock _request4 = new ListsRequestMock
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public AListsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
