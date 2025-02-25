﻿using System.Collections.Generic;
using System.Linq;
using RR.DomainContracts;
using RR.Models;
using RR.QueryObjects;
using RR.RepositoryContracts;

namespace RR.DomainServices
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public List<Restaurant> TopThreeRestaurantByAverageReview()
        {
            var resaurants = _restaurantRepository.GetAll();

            var query = new TopThreeRatingQuery();

            return query.AsExpression(resaurants);
        }

        public List<Restaurant> AllRestaurants()
        {
            return _restaurantRepository.GetAll().ToList();
        }

        public List<Restaurant> SearchAll(string searchParameter)
        {
            var query = new SearchRestaurantQuery(searchParameter);

            var restaurants = _restaurantRepository.GetAll();

            return query.AsExpression(restaurants);
        }

        public Restaurant SearchByName(string searchParameter)
        {
            return _restaurantRepository.GetByName(searchParameter);
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.Add(restaurant);
        }

        public List<Restaurant> AllRestaurants(string orderBy)
        {
            var allRestaurants = _restaurantRepository.GetAll();

            var query = new FilterRestaurantsQuery(orderBy);

            return query.AsExpression(allRestaurants);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.UpdateRestaurant(restaurant);
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.DeleteRestaurant(restaurant);
        }
    }
}
