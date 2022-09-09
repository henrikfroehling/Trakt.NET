namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserSavedFiltersRequest_Tests
    {
        [Fact]
        public void Test_UserSavedFiltersRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserSavedFiltersRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserSavedFiltersRequest_Has_Valid_UriTemplate()
        {
            var request = new UserSavedFiltersRequest();
            request.UriTemplate.Should().Be("users/saved_filters{?section,page,limit}");
        }

        [Theory, ClassData(typeof(UserSavedFiltersRequest_TestData))]
        public void Test_UserSavedFiltersRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                 IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class UserSavedFiltersRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktFilterSection _section = TraktFilterSection.Movies;
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly UserSavedFiltersRequest _request1 = new UserSavedFiltersRequest
            {
                Section = _section
            };

            private static readonly UserSavedFiltersRequest _request2 = new UserSavedFiltersRequest
            {
                Page = _page
            };

            private static readonly UserSavedFiltersRequest _request3 = new UserSavedFiltersRequest
            {
                Limit = _limit
            };

            private static readonly UserSavedFiltersRequest _request4 = new UserSavedFiltersRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly UserSavedFiltersRequest _request5 = new UserSavedFiltersRequest
            {
                Section = _section,
                Page = _page
            };

            private static readonly UserSavedFiltersRequest _request6 = new UserSavedFiltersRequest
            {
                Section = _section,
                Limit = _limit
            };

            private static readonly UserSavedFiltersRequest _request7 = new UserSavedFiltersRequest
            {
                Section = _section,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public UserSavedFiltersRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strSection = _section.UriName;
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection
                    }});

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

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["section"] = strSection,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
