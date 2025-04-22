using ProgrammingTesting.Models;
using SimpleProgrammingTests.Features.Inky;

namespace ProgrammingTesting.Tests.Features.Inky
{
    [Collection("TestsWithInkFile")]
    public class TestPlayTests
    {
        [Fact]
        public void Is_Path_Correctly_Handled()
        {
            //given
            String inkContent = File.ReadAllText(@"C:\Users\John\Downloads\Test.ink");
            //when
            TestPlay sut = new TestPlay(inkContent);
            //then
            Assert.Contains(@"What is C# ?", sut.CurrentQuestion);
        }
    }
}
