using ProgrammingTesting.Models;
using SimpleProgrammingTests.Features.Inky;
using System;

namespace ProgrammingTesting.Tests.Features.Inky
{
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

        [Fact]
        public void Get_All_Unitworks_From_Test_Play()
        {
            //given
            String inkContent = File.ReadAllText(@"C:\Users\John\Downloads\Test.ink");
            TestPlay testPlay = new TestPlay(inkContent);
            TestUnitworkRepository sut = new TestUnitworkRepository(testPlay);

            //when
            IEnumerable<TestUnitwork> testUnitworks = sut.GetTestUnitworks();

            //then
            Assert.Equal(2, testUnitworks.Count());
            Assert.Equal(2, testUnitworks.ElementAt(0).Answers.Count());
            Assert.Equal(2, testUnitworks.ElementAt(1).Answers.Count());
        }
    }
}
