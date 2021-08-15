using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class TestRepository : IRepository<Test>
    {
        private readonly LotoAppDbContext _context;

        public TestRepository(LotoAppDbContext context)
        {
            _context = context;
        }

        public void Delete(Test entity)
        {
            _context.Tests.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Test> GetAll()
        {
            return _context.Tests;
        }

        public Test GetById(int id)
        {
            return _context.Tests.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Test entity)
        {
            _context.Tests.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Test entity)
        {
            _context.Tests.Update(entity);
            _context.SaveChanges();
        }
    }
}
