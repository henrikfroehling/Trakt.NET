namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktUserLikeTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktUserLikeTypeConverter))]
            public TraktUserLikeType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktUserLikeTypeHasMembers()
        {
            typeof(TraktUserLikeType).GetEnumNames().Should().HaveCount(3)
                                                         .And.Contain("Unspecified", "Comment", "List");
        }

        [TestMethod]
        public void TestTraktUserLikeTypeGetAsString()
        {
            TraktUserLikeType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktUserLikeType.Comment.AsString().Should().Be("comment");
            TraktUserLikeType.List.AsString().Should().Be("list");
        }

        [TestMethod]
        public void TestTraktUserLikeTypeGetAsStringUriParameter()
        {
            TraktUserLikeType.Unspecified.AsStringUriParameter().Should().NotBeNull().And.BeEmpty();
            TraktUserLikeType.Comment.AsStringUriParameter().Should().Be("comments");
            TraktUserLikeType.List.AsStringUriParameter().Should().Be("lists");
        }

        [TestMethod]
        public void TestTraktUserLikeTypeWriteAndReadJson_Comment()
        {
            var obj = new TestObject { Value = TraktUserLikeType.Comment };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktUserLikeType.Comment);
        }

        [TestMethod]
        public void TestTraktUserLikeTypeWriteAndReadJson_List()
        {
            var obj = new TestObject { Value = TraktUserLikeType.List };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktUserLikeType.List);
        }

        [TestMethod]
        public void TestTraktUserLikeTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktUserLikeType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktUserLikeType.Unspecified);
        }
    }
}
