using Ink;
using Ink.Runtime;

namespace SimpleProgrammingTests.Features.Inky
{
    public class TestPlay
    {
        private Story _test;

        public String? CurrentQuestion { get; set; }

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
            this.Continue();
        }

        public TestPlay()
        {
            String inkContent = Task.Run(() => LoadTestAsset()).Result;
            var compiler = new Compiler(inkContent);
            _test = compiler.Compile();
            this.Continue();

            async Task<String> LoadTestAsset()
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("Test.ink");
                using var reader = new StreamReader(stream);

                return reader.ReadToEnd();
            }
        }

        public String Continue()
        {
            this.CurrentQuestion = _test.Continue();
            return this.CurrentQuestion;
        }

        public void Choose(Choice choice) => _test.ChooseChoiceIndex(choice.index);

        public void ChoiceSkip() => _test.ChooseChoiceIndex(0);

        public void Reset() => _test.ResetState();
    }
}
