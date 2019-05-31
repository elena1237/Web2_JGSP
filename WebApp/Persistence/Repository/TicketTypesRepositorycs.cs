using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class TicketTypesRepositorycs : Repository<TicketType, int>, ITicketTypeRepository
    {
        public TicketTypesRepositorycs(DbContext context) : base(context)
        {
        }
    }

}