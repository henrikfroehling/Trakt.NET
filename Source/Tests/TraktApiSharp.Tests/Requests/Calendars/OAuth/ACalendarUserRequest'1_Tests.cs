namespace TraktApiSharp.Tests.Requests.Calendars.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Calendars;
    using TraktApiSharp.Requests.Calendars.OAuth;
    using Xunit;

    [Category("Requests.Calendars.OAuth")]
    public class ACalendarUserRequest_1_Tests
    {
        [Fact]
        public void Test_ACalendarUserRequest_1_IsAbstract()
        {
            typeof(ACalendarUserRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ACalendarUserRequest_1_Has_GenericTypeParameter()
        {
            typeof(ACalendarUserRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ACalendarUserRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ACalendarUserRequest_1_Inherits_ACalendarRequest()
        {
            typeof(ACalendarUserRequest<int>).IsSubclassOf(typeof(ACalendarRequest<int>)).Should().BeTrue();
        }
    }
}
