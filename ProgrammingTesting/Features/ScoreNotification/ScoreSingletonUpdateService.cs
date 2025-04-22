using ProgrammingTesting.Models;
using ProgrammingTesting.Singletons;

namespace ProgrammingTesting.Features.ScoreNotification
{
    public class ScoreSingletonUpdateService : IScoreNotificationService
    {
        public void Notify(IEnumerable<TestUnitwork> testUnitworks)
        {
            Score.Value = 0;
            foreach (var anAnsweredTestUnitwork in testUnitworks)
            {
                Score.Value += anAnsweredTestUnitwork.SelectedAnswer!.Score;
            }
        }
    }
}
