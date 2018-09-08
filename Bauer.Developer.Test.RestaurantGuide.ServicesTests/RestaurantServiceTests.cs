using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bauer.Developer.Test.RestaurantGuide.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bauer.Developer.Test.RestaurantGuide.Domain;
using Bauer.Developer.Test.RestaurantGuide.DataAccess.Common;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace Bauer.Developer.Test.RestaurantGuide.Services.Tests
{
    [TestClass()]
    public class RestaurantServiceTests
    {
        [TestMethod()]
        public void WhenTryingtoSaveAnEmptyRestaurantEntity()
        {
            //Arrange
            var restaurant = new Restaurant();

            var moqRestaurantRepository = new Mock<IBaseRepository<Restaurant>>();
            moqRestaurantRepository.Setup(x => x.Update(restaurant)).Returns(1);
            var moqUnitOfWork = new Mock<IUnitOfWork>();
            moqUnitOfWork.Setup(x => x.Repository<Restaurant>()).Returns(moqRestaurantRepository.Object);
            var restaurantService = new RestaurantService(moqUnitOfWork.Object);
            //Act
            void act() { restaurantService.SaveRestaurant(restaurant); }
            //Assert,
            Assert.ThrowsException<ValidationException>(new Action(act));
        }

        [TestMethod()]
        public void WhenTryingtoSaveAValidPhoneNumberRestaurant()
        {
            //Arrange
            var restaurant = new Restaurant();
            restaurant.Name = "Test restaurant";
            restaurant.PhoneNumber = "(04)1111 22221234";
            restaurant.Id = 1;
            restaurant.PostCode = "1111";
            restaurant.Rating = 1;
            restaurant.State = "NSW";
            restaurant.Suburb = "Test one";
            restaurant.AddressLine1 = "Address 1";
            restaurant.AddressLine2 = "Address 2";
            restaurant.Chef = "Test Chef";
            restaurant.CuisineId = 1;

            var moqRestaurantRepository = new Mock<IBaseRepository<Restaurant>>();
            moqRestaurantRepository.Setup(x => x.Update(restaurant)).Returns(1);
            var moqUnitOfWork = new Mock<IUnitOfWork>();
            moqUnitOfWork.Setup(x => x.Repository<Restaurant>()).Returns(moqRestaurantRepository.Object);
            moqUnitOfWork.Setup(x => x.SaveChanges()).Returns(1);
            var restaurantService = new RestaurantService(moqUnitOfWork.Object);
            ValidationException vex = null;
            //Act
            try
            {

                restaurantService.SaveRestaurant(restaurant);
            }
            catch (Exception v)
            {
                Assert.Fail(v.Message);
            }
            //Assert,
            Assert.IsTrue(restaurant.PhoneNumber == "411112222");
        }

        [TestMethod()]
        public void WhenTryingtoSaveARestaurantWithNoName()
        {
            //Arrange
            var restaurant = new Restaurant();
            restaurant.Name = null;
            restaurant.PhoneNumber = "0411112222";
            restaurant.Id = 1;
            restaurant.PostCode = "1111";
            restaurant.Rating = 1;
            restaurant.State = "NSW";
            restaurant.Suburb = "Test one";
            restaurant.AddressLine1 = "Address 1";
            restaurant.AddressLine2 = "Address 2";
            restaurant.Chef = "Test Chef";
            restaurant.CuisineId = 1;

            var moqRestaurantRepository = new Mock<IBaseRepository<Restaurant>>();
            moqRestaurantRepository.Setup(x => x.Update(restaurant)).Returns(1);
            var moqUnitOfWork = new Mock<IUnitOfWork>();
            moqUnitOfWork.Setup(x => x.Repository<Restaurant>()).Returns(moqRestaurantRepository.Object);
            var restaurantService = new RestaurantService(moqUnitOfWork.Object);
            ValidationException vex = null;
            //Act
            try
            {

                restaurantService.SaveRestaurant(restaurant);
            }
            catch(ValidationException v)
            {
                vex = v;
            }
            //Assert,
            Assert.IsTrue(vex != null && (vex.Value as ICollection<ValidationResult>).Any(x => x.MemberNames.Any(name => name == nameof(restaurant.Name))));
        }

        [TestMethod()]
        public void WhenTryingtoSaveARestaurantWithAHugeName()
        {
            //Arrange
            var restaurant = new Restaurant();
            restaurant.Name = new String('a', 251); 
            restaurant.PhoneNumber = "0411112222";
            restaurant.Id = 1;
            restaurant.PostCode = "1111";
            restaurant.Rating = 1;
            restaurant.State = "NSW";
            restaurant.Suburb = "Test one";
            restaurant.AddressLine1 = "Address 1";
            restaurant.AddressLine2 = "Address 2";
            restaurant.Chef = "Test Chef";
            restaurant.CuisineId = 1;

            var moqRestaurantRepository = new Mock<IBaseRepository<Restaurant>>();
            moqRestaurantRepository.Setup(x => x.Update(restaurant)).Returns(1);
            var moqUnitOfWork = new Mock<IUnitOfWork>();
            moqUnitOfWork.Setup(x => x.Repository<Restaurant>()).Returns(moqRestaurantRepository.Object);
            var restaurantService = new RestaurantService(moqUnitOfWork.Object);
            ValidationException vex = null;
            //Act
            try
            {

                restaurantService.SaveRestaurant(restaurant);
            }
            catch (ValidationException v)
            {
                vex = v;
            }
            //Assert,
            Assert.IsTrue(vex != null && (vex.Value as ICollection<ValidationResult>).Any(x => x.MemberNames.Any(name => name == nameof(restaurant.Name))));
        }

        [TestMethod()]
        public void WhenTryingtoSaveARestaurantWithAHugeChefName()
        {
            //Arrange
            var restaurant = new Restaurant();
            restaurant.Name = "Test restaurant";
            restaurant.PhoneNumber = "0411112222";
            restaurant.Id = 1;
            restaurant.PostCode = "1111";
            restaurant.Rating = 1;
            restaurant.State = "NSW";
            restaurant.Suburb = "Test one";
            restaurant.AddressLine1 = "Address 1";
            restaurant.AddressLine2 = "Address 2";
            restaurant.Chef = new String('a', 501); 
            restaurant.CuisineId = 1;

            var moqRestaurantRepository = new Mock<IBaseRepository<Restaurant>>();
            moqRestaurantRepository.Setup(x => x.Update(restaurant)).Returns(1);
            var moqUnitOfWork = new Mock<IUnitOfWork>();
            moqUnitOfWork.Setup(x => x.Repository<Restaurant>()).Returns(moqRestaurantRepository.Object);
            var restaurantService = new RestaurantService(moqUnitOfWork.Object);
            ValidationException vex = null;
            //Act
            try
            {

                restaurantService.SaveRestaurant(restaurant);
            }
            catch (ValidationException v)
            {
                vex = v;
            }
            //Assert,
            Assert.IsTrue(vex != null && (vex.Value as ICollection<ValidationResult>).Any(x => x.MemberNames.Any(name => name == nameof(restaurant.Chef))));
        }

        [TestMethod()]
        public void WhenTryingtoSaveARestaurantWithAnEmptyChefName()
        {
            //Arrange
            var restaurant = new Restaurant();
            restaurant.Name = "Test restaurant";
            restaurant.PhoneNumber = "0411112222";
            restaurant.Id = 1;
            restaurant.PostCode = "1111";
            restaurant.Rating = 1;
            restaurant.State = "NSW";
            restaurant.Suburb = "Test one";
            restaurant.AddressLine1 = "Address 1";
            restaurant.AddressLine2 = "Address 2";
            restaurant.Chef = String.Empty;
            restaurant.CuisineId = 1;

            var moqRestaurantRepository = new Mock<IBaseRepository<Restaurant>>();
            moqRestaurantRepository.Setup(x => x.Update(restaurant)).Returns(1);
            var moqUnitOfWork = new Mock<IUnitOfWork>();
            moqUnitOfWork.Setup(x => x.Repository<Restaurant>()).Returns(moqRestaurantRepository.Object);
            var restaurantService = new RestaurantService(moqUnitOfWork.Object);
            ValidationException vex = null;
            //Act
            try
            {

                restaurantService.SaveRestaurant(restaurant);
            }
            catch (ValidationException v)
            {
                vex = v;
            }
            //Assert,
            Assert.IsTrue(vex != null && (vex.Value as ICollection<ValidationResult>).Any(x => x.MemberNames.Any(name => name == nameof(restaurant.Chef))));
        }

        [TestMethod()]
        public void WhenTryingtoSaveARestaurantWithUnicodeChefName()
        {
            //Arrange
            var restaurant = new Restaurant();
            restaurant.Name = "Test restaurant";
            restaurant.PhoneNumber = "0411112222";
            restaurant.Id = 1;
            restaurant.PostCode = "1111";
            restaurant.Rating = 1;
            restaurant.State = "NSW";
            restaurant.Suburb = "Test one";
            restaurant.AddressLine1 = "Address 1";
            restaurant.AddressLine2 = "Address 2";
            restaurant.Chef = "Un bloc din Capitală";
            restaurant.CuisineId = 1;

            var moqRestaurantRepository = new Mock<IBaseRepository<Restaurant>>();
            moqRestaurantRepository.Setup(x => x.Update(restaurant)).Returns(1);
            var moqUnitOfWork = new Mock<IUnitOfWork>();
            moqUnitOfWork.Setup(x => x.Repository<Restaurant>()).Returns(moqRestaurantRepository.Object);
            var restaurantService = new RestaurantService(moqUnitOfWork.Object);
            ValidationException vex = null;
            //Act
            try
            {

                restaurantService.SaveRestaurant(restaurant);
            }
            catch (Exception v)
            {
                Assert.Fail();
            }
            //Assert,
            Assert.IsTrue(1 == 1);
        }


        [TestMethod()]
        public void WhenTryingtoSaveARestaurantWithInvalidPhoneNumber()
        {
            //Arrange
            var restaurant = new Restaurant();
            restaurant.Name = "Test restaurant";
            restaurant.PhoneNumber = "041111222";
            restaurant.Id = 1;
            restaurant.PostCode = "1111";
            restaurant.Rating = 1;
            restaurant.State = "NSW";
            restaurant.Suburb = "Test one";
            restaurant.AddressLine1 = "Address 1";
            restaurant.AddressLine2 = "Address 2";
            restaurant.Chef = "Test chef";
            restaurant.CuisineId = 1;

            var moqRestaurantRepository = new Mock<IBaseRepository<Restaurant>>();
            moqRestaurantRepository.Setup(x => x.Update(restaurant)).Returns(1);
            var moqUnitOfWork = new Mock<IUnitOfWork>();
            moqUnitOfWork.Setup(x => x.Repository<Restaurant>()).Returns(moqRestaurantRepository.Object);
            var restaurantService = new RestaurantService(moqUnitOfWork.Object);
            ValidationException vex = null;
            //Act
            try
            {

                restaurantService.SaveRestaurant(restaurant);
            }
            catch (ValidationException v)
            {
                vex = v;
            }
            //Assert,
            Assert.IsTrue(vex != null && (vex.Value as ICollection<ValidationResult>).Any(x => x.MemberNames.Any(name => name == nameof(restaurant.PhoneNumber))));
        }

    }
}