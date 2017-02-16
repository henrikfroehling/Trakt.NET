namespace TraktApiSharp.Tests.Objects.JsonReader
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader")]
    public class ITraktJsonReader_1_Tests
    {
        [Fact]
        public void Test_ITraktJsonReader_1_Is_Interface()
        {
            typeof(ITraktJsonReader<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktJsonReader_1_Has_Read_Method()
        {
            var methodInfo = typeof(ITraktJsonReader<int>).GetMethods().FirstOrDefault(m => m.Name == "Read");

            methodInfo.ReturnType.Should().Be(typeof(int));
            methodInfo.GetParameters().Should().NotBeEmpty().And.HaveCount(1);

            var parameterInfo = methodInfo.GetParameters().First();

            parameterInfo.Should().NotBeNull();
            parameterInfo.ParameterType.Should().Be(typeof(string));
            parameterInfo.Name.Should().Be("json");
        }
    }
}
