using Ink;
using Ink.Runtime;

namespace SimpleProgrammingTests.Features.Inky
{
    public class TestPlay
    {
        private Story _test;

        public Boolean CanContinue => _test.canContinue;

        public Boolean HasChoices 
        { 
            get { return _test.currentChoices.Count > 0; } 
        }

        public List<String> CurrentTags => _test.currentTags;

        public List<Choice> CurrentChoices => _test.currentChoices;

        public TestPlay(String inkContent)
        {
            var compiler = new Compiler(inkContent);
            _test = compiler.Compile();
        }

        public String Continue() => _test.Continue();

        public void AnswerQuestion(Choice choice)
        {
            _test.ChooseChoiceIndex(choice.index);
        }
    }
}
