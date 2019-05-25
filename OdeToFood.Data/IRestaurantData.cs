using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>() {
                new Restaurant{ Id=1, Name="Scott's Pizza",Location="Maryland",Cuisine=CuisineType.Italain},
                new Restaurant{ Id=2, Name="Cinnamon Club",Location="London",Cuisine=CuisineType.Mexican},
                new Restaurant{ Id=3, Name="La Costa",Location="California",Cuisine=CuisineType.Indian}
            };
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
