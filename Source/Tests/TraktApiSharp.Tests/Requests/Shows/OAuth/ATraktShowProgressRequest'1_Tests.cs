namespace TraktApiSharp.Tests.Requests.Shows.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Shows.OAuth;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Shows.OAuth")]
    public class ATraktShowProgressRequest_1_Tests
    {
        internal class TraktShowProgressRequestMock : ATraktShowProgressRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ATraktShowProgressRequest_1_Is_Abstract()
        {
            typeof(ATraktShowProgressRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktShowProgressRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktShowProgressRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktShowProgressRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktShowProgressRequest_1_Inherits_ATraktGetRequest_1()
        {
            typeof(ATraktShowProgressRequest<int>).IsSubclassOf(typeof(ATraktGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktShowProgressRequest_1_Implements_ITraktHasId_Interface()
        {
            typeof(ATraktShowProgressRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_ATraktShowProgressRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new TraktShowProgressRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ATraktShowProgressRequest_1_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktShowProgressRequestMock();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.Shows);
        }

        [Fact]
        public void Test_ATraktShowProgressRequest_1_Has_Hidden_Property()
        {
            var propertyInfo = typeof(ATraktShowProgressRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Hidden")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }

        [Fact]
        public void Test_ATraktShowProgressRequest_1_Has_Specials_Property()
        {
            var propertyInfo = typeof(ATraktShowProgressRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Specials")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }

        [Fact]
        public void Test_ATraktShowProgressRequest_1_Has_CountSpecials_Property()
        {
            var propertyInfo = typeof(ATraktShowProgressRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "CountSpecials")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }

        [Fact]
        public void Test_ATraktShowProgressRequest_1_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new TraktShowProgressRequestMock();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            requestMock = new TraktShowProgressRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            requestMock = new TraktShowProgressRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktShowProgressRequestMock_TestData))]
        public void Test_ATraktShowProgressRequest_1_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                     IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktShowProgressRequestMock_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const bool _hidden = true;
            private const bool _specials = true;
            private const bool _countSpecials = true;
            
            private static readonly TraktShowProgressRequestMock _request1 = new TraktShowProgressRequestMock
            {
                Id = _id
            };

            private static readonly TraktShowProgressRequestMock _request2 = new TraktShowProgressRequestMock
            {
                Id = _id,
                Hidden = _hidden
            };

            private static readonly TraktShowProgressRequestMock _request3 = new TraktShowProgressRequestMock
            {
                Id = _id,
                Specials = _specials
            };

            private static readonly TraktShowProgressRequestMock _request4 = new TraktShowProgressRequestMock
            {
                Id = _id,
                CountSpecials = _countSpecials
            };

            private static readonly TraktShowProgressRequestMock _request5 = new TraktShowProgressRequestMock
            {
                Id = _id,
                Hidden = _hidden,
                Specials = _specials
            };

            private static readonly TraktShowProgressRequestMock _request6 = new TraktShowProgressRequestMock
            {
                Id = _id,
                Hidden = _hidden,
                CountSpecials = _countSpecials
            };

            private static readonly TraktShowProgressRequestMock _request7 = new TraktShowProgressRequestMock
            {
                Id = _id,
                Specials = _specials,
                CountSpecials = _countSpecials
            };

            private static readonly TraktShowProgressRequestMock _request8 = new TraktShowProgressRequestMock
            {
                Id = _id,
                Hidden = _hidden,
                Specials = _specials,
                CountSpecials = _countSpecials
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktShowProgressRequestMock_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strHidden = _hidden.ToString().ToLower();
                var strSpecials = _specials.ToString().ToLower();
                var strCountSpecials = _countSpecials.ToString().ToLower();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["hidden"] = strHidden
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["specials"] = strSpecials
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["count_specials"] = strCountSpecials
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["hidden"] = strHidden,
                        ["specials"] = strSpecials
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["hidden"] = strHidden,
                        ["count_specials"] = strCountSpecials
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["specials"] = strSpecials,
                        ["count_specials"] = strCountSpecials
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["hidden"] = strHidden,
                        ["specials"] = strSpecials,
                        ["count_specials"] = strCountSpecials
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
