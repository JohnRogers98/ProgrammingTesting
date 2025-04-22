using ProgrammingTesting.Features.ScoreNotification;
using ProgrammingTesting.Models;
using System.Collections.ObjectModel;

namespace ProgrammingTesting.ViewModels
{
    public class TestUnitworkViewModel : BaseViewModel
    {
        private IEnumerator<TestUnitwork> _testUnitworks;

        private IList<TestUnitwork> _answeredTestUnitworks = new List<TestUnitwork>();

        private IScoreNotificationService _scoreNotificationService;

        Int32 _id = Int32.MinValue;
        public Int32 Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        String _question = String.Empty;
        public String Question
        {
            get { return _question; }
            set { SetProperty(ref _question, value); }
        }

        public ObservableCollection<Answer> Answers { get; set; } = new ObservableCollection<Answer>();

        Answer? _selectedAnswer;
        public Answer? SelectedAnswer
        {
            get { return _selectedAnswer; }
            set 
            {
                _testUnitworks.Current.SelectedAnswer = value;
                SetProperty(ref _selectedAnswer, value); 
            }
        }

        public TestUnitworkViewModel(TestUnitworkRepository testRepository, IScoreNotificationService scoreNotificationService) 
        {
            _testUnitworks = testRepository.GetEnumerator();
            _scoreNotificationService = scoreNotificationService;

            this.NextTestUnitwork();
        }

        public Boolean NextTestUnitwork()
        {
            if (_testUnitworks.MoveNext())
            {
                Id = _testUnitworks.Current.Id;
                Question = _testUnitworks.Current.Question;
                Answers.Clear();
                foreach (var anAnswer in _testUnitworks.Current.Answers)
                {
                    Answers.Add(anAnswer);
                }
                return true;
            }

            _scoreNotificationService.Notify(_answeredTestUnitworks);

            return false;
        }
        
        public void AddCurrentAnsweredTestToAnseredCollection() => 
            _answeredTestUnitworks.Add(_testUnitworks.Current);
    }
}
