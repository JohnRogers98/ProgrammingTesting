using ProgrammingTesting.Extensions;

namespace ProgrammingTesting.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("101", 101)]
        public void ToInt32(String strNumber, Int32 expectedNumber)
        {
            Assert.Equal(expectedNumber, strNumber.ToInt32());
        }

        [Theory]
        [InlineData("mark_1", "mark_", "1")]
        [InlineData("q_11", "q_", "11")]
        [InlineData("q_11", "w_", null)]
        public void GetSubstringAfter(String str, String beginScipStr, String expectedSubstring)
        {
            Assert.Equal(expectedSubstring, str.GetSubstringAfter(beginScipStr));
        }
    }
}
