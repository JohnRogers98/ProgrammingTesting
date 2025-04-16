namespace ProgrammingTesting.Models
{
    public class TestUnitwork
    {
        public required Int32 Id { get; init; }

        public required String Question {  get; init; }

        public required IEnumerable<Answer> Answers { get; init; }
        
        public Answer? SelectedAnswer { get; set; }
    }

    public class Answer
    {
        public required Int32 Id { get; set; }
        public required String Text { get; set; }
        public required Int32 Score { get; set; }
    }
}
