using DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class SessionRepository : IRepository<Session>
    {
        private readonly LotoAppDbContext _context;

        public SessionRepository(LotoAppDbContext context)
        {
            _context = context;
        }

        public void Delete(Session entity)
        {
            _context.Sessions.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Session> GetAll()
        {
            return _context.Sessions.Include(x => x.Tickets);
        }

        public Session GetById(int id)
        {
            return _context.Sessions.Include(x => x.Tickets).FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Session entity)
        {
            _context.Sessions.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Session entity)
        {
            _context.Sessions.Update(entity);
            _context.SaveChanges();
        }
    }
}
