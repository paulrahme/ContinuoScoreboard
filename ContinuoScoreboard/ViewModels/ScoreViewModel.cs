using ReactiveUI;
using System;
using System.Linq;
using Avalonia.Interactivity;
using ContinuoScoreboard.Models;

namespace ContinuoScoreboard.ViewModels
{
    public class ScoreViewModel : ReactiveObject
    {
        private readonly Score _score = new();
        private string _player1Name, _player2Name;
        private string _player1ScoreList = string.Empty, _player2ScoreList = string.Empty;
        private int _player1ScoreAmount = 10, _player2ScoreAmount = 10;
        private int _player1Total = 0, _player2Total = 0;
        private bool _player1HasScores, _player2HasScores;
        
        public string? Player1Name
        {
            get => _player1Name;
            set
            {
                _score.SetPlayerName(0, value);
                this.RaiseAndSetIfChanged(ref _player1Name, value);
            }
        }
        
        public string? Player2Name
        {
            get => _player2Name;
            set
            {
                _score.SetPlayerName(1, value);
                this.RaiseAndSetIfChanged(ref _player2Name, value);
            }
        }

        public string Player1ScoreList
        {
            get => _player1ScoreList;
            set => this.RaiseAndSetIfChanged(ref _player1ScoreList, value);
        }

        public string Player2ScoreList
        {
            get => _player2ScoreList;
            set => this.RaiseAndSetIfChanged(ref _player2ScoreList, value);
        }

        public int Player1Total
        {
            get => _player1Total;
            set => this.RaiseAndSetIfChanged(ref _player1Total, value);
        }

        public int Player2Total
        {
            get => _player2Total;
            set => this.RaiseAndSetIfChanged(ref _player2Total, value);
        }

        public int Player1ScoreAmount
        {
            get => _player1ScoreAmount;
            set => this.RaiseAndSetIfChanged(ref _player1ScoreAmount, value);
        }

        public int Player2ScoreAmount
        {
            get => _player2ScoreAmount;
            set => this.RaiseAndSetIfChanged(ref _player2ScoreAmount, value);
        }

        public bool Player1HasScores
        {
            get => _player1HasScores;
            set => this.RaiseAndSetIfChanged(ref _player1HasScores, value);
        }

        public bool Player2HasScores
        {
            get => _player2HasScores;
            set => this.RaiseAndSetIfChanged(ref _player2HasScores, value);
        }

        public void AddPlayer1Score()
        {
            _score.AddScore(0, Player1ScoreAmount);
            Player1ScoreList = _score.GetScoreList(0);
            Player1Total = _score.GetTotal(0);
        }

        public void AddPlayer2Score()
        {
            _score.AddScore(1, Player2ScoreAmount);
            Player2ScoreList = _score.GetScoreList(1);
            Player1Total = _score.GetTotal(1);
        }

        public void UndoPlayer1Score()
        {
            if (_score.RemoveLastScore(0))
            {
                Player1ScoreList = _score.GetScoreList(0);
                Player1Total = _score.GetTotal(0);
            }
        }

        /// <summary> Constructor </summary>
        /// <remarks> Includes reactive property subscribers</remarks>
        public ScoreViewModel()
        {
            _player1Name = _score.GetPlayerName(0);
            _player2Name = _score.GetPlayerName(1);
        }
    }
}
