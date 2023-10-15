using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;

namespace CocktailRecipesRepository;

public partial class AddCocktail : Page
{
    private Cocktail newCocktail;
    public AddCocktail()
    {
        InitializeComponent();
        newCocktail = new Cocktail();
        newCocktail.ingredients = new List<Ingredient>();
    }

    private void AddIngredient(object sender, RoutedEventArgs e)
    {
        Ingredient newIngredient = new Ingredient();
        newIngredient.name = IngredientTextBox.Text;
        newIngredient.unit = UnitComboBox.Text;
        newIngredient.quantity = Int32.Parse(QuantityTextBox.Text);
        newIngredient.step = StepComboBox.Text;
        String temp = newIngredient.name + " " + newIngredient.quantity.ToString()+ " " + newIngredient.unit +" " + newIngredient.step;
        IngredientListBox.Items.Add(temp);
        newCocktail.ingredients.Add(newIngredient);
    }

    private void DeleteIngredient(object sender, RoutedEventArgs e)
    {
        string ingredientName = IngredientListBox.SelectedItem.ToString();
        var strings = ingredientName.Split(ingredientName, ' ');
        var ingredientToDelete =
            newCocktail.ingredients.SingleOrDefault(ingredient => ingredient.name == strings[0]);
        newCocktail.ingredients.Remove(ingredientToDelete);
        IngredientListBox.Items.Remove(IngredientListBox.SelectedItem);
    }

    private void SaveCocktail(object sender, RoutedEventArgs e)
    {
        newCocktail.name = CoctailNameTextBox.Text;
        newCocktail.glass = GlassComboBox.Text;
        newCocktail.iceInGlass = (bool)IceInGlassCheckBox.IsChecked;
        
        List<XElement> ings = new List<XElement>();
        foreach (var ing in newCocktail.ingredients)
        {
            XElement newIng =
                new XElement("Ingredient",
                    new XElement("name", ing.name),
                    new XElement("quantity", ing.quantity.ToString()),
                    new XElement("unit", ing.unit),
                    new XElement("step", ing.step)
                );
            ings.Add(newIng);
        }
        XElement newIngToPut=new XElement("Cocktail",
                new XElement("name", newCocktail.name),
                new XElement("iceInGlass", newCocktail.iceInGlass.ToString()),
                new XElement("glass", newCocktail.glass),
                new XElement("ingredients", ings)
            );
        XDocument xmlDocument;
        if (!File.Exists("Recipes.xml"))
        {
            xmlDocument = new XDocument(new XElement("Coctails",newIngToPut));
        }
        else
        {
            xmlDocument = XDocument.Load("Recipes.xml");
            xmlDocument.Root.Add(newIngToPut);
        }
        xmlDocument.Save("Recipes.xml");
    }
}