using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;
        private readonly ILogger<ListModel> _logger;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration config, IRestaurantData restaurantData, ILogger<ListModel> logger ) //via dependency injection we have access to config in this page
        {
            _config = config;
            _restaurantData = restaurantData;
            _logger = logger;
        }
        
        public void OnGet()   //this responds to an HttpGet request
        {
            _logger.LogError("Executing ListModel");
            Message = _config["Message"]; //the message stored in app settings.json
            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
