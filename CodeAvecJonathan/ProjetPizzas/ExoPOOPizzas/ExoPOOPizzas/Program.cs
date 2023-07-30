using System;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace projet_pizza
{
    class PizzaPerso : Pizza
    {
        private static int indexPizza;
        public PizzaPerso() : base("Pizza Personnalisée", 5, false, null)
        {
            Ingredients = new List<string>();
            Name = Name + " " + (indexPizza + 1);
            indexPizza++;

            while (true)
            {
                Console.WriteLine("Ecrivez les ingrédients de votre pizza personnalisée:");
                var ingredient = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(ingredient))
                {
                    Console.WriteLine($"Sélection {Name} enregistrée!\n");
                    break;
                }
                else
                {
                    if (Ingredients.Contains(ingredient))
                    {
                        Console.WriteLine("Cet ingrédient a déjà été ajouté!");
                        continue;
                    }
                    else
                    {
                        Ingredients.Add(ingredient);
                        Console.WriteLine(string.Join(", ", Ingredients));
                        Console.WriteLine();
                    }
                }
            }
            Price = 5 + (1.5f * Ingredients.Count());
        }
    }
    class Pizza
    {
        public string Name { get; init; }
        public float Price { get; init; }
        public bool IsVege { get; init; }
        public List<string> Ingredients { get; init; } = new List<string>();

        public Pizza (string name, float price, bool isVege, List<string> ingredients)
        {
            Name = name;
            Price = price;
            IsVege = isVege;
            Ingredients = ingredients;
        }

        public void Afficher()
        {
            string DisplayedPizza = IsVege ? $"{FormatFirstLetterToUpper(Name)} (V) - {Price} €" : $"{FormatFirstLetterToUpper(Name)} - {Price} €";
            Console.WriteLine(DisplayedPizza);

            List<string> DisplayedIngredients = new List<string>();
            foreach (string ingredient in Ingredients)
            {
                DisplayedIngredients.Add(FormatFirstLetterToUpper(ingredient));
            }

            if (Ingredients != null &&  Ingredients.Count > 0)
            {
                Console.WriteLine(string.Join(", ", DisplayedIngredients));
            }
            else
            {
                Console.WriteLine("-");
            }

            Console.WriteLine("");
            
        }

        private static string FormatFirstLetterToUpper(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            str = str.ToUpper();
            return $"{str[0]}{str[1..].ToLower()}";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<string> ingredients4Fromages = new List<string>()
            {
                "Base crème", 
                "Chèvre",
                "BleU",
                "moZZarella",
                "cOmté"
            };
            List<string> ingredientsChorizo = new List<string>()
            {
                "BAse tomate",
                "tomate",
                "Chorizo",
                "MozzarElla",
                "Poivrons"
            };
            List<string> ingredientsThai = new List<string>()
            {
                "base tOmate",
                "poulet",
                "noix de Cajou",
                "Roquette",
                "Sauce Thaï",
                "Coriandre fraîche"
            };
            List<string> ingredientsChevreMiel = new List<string>()
            {
                "Base tomate",
                "Chèvre",
                "Mozzarella",
                "Chèvre"
            };
            List<string> ingredientsReine = new List<string>()
            {
                "Base tomate",
                "Jambon",
                "Mozzarella"
            };

            List<Pizza> CartePizzas = new List<Pizza>()
            {
                new Pizza("4 Fromages", 11.5f, true, ingredients4Fromages),
                new Pizza("chorizo", 9.5f, false, ingredientsChorizo),
                new Pizza("THAÎ", 12.5f, false, ingredientsThai),
                new Pizza("ChèVre MIel", 10.5f, true, ingredientsChevreMiel),
                new Pizza("ReinE", 8.5f, false, ingredientsReine),
                new PizzaPerso(),
                new PizzaPerso()
            };

            CartePizzas = CartePizzas.OrderBy(p => p.Price).ToList(); //Tri du plus petit au plus grand
            CartePizzas = CartePizzas.OrderByDescending(p => p.Price).ToList(); //Tri du plus grand au plus petit

            //Pizza maxPricePizza = CartePizzas[0];
            //Pizza minPricePizza = CartePizzas[0];

            //foreach (Pizza p in CartePizzas)
            //{
            //    if (maxPricePizza.Price < p.Price)
            //    {
            //        maxPricePizza = p;
            //    }
            //    if (minPricePizza.Price > p.Price)
            //    {
            //        minPricePizza = p;
            //    }
            //}

            //CartePizzas = CartePizzas.Where(p => p.Ingredients.Where(i => i.ToLower().Contains("tomate")).ToList().Count > 0).ToList();
            //Console.WriteLine("Les pizzas qui contiennent de la tomate sont:");
            

            foreach (Pizza pizza in CartePizzas)
            {
                pizza.Afficher();
            }

            //Console.WriteLine($"La pizza la plus chère est :");
            //maxPricePizza.Afficher();
            //Console.WriteLine($"La pizza la moins chère est :");
            //minPricePizza.Afficher();


        }
    }
}