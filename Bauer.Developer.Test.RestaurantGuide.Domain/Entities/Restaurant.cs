using Bauer.Developer.Test.RestaurantGuide.Domain.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bauer.Developer.Test.RestaurantGuide.Domain
{

    [MetadataType(typeof(RestaurantMetadata))]
    public partial class Restaurant : IEntity
    {

    }

    public class RestaurantMetadata
    {
        [Required]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The restaurant name is mandatory (nobody likes a no name restaurant)")]
        [MaxLength(250, ErrorMessage = "The name of the restaurant is too long (everbody likes a name that they can remember)")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The restaurant must have at least a cuisine, don't you think?")]
        public int CuisineId { get; set; }
        [Required(ErrorMessage = "The restaurant must have a chef, no?")]
        [MaxLength(500, ErrorMessage = "The chef name is too long, please keep it to essentials")]
        public string Chef { get; set; }
        [Required(ErrorMessage = "The restaurant must have a rating")]
        public byte Rating { get; set; }
        [Required(ErrorMessage = "The restaurant must have an address")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Suburb { get; set; }
        [Required(ErrorMessage = "The restaurant must have a state and be in one")]
        public string State { get; set; }
        [Required(ErrorMessage = "The restaurant must have a postcode")]
        public string PostCode { get; set; }
        [Required(ErrorMessage = "The restaurant must have a phone number")]
        [AustralianPhoneNumber(ErrorMessage = "The phone number is not a valid one in Australia")]
        public string PhoneNumber { get; set; }
    }
}
