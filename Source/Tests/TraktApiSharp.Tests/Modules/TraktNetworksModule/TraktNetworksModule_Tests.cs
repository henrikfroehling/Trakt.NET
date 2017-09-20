namespace TraktApiSharp.Tests.Modules.TraktNetworksModule
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Modules;
    using Xunit;

    [Category("Modules.Networks")]
    public partial class TraktNetworksModule_Tests
    {
        [Fact]
        public void Test_TraktNetworksModule_Inherits_ITraktModule_Interface()
        {
            typeof(TraktNetworksModule).GetInterfaces().Should().Contain(typeof(ITraktModule));
        }
    }
}
