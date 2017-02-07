namespace TraktApiSharp.Tests.Requests.Calendars.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Calendars;
    using TraktApiSharp.Requests.Calendars.OAuth;
    using Xunit;

    [Category("Requests.Calendars.OAuth")]
    public class ATraktCalendarUserRequest_1_Tests
    {
        [Fact]
        public void Test_ATraktCalendarUserRequest_1_IsAbstract()
        {
            typeof(ATraktCalendarUserRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktCalendarUserRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktCalendarUserRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktCalendarUserRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktCalendarUserRequest_1_Inherits_ATraktCalendarRequest()
        {
            typeof(ATraktCalendarUserRequest<int>).IsSubclassOf(typeof(ATraktCalendarRequest<int>)).Should().BeTrue();
        }
    }
}
