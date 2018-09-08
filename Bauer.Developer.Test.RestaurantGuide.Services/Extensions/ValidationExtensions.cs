using AutoMapper;
using Bauer.Developer.Test.RestaurantGuide.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bauer.Developer.Test.RestaurantGuide.Services.Validation
{
    public static class ValidationExtensions
    {
        public static bool TryValidateObject(this IEntity entity, out List<ValidationResult> validationResults)
        {
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(entity);
            validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(entity, context, validationResults, true);
            if (!isValid) return false;
            var metadataTypeAttribute = entity.GetType().GetCustomAttributes(
        typeof(MetadataTypeAttribute), true
    ).FirstOrDefault() as MetadataTypeAttribute;
            if (metadataTypeAttribute == null)
                return true;
            //Mapper.Initialize();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap(entity.GetType(), metadataTypeAttribute.MetadataClassType);
            });
            var metadataObject = config.CreateMapper().Map(entity, entity.GetType(), metadataTypeAttribute.MetadataClassType);
            context = new System.ComponentModel.DataAnnotations.ValidationContext(metadataObject);
            isValid = Validator.TryValidateObject(metadataObject, context, validationResults, true);
            return isValid;
        }
    }
}
