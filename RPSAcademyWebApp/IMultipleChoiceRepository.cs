using RPSAcademyWebApp.Models;

namespace RPSAcademyWebApp
{
    public interface IMultipleChoiceRepository
    {
        public IEnumerable<MultipleChoice> GetAllQuestions();

        public MultipleChoice GetQuestion(int id);

        public void UpdateQuestion(MultipleChoice question);

        public void InsertQuestion(MultipleChoice Ques);

        public IEnumerable<Subjects> GetSubjects();

        public MultipleChoice AssignSubject(MultipleChoice question);

        public MultipleChoice GetNumberOfQuestion();
        public MultipleChoice MultipleChoiceQuestion(int questionNumber);

        public int AnswerChecker(string answer, string correctAnswer);
        public int GivePoint(int scoreToIncrement);
    }
}
