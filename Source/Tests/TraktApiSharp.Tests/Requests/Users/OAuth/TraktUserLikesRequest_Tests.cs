namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserLikesRequest_Tests
    {
        [Fact]
        public void Test_TraktUserLikesRequest_Is_Not_Abstract()
        {
            typeof(TraktUserLikesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserLikesRequest_Is_Sealed()
        {
            typeof(TraktUserLikesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserLikesRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(TraktUserLikesRequest).IsSubclassOf(typeof(ATraktGetRequest<ITraktUserLikeItem>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserLikesRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(TraktUserLikesRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_TraktUserLikesRequest_Has_Type_Property()
        {
            var propertyInfo = typeof(TraktUserLikesRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktUserLikeType));
        }

        [Fact]
        public void Test_TraktUserLikesRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUserLikesRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserLikesRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserLikesRequest();
            request.UriTemplate.Should().Be("users/likes{/type}{?page,limit}");
        }

        [Theory, ClassData(typeof(TraktUserLikesRequest_TestData))]
        public void Test_TraktUserLikesRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                               IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktUserLikesRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktUserLikeType _type = TraktUserLikeType.Comment;
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly TraktUserLikesRequest _request1 = new TraktUserLikesRequest();

            private static readonly TraktUserLikesRequest _request2 = new TraktUserLikesRequest
            {
                Type = _type
            };

            private static readonly TraktUserLikesRequest _request3 = new TraktUserLikesRequest
            {
                Page = _page
            };

            private static readonly TraktUserLikesRequest _request4 = new TraktUserLikesRequest
            {
                Limit = _limit
            };

            private static readonly TraktUserLikesRequest _request5 = new TraktUserLikesRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserLikesRequest _request6 = new TraktUserLikesRequest
            {
                Type = _type,
                Page = _page
            };

            private static readonly TraktUserLikesRequest _request7 = new TraktUserLikesRequest
            {
                Type = _type,
                Limit = _limit
            };

            private static readonly TraktUserLikesRequest _request8 = new TraktUserLikesRequest
            {
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktUserLikesRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strType = _type.UriName;

                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
