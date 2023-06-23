namespace RPSAcademyWebApp.Models
{
    public class Game
    {
        public Game()
        {
            
        }

        public string UserName{ get; set; }
        public string OppName { get; set; }
        public string OppImage { get; set; }
        public string OppDescription { get; set; }
        public string OppStats { get; set; }
        public List<int> OppDifficulty { get; set; }
        public int WinPoint { get; set; }
        public int OppScore { get; set; }
        public int UserScore { get; set; }
        public int WinnerOfRound { get; set; }
        public int OppID { get; set; }
        public int TotalQuestionNumber { get; set; }

    }
}
