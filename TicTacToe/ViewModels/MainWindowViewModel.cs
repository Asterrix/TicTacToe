using ReactiveUI;
using TicTacToe.Models;

namespace TicTacToe.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    public WindowSize WindowSize { get; } = new();
}