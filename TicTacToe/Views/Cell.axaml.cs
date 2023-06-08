using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TicTacToe.Models;
using static Avalonia.AvaloniaProperty;

namespace TicTacToe.Views;

public partial class Cell : UserControl
{
    public static readonly StyledProperty<int> RowProperty = Register<Cell, int>(nameof(Row));
    public static readonly StyledProperty<int> ColumnProperty = Register<Cell, int>(nameof(Column));
    public static readonly StyledProperty<Game> GameProperty = Register<Cell, Game>(nameof(Game));
    
    public int Row
    {
        get => GetValue(RowProperty);
        set => SetValue(RowProperty, value);
    }

    public int Column
    {
        get => GetValue(ColumnProperty);
        set => SetValue(ColumnProperty, value);
    }
    
    public Game Game
    {
        get => GetValue(GameProperty);
        set => SetValue(GameProperty, value);
    }
    
    public Cell()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var button = (Button)sender!;

        var currentPlayer = Game.GetCurrentPlayer();
        if (!ReferenceEquals(button.Content, ""))
        {
            return;
        }
        
        // Change the content of a button to appropriate sign 
        button.Content = currentPlayer switch
        {
            Player.Player1 => "X",
            Player.Player2 => "O",
            _ => button.Content
        };
        
        bool winner = Game.PlayTheGame(Row, Column, currentPlayer);
        if (winner)
        {
            var popupWindow = new Winner();
            popupWindow.SystemDecorations = SystemDecorations.None;
            popupWindow.Show();
        }
    }
}