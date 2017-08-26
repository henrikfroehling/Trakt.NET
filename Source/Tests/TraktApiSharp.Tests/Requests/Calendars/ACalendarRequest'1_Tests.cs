namespace TraktApiSharp.Tests.Requests.Calendars
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Calendars;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Calendars")]
    public class ACalendarRequest_1_Tests
    {
        internal class CalendarRequestMock : ACalendarRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ACalendarRequest_1_IsAbstract()
        {
            typeof(ACalendarRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ACalendarRequest_1_Has_GenericTypeParameter()
        {
            typeof(ACalendarRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ACalendarRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ACalendarRequest_1_Inherits_ATraktGetRequest_1()
        {
            typeof(ACalendarRequest<int>).IsSubclassOf(typeof(AGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ACalendarRequest_1_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(ACalendarRequest<>).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_ACalendarRequest_1_Implements_ITraktSupportsFilter_Interface()
        {
            typeof(ACalendarRequest<>).GetInterfaces().Should().Contain(typeof(ISupportsFilter));
        }

        [Fact]
        public void Test_ACalendarRequest_1_Has_StartDate_Property()
        {
            var propertyInfo = typeof(ACalendarRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "StartDate")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ACalendarRequest_1_Has_Days_Property()
        {
            var propertyInfo = typeof(ACalendarRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Days")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ACalendarRequest_1_Validate_Throws_Exceptions()
        {
            var requestMock = new CalendarRequestMock { Days = 0 };

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentOutOfRangeException>();

            requestMock = new CalendarRequestMock { Days = 32 };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}
