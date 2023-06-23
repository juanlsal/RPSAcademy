using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using RPSAcademyWebApp.Models;
using System;
using System.Security.Cryptography;

namespace RPSAcademyWebApp.Controllers
{
    public class PlayController : Controller
    {
        private readonly IGameRepository repo;
        public PlayController(IGameRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult ChooseOpp(string userName, int totalQuestionNumber)
        {
            Game game = new Game();
            {
                game.UserName = userName;
                game.TotalQuestionNumber = totalQuestionNumber;
            }
            return View(game);
        }
        public IActionResult RoundOfRPS(int oppID, string userName, int userScore, string oppName, int oppScore, int winPoint, int totalQuestionNumber)
        {
            Game game = new Game();
            {
                game.OppID = oppID;
                game.UserName = userName;
                game.UserScore = userScore;
                game.OppName = oppName;
                game.OppScore = oppScore;
                game.OppImage = repo.SetOppImage(oppID);
                game.OppDescription = repo.SetDescription(oppID);
                game.OppStats = repo.SetStats(oppID);
                game.OppDifficulty = repo.SetDifficulty(oppID);
                game.WinPoint = winPoint;
                game.TotalQuestionNumber = totalQuestionNumber;
            }
            return View(game);
        }
        public IActionResult SetWinPoint(int oppID, string userName, string oppName, int totalQuestionNumber)
        {
            Game game = new Game();
            {
                game.OppID = oppID;
                game.UserName = userName;
                game.UserScore = 0;
                game.OppName = oppName;
                game.OppScore = 0;
                game.OppImage = repo.SetOppImage(oppID);
                game.OppDescription= repo.SetDescription(oppID);
                game.OppStats = repo.SetStats(oppID);
                game.TotalQuestionNumber = totalQuestionNumber;
            }
            return View(game);
        }
        public IActionResult ResultOfRPS(int oppID, int winPoint, string userName, string oppName, int userScore, int oppScore, int userSelectionRPS, int totalQuestionNumber)
        {
            Game game = new Game();
            {
                game.OppID = oppID;
                game.UserName = userName;
                game.UserScore = userScore;
                game.OppName = oppName;
                game.OppScore = oppScore;
                game.OppImage = repo.SetOppImage(oppID);
                game.TotalQuestionNumber = totalQuestionNumber;
                game.WinPoint = winPoint;
            }
            var descision = repo.DecisionOfRound(userSelectionRPS);
            switch (descision)
            {
                //user wins
                case 1:
                    game.UserScore += 1;
                    game.WinnerOfRound = 1;
                    break;

                //opp wins
                case 2:
                    game.OppScore += 1;
                    game.WinnerOfRound = 2;
                    break;

                //draw
                case 3:
                    game.WinnerOfRound = 3;
                    break;
            }

            return View(game);
        }
        public IActionResult ResultOfOppQuestion(int winPoint, string userName, string oppImage, string oppName, string oppDescription, string oppStats, List<int> oppDifficulty, int userScore, int oppScore, int userSelectionRPS, int totalQuestionNumber)
        {
            Game game = new Game();
            {
                game.UserName = userName;
                game.OppImage = oppImage;
                game.OppName = oppName;
                game.OppDescription = oppDescription;
                game.OppStats = oppStats;
                game.OppDifficulty = oppDifficulty;
                game.TotalQuestionNumber = totalQuestionNumber;
            }

            Random random = new Random();
            var answer = oppDifficulty[random.Next(0, oppDifficulty.Count)];
            switch (answer)
            {
                case 1:
                    game.OppScore = oppScore + 1;
                    return View(game);
                default:
                    return View(game);
            }

        }
        public IActionResult ResultOfQuestionForRPS(string answer, int path, int oppID, int winPoint, string userName, string oppName, int userScore, int oppScore, int totalQuestionNumber, string subject, string question, string answerA, string answerB, string answerC, string answerD, string correctAnswer, string correctAnswerString)
        {
            Random random = new Random();
            Game game = new Game();
            {
                game.OppID = oppID;
                game.UserName = userName;
                game.UserScore = userScore;
                game.OppName = oppName;
                game.OppScore = oppScore;
                game.WinPoint = winPoint;
                game.OppImage = repo.SetOppImage(oppID);
                game.TotalQuestionNumber = totalQuestionNumber;
            }
            ViewBag.Path = path;
            ViewBag.Subject = subject;
            ViewBag.Question = question;
            ViewBag.AnswerA = answerA;
            ViewBag.AnswerB = answerB;
            ViewBag.AnswerC = answerC;
            ViewBag.AnswerD = answerD;
            ViewBag.CorrectAnswer = correctAnswer;
            ViewBag.CorrectAnswerString = correctAnswerString;

            //who is answering question
            switch (path)
            {
                //user is answering
                case 1:
                    var answerChecker = repo.AnswerChecker(answer, correctAnswer);
                    switch (answerChecker)
                    {
                        //correct
                        case 1:
                            game.UserScore = userScore + 1;

                            //path2 is set to 1 if user answers correctly.
                            ViewBag.Path2 = 1;
                            return View(game);

                        //incorrect
                        case 2:
                            //path2 is set to 2 if user answers incorrectly.
                            ViewBag.Path2 = 2;
                            return View(game);

                        //never used
                        default:
                            return View(game);
                    }

                //opp is answering
                case 2:
                    var difficulty = repo.SetDifficulty(oppID);
                    var oppAnswer = random.Next(0, 9);
                    switch (difficulty[oppAnswer])
                    {
                        case 1:
                            game.OppScore = oppScore + 1;
                            ViewBag.Path3 = 1;
                            return View(game);

                        case 2:
                            ViewBag.Path3 = 2;
                            return View(game);

                        //never used
                        default:
                            return View(game);
                    }

                //never used
                default:
                    return View(game);
            }

        }
        public IActionResult RedemptionQuestion(int path, int oppID, int winPoint, string userName, string oppName, int userScore, int oppScore, int totalQuestionNumber, string subject, string question, string answerA, string answerB, string answerC, string answerD, string correctAnswer, string correctAnswerString)
        {
            Game game = new Game();
            {
                game.OppID = oppID;
                game.UserName = userName;
                game.OppName = oppName;
                game.WinPoint = winPoint;
                game.UserScore = userScore;
                game.OppScore = oppScore;
                game.TotalQuestionNumber = totalQuestionNumber;
                game.OppImage = repo.SetOppImage(game.OppID);
            }
            ViewBag.Subject = subject;
            ViewBag.Question = question;
            ViewBag.AnswerA = answerA;
            ViewBag.AnswerB = answerB;
            ViewBag.AnswerC = answerC;
            ViewBag.AnswerD = answerD;
            ViewBag.CorrectAnswer = correctAnswer;
            ViewBag.CorrectAnswerString = correctAnswerString;
            ViewBag.Path = path;
            return View(game);
        }
        public IActionResult ResultForRedemptionQuestion(int path, string userName, int oppID, int userScore, string oppName, int oppScore, int winPoint, int totalQuestionNumber, string answer, string correctAnswer, string subject, string question, string answerA, string answerB, string answerC, string answerD, string correctAnswerString)
        {
            Random random = new Random();
            ViewBag.Subject = subject;
            ViewBag.Question = question;
            ViewBag.AnswerA = answerA;
            ViewBag.AnswerB = answerB;
            ViewBag.AnswerC = answerC;
            ViewBag.AnswerD = answerD;
            ViewBag.CorrectAnswer = correctAnswer;
            ViewBag.CorrectAnswerString = correctAnswerString;

            Game game = new Game();
            {
                game.OppID = oppID;
                game.UserName = userName;
                game.UserScore = userScore;
                game.OppName = oppName;
                game.OppScore = oppScore;
                game.WinPoint = winPoint;
                game.OppImage = repo.SetOppImage(oppID);
                game.TotalQuestionNumber = totalQuestionNumber;
            }
            switch (path)
            {
                //user answers
                case 1:
                    var answerChecker = repo.AnswerChecker(answer, correctAnswer);
                    switch (answerChecker)
                    {
                        //user answers correctly
                        case 1:
                            game.UserScore = userScore + 1;

                            //path2 is set to 1 if user answers correctly.
                            ViewBag.Path = 1;
                            return View(game);

                        //incorrect
                        case 2:
                            //path2 is set to 2 if user answers incorrectly.
                            ViewBag.Path = 2;
                            return View(game);

                        //never used
                        default:
                            return View(game);
                    }

                //opp answers
                case 2:
                    var difficulty = repo.SetDifficulty(oppID);
                    var oppAnswer = random.Next(0, 9);
                    switch (difficulty[oppAnswer])
                    {
                        case 1:
                            game.OppScore = oppScore + 1;
                            ViewBag.Path2 = 1;
                            return View(game);

                        case 2:
                            ViewBag.Path2 = 2;
                            return View(game);

                        //never used
                        default:
                            return View(game);
                    }

                //never used
                default:
                    return View(game);
            }
        }
    }
}