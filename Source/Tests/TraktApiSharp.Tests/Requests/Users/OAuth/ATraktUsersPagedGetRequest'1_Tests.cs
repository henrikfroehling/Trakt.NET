namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class ATraktUsersPagedGetRequest_1_Tests
    {
        internal class TraktUsersPagedGetRequestMock : ATraktUsersPagedGetRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }

            public override void Validate()
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Test_ATraktUsersPagedGetRequest_1_Is_Abstract()
        {
            typeof(ATraktUsersPagedGetRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktUsersPagedGetRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktUsersPagedGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktUsersPagedGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktUsersPagedGetRequest_1_Inherits_ATraktUsersGetRequest_1()
        {
            typeof(ATraktUsersPagedGetRequest<int>).IsSubclassOf(typeof(AUsersGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktUsersPagedGetRequest_1_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(ATraktUsersPagedGetRequest<>).GetInterfaces().Should().Contain(typeof(ISupportsPagination));
        }

        [Fact]
        public void Test_ATraktUsersPagedGetRequest_1_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUsersPagedGetRequestMock();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Theory, ClassData(typeof(TraktUsersPagedGetRequestMock_TestData))]
        public void Test_ATraktUsersPagedGetRequest_1_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                      IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktUsersPagedGetRequestMock_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly TraktUsersPagedGetRequestMock _request1 = new TraktUsersPagedGetRequestMock();

            private static readonly TraktUsersPagedGetRequestMock _request2 = new TraktUsersPagedGetRequestMock
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUsersPagedGetRequestMock _request3 = new TraktUsersPagedGetRequestMock
            {
                Page = _page
            };

            private static readonly TraktUsersPagedGetRequestMock _request4 = new TraktUsersPagedGetRequestMock
            {
                Limit = _limit
            };

            private static readonly TraktUsersPagedGetRequestMock _request5 = new TraktUsersPagedGetRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktUsersPagedGetRequestMock _request6 = new TraktUsersPagedGetRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktUsersPagedGetRequestMock _request7 = new TraktUsersPagedGetRequestMock
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUsersPagedGetRequestMock _request8 = new TraktUsersPagedGetRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktUsersPagedGetRequestMock_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strExtendedInfo = _extendedInfo.ToString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
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
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
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
