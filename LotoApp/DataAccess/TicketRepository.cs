using DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class TicketRepository : IRepository<Ticket>
    {
        private readonly LotoAppDbContext _context;

        public TicketRepository(LotoAppDbContext context)
        {
            _context = context;
        }

        public void Delete(Ticket entity)
        {
            _context.Tickets.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _context.Tickets.Include(x => x.User);
        }

        public Ticket GetById(int id)
        {
            return _context.Tickets.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Ticket entity)
        {
            _context.Tickets.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Ticket entity)
        {
            _context.Tickets.Update(entity);
            _context.SaveChanges();
        }
    }
}
