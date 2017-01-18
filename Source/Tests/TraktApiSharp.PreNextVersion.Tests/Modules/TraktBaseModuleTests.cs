namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Modules;

    [TestClass]
    public class TraktBaseModuleTests
    {
        [TestMethod]
        public void TestTraktBaseModuleIsAbstract()
        {
            typeof(TraktBaseModule).IsAbstract.Should().BeTrue();
        }
    }
}
