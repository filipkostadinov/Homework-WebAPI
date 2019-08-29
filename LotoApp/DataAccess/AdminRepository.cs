using DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class AdminRepository : IRepository<Admin>
    {
        private readonly LotoAppDbContext _context;

        public AdminRepository(LotoAppDbContext context)
        {
            _context = context;
        }

        public void Delete(Admin entity)
        {
            _context.Admins.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Admin> GetAll()
        {
            return _context.Admins;
        }

        public Admin GetById(int id)
        {
            var admin = _context.Admins.FirstOrDefault(x => x.Id == id);
            return admin;
        }

        public void Insert(Admin entity)
        {
            _context.Admins.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Admin entity)
        {
            _context.Admins.Update(entity);
            _context.SaveChanges();
        }
    }
}
