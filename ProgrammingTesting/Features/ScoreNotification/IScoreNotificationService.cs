using ProgrammingTesting.Models;

namespace ProgrammingTesting.Features.ScoreNotification
{
    public interface IScoreNotificationService
    {
        void Notify(IEnumerable<TestUnitwork> testUnitworks);
    }
}
