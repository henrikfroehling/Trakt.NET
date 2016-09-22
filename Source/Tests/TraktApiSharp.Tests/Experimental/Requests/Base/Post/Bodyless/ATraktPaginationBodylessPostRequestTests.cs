﻿namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktPaginationBodylessPostRequestTests
    {
        [TestMethod]
        public void TestATraktPaginationBodylessPostRequestIsAbstract()
        {
            typeof(ATraktPaginationBodylessPostRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktPaginationBodylessPostRequestIsSubclassOfATraktPaginationRequest()
        {
            typeof(ATraktPaginationBodylessPostRequest<int>).IsSubclassOf(typeof(ATraktPaginationRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktPaginationBodylessPostRequestHasGenericTypeParameter()
        {
            typeof(ATraktPaginationBodylessPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPaginationBodylessPostRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestATraktPaginationBodylessPostRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktPaginationBodylessPostRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }
    }
}
