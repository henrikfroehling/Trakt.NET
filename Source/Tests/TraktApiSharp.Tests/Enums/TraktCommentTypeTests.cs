namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktCommentTypeTests
    {
        [TestMethod]
        public void TestTraktCommentTypeIsTraktEnumeration()
        {
            var enumeration = new TraktCommentType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktCommentTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktCommentType>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktCommentType>() { TraktCommentType.Unspecified, TraktCommentType.Review,
                                                                      TraktCommentType.Shout, TraktCommentType.All });
        }
    }
}
