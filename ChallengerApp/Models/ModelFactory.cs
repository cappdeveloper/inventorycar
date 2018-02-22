using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Challenger.Data.Entities;
using WebMatrix.WebData;
using System.Web.Security;

namespace ChallengerApp.Models
{
    public class ModelFactory
    {
        public Challenger.Data.Entities.UserProfile Create(UserProfileViewModel model)
        {
            return new Challenger.Data.Entities.UserProfile
            {
                UserId = model.UserId,
                Name = model.Name,
                UserName = model.UserName,
                IsActive = model.IsActive,
                Created = model.Created,
                Modified = model.Modified
            };
        }
        public UserProfileViewModel Create(Challenger.Data.Entities.UserProfile model)
        {
            return new UserProfileViewModel
            {
                UserId = model.UserId,
                Name = model.Name,
                UserName = model.UserName,
                IsActive = model.IsActive,
                Created = model.Created,
                Modified = model.Modified
            };
        }


     
        public Role Create(RoleViewModel model)
        {
            return new Role
            {
                RoleId = model.RoleId,
                RoleName = model.RoleName
            };
        }
        public RoleViewModel Create(Role model)
        {
            return new RoleViewModel
            {
                RoleId = model.RoleId,
                RoleName = model.RoleName
            };
        }

      
        public Vehicle Create(vehicletype model)
        {
            var vehicle = new Vehicle
            {
                Id = model.Id,
                Brand=model.Brand,
                Model=model.Model,
                Price=model.Price,
                Year=model.Year,
                IsNew=model.IsNew,
           UserName=model.UserName

        };
             return vehicle;
        }
        public vehicletype Create(Vehicle model)
        {
            var vehicleModel = new vehicletype
            {
                Id = model.Id,
                Year = model.Year,
                Brand=model.Brand,
                Model=model.Model,
                Price=model.Price,
                IsNew=model.IsNew,
                UserName=model.UserName
               
            };

            return vehicleModel;
        }


    }


}