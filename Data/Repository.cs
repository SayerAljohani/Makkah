using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
 
namespace WebApplication1.Data
{
    public class Repository : IRepository
    {
        private readonly MakkahDbContext _context;

        public Repository(MakkahDbContext context)
        {
            _context = context;
        }

        public int GetAll()
        {
            return _context.Persons.Count();
        }

        public int GetFingers(string category)
        {
            return _context.Persons.Where(p=>p.Category==category.Trim()).Count();
        }

        public void Add(Person p)
        {
            _context.Add(p);
        }

        public Statistic GetData()
        {
            var data =  _context.Persons;
            return new Statistic()
            {
                Total = data.Count(),
                EmployeeRate = data.Where(p => p.Category == "employee").Count(),
                StudentRate = data.Where(p => p.Category == "student").Count()
            };
        }
    }
}
