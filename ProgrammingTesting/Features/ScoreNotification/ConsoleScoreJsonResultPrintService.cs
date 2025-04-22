using ProgrammingTesting.Models;
using System.Diagnostics;
using System.Text.Json;

namespace ProgrammingTesting.Features.ScoreNotification
{
    public class ConsoleScoreJsonResultPrintService : IScoreNotificationService
    {
        public void Notify(IEnumerable<TestUnitwork> testUnitworks)
        {
            Debug.WriteLine( JsonSerializer.Serialize(testUnitworks) );
        }
    }
}
