using Dapper;
using RPSAcademyWebApp.Models;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Metrics;

namespace RPSAcademyWebApp
{
    public class GameRepository : IGameRepository
    {
        //summary: Determines the winner of a rock paper scissor round
        //returns: 1 if user wins round
        //         2 if opp wins round
        //         3 if round is a draw
        public int DecisionOfRound(int userSelection)
        {
            var random = new Random();
            var possibleSelection = new List<string> {"rock","paper","scissors"};
            var oppChoice = random.Next(1,3);
            switch(userSelection)
            {
                //user selects rock
                case 1:
                    switch (possibleSelection[oppChoice])
                    {
                        case "rock":
                            return 3;

                        case "paper":
                            return 2;

                        case "scissors":
                            return 1;

                        //never selected
                        default:
                            return 0;
                    }

                //user selects paper
                case 2:
                    switch (possibleSelection[oppChoice])
                    {
                        case "rock":
                            return 1;

                        case "paper":
                            return 3;

                        case "scissors":
                            return 2;

                        //never selected
                        default:
                            return 0;
                    }

                //user selects scissors
                case 3:
                    switch (possibleSelection[oppChoice])
                    {
                        case "rock":
                            return 1;

                        case "paper":
                            return 2;

                        case "scissors":
                            return 1;

                        //never selected
                        default:
                            return 0;
                    }

                //never selected
                default: return 0;
            }
        }


        //summary: Increases score of the int inserted in the parameters
        //returns: score incremented by 1 point
        public int GivePoint(int scoreToIncrement)
        {
            return scoreToIncrement++;
        }


        //summary: Sets opponents probability of answering a question correctly by the opponent ID given in the parameters
        //returns: a list used for probability. each '1' added to the list represents 10% increase of answering question correctly
        public List<int> SetDifficulty(int oppID)
        {
            //if 1 is selected from difficulty list opp answers correctly
            //if 2 is selected from difficulty list opp answers incorrectly
            List<int> difficulty = new List<int>(10);
            switch(oppID)
            {
                //novice nancy
                //0% chance of answering question correctly
                case 0:
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    return difficulty;

                //beginner ben
                //10% chance of answering question correctly
                case 1:
                    difficulty.Add(1);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    return difficulty;

                //junior developer julie
                //20% chance of answering question correctly
                case 2:
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    return difficulty;

                //intermediate isaac
                //30% chance of answering question correctly
                case 3:
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    return difficulty;

                //advanced amelia
                //40% chance of answering question correctly
                case 4:
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    return difficulty;

                //senior developer sam
                //50% chance of answering question correctly
                case 5:
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    return difficulty;

                //expert ethan
                //60% chance of answering question correctly
                case 6:
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    return difficulty;

                //masterful morgan
                //70% chance of answering question correctly
                case 7:
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    return difficulty;

                //guru giselle
                //80% chance of answering question correctly
                case 8:
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(2);
                    difficulty.Add(2);
                    return difficulty;

                //visionary victor
                //90% chance of answering question correctly
                case 9:
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(2);
                    return difficulty;

                //legendary lila
                //100% chance of answering question correctly
                case 10:
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    difficulty.Add(1);
                    return difficulty;

                //never selected
                default:
                    return difficulty;

            }
        }


        //summary: Sets opponents stats by the opponent ID given in the parameters
        //returns: a string used to show user the probality of the selected opponent
        public string SetStats(int oppID)
        {
            string stats;
            switch (oppID)
            {
                //novice nancy
                case 0:
                    stats = "0% chance of answering question correctly";
                    return stats;

                //beginner ben
                case 1:
                    stats = "10% chance of answering question correctly";
                    return stats;

                //junior developer julie
                case 2:
                    stats = "20% chance of answering question correctly";
                    return stats;

                //intermediate isaac
                case 3:
                    stats = "30% chance of answering question correctly";
                    return stats;

                //advanced amelia
                case 4:
                    stats = "40% chance of answering question correctly";
                    return stats;

                //senior developer sam
                case 5:
                    stats = "50% chance of answering question correctly";
                    return stats;

                //expert ethan
                case 6:
                    stats = "60% chance of answering question correctly";
                    return stats;

                //masterful morgan
                case 7:
                    stats = "70% chance of answering question correctly";
                    return stats;

                //guru giselle
                case 8:
                    stats = "80% chance of answering question correctly";
                    return stats;

                //visionary victor
                case 9:
                    stats = "90% chance of answering question correctly";
                    return stats;

                //legendary lila
                case 10:
                    stats = "100% chance of answering question correctly";
                    return stats;

                //never selected
                default:
                    stats = "";
                    return stats;

            }
        } 


        //summary: Sets opponents description by the opponent ID given in the parameters
        //returns: a string used to show user a description of the selected opponent
        public string SetDescription(int oppID)
        {
            string description;
            switch (oppID)
            {
                //novice nancy
                case 0:
                    description = "Nancy is a beginner in coding with a basic understanding of programming concepts and syntax. She is enthusiastic about learning and wants to improve her skills in programming. Natalie is open to new challenges and approaches coding with a growth mindset. She possesses excellent communication and problem-solving abilities and is proactive in seeking out resources and guidance. With her positive attitude and determination, she is well-equipped to make significant progress in her coding journey.";
                    return description;

                //beginner ben
                case 1:
                    description = "As Ben gains more experience in coding, he is expanding his skills and taking on more complex projects. He is exploring different programming languages and frameworks while seeking out collaboration opportunities to improve his communication and teamwork skills. Ben also understands the importance of staying up-to-date with industry trends and advancements, attending tech events to network and stay informed. Through each new challenge, Ben is growing as a coder and developing a strong foundation for a successful career in software development.";
                    return description;

                //junior developer julie
                case 2:
                    description = "";
                    return description;

                //intermediate isaac
                case 3:
                    description = "As Isaac continues his coding journey, he's pushing himself to explore new languages and frameworks outside of his comfort zone. He's taking on more challenging projects that require him to stretch his problem-solving skills and think outside the box. Isaac's curiosity and passion for coding have led him to pursue new areas of interest, such as machine learning and data science. He's taking online courses and attending workshops to deepen his understanding of these fields and explore how they intersect with his programming skills.";
                    return description;

                //advanced amelia
                case 4:
                    description = "Amelia is a seasoned coder with a wealth of experience under her belt. She's honed her technical skills over the years and is comfortable working with a variety of programming languages and frameworks. Amelia's focus has shifted towards optimizing her coding process, making use of tools and techniques like automation and version control to streamline her workflow.";
                    return description;

                //senior developer sam
                case 5:
                    description = "As Sam continues their coding journey, they're taking on increasingly complex challenges and pushing the boundaries of what's possible with technology. Sam is also dedicated to mentoring and sharing their knowledge with others. They've taken on leadership roles on development teams, providing guidance and support to junior developers and working to create a collaborative and supportive work environment. Sam is passionate about empowering others to achieve their full potential and is always looking for opportunities to give back to the coding community.";
                    return description;

                //expert ethan
                case 6:
                    description = "As an experienced coder, Ethan is always seeking out ways to stay ahead of the curve and push the boundaries of what's possible with technology. They've developed a reputation as an expert in their field, providing mentorship and guidance to other developers and contributing to the wider coding community through open-source projects and publications. Ethan is also a skilled communicator and collaborator. They're adept at working with cross-functional teams, bridging the gap between technical and non-technical stakeholders and ensuring that everyone is aligned towards a common goal.";
                    return description;

                //masterful morgan
                case 7:
                    description = "As a master coder with over two decades of experience, Morgan has established themselves as a true expert in their field. They have a deep understanding of software development and are comfortable working with the most complex systems in the industry. Morgan has tackled some of the toughest coding challenges out there and has consistently delivered elegant and efficient solutions.";
                    return description;

                //guru giselle
                case 8:
                    description = "As a true coding guru, Giselle is constantly pushing the boundaries of what's possible with technology. She has spent her entire career immersed in the world of coding and has established herself as a true thought leader in the industry. Giselle's contributions to the development of programming languages and software tools have had a significant impact on the field, and her expertise is highly sought-after by companies and organizations around the world. Giselle is also a gifted communicator and mentor. She's a sought-after speaker at conferences and events, where she shares her insights and knowledge with others in the industry.";
                    return description;

                //visionary victor
                case 9:
                    description = "";
                    return description;

                //legendary lila
                case 10:
                    description = "As a coding legend, Lila has established herself as one of the most influential figures in the world of technology. With over 35 years of experience, she has played a key role in the development of some of the most transformative technologies of our time, from the early days of the internet to the current wave of artificial intelligence and machine learning. Through her work, Lila has demonstrated the immense potential of technology to create positive change in the world, and has inspired countless others to pursue careers in coding and technology.";
                    return description;

                //never selected
                default:
                    description = "";
                    return description;

            }
        }


        //summary: Sets opponents image by the opponent ID given in the parameters
        //returns: a string representing the image of the selected opponent
        public string SetOppImage(int oppID)
        {
            string image;
            switch (oppID)
            {
                //novice nancy
                case 0:
                    image = "https://images.chesscomfiles.com/uploads/v1/user/66746066.19a65fbb.200x200o.05bddf716131.png";
                    return image;

                //beginner ben
                case 1:
                    image = "https://images.chesscomfiles.com/uploads/v1/user/86372808.f93673f8.200x200o.3fbbc6d3beb4.png";
                    return image;

                //junior developer julie
                case 2:
                    image = "https://images.chesscomfiles.com/uploads/v1/user/66746152.1f1905ee.200x200o.ff1b08a80f9c.png";
                    return image;

                //intermediate Isaac
                case 3:
                    image = "https://images.chesscomfiles.com/uploads/v1/user/66746112.62754ebd.200x200o.ed2f2f2e6cae.png";
                    return image;

                //advanced amelia
                case 4:
                    image = "https://images.chesscomfiles.com/uploads/v1/user/66745990.8caa7131.200x200o.ee3f384b460f.png";
                    return image;

                //senior developer sam
                case 5:
                    image = "https://images.chesscomfiles.com/uploads/v1/user/66746068.6b0443e7.200x200o.431299f833ac.png";
                    return image;

                //expert ethan
                case 6:
                    image = "https://images.chesscomfiles.com/uploads/v1/user/66746100.bdace8c3.200x200o.315e695aec56.png";
                    return image;

                //masterful morgan
                case 7:
                    image = "https://images.chesscomfiles.com/uploads/v1/user/66745978.64d840c2.200x200o.fc49daaa55f1.png";
                    return image;

                //guru giselle
                case 8:
                    image = "https://images.chesscomfiles.com/uploads/v1/user/66746128.b0c866b0.200x200o.ea4f52c7cf90.png";
                    return image;

                //visionary victor
                case 9:
                    image = "https://images.chesscomfiles.com/uploads/v1/user/66745948.f2132f62.200x200o.086d7249e99f.png";
                    return image;

                //legendary lila
                case 10:
                    image = "https://images.chesscomfiles.com/uploads/v1/user/66746134.3681aa8d.200x200o.0fbf4b25d3d8.png";
                    return image;

                default:
                    image = "";
                    return image;
            }
        }


        //summary: checks users answer to a question when playing the game.
        //returns: 1 if user answers correctly
        //         2 if user answers incorrectly
        public int AnswerChecker(string answer, string correctAnswer)
        {
            switch (correctAnswer.ToLower())
            {
                case "a":
                    if (answer == "a")
                    {
                        //answer is correct
                        return 1;
                    }
                    else
                    {
                        //answer is wrong
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
    }
}