using ProgrammingTesting.Models;
using SimpleProgrammingTests.Features.Inky;

namespace ProgrammingTesting.Tests.Features.Inky
{
    [Collection("Ink")]
    public class TestPlayTests
    {
        [Fact]
        public void Is_Path_Correctly_Handled()
        {
            //when
            TestPlay sut = new TestPlay(InkTestContent.Value);
            //then
            Assert.Contains(@"What is C# ?", sut.CurrentQuestion);
        }
    }
}
