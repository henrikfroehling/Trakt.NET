﻿namespace TraktApiSharp.Tests.Extensions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using TraktApiSharp.Extensions;

    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod]
        public void TestDateTimeExtensionsMin()
        {
            var datetime1 = DateTime.Now;
            var datetime2 = DateTime.Now.AddSeconds(1);

            datetime1.Min(datetime2).Should().Be(datetime1);
            datetime2.Min(datetime1).Should().Be(datetime1);
        }

        [TestMethod]
        public void TestDateTimeExtensionsMax()
        {
            var datetime1 = DateTime.Now;
            var datetime2 = DateTime.Now.AddSeconds(1);

            datetime1.Max(datetime2).Should().Be(datetime2);
            datetime2.Max(datetime1).Should().Be(datetime2);
        }

        [TestMethod]
        public void TestDateTimeExtensionsYearsBetween()
        {
            var datetime1 = DateTime.Now;
            var datetime2 = DateTime.Now.AddYears(1);

            datetime1.YearsBetween(datetime2).Should().Be(1);
            datetime2.YearsBetween(datetime1).Should().Be(1);

            var datetime3 = DateTime.Now;
            var datetime4 = DateTime.Now.AddYears(0);

            datetime3.YearsBetween(datetime4).Should().Be(0);
            datetime4.YearsBetween(datetime3).Should().Be(0);

            var datetime5 = DateTime.Now;
            var datetime6 = DateTime.Now.AddYears(5);

            datetime5.YearsBetween(datetime6).Should().Be(5);
            datetime6.YearsBetween(datetime5).Should().Be(5);

            var datetime7 = DateTime.Now;
            var datetime8 = DateTime.Now.AddYears(-5);

            datetime7.YearsBetween(datetime8).Should().Be(5);
            datetime8.YearsBetween(datetime7).Should().Be(5);
        }
    }
}
