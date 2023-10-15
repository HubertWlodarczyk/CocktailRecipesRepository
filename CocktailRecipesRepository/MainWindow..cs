﻿using System.Windows;

namespace CocktailRecipesRepository;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        MenuFrame.Navigate(new Menu());
    }
}