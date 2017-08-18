namespace TraktApiSharp.Tests.Objects.Get.People.Credits.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits;
    using TraktApiSharp.Objects.Get.People.Credits.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class TraktPersonShowCreditsCastItemArrayJsonReader_Tests
    {
        [Fact]
        public void Test_TraktPersonShowCreditsCastItemArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(TraktPersonShowCreditsCastItemArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktPersonShowCreditsCastItem>));
        }
    }
}
