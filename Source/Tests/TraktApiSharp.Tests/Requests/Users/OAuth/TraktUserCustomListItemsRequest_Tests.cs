namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Get.Users.Lists.Implementations;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserCustomListItemsRequest_Tests
    {
        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Is_Not_Abstract()
        {
            typeof(TraktUserCustomListItemsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Is_Sealed()
        {
            typeof(TraktUserCustomListItemsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Inherits_ATraktUsersPagedGetRequest_1()
        {
            typeof(TraktUserCustomListItemsRequest).IsSubclassOf(typeof(ATraktUsersPagedGetRequest<TraktListItem>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktUserCustomListItemsRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserCustomListItemsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Has_Type_Property()
        {
            var propertyInfo = typeof(TraktUserCustomListItemsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktListItemType));
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUserCustomListItemsRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktUserCustomListItemsRequest();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.Lists);
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserCustomListItemsRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/items{/type}{?extended,page,limit}");
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserCustomListItemsRequest { Id = "123" };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserCustomListItemsRequest { Username = string.Empty, Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserCustomListItemsRequest { Username = "invalid username", Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id is null
            request = new TraktUserCustomListItemsRequest { Username = "username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktUserCustomListItemsRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktUserCustomListItemsRequest { Username = "username", Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktUserCustomListItemsRequest_TestData))]
        public void Test_TraktUserCustomListItemsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                         IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktUserCustomListItemsRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private const string _id = "123";
            private static readonly TraktListItemType _type = TraktListItemType.Episode;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly TraktUserCustomListItemsRequest _request1 = new TraktUserCustomListItemsRequest
            {
                Username = _username,
                Id = _id
            };

            private static readonly TraktUserCustomListItemsRequest _request2 = new TraktUserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Type = _type
            };

            private static readonly TraktUserCustomListItemsRequest _request3 = new TraktUserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUserCustomListItemsRequest _request4 = new TraktUserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Page = _page
            };

            private static readonly TraktUserCustomListItemsRequest _request5 = new TraktUserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Limit = _limit
            };

            private static readonly TraktUserCustomListItemsRequest _request6 = new TraktUserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserCustomListItemsRequest _request7 = new TraktUserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUserCustomListItemsRequest _request8 = new TraktUserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Type = _type,
                Page = _page
            };

            private static readonly TraktUserCustomListItemsRequest _request9 = new TraktUserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Type = _type,
                Limit = _limit
            };

            private static readonly TraktUserCustomListItemsRequest _request10 = new TraktUserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserCustomListItemsRequest _request11 = new TraktUserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktUserCustomListItemsRequest _request12 = new TraktUserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktUserCustomListItemsRequest _request13 = new TraktUserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserCustomListItemsRequest _request14 = new TraktUserCustomListItemsRequest
            {
                Username = _username,
                Id = _id,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktUserCustomListItemsRequest_TestData()
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
