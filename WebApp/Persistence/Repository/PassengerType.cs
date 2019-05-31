using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Persistence.Repository
{
    public class PassengerType : Repository<PassengerType,int> ,IPassengerTypeRepository
    {
        public PassengerType(DbContext context) : base(context)
        {

        }
    }
}