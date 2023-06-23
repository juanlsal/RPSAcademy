namespace RPSAcademyWebApp.Models
{
    public class MultipleChoice
    {
        public int? QuestionNumber { get; set; }
        public string? Question { get; set; }
        public string? AnswerA { get; set; }
        public string? AnswerB { get; set; }
        public string? AnswerC { get; set; }
        public string? AnswerD { get; set; }
        public string? CorrectAnswer { get; set; }
        public string? CorrectAnswerString { get; set; }
        public string? Subject { get; set; }
        public IEnumerable<Subjects> Subjects { get; set; }

        public IEnumerable<MultipleChoice> Answers { get; set; }

        public int SubjectID { get; set; }

        public int TotalQuestionNumber { get; set; }

        public int CorrectAnswerID { get; set; }
    }
}
