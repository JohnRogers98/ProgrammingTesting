using SimpleProgrammingTests.Features.Inky;

namespace ProgrammingTesting.Tests.Features.Inky
{
    public class TestPlayTests
    {
        [Fact]
        public void Is_Path_Correctly_Handled()
        {
            //given
            String inkContent = File.ReadAllText(@"C:\Users\John\Downloads\Queen tale.ink");
            //when
            TestPlay sut = new TestPlay(inkContent);
            //then
            Assert.True(sut.CanContinue);
        }
    }
}
