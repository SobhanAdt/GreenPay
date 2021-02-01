using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HamkaranRepository : IHamkaranRepository
    {
        private GreenPayContext db;

        public HamkaranRepository(GreenPayContext context)
        {
            this.db = context;
        }
        public IEnumerable<Hamkaran> GetAllHamkarans()
        {
            return db.Hamkarans;
        }

        public Hamkaran GetHamkaranById(int hamkaranId)
        {
            return db.Hamkarans.Find(hamkaranId);
        }

        public bool InsertHamkaran(Hamkaran hamkaran)
        {
            try
            {
                db.Hamkarans.Add(hamkaran);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateHamkaran(Hamkaran hamkaran)
        {
            try
            {
                db.Entry(hamkaran).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteHamkaran(Hamkaran hamkaran)
        {
            try
            {
                db.Entry(hamkaran).State = EntityState.Deleted;
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool DeleteHamkaran(int hamkaranId)
        {
            try
            {
                var hamkar= db.Hamkarans.Find(hamkaranId);
                DeleteHamkaran(hamkar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
           db.Dispose();
        }
    }
}
