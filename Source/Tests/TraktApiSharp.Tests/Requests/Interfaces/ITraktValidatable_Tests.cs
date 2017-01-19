namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Interfaces")]
    public class ITraktValidatable_Tests
    {
        [Fact]
        public void Test_ITraktValidatable_Is_Interface()
        {
            typeof(ITraktValidatable).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktValidatable_Has_Validate_Method()
        {
            var methodInfo = typeof(ITraktValidatable).GetMethods()
                                                      .Where(m => m.Name == "Validate")
                                                      .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(void));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
