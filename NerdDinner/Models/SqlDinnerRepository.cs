using Nerddinner;
using Nerddinner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public class SqlDinnerRepository : IDinnerRepository
    {
        DB db;
        public SqlDinnerRepository()
        {
            db = new DB();

        }
        public void Add(Dinner dinner)
        {
            db.Dinners.InsertOnSubmit(dinner);
        }

        public void Delete(Dinner dinner)
        {
            db.Dinners.DeleteOnSubmit(dinner);
            db.SubmitChanges();
        }

        public IQueryable<Dinner> FindAllDinners()
        {
            return db.Dinners;
        }

        public Dinner GetDinner(int id)
        {
            return db.Dinners.SingleOrDefault(x => x.DinnerID == id);
        }

        public void Update(Dinner dinner)
        {
            db.SubmitChanges();
        }
    }
}
