namespace TraktApiSharp.Tests.Extensions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Extensions;

    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void TestStringExtensionsFirstToUpper()
        {
            string expectedValue = "Abcdef";

            string value1 = "abcdef";
            string value2 = "ABCDEF";
            string value3 = "abcdeF";
            string value4 = "Abcdef";
            string value5 = "aBcDeF";
            string value6 = "AbCdEf";

            string value7 = " abcdef ";
            string value8 = " ABCDEF ";
            string value9 = " abcdeF ";
            string value10 = " Abcdef ";
            string value11 = " aBcDeF ";
            string value12 = " AbCdEf ";

            string value13 = " abcdef";
            string value14 = " ABCDEF";
            string value15 = " abcdeF";
            string value16 = " Abcdef";
            string value17 = " aBcDeF";
            string value18 = " AbCdEf";

            string value19 = "abcdef ";
            string value20 = "ABCDEF ";
            string value21 = "abcdeF ";
            string value22 = "Abcdef ";
            string value23 = "aBcDeF ";
            string value24 = "AbCdEf ";

            value1.FirstToUpper().Should().Be(expectedValue);
            value2.FirstToUpper().Should().Be(expectedValue);
            value3.FirstToUpper().Should().Be(expectedValue);
            value4.FirstToUpper().Should().Be(expectedValue);
            value5.FirstToUpper().Should().Be(expectedValue);
            value6.FirstToUpper().Should().Be(expectedValue);

            value7.FirstToUpper().Should().Be(expectedValue);
            value8.FirstToUpper().Should().Be(expectedValue);
            value9.FirstToUpper().Should().Be(expectedValue);
            value10.FirstToUpper().Should().Be(expectedValue);
            value11.FirstToUpper().Should().Be(expectedValue);
            value12.FirstToUpper().Should().Be(expectedValue);

            value13.FirstToUpper().Should().Be(expectedValue);
            value14.FirstToUpper().Should().Be(expectedValue);
            value15.FirstToUpper().Should().Be(expectedValue);
            value16.FirstToUpper().Should().Be(expectedValue);
            value17.FirstToUpper().Should().Be(expectedValue);
            value18.FirstToUpper().Should().Be(expectedValue);

            value19.FirstToUpper().Should().Be(expectedValue);
            value20.FirstToUpper().Should().Be(expectedValue);
            value21.FirstToUpper().Should().Be(expectedValue);
            value22.FirstToUpper().Should().Be(expectedValue);
            value23.FirstToUpper().Should().Be(expectedValue);
            value24.FirstToUpper().Should().Be(expectedValue);
        }

        [TestMethod]
        public void TestStringExtensionsWordCount()
        {
            string value1 = string.Empty;
            string value2 = " one\t";
            string value3 = " one";
            string value4 = "one";
            string value5 = " one\ttwo three:four,five six\nseven eight;";
            string value6 = "\tone\ttwo three:four,five six\nseven eight;nine.";
            string value7 = "\tone\ttwo three:four,five six\nseven eight;nine";
            string value8 = "one\ttwo three:four,five six\nseven eight;nine";

            value1.WordCount().Should().Be(0);
            value2.WordCount().Should().Be(1);
            value3.WordCount().Should().Be(1);
            value4.WordCount().Should().Be(1);
            value5.WordCount().Should().Be(8);
            value6.WordCount().Should().Be(9);
            value7.WordCount().Should().Be(9);
            value8.WordCount().Should().Be(9);
        }

        [TestMethod]
        public void TestStringExtensionsContainsSpace()
        {
            string value1 = string.Empty;
            string value2 = "value2";
            string value3 = " value3";
            string value4 = "value4 ";
            string value5 = " value5 ";
            string value6 = "val ue6";

            value1.ContainsSpace().Should().BeFalse();
            value2.ContainsSpace().Should().BeFalse();
            value3.ContainsSpace().Should().BeTrue();
            value4.ContainsSpace().Should().BeTrue();
            value5.ContainsSpace().Should().BeTrue();
            value6.ContainsSpace().Should().BeTrue();
        }
    }
}
