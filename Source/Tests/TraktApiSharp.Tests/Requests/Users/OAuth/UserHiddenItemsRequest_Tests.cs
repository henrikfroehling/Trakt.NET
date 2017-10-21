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
    public class UserHiddenItemsRequest_Tests
    {
        [Fact]
        public void Test_UserHiddenItemsRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserHiddenItemsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserHiddenItemsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserHiddenItemsRequest();
            request.UriTemplate.Should().Be("users/hidden/{section}{?type,extended,page,limit}");
        }

        [Fact]
        public void Test_UserHiddenItemsRequest_Validate_Throws_Exceptions()
        {
            // section is null
            var requestMock = new UserHiddenItemsRequest();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // section is unspecified
            requestMock = new UserHiddenItemsRequest { Section = TraktHiddenItemsSection.Unspecified };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(UserHiddenItemsRequest_TestData))]
        public void Test_UserHiddenItemsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class UserHiddenItemsRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktHiddenItemsSection _section = TraktHiddenItemsSection.ProgressWatched;
            private static readonly TraktHiddenItemType _itemType = TraktHiddenItemType.Season;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly UserHiddenItemsRequest _request1 = new UserHiddenItemsRequest
            {
                Section = _section
            };

            private static readonly UserHiddenItemsRequest _request2 = new UserHiddenItemsRequest
            {
                Section = _section,
                Type = _itemType
            };

            private static readonly UserHiddenItemsRequest _request3 = new UserHiddenItemsRequest
            {
                Section = _section,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserHiddenItemsRequest _request4 = new UserHiddenItemsRequest
            {
                Section = _section,
                Page = _page
            };

            private static readonly UserHiddenItemsRequest _request5 = new UserHiddenItemsRequest
            {
                Section = _section,
                Limit = _limit
            };

            private static readonly UserHiddenItemsRequest _request6 = new UserHiddenItemsRequest
            {
                Section = _section,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserHiddenItemsRequest _request7 = new UserHiddenItemsRequest
            {
                Section = _section,
                Type = _itemType,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserHiddenItemsRequest _request8 = new UserHiddenItemsRequest
            {
                Section = _section,
                Type = _itemType,
                Page = _page
            };

            private static readonly UserHiddenItemsRequest _request9 = new UserHiddenItemsRequest
            {
                Section = _section,
                Type = _itemType,
                Limit = _limit
            };

            private static readonly UserHiddenItemsRequest _request10 = new UserHiddenItemsRequest
            {
                Section = _section,
                Type = _itemType,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserHiddenItemsRequest _request11 = new UserHiddenItemsRequest
            {
                Section = _section,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly UserHiddenItemsRequest _request12 = new UserHiddenItemsRequest
            {
                Section = _section,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly UserHiddenItemsRequest _request13 = new UserHiddenItemsRequest
            {
                Section = _section,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserHiddenItemsRequest _request14 = new UserHiddenItemsRequest
            {
                Section = _section,
                Type = _itemType,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public UserHiddenItemsRequest_TestData()
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
