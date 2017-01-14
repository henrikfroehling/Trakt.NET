﻿namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;

    [TestClass]
    public class ATraktUsersListGetRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestATraktUsersListGetRequestIsAbstract()
        {
            typeof(ATraktUsersListGetRequest).IsAbstract.Should().BeTrue();
        }
    }
}
