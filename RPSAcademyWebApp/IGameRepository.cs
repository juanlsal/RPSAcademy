using RPSAcademyWebApp.Models;

namespace RPSAcademyWebApp
{
    //summary: providing a common set of behaviors or capabilities that can be implemented by multiple classes
    public interface IGameRepository
    {
        public int DecisionOfRound(int userSelection);
        public int GivePoint(int scoreToIncrement);
        public List<int> SetDifficulty(int oppID);
        public string SetStats(int oppID);
        public string SetDescription(int oppID);
        public string SetOppImage(int oppID);
        public int AnswerChecker(string answer, string correctAnswer);
    }
}
