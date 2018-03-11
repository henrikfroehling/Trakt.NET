namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserCustomListItemsRequest_Tests
    {
        [Fact]
        public void Test_UserCustomListItemsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserCustomListItemsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserCustomListItemsRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new UserCustomListItemsRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_UserCustomListItemsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserCustomListItemsRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/items{/type}{?extended,page,limit}");
        }

        [Fact]
        public void Test_UserCustomListItemsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserCustomListItemsRequest { Id = "123" };

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty username
            request = new UserCustomListItemsRequest { Username = string.Empty, Id = "123" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // username with spaces
            request = new UserCustomListItemsRequest { Username = "invalid username", Id = "123" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id is null
            request = new UserCustomListItemsRequest { Username = "username" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new UserCustomListItemsRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new UserCustomListItemsRequest { Username = "username", Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }

        [Theory, ClassData(typeof(UserCustomListItemsRequest_TestData))]
        public void Test_UserCustomListItemsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                    IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class UserCustomListItemsRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private const string _id = "123";
            private static readonly TraktListItemType _type = TraktListItemType.Episode;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly UserCustomListItemsRequest _request1 = new UserCustomListItemsRequest
            {
                Username = _username,
                Id = _id
            };

            private static readonly UserCustomListItemsRequest _request2 = new UserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Type = _type
            };

            private static readonly UserCustomListItemsRequest _request3 = new UserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserCustomListItemsRequest _request4 = new UserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Page = _page
            };

            private static readonly UserCustomListItemsRequest _request5 = new UserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Limit = _limit
            };

            private static readonly UserCustomListItemsRequest _request6 = new UserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserCustomListItemsRequest _request7 = new UserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserCustomListItemsRequest _request8 = new UserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Type = _type,
                Page = _page
            };

            private static readonly UserCustomListItemsRequest _request9 = new UserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Type = _type,
                Limit = _limit
            };

            private static readonly UserCustomListItemsRequest _request10 = new UserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserCustomListItemsRequest _request11 = new UserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly UserCustomListItemsRequest _request12 = new UserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly UserCustomListItemsRequest _request13 = new UserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserCustomListItemsRequest _request14 = new UserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public UserCustomListItemsRequest_TestData()
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
                        ["username"] = _username,
                        ["id"] = _id
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
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
