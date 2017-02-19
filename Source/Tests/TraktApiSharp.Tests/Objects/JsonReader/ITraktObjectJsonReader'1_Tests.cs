namespace TraktApiSharp.Tests.Objects.JsonReader
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader")]
    public class ITraktObjectJsonReader_1_Tests
    {
        [Fact]
        public void Test_ITraktObjectJsonReader_1_Is_Interface()
        {
            typeof(ITraktObjectJsonReader<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktObjectJsonReader_1_Has_ReadObject_Method()
        {
            var methodInfo = typeof(ITraktObjectJsonReader<int>).GetMethods().FirstOrDefault(m => m.Name == "ReadObject");

            methodInfo.ReturnType.Should().Be(typeof(int));
            methodInfo.GetParameters().Should().NotBeEmpty().And.HaveCount(1);

            var parameterInfo = methodInfo.GetParameters().First();

            parameterInfo.Should().NotBeNull();
            parameterInfo.ParameterType.Should().Be(typeof(string));
            parameterInfo.Name.Should().Be("json");
        }
    }
}
