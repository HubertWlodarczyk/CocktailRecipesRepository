using System.Collections.Generic;

namespace CocktailRecipesRepository;

public class Cocktail
{
    public string name { get; set; }
    public bool iceInGlass { get; set; }
    public string glass { get; set; }
    public List<Ingredient> ingredients { get; set; }
}