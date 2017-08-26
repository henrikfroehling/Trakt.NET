namespace TraktApiSharp.Tests.Requests.Search
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Search;
    using Xunit;

    [Category("Requests.Search")]
    public class SearchIdLookupRequest_Tests
    {
        [Fact]
        public void Test_SearchIdLookupRequest_IsNotAbstract()
        {
            typeof(SearchIdLookupRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SearchIdLookupRequest_IsSealed()
        {
            typeof(SearchIdLookupRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SearchIdLookupRequest_Inherits_ATraktSearchRequest()
        {
            typeof(SearchIdLookupRequest).IsSubclassOf(typeof(ASearchRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_SearchIdLookupRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new SearchIdLookupRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_SearchIdLookupRequest_Has_Valid_UriTemplate()
        {
            var request = new SearchIdLookupRequest();
            request.UriTemplate.Should().Be("search/{id_type}/{id}{?type,extended,page,limit}");
        }

        [Fact]
        public void Test_SearchIdLookupRequest_Has_IdType_Property()
        {
            var propertyInfo = typeof(SearchIdLookupRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "IdType")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktSearchIdType));
        }

        [Fact]
        public void Test_SearchIdLookupRequest_Has_LookupId_Property()
        {
            var propertyInfo = typeof(SearchIdLookupRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "LookupId")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_SearchIdLookupRequest_Validate_Throws_ArgumentNullException()
        {
            // no id type set
            var request = new SearchIdLookupRequest { LookupId = "lookupId" };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // no lookup id set
            request = new SearchIdLookupRequest { IdType = TraktSearchIdType.Trakt };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Test_SearchIdLookupRequest_Validate_Throws_ArgumentException()
        {
            // id type is unspecified
            var request = new SearchIdLookupRequest { LookupId = "lookupId", IdType = TraktSearchIdType.Unspecified };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // lookup id is empty
            request = new SearchIdLookupRequest { LookupId = string.Empty, IdType = TraktSearchIdType.Trakt };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // lookup id contains spaces
            request = new SearchIdLookupRequest { LookupId = "lookup id", IdType = TraktSearchIdType.Trakt };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(SearchIdLookupRequest_TestData))]
        public void Test_SearchIdLookupRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                    IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class SearchIdLookupRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktSearchIdType _idType = TraktSearchIdType.Trakt;
            private const string _lookupId = "searchQuery";
            private static readonly TraktSearchResultType _resultTypes = TraktSearchResultType.Movie | TraktSearchResultType.Show;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktSearchField _searchFields = TraktSearchField.Description | TraktSearchField.Title;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly SearchIdLookupRequest _request1 = new SearchIdLookupRequest
            {
                IdType = _idType,
                LookupId = _lookupId
            };

            private static readonly SearchIdLookupRequest _request2 = new SearchIdLookupRequest
            {
                IdType = _idType,
                LookupId = _lookupId,
                ResultTypes = _resultTypes
            };

            private static readonly SearchIdLookupRequest _request3 = new SearchIdLookupRequest
            {
                IdType = _idType,
                LookupId = _lookupId,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SearchIdLookupRequest _request4 = new SearchIdLookupRequest
            {
                IdType = _idType,
                LookupId = _lookupId,
                Page = _page
            };

            private static readonly SearchIdLookupRequest _request5 = new SearchIdLookupRequest
            {
                IdType = _idType,
                LookupId = _lookupId,
                Limit = _limit
            };

            private static readonly SearchIdLookupRequest _request6 = new SearchIdLookupRequest
            {
                IdType = _idType,
                LookupId = _lookupId,
                ResultTypes = _resultTypes,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SearchIdLookupRequest _request7 = new SearchIdLookupRequest
            {
                IdType = _idType,
                LookupId = _lookupId,
                ResultTypes = _resultTypes,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly SearchIdLookupRequest _request8 = new SearchIdLookupRequest
            {
                IdType = _idType,
                LookupId = _lookupId,
                ResultTypes = _resultTypes,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly SearchIdLookupRequest _request9 = new SearchIdLookupRequest
            {
                IdType = _idType,
                LookupId = _lookupId,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly SearchIdLookupRequest _request10 = new SearchIdLookupRequest
            {
                IdType = _idType,
                LookupId = _lookupId,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly SearchIdLookupRequest _request11 = new SearchIdLookupRequest
            {
                IdType = _idType,
                LookupId = _lookupId,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public SearchIdLookupRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strIdType = _idType.UriName;
                var strResultTypes = _resultTypes.UriName;
                var strExtendedInfo = _extendedInfo.ToString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id_type"] = strIdType,
                        ["id"] = _lookupId
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id_type"] = strIdType,
                        ["id"] = _lookupId,
                        ["type"] = strResultTypes
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id_type"] = strIdType,
                        ["id"] = _lookupId,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id_type"] = strIdType,
                        ["id"] = _lookupId,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id_type"] = strIdType,
                        ["id"] = _lookupId,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id_type"] = strIdType,
                        ["id"] = _lookupId,
                        ["type"] = strResultTypes,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id_type"] = strIdType,
                        ["id"] = _lookupId,
                        ["type"] = strResultTypes,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id_type"] = strIdType,
                        ["id"] = _lookupId,
                        ["type"] = strResultTypes,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id_type"] = strIdType,
                        ["id"] = _lookupId,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id_type"] = strIdType,
                        ["id"] = _lookupId,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id_type"] = strIdType,
                        ["id"] = _lookupId,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
