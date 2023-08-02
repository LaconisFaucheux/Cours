using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PizzaMama.Data;
using PizzaMama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaMama.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private DataContext _dataContext;

        public PrivacyModel(ILogger<PrivacyModel> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        public void OnGet()
        {
            //Pizza pizza = new Pizza() {nom = "PizzaTest", prix = 5 };
            //_dataContext.Pizzas.Add(pizza);
            //_dataContext.SaveChanges();
            
        }
    }
}
