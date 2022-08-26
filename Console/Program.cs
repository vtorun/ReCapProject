using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;



//CarManager carManager = new CarManager(new EfCarDal());
//foreach (var car in carManager.GetCarDetails().Data)
//{
//    Console.WriteLine(car.CarId + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
//}

//Console.WriteLine("----------------------------------");
//carManager.Add(new Entities.Concrete.Car { BrandId = 4, ColorId = 4, ModelYear = 2018, DailyPrice = 175, Description = "Araba" });

ColorManager colorManager = new ColorManager(new EfColorDal());
foreach (var color in colorManager.GetAll().Data)
{
    Console.WriteLine(color.ColorId + " " + color.ColorName);
}

//RentalManager rentalManager = new RentalManager(new EfRentalDal());
//Rental rental = new Rental();
//rental.CarId = 2;
//rental.CustomerId = 3;
//rental.RentDate = DateTime.Now.Date;
//rentalManager.Add(rental);

//foreach (var item in rentalManager.GetAll().Data)
//{
//    Console.WriteLine(item.CarId);
//}





