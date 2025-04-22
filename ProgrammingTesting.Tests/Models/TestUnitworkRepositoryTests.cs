using ProgrammingTesting.Models;
using SimpleProgrammingTests.Features.Inky;

namespace ProgrammingTesting.Tests.Models
{
    [Collection("Ink")]
    public class TestUnitworkRepositoryTests
    {
        [Theory]
        [InlineData(2, 2)]
        public void Get_All_Unitworks_From_Test_Play( Int32 questionCount, Int32 answerCountInEachQuestion)
        {
            //given
            TestPlay testPlay = new TestPlay(InkTestContent.Value);
            TestUnitworkRepository sut = new TestUnitworkRepository(testPlay);

            //when
            IEnumerable<TestUnitwork> testUnitworks = sut.GetTestUnitworks();

            //then
            Assert.Equal(questionCount, testUnitworks.Count());
            Assert.Equal(answerCountInEachQuestion, testUnitworks.ElementAt(0).Answers.Count());
            Assert.Equal(answerCountInEachQuestion, testUnitworks.ElementAt(1).Answers.Count());
        }

        [Theory]
        [InlineData(2)]
        public void Get_All_Unitworks_From_Test_Play_By_Coroutine(Int32 questionCount)
        {
            //given
            TestPlay testPlay = new TestPlay(InkTestContent.Value);
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
