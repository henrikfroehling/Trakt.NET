namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Interfaces")]
    public class IValidatable_Tests
    {
        [Fact]
        public void Test_IValidatable_Is_Interface()
        {
            typeof(IValidatable).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IValidatable_Has_Validate_Method()
        {
            var methodInfo = typeof(IValidatable).GetMethods()
                                                      .Where(m => m.Name == "Validate")
                                                      .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(void));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
