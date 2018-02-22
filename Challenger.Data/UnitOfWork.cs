using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenger.Data.Entities;
using Challenger.Data.Concrete;


namespace Challenger.Data
{
    public class UnitOfWork : IDisposable
    {
        private ChallengerContext context = new ChallengerContext();

        private UserProfileRepository _userProfileRepository;
        private RoleRepository _roleRepository;
        private VehicleRepository _vehicleRepository;
       
        public UserProfileRepository UserProfileRepository
        {
            get
            {
                if (_userProfileRepository == null)
                {
                    _userProfileRepository = new UserProfileRepository(context);
                }
                return _userProfileRepository;
            }
        }
        public RoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new RoleRepository(context);
                }
                return _roleRepository;
            }
        }
        public VehicleRepository VehicleRepository
        {
            get
            {
                if (_vehicleRepository == null)
                {
                    _vehicleRepository = new VehicleRepository(context);
                }
                return _vehicleRepository;
            }
        }
      
        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                
            }
           
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
