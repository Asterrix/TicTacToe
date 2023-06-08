using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TicTacToe.Models;
using static Avalonia.AvaloniaProperty;

namespace TicTacToe.Views;

public partial class CellGrid : UserControl
{
    private static readonly StyledProperty<Game> GameProperty = Register<CellGrid, Game>(nameof(Game));

    public Game Game
    {
        get => GetValue(GameProperty);
        set => SetValue(GameProperty, value);
    }
    public CellGrid()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}