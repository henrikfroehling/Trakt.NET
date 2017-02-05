namespace TraktApiSharp.Tests.Requests.Calendars
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Calendars;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Calendars")]
    public class ATraktCalendarRequest_1_Tests
    {
        internal class TraktCalendarRequestMock : ATraktCalendarRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ATraktCalendarRequest_1_IsAbstract()
        {
            typeof(ATraktCalendarRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktCalendarRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktCalendarRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktCalendarRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktCalendarRequest_1_Inherits_ATraktGetRequest_1()
        {
            typeof(ATraktCalendarRequest<int>).IsSubclassOf(typeof(ATraktGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktCalendarRequest_1_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(ATraktCalendarRequest<>).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_ATraktCalendarRequest_1_Implements_ITraktSupportsFilter_Interface()
        {
            typeof(ATraktCalendarRequest<>).GetInterfaces().Should().Contain(typeof(ITraktSupportsFilter));
        }

        [Fact]
        public void Test_ATraktCalendarRequest_1_Has_StartDate_Property()
        {
            var startDatePropertyInfo = typeof(ATraktCalendarRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "StartDate")
                    .FirstOrDefault();

            startDatePropertyInfo.CanRead.Should().BeTrue();
            startDatePropertyInfo.CanWrite.Should().BeTrue();
            startDatePropertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ATraktCalendarRequest_1_Has_Days_Property()
        {
            var daysPropertyInfo = typeof(ATraktCalendarRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Days")
                    .FirstOrDefault();

            daysPropertyInfo.CanRead.Should().BeTrue();
            daysPropertyInfo.CanWrite.Should().BeTrue();
            daysPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ATraktCalendarRequest_1_Validate_Throws_Exceptions()
        {
            var requestMock = new TraktCalendarRequestMock { Days = 0 };

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentOutOfRangeException>();

            requestMock = new TraktCalendarRequestMock { Days = 32 };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}
