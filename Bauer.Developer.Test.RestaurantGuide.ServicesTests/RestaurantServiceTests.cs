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
using System.Linq.Expressions;

namespace Bauer.Developer.Test.RestaurantGuide.Services.Tests
{
    [TestClass()]
    public class RestaurantServiceTests
    {
        private Restaurant CreateAValidRestaurant(int id = 1)
        {
            var restaurant = new Restaurant();
            restaurant.Name = "Test restaurant";
            restaurant.PhoneNumber = "(04)1111 2222 123456";
            restaurant.Id = id;
            restaurant.PostCode = "1111";
            restaurant.Rating = 1;
            restaurant.State = "NSW";
            restaurant.Suburb = "Test one";
            restaurant.AddressLine1 = "Address 1";
            restaurant.AddressLine2 = "Address 2";
            restaurant.Chef = "Test Chef";
            restaurant.CuisineId = 1;
            return restaurant;
        }

        private IQueryable<Restaurant> data;
        protected IQueryable<Restaurant> Data
        {
            get
            {
                if (data == null)
                    return new List<Restaurant>
                    {
                        CreateAValidRestaurant(),
                        CreateAValidRestaurant(2),
                        CreateAValidRestaurant(3),
                    }.AsQueryable();
                else
                    return data;
            }
            set
            {
                this.data = value;
            }
        }

        private RestaurantService MoqARestaurantService()
        {
            var moqRestaurantRepository = new Mock<IBaseRepository<Restaurant>>();
            moqRestaurantRepository.Setup(x => x.Update(It.IsAny<Restaurant>())).Returns(1);
            moqRestaurantRepository.Setup(x => x.Create(It.IsAny<Restaurant>())).Returns((Restaurant r) =>
            {
                var l = Data.ToList();
                l.Add(r);
                Data = l.AsQueryable();
                return r;
            });
            moqRestaurantRepository.Setup(x => x.All()).Returns(Data);
            moqRestaurantRepository.Setup(x => x.Find(It.IsAny<Expression<Func<Restaurant, bool>>>())).Returns((Expression<Func<Restaurant, bool>> predicate) => Data.FirstOrDefault(predicate));


            var moqUnitOfWork = new Mock<IUnitOfWork>();
            moqUnitOfWork.Setup(x => x.Repository<Restaurant>()).Returns(moqRestaurantRepository.Object);
            moqUnitOfWork.Setup(x => x.SaveChanges()).Returns(1);

            var restaurantService = new RestaurantService(moqUnitOfWork.Object);
            return restaurantService;
        }

        [TestMethod()]
        public void WhenTryingtoGetAllRestaurants()
        {
            //Arrange
            var restaurantService = MoqARestaurantService();
            //Act
            var restaurants = restaurantService.GetAllRestaurants();
            //Assert
            Assert.IsTrue(restaurants.Count() == Data.Count());
        }

        [TestMethod()]
        public void WhenTryingtoGetARestaurant()
        {
            //Arrange
            var restaurantService = MoqARestaurantService();
            //Act
            var restaurant = restaurantService.GetRestaurantById(1);
            //Assert
            Assert.IsTrue(restaurant != null && restaurant.Id == 1);
        }

        [TestMethod()]
        public void WhenTryingtoSaveANewValidRestaurant()
        {
            //Arrange
            var dataCount = Data.Count();
            var restaurant = CreateAValidRestaurant(0);
            var restaurantService = MoqARestaurantService();
            //Act
            try
            {
                restaurantService.SaveRestaurant(restaurant);
            }
            catch (Exception v)
            {
                Assert.Fail(v.Message);
            }
            //Assert
            Assert.IsTrue(Data.Count() == dataCount + 1);
        }

        [TestMethod()]
        public void WhenTryingtoSaveAnEmptyRestaurantEntity()
        {
            //Arrange
            var restaurant = new Restaurant();
            var restaurantService = MoqARestaurantService();
            //Act
            void act() { restaurantService.SaveRestaurant(restaurant); }
            //Assert
            Assert.ThrowsException<ValidationException>(new Action(act));
        }

        [TestMethod()]
        public void WhenTryingtoSaveAValidPhoneNumberRestaurant()
        {
            //Arrange
            var restaurant = CreateAValidRestaurant();
            var restaurantService = MoqARestaurantService();
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
        public void WhenTryingtoSaveAValidPhoneNumberWithAustralianInternationalPrefix()
        {
            //Arrange
            var restaurant = CreateAValidRestaurant();
            restaurant.PhoneNumber = "(+614)1111 2222 123456";
            var restaurantService = MoqARestaurantService();
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
        public void WhenTryingtoSaveARestaurantWithAPhoneNumberWithParanthesisNotEnclosingTheAreaCode()
        {
            //Arrange
            var restaurant = CreateAValidRestaurant();
            restaurant.PhoneNumber = "0411(11) 2222 123456";
            var restaurantService = MoqARestaurantService();
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

        [TestMethod()]
        public void WhenTryingtoSaveARestaurantWithAPhoneNumberWhereOpeningParanthesisNotMatchtClosingOnes()
        {
            //Arrange
            var restaurant = CreateAValidRestaurant();
            restaurant.PhoneNumber = "(041111 2222 123456";
            var restaurantService = MoqARestaurantService();
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

        [TestMethod()]
        public void WhenTryingtoSaveARestaurantWithNoName()
        {
            //Arrange
            var restaurant = CreateAValidRestaurant();
            restaurant.Name = null;
            var restaurantService = MoqARestaurantService();
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
        public void WhenTryingtoSaveARestaurantWithAHugeName()
        {
            //Arrange
            var restaurant = CreateAValidRestaurant();
            restaurant.Name = new String('a', 251);
            var restaurantService = MoqARestaurantService();
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
            var restaurant = CreateAValidRestaurant();
            restaurant.Chef = new String('a', 501);
            var restaurantService = MoqARestaurantService();
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
            var restaurant = CreateAValidRestaurant();
            restaurant.Chef = String.Empty;
            var restaurantService = MoqARestaurantService();
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
            var restaurant = CreateAValidRestaurant();
            restaurant.Chef = "Un bloc din Capitală";

            var restaurantService = MoqARestaurantService();
            //Act
            try
            {
                restaurantService.SaveRestaurant(restaurant);
            }
            catch (Exception v)
            {
                Assert.Fail();
            }
            //Assert
            Assert.IsTrue(restaurant.Chef == "Un bloc din Capitală");
        }

        [TestMethod()]
        public void WhenTryingtoSaveARestaurantWithInvalidPhoneNumber()
        {
            //Arrange
            var restaurant = CreateAValidRestaurant();
            restaurant.PhoneNumber = "44111122";
            var restaurantService = MoqARestaurantService();
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

        [TestMethod()]
        public void WhenTryingtoSaveARestaurantWithNotAustralianPhoneNumber()
        {
            //Arrange
            var restaurant = CreateAValidRestaurant();
            restaurant.PhoneNumber = "+40721112222";
            var restaurantService = MoqARestaurantService();
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

        [TestMethod()]
        public void WhenTryingtoSaveARestaurantWithInvalidCointainingLettersPhoneNumber()
        {
            //Arrange
            var restaurant = CreateAValidRestaurant();
            restaurant.PhoneNumber = "041111 2a22";

            var restaurantService = MoqARestaurantService();
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

        [TestMethod()]
        public void WhenTryingtoSaveARestaurantWithRatingAbove5()
        {
            //Arrange
            var restaurant = CreateAValidRestaurant();
            restaurant.Rating = 6;
            var restaurantService = MoqARestaurantService();
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
            Assert.IsTrue(vex != null && (vex.Value as ICollection<ValidationResult>).Any(x => x.MemberNames.Any(name => name == nameof(restaurant.Rating))));
        }

    }
}