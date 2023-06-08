using System;

namespace TicTacToe.Models;

public class Game
{
    private int[,] _board = new int[3, 3];
    private const Player Player1 = Player.Player1;
    private const Player Player2 = Player.Player2;
    private Player _currentPlayer = Player1;

    private void PlaceSign(int row, int column, Player player)
    {
        if (row > 3 || row < 0 || column > 3 || column < 0) return;
        if(_board[row, column] != 0) return;
        
        _board[row, column] += player switch
        {
            Player1 => 1,
            Player2 => 2,
            _ => throw new ArgumentOutOfRangeException(nameof(player), player, null)
        };
    }

    private bool CheckForWinner(int row, int column)
    {
        int sign = _board[row, column];

        // Check row
        if (_board[row, 0] == sign && _board[row, 1] == sign && _board[row, 2] == sign)
        {
            return true;
        }

        // Check column
        if (_board[0, column] == sign && _board[1, column] == sign && _board[2, column] == sign)
        {
            return true;
        }

        // Check diagonals
        if (row == column || row + column == 2)
        {
            if (_board[0, 0] == sign && _board[1, 1] == sign && _board[2, 2] == sign)
            {
                return true;
            }

            if (_board[0, 2] == sign && _board[1, 1] == sign && _board[2, 0] == sign)
            {
                return true;
            }
        }

        return false;
    }

    public Player GetCurrentPlayer()
    {
        return _currentPlayer;
    }

    private void SwitchPlayer()
    {
        _currentPlayer = _currentPlayer switch
        {
            Player1 => Player2,
            Player2 => Player1,
            _ => _currentPlayer
        };
    }

    private void Restart()
    {
        _board = new int[3, 3];
    }

    public bool PlayTheGame(int row, int column, Player player)
    {
        PlaceSign(row, column, player);
        if (CheckForWinner(row, column))
        {
            Restart();
            return true;
        }

        SwitchPlayer();
        return false;
    }
}