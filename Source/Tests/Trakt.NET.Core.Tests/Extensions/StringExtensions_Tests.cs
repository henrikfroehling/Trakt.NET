namespace TraktNet.Core.Tests.Extensions
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using Xunit;

    [TestCategory("Extensions")]
    public class StringExtensions_Tests
    {
        [Fact]
        public void Test_StringExtensions_FirstToUpper()
        {
            const string expectedValue = "Abcdef";

            const string value1 = "abcdef";
            const string value2 = "ABCDEF";
            const string value3 = "abcdeF";
            const string value4 = "Abcdef";
            const string value5 = "aBcDeF";
            const string value6 = "AbCdEf";

            const string value7 = " abcdef ";
            const string value8 = " ABCDEF ";
            const string value9 = " abcdeF ";
            const string value10 = " Abcdef ";
            const string value11 = " aBcDeF ";
            const string value12 = " AbCdEf ";

            const string value13 = " abcdef";
            const string value14 = " ABCDEF";
            const string value15 = " abcdeF";
            const string value16 = " Abcdef";
            const string value17 = " aBcDeF";
            const string value18 = " AbCdEf";

            const string value19 = "abcdef ";
            const string value20 = "ABCDEF ";
            const string value21 = "abcdeF ";
            const string value22 = "Abcdef ";
            const string value23 = "aBcDeF ";
            const string value24 = "AbCdEf ";

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

        [Fact]
        public void Test_StringExtensions_WordCount()
        {
            string value1 = string.Empty;
            const string value2 = " one\t";
            const string value3 = " one";
            const string value4 = "one";
            const string value5 = " one\ttwo three:four,five six\nseven eight;";
            const string value6 = "\tone\ttwo three:four,five six\nseven eight;nine.";
            const string value7 = "\tone\ttwo three:four,five six\nseven eight;nine";
            const string value8 = "one\ttwo three:four,five six\nseven eight;nine";

            value1.WordCount().Should().Be(0);
            value2.WordCount().Should().Be(1);
            value3.WordCount().Should().Be(1);
            value4.WordCount().Should().Be(1);
            value5.WordCount().Should().Be(8);
            value6.WordCount().Should().Be(9);
            value7.WordCount().Should().Be(9);
            value8.WordCount().Should().Be(9);
        }

        [Fact]
        public void Test_StringExtensions_ContainsSpace()
        {
            string value1 = string.Empty;
            const string value2 = "value2";
            const string value3 = " value3";
            const string value4 = "value4 ";
            const string value5 = " value5 ";
            const string value6 = "val ue6";

            value1.ContainsSpace().Should().BeFalse();
            value2.ContainsSpace().Should().BeFalse();
            value3.ContainsSpace().Should().BeTrue();
            value4.ContainsSpace().Should().BeTrue();
            value5.ContainsSpace().Should().BeTrue();
            value6.ContainsSpace().Should().BeTrue();
        }
    }
}
