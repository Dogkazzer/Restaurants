﻿using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.View_Components
{
    public class RestaurantCountViewComponent: ViewComponent
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IViewComponentResult Invoke()
        {
            var count = _restaurantData.GetCountOfRestaurants();
            return View(count);
        }
    }
}
