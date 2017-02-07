namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktHasUriPathParameters_Tests
    {
        [Fact]
        public void Test_ITraktHasUriPathParameters_Is_Interface()
        {
            typeof(ITraktHasUriPathParameters).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktHasUriPathParameters_Has_GetUriPathParameters_Method()
        {
            var methodInfo = typeof(ITraktHasUriPathParameters).GetMethods()
                                                               .Where(m => m.Name == "GetUriPathParameters")
                                                               .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
