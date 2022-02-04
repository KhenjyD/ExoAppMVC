using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data
{
    public class AgendaDbConnect: DbContext
    {
        public AgendaDbConnect(DbContextOptions<AgendaDbConnect> option) : base(option)
        { }

        public DbSet<Broker> Brokers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
