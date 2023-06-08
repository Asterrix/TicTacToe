using ReactiveUI;
using TicTacToe.Models;

namespace TicTacToe.ViewModels;

public class CellGridViewModel : ReactiveObject
{
    public Game Game { get; set; } = new();
}