using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Charlie's Pizza", Location="Marlborough", Cuisine=CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Pomegranate", Location="Manchester", Cuisine=CuisineType.Italian},
                new Restaurant { Id = 3, Name = "Awesome Avocado", Location = "Southsea", Cuisine=CuisineType.Vegan}
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id); //find the restaurant to delete inside of the collection of restaurants that we have where id matches the incoming id
            if (restaurant != null) //if the restaurant exists
            {
                restaurants.Remove(restaurant); //go to the restaurants collection and remove this object
            }
            return null;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}
