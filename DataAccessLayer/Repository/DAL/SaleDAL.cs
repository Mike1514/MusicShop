using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataAccessLayer
{
    public class SaleDAL
    {
        public Sale AddSale([FromBody] Sale a)
        {
            var db = new DotNetLabDbContext();
            db.Add(a);
            db.SaveChanges();
            return a;

        }

        public Sale EditSale([FromBody] Sale sale)
        {
            var db = new DotNetLabDbContext();
            Sale a = new Sale();
            a = db.Sales.FirstOrDefault(x => x.Id == sale.Id);
            if (a != null)
            {
                a.TransactionDate = sale.TransactionDate;
                a.Quantity = sale.Quantity;
                a.StoreId = sale.StoreId;
                a.EmployeeId = sale.EmployeeId;
                a.Note = sale.Note;
            }
            db.SaveChangesAsync();
            return sale;
        }

        public List<Sale> GetAllSale()
        {
            var db = new DotNetLabDbContext();
            return db.Sales.ToList();
        }

        public Sale GetMediaById(int Id)
        {
            var db = new DotNetLabDbContext();
            Sale a = new Sale();
            a = db.Sales.FirstOrDefault(x => x.Id == Id);
            return a;
        }

        public Sale DeleteSaleById(int Id)
        {
            var db = new DotNetLabDbContext();
            Sale a = db.Sales.FirstOrDefault(x => x.Id == Id);

            if (Id != null)
            {
                db.Sales.Remove(a);
            }
            db.SaveChanges();
            return a;
        }
    }
}
