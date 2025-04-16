using ProgrammingTesting.Extensions;
using ProgrammingTesting.Models.Abstracts;
using SimpleProgrammingTests.Features.Inky;

namespace ProgrammingTesting.Models
{
    public class TestUnitworkRepository : ITestUnitworkRepository
    {
        private readonly TestPlay _testPlay;

        public TestUnitworkRepository(TestPlay testPlay) => (_testPlay) = testPlay;

        public IEnumerable<TestUnitwork> GetTestUnitworks()
        {
            IList<TestUnitwork> testUnitworks = new List<TestUnitwork>();
            foreach(TestUnitwork aTestUnitwork in this)
            {
                testUnitworks.Add(aTestUnitwork);
            }
            return testUnitworks;
        }

        public IEnumerator<TestUnitwork> GetEnumerator()
        {
            while(_testPlay.CanContinue || _testPlay.HasChoices)
            {
                TestUnitwork aTestUnitwork = this.GetTestunitWork();
                _testPlay.ChoiceSkip();
                _testPlay.Continue();
                yield return aTestUnitwork;
            }
            
            _testPlay.Reset();    
            yield break;
        }

        private TestUnitwork GetTestunitWork()
        {
            String question = _testPlay.CurrentQuestion!;

            Int32 questionId = _testPlay.CurrentTags
                .Where(tag => tag.StartsWith("q_"))
                .First()
                .GetSubstringAfter("q_")!
                .ToInt32();
            
            IList<Answer> answers = new List<Answer>();
            _testPlay.CurrentChoices.ForEach(choice => {
                answers.Add(
                    new Answer 
                    {
                        Id = choice.index,
                        Text = choice.text,
                        Score = choice.tags.Where(tag => tag.StartsWith("mark_")).First().GetSubstringAfter("mark_")!.ToInt32()
                    }
                );
            });
            
            return new TestUnitwork{ Id = questionId, Question = question, Answers = answers};
        }
    }
}
