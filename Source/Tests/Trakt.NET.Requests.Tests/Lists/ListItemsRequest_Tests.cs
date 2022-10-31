namespace TraktNet.Requests.Tests.Lists
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Lists;
    using TraktNet.Requests.Parameters;
    using Xunit;

    [TestCategory("Requests.Lists")]
    public class ListItemsRequest_Tests
    {
        [Fact]
        public void Test_ListItemsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new ListItemsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ListItemsRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new ListItemsRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_ListItemsRequest_Has_Valid_UriTemplate()
        {
            var request = new ListItemsRequest();
            request.UriTemplate.Should().Be("lists/{id}/items{/type}{?extended,page,limit}");
        }

        [Fact]
        public void Test_ListItemsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ListItemsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new ListItemsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new ListItemsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }

        [Theory, ClassData(typeof(ListItemsRequest_TestData))]
        public void Test_ListItemsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                          IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class ListItemsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private static readonly TraktListItemType _type = TraktListItemType.Episode;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly ListItemsRequest _request1 = new ListItemsRequest
            {
                Id = _id
            };

            private static readonly ListItemsRequest _request2 = new ListItemsRequest
            {
                Id = _id,
                Type = _type
            };

            private static readonly ListItemsRequest _request3 = new ListItemsRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo
            };

            private static readonly ListItemsRequest _request4 = new ListItemsRequest
            {
                Id = _id,
                Page = _page
            };

            private static readonly ListItemsRequest _request5 = new ListItemsRequest
            {
                Id = _id,
                Limit = _limit
            };

            private static readonly ListItemsRequest _request6 = new ListItemsRequest
            {
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly ListItemsRequest _request7 = new ListItemsRequest
            {
                Id = _id,
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly ListItemsRequest _request8 = new ListItemsRequest
            {
                Id = _id,
                Type = _type,
                Page = _page
            };

            private static readonly ListItemsRequest _request9 = new ListItemsRequest
            {
                Id = _id,
                Type = _type,
                Limit = _limit
            };

            private static readonly ListItemsRequest _request10 = new ListItemsRequest
            {
                Id = _id,
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly ListItemsRequest _request11 = new ListItemsRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly ListItemsRequest _request12 = new ListItemsRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly ListItemsRequest _request13 = new ListItemsRequest
            {
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly ListItemsRequest _request14 = new ListItemsRequest
            {
                Id = _id,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public ListItemsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strType = _type.UriName;
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
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["type"] = strType,
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
