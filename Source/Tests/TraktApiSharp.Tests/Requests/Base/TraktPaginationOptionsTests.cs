namespace TraktApiSharp.Tests.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktPaginationOptionsTests
    {
        [TestMethod]
        public void TestTraktPaginationOptionsConstructor()
        {
            var options1 = new TraktPaginationOptions();

            options1.Page.Should().NotHaveValue();
            options1.Limit.Should().NotHaveValue();

            var options2 = new TraktPaginationOptions(1, null);

            options2.Page.Should().Be(1);
            options2.Limit.Should().NotHaveValue();

            var options3 = new TraktPaginationOptions(null, 1);

            options3.Page.Should().NotHaveValue();
            options3.Limit.Should().Be(1);

            var options4 = new TraktPaginationOptions(1, 1);

            options4.Page.Should().Be(1);
            options4.Limit.Should().Be(1);

            var options5 = new TraktPaginationOptions(null, null);

            options5.Page.Should().NotHaveValue();
            options5.Limit.Should().NotHaveValue();
        }
    }
}
