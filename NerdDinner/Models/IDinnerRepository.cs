using Nerddinner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public interface IDinnerRepository
    {
        IQueryable<Dinner> FindAllDinners();
        Dinner GetDinner(int id);
        void Add(Dinner dinner);
        void Update(Dinner dinner);
        void Delete(Dinner dinner);
    }
}