using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bauer.Developer.Test.RestaurantGuide.Domain
{
    [MetadataType(typeof(CuisineMetadata))]
    public partial class Cuisine
    {
    }

    public  class CuisineMetadata
    {
        [Required]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The cusine name is a mandatory field, please fill it")]
        [MaxLength(100, ErrorMessage = "The name of the cusisine is too long, plese enter something shorter")]
        public string Name { get; set; }
    }
}
