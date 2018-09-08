using Bauer.Developer.Test.RestaurantGuide.Domain;
using Bauer.Developer.Test.RestaurantGuide.Domain.ValidationAttributes;
using Bauer.Developer.Test.RestaurantGuide.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bauer.Developer.Test.RestaurantGuide.Site.Models
{
    [MetadataType(typeof(RestaurantModelMetadata))]
    public class RestaurantModel
    {
        public RestaurantModel()
        {

        }
        public RestaurantModel(Restaurant restaurant)
        {
            if (restaurant == null)
                return;
            this.Id = restaurant.Id;
            this.Name = restaurant.Name;
            this.Chef = restaurant.Chef;
            this.PhoneNumber = restaurant.PhoneNumber;
            this.PostCode = restaurant.PostCode;
            this.Rating = restaurant.Rating;
            this.State = restaurant.State;
            this.Suburb = restaurant.Suburb;
            this.AddressLine1 = restaurant.AddressLine1;
            this.AddressLine2 = restaurant.AddressLine2;
            this.CuisineId = restaurant.CuisineId;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
        public string Chef { get; set; }
        public string PhoneNumber { get; set; }
        public int? CuisineId { get; set; }
        public byte? Rating { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Cuisine
        {
            get
            {
                if (CuisineId.HasValue)
                {
                    return ((CuisineEnum)(CuisineId)).ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                try
                {
                    this.CuisineId = (int)((CuisineEnum)Enum.Parse(typeof(CuisineEnum), value));
                }
                catch
                {
                    this.CuisineId = null;
                }
            }
        }

        /// <summary>
        /// To the restaurant.
        /// </summary>
        /// <returns>A restaurant object</returns>
        public Restaurant ToRestaurant(Restaurant restaurant = null)
        {
            if (restaurant == null)
                restaurant = new Restaurant();
            restaurant.Id = this.Id ?? restaurant.Id;
            restaurant.Name = this.Name ?? restaurant.Name;
            restaurant.Chef = this.Chef ?? restaurant.Chef;
            restaurant.PhoneNumber = this.PhoneNumber ?? restaurant.PhoneNumber;
            restaurant.PostCode = this.PostCode ?? restaurant.PostCode;
            restaurant.Rating = this.Rating ?? restaurant.Rating;
            restaurant.State = this.State ?? restaurant.State;
            restaurant.Suburb = this.Suburb ?? restaurant.Suburb;
            restaurant.AddressLine1 = this.AddressLine1 ?? restaurant.AddressLine1;
            restaurant.AddressLine2 = this.AddressLine2 ?? restaurant.AddressLine2;
            restaurant.CuisineId = this.CuisineId ?? restaurant.CuisineId;
            return restaurant;
        }

        private string phoneNumberFormated;
        public string PhoneNumberFormated
        {
            get
            {
                if (PhoneNumber != null)
                {
                    if (this.PhoneNumber.Length > 8)
                    {
                        return $"(0{this.PhoneNumber.Substring(0, 1)}){this.PhoneNumber.Substring(1, 4)} {this.PhoneNumber.Substring(4, 4)}";
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return phoneNumberFormated;
                }
            }
            set
            {
                this.PhoneNumber = phoneNumberFormated = RestaurantService.TransformPhoneNumber(value);
            }
        }
    }

    internal class RestaurantModelMetadata : RestaurantMetadata
    {
        [Required(ErrorMessage = "The restaurant must have a phone number")]
        [AustralianPhoneNumber(ErrorMessage = "The phone number is not a valid one in Australia")]
        [RegularExpression(@"^\({0,1}((0|\+61|61){0,1}(2|4|3|7|8)){1}\){0,1}(\ |-){0,1}[0-9]{2}(\ |-){0,1}[0-9]{2}(\ |-){0,1}[0-9]{1}(\ |-){0,1}[0-9]{3,}$", ErrorMessage = "The phone number is not a valid one")]
        public string PhoneNumberFormated { get; set; }
    }
}