using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataAccessLayer
{
    public class StoreDAL
    {
        public Store AddStore([FromBody] Store a)
        {
            var db = new DotNetLabDbContext();
            db.Add(a);
            db.SaveChanges();
            return a;

        }

        public Store EditStore([FromBody] Store store)
        {
            var db = new DotNetLabDbContext();
            Store a = new Store();
            a = db.Stores.FirstOrDefault(x => x.Id == store.Id);
            if (a != null)
            {
                a.StoreName = store.StoreName;
                a.Address = store.Address;
                a.Phone = store.Phone;
                a.WorkingHours = store.WorkingHours;
            }
            db.SaveChangesAsync();
            return store;
        }

        public List<Store> GetAllStore()
        {
            var db = new DotNetLabDbContext();
            return db.Stores.ToList();
        }

        public Store GetMediaById(int Id)
        {
            var db = new DotNetLabDbContext();
            Store a = new Store();
            a = db.Stores.FirstOrDefault(x => x.Id == Id);
            return a;
        }

        public Store DeleteStoreById(int Id)
        {
            var db = new DotNetLabDbContext();
            Store a = db.Stores.FirstOrDefault(x => x.Id == Id);

            if (Id != null)
            {
                db.Stores.Remove(a);
            }
            db.SaveChanges();
            return a;
        }
    }
}
