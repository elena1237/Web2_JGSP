using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;
using WebApp.Persistence.Repository;

namespace WebApp.Persistence.UnitOfWork
{
    public class DemoUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
      
        public DemoUnitOfWork(DbContext context)
        {
            _context = context;
        }


         [Dependency]
        public ILineRepository Lines { get; set; }
        [Dependency]
        public ITicketTypeRepository TicketTypes { get; set; } 
        [Dependency]
        public IVehicleRepository Vehicles { get; set; }
        [Dependency]
        public IPassengerRepository Passengers { get; set; }
        [Dependency]
        public IPassengerTypeRepository PassengerTypes { get; set; }
        [Dependency]
        public IPriceListRepository PriceLists { get; set; }
        [Dependency]
        public IStationRepository Stations { get; set; }
        [Dependency]
        public IScheduleRepository Schedules { get; set; }
        [Dependency]
        public IScheduleTypesRepository ScheduleTypes { get; set; }
        [Dependency]
        public ITicketsRepository Tickets { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}