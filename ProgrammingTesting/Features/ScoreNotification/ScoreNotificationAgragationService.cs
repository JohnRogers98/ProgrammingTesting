using ProgrammingTesting.Models;

namespace ProgrammingTesting.Features.ScoreNotification
{
    public class ScoreNotificationAgragationService : IScoreNotificationService
    {
        private IEnumerable<IScoreNotificationService> _scoreNotificationServices;

        public ScoreNotificationAgragationService(IEnumerable<IScoreNotificationService> scoreNotificationServices) 
            => _scoreNotificationServices = scoreNotificationServices;

        public void Notify(IEnumerable<TestUnitwork> testUnitworks)
        {
            foreach(var aNonificationService in _scoreNotificationServices)
            {
                aNonificationService.Notify(testUnitworks);
            }
        }
    }
}
