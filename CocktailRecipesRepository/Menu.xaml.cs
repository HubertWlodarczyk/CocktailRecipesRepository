using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;

namespace CocktailRecipesRepository;

public partial class Menu : Page
{
    public Menu()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new AddCocktail());
    }
}