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
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserHiddenItemsRequest_Tests
    {
        [Fact]
        public void Test_TraktUserHiddenItemsRequest_Is_Not_Abstract()
        {
            typeof(TraktUserHiddenItemsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserHiddenItemsRequest_Is_Sealed()
        {
            typeof(TraktUserHiddenItemsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserHiddenItemsRequest_Inherits_ATraktUsersPagedGetRequest_1()
        {
            typeof(TraktUserHiddenItemsRequest).IsSubclassOf(typeof(ATraktUsersPagedGetRequest<ITraktUserHiddenItem>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserHiddenItemsRequest_Has_Section_Property()
        {
            var propertyInfo = typeof(TraktUserHiddenItemsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Section")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktHiddenItemsSection));
        }

        [Fact]
        public void Test_TraktUserHiddenItemsRequest_Has_Type_Property()
        {
            var propertyInfo = typeof(TraktUserHiddenItemsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktHiddenItemType));
        }

        [Fact]
        public void Test_TraktUserHiddenItemsRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUserHiddenItemsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserHiddenItemsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserHiddenItemsRequest();
            request.UriTemplate.Should().Be("users/hidden/{section}{?type,extended,page,limit}");
        }

        [Fact]
        public void Test_TraktUserHiddenItemsRequest_Validate_Throws_Exceptions()
        {
            // section is null
            var requestMock = new TraktUserHiddenItemsRequest();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // section is unspecified
            requestMock = new TraktUserHiddenItemsRequest { Section = TraktHiddenItemsSection.Unspecified };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktUserHiddenItemsRequest_TestData))]
        public void Test_TraktUserHiddenItemsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                     IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktUserHiddenItemsRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktHiddenItemsSection _section = TraktHiddenItemsSection.ProgressWatched;
            private static readonly TraktHiddenItemType _itemType = TraktHiddenItemType.Season;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly TraktUserHiddenItemsRequest _request1 = new TraktUserHiddenItemsRequest
            {
                Section = _section
            };

            private static readonly TraktUserHiddenItemsRequest _request2 = new TraktUserHiddenItemsRequest
            {
                Section = _section,
                Type = _itemType
            };

            private static readonly TraktUserHiddenItemsRequest _request3 = new TraktUserHiddenItemsRequest
            {
                Section = _section,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUserHiddenItemsRequest _request4 = new TraktUserHiddenItemsRequest
            {
                Section = _section,
                Page = _page
            };

            private static readonly TraktUserHiddenItemsRequest _request5 = new TraktUserHiddenItemsRequest
            {
                Section = _section,
                Limit = _limit
            };

            private static readonly TraktUserHiddenItemsRequest _request6 = new TraktUserHiddenItemsRequest
            {
                Section = _section,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserHiddenItemsRequest _request7 = new TraktUserHiddenItemsRequest
            {
                Section = _section,
                Type = _itemType,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUserHiddenItemsRequest _request8 = new TraktUserHiddenItemsRequest
            {
                Section = _section,
                Type = _itemType,
                Page = _page
            };

            private static readonly TraktUserHiddenItemsRequest _request9 = new TraktUserHiddenItemsRequest
            {
                Section = _section,
                Type = _itemType,
                Limit = _limit
            };

            private static readonly TraktUserHiddenItemsRequest _request10 = new TraktUserHiddenItemsRequest
            {
                Section = _section,
                Type = _itemType,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserHiddenItemsRequest _request11 = new TraktUserHiddenItemsRequest
            {
                Section = _section,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktUserHiddenItemsRequest _request12 = new TraktUserHiddenItemsRequest
            {
                Section = _section,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktUserHiddenItemsRequest _request13 = new TraktUserHiddenItemsRequest
            {
                Section = _section,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserHiddenItemsRequest _request14 = new TraktUserHiddenItemsRequest
            {
                Section = _section,
                Type = _itemType,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktUserHiddenItemsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strSection = _section.UriName;
                var strItemType = _itemType.UriName;
                var strExtendedInfo = _extendedInfo.ToString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["type"] = strItemType
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["type"] = strItemType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["type"] = strItemType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["type"] = strItemType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["type"] = strItemType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["type"] = strItemType,
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
