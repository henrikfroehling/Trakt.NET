namespace TraktNet.Tests.Requests.Calendars
{
    using FluentAssertions;
    using System;
    using Traits;
    using TraktNet.Requests.Calendars;
    using Xunit;

    [Category("Requests.Calendars")]
    public class ACalendarRequest_1_Tests
    {
        internal class CalendarRequestMock : ACalendarRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ACalendarRequest_1_Validate_Throws_Exceptions()
        {
            var requestMock = new CalendarRequestMock { Days = 0 };

            Action act = () => requestMock.Validate();
            act.Should().Throw<ArgumentOutOfRangeException>();

            requestMock = new CalendarRequestMock { Days = 32 };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
