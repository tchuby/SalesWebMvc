using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using System;
using System.Linq;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecords.Any()) 
            {
                return; //DB has been seeded
            };

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bobbrown@email.com", new DateTime(1992, 4, 30), 1000.00, d1);
            Seller s2 = new Seller(2, "Willian White", "willian@email.com", new DateTime(1989, 8, 15), 1000.00, d2);
            Seller s3 = new Seller(3, "Rose Red", "bobbrown@email.com", new DateTime(1996, 2, 27), 1000.00, d3);
            Seller s4 = new Seller(4, "George Green", "bobbrown@email.com", new DateTime(1999, 6, 17), 1000.00, d4);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2021, 02, 15), 1200.00, SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2021, 02, 15), 1150.00, SaleStatus.Billed, s2);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2021, 02, 16), 1350.00, SaleStatus.Billed, s3);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2021, 02, 17), 2000.00, SaleStatus.Billed, s4);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4);
            _context.SalesRecords.AddRange(sr1, sr2, sr3, sr4);

            _context.SaveChanges();
        }
    }
}
