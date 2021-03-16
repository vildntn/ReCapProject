using Core.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {//magic stringi önlemek için oluşturduğumuz sınıf
        //static --> sürekli instance yani newlemeye gerek kalmadan sürekli kullanabiliriz
        public static string CarAdded = "New Car Added";
        public static string CarDeleted = "Car Deleted";
        public static string CarUpdated = "Car Updated";
        public static string CarListed = "Cars Listed";
        public static string UnSuccessful = "Operation Failed";


        public static string BrandAdded = "New Brand Added";
        public static string BrandDeleted = "Brand Deleted";
        public static string BrandUpdated = "Brand Updated";
        public static string BrandListed = "Brands Listed";



        public static string ColorAdded = "New Color Added";
        public static string ColorDeleted = "Color Deleted";
        public static string ColorUpdated = "Color Updated";
        public static string ColorListed = "Colors Listed";



        public static string RentalAdded = "New Rental Added";
        public static string RentalDeleted = "Rental Deleted";
        public static string RentalUpdated = "Rental Updated";
        public static string RentalListed = "Rental Listed";


        public static string CustomerAdded = "New Customer Added";
        public static string CustomerDeleted = "Customer Deleted";
        public static string CustomerUpdated = "Customer Updated";
        public static string CustomerListed = "Customer Listed";


        public static string UserAdded = "New User Added ";
        public static string UserDeleted = "User Deleted";
        public static string UserUpdated = "User Updated";
        public static string UserListed = "User Listed";



        public static string CarImageAdded = "New Car Image Added ";
        public static string CarImageDeleted = "Car Image Deleted";
        public static string CarImageUpdated = "Car Image Updated";
        public static string CarImageListed = "Car Image Listed";


        public static string BrandNameInvalid = "Brand name invalid.Brand Name Must Be More Than Two Characters.";
        public static string CarImageLimitet="Only 5 images can be entered for a car";
        public static string AuthorizationDenied= "You have no authority.";

        public static string AccessTokenCreated = "Token created";
        public static string UserAlreadyExists="User Already Exist";
        public static string SuccessfulLogin = "Successful Login";
        public static string PasswordError = "The Password is Incorrect.";
        public static string UserNotFound="User Not Found";
        public static string UserRegistered = "User Registration is Successful.";
    }
}
