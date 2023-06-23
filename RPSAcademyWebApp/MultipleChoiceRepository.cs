using Dapper;
using RPSAcademyWebApp.Models;
using System.Data;

namespace RPSAcademyWebApp
{
    public class MultipleChoiceRepository : IMultipleChoiceRepository
    {
        private readonly IDbConnection _conn;

        public MultipleChoiceRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public MultipleChoice AssignSubject(MultipleChoice question)
        {
            var subjectList = GetSubjects();
            question.Subjects = subjectList;
            return question;
        }

        public MultipleChoice MultipleChoiceQuestion(int questionNumber)
        {
            return _conn.QuerySingle<MultipleChoice>($"SELECT  mc.QuestionNumber, mc.SubjectID, s.Subject, mc.Question, mc.AnswerA, mc.AnswerB, mc.AnswerC, mc.AnswerD, mc.CorrectAnswerString, mc.CorrectAnswerID, a.CorrectAnswer from multiplechoice as mc Inner JOIN subjects as s ON mc.SubjectID = s.SubjectID Inner Join answers as a ON mc.CorrectAnswerID = a.CorrectAnswerID Where QuestionNumber = {questionNumber};");
        }


        public IEnumerable<MultipleChoice> GetAllQuestions()
        {
            return _conn.Query<MultipleChoice>("SELECT  mc.QuestionNumber, mc.SubjectID, s.Subject, mc.Question, mc.AnswerA, mc.AnswerB, mc.AnswerC, mc.AnswerD, mc.CorrectAnswerString, mc.CorrectAnswerID, a.CorrectAnswer from multiplechoice as mc Inner JOIN subjects as s ON mc.SubjectID = s.SubjectID Inner Join answers as a ON mc.CorrectAnswerID = a.CorrectAnswerID Order BY QuestionNumber ASC;");
        }

        public MultipleChoice GetNumberOfQuestion()
        {
            return _conn.QuerySingle<MultipleChoice>("Select Count(distinct QuestionNumber) as \"TotalQuestionNumber\" from multiplechoice;");
        }

        public MultipleChoice GetQuestion(int id)
        {
            return _conn.QuerySingle<MultipleChoice>("SELECT  mc.QuestionNumber, mc.SubjectID, s.Subject, mc.Question, mc.AnswerA, mc.AnswerB, mc.AnswerC, mc.AnswerD, mc.CorrectAnswerString, mc.CorrectAnswerID, a.CorrectAnswer from multiplechoice as mc Inner JOIN subjects as s ON mc.SubjectID = s.SubjectID Inner Join answers as a ON mc.CorrectAnswerID = a.CorrectAnswerID Where QuestionNumber = @id;", 
                new { id = id});
        }

        public IEnumerable<Subjects> GetSubjects()
        {
            return _conn.Query<Subjects>("Select S.SubjectID, S.Subject, A.CorrectAnswerID, A.CorrectAnswer FROM subjects as S Left Join answers as A On S.SubjectID = A.CorrectAnswerID");
        }


        public void InsertQuestion(MultipleChoice ques)
        {
            _conn.Execute("Insert into multiplechoice ( SubjectID, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswerID, CorrectAnswerString) Values ( @subjectID, @question, @answerA, @answerB, @answerC, @answerD, @correctAnswerID, @correctAnswerString); ",
                new { subjectID = ques.SubjectID, question = ques.Question, answerA = ques.AnswerA, answerB = ques.AnswerB, answerC = ques.AnswerC, answerD = ques.AnswerD, correctAnswerID = ques.CorrectAnswerID, correctAnswerString = ques.CorrectAnswerString });
        }

        public void UpdateQuestion(MultipleChoice ques)
        {
            _conn.Execute("Update multiplechoice SET SubjectID = @subjectID, Question = @question, AnswerA = @answerA, AnswerB = @answerB, AnswerC = @answerC, AnswerD = @answerD, CorrectAnswerID = @correctAnswerID, CorrectAnswerString = @correctAnswerString WHERE QuestionNumber = @id;"
                , new { subjectID = ques.SubjectID, question = ques.Question, answerA = ques.AnswerA, answerB = ques.AnswerB, answerC = ques.AnswerC, answerD = ques.AnswerD, correctAnswerID = ques.CorrectAnswerID, correctAnswerString = ques.CorrectAnswerString, id = ques.QuestionNumber });
        }

        public int AnswerChecker(string answer, string correctAnswer)
        {
            switch (correctAnswer.ToLower())
            {
                case "a":
                    if (answer == "a")
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                case "b":
                    if (answer == "b")
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                case "c":
                    if (answer == "c")
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                case "d":
                    if (answer == "d")
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                default:
                    return 0;


            }
        }


        //summary: Increases score of the int inserted in the parameters
        //returns: score incremented by 1 point
        public int GivePoint(int scoreToIncrement)
        {
            return scoreToIncrement++;
        }

    }
}
