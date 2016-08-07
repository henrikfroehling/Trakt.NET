namespace TraktApiSharp.Tests.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktObjectTypeTests
    {
        [TestMethod]
        public void TestTraktObjectTypeIsTraktEnumeration()
        {
            var enumeration = new TraktObjectType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktObjectTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktObjectType>();

            allValues.Should().NotBeNull().And.HaveCount(7);
            allValues.Should().Contain(new List<TraktObjectType>() { TraktObjectType.Unspecified, TraktObjectType.Movie,
                                                                     TraktObjectType.Show, TraktObjectType.Season,
                                                                     TraktObjectType.Episode, TraktObjectType.List,
                                                                     TraktObjectType.All });
        }
    }
}
