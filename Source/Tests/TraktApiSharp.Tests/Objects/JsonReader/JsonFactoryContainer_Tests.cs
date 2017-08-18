namespace TraktApiSharp.Tests.Objects.JsonReader
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader")]
    public class JsonFactoryContainer_Tests
    {
        [Fact]
        public void Test_JsonFactoryContainer_Has_CreateObjectReader_Method()
        {
            var methodInfo = typeof(JsonFactoryContainer).GetMethods().FirstOrDefault(m => m.Name == "CreateObjectReader");
            methodInfo.GetParameters().Should().BeEmpty();
            methodInfo.IsGenericMethod.Should().BeTrue();
        }

        [Fact]
        public void Test_JsonFactoryContainer_Has_CreateArrayReader_Method()
        {
            var methodInfo = typeof(JsonFactoryContainer).GetMethods().FirstOrDefault(m => m.Name == "CreateArrayReader");
            methodInfo.GetParameters().Should().BeEmpty();
            methodInfo.IsGenericMethod.Should().BeTrue();
        }

        [Fact]
        public void Test_JsonFactoryContainer_Has_GetReaderFactory_Method()
        {
            var methodInfo = typeof(JsonFactoryContainer).GetMethods().FirstOrDefault(m => m.Name == "GetReaderFactory");
            methodInfo.GetParameters().Should().BeEmpty();
            methodInfo.IsGenericMethod.Should().BeTrue();
        }
    }
}
