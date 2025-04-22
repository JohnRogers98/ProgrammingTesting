using ProgrammingTesting.Models;
using SimpleProgrammingTests.Features.Inky;

namespace ProgrammingTesting.Tests.Models
{
    [Collection("TestsWithInkFile")]
    public class TestUnitworkRepositoryTests
    {
        [Theory]
        [InlineData(@"C:\Users\John\Downloads\Test.ink", 2, 2)]
        public void Get_All_Unitworks_From_Test_Play(String inkFilePath, Int32 questionCount, Int32 answerCountInEachQuestion)
        {
            //given
            String inkContent = File.ReadAllText(inkFilePath);
            TestPlay testPlay = new TestPlay(inkContent);
            TestUnitworkRepository sut = new TestUnitworkRepository(testPlay);

            //when
            IEnumerable<TestUnitwork> testUnitworks = sut.GetTestUnitworks();

            //then
            Assert.Equal(questionCount, testUnitworks.Count());
            Assert.Equal(answerCountInEachQuestion, testUnitworks.ElementAt(0).Answers.Count());
            Assert.Equal(answerCountInEachQuestion, testUnitworks.ElementAt(1).Answers.Count());
        }

        [Theory]
        [InlineData(@"C:\Users\John\Downloads\Test.ink", 2)]
        public void Get_All_Unitworks_From_Test_Play_By_Coroutine(String inkFilePath, Int32 questionCount)
        {
            //given
            String inkContent = File.ReadAllText(inkFilePath);
            TestPlay testPlay = new TestPlay(inkContent);
            TestUnitworkRepository sut = new TestUnitworkRepository(testPlay);

            //when
            Int32 enumeratorCount = 0;
            foreach (var item in sut)
            {
                enumeratorCount++;
            }

            //then
            Assert.Equal(questionCount, enumeratorCount);
        }
    }
}
