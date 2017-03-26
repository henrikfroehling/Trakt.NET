namespace TraktApiSharp.Tests.Requests.Shows.OAuth
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Requests.Shows.OAuth;
    using Xunit;

    [Category("Requests.Shows.OAuth")]
    public class TraktShowCollectionProgressRequest_Tests
    {
        [Fact]
        public void Test_TraktShowCollectionProgressRequest_Is_Not_Abstract()
        {
            typeof(TraktShowCollectionProgressRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowCollectionProgressRequest_Is_Sealed()
        {
            typeof(TraktShowCollectionProgressRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowCollectionProgressRequest_Inherits_ATraktShowProgressRequest_1()
        {
            typeof(TraktShowCollectionProgressRequest).IsSubclassOf(typeof(ATraktShowProgressRequest<TraktShowCollectionProgress>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowCollectionProgressRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowCollectionProgressRequest();
            request.UriTemplate.Should().Be("shows/{id}/progress/collection{?hidden,specials,count_specials}");
        }

        [Theory, ClassData(typeof(TraktShowCollectionProgressRequest_TestData))]
        public void Test_TraktShowCollectionProgressRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                            IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktShowCollectionProgressRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const bool _hidden = true;
            private const bool _specials = true;
            private const bool _countSpecials = true;

            private static readonly TraktShowCollectionProgressRequest _request1 = new TraktShowCollectionProgressRequest
            {
                Id = _id
            };

            private static readonly TraktShowCollectionProgressRequest _request2 = new TraktShowCollectionProgressRequest
            {
                Id = _id,
                Hidden = _hidden
            };

            private static readonly TraktShowCollectionProgressRequest _request3 = new TraktShowCollectionProgressRequest
            {
                Id = _id,
                Specials = _specials
            };

            private static readonly TraktShowCollectionProgressRequest _request4 = new TraktShowCollectionProgressRequest
            {
                Id = _id,
                CountSpecials = _countSpecials
            };

            private static readonly TraktShowCollectionProgressRequest _request5 = new TraktShowCollectionProgressRequest
            {
                Id = _id,
                Hidden = _hidden,
                Specials = _specials
            };

            private static readonly TraktShowCollectionProgressRequest _request6 = new TraktShowCollectionProgressRequest
            {
                Id = _id,
                Hidden = _hidden,
                CountSpecials = _countSpecials
            };

            private static readonly TraktShowCollectionProgressRequest _request7 = new TraktShowCollectionProgressRequest
            {
                Id = _id,
                Specials = _specials,
                CountSpecials = _countSpecials
            };

            private static readonly TraktShowCollectionProgressRequest _request8 = new TraktShowCollectionProgressRequest
            {
                Id = _id,
                Hidden = _hidden,
                Specials = _specials,
                CountSpecials = _countSpecials
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktShowCollectionProgressRequest_TestData()
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
