using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ContinuoScoreboard.Models;

public class Score
{
    public const int NumPlayers = 2;

    private readonly string[] _playerNames = ["Player 1", "Player 2"];
    private readonly List<int>[] _playerScores = [[], []];

    public string GetPlayerName(int playerIdx)
    {
        Debug.Assert(playerIdx < NumPlayers);
        return _playerNames[playerIdx];
    }
    
    public void SetPlayerName(int playerIdx, string playerName)
    {
        Debug.Assert(playerIdx < NumPlayers);
        _playerNames[playerIdx] = playerName;
    }
    
    public void AddScore(int playerIdx, int score)
    {
        Debug.Assert(playerIdx < NumPlayers);
        _playerScores[playerIdx].Add(score);
    }

    public bool RemoveLastScore(int playerIdx)
    {
        Debug.Assert(playerIdx < NumPlayers);
        
        var scoreList = _playerScores[playerIdx];
        if (scoreList.Count > 0)
        {
            scoreList.RemoveAt(scoreList.Count - 1);
            return true;
        }

        return false;
    }

    public bool HasScores(int playerIdx)
    {
        Debug.Assert(playerIdx < NumPlayers);
        return _playerScores[playerIdx].Count > 0;
    }

    public string GetScoreList(int playerIdx)
    {
        Debug.Assert(playerIdx < NumPlayers);
        return _playerScores[playerIdx].Aggregate(string.Empty, (current, score) => current + $"{score}\n");
    }

    public int GetTotal(int playerIdx)
    {
        Debug.Assert(playerIdx < NumPlayers);
        return _playerScores[playerIdx].Sum();
    }
    
    public int GetMax(int playerIdx)
    {
        Debug.Assert(playerIdx < NumPlayers);
        return _playerScores[playerIdx].Max();
    }
}
