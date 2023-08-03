using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaMama.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaMama.Pages
{
    public class MenuPizzasModel : PageModel
    {
        private readonly PizzaMama.Data.DataContext _context;
        public IList<Pizza> cartePizzas {get; set;}

        public MenuPizzasModel(PizzaMama.Data.DataContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            cartePizzas = await _context.Pizzas.ToListAsync();
        }
    }
}
