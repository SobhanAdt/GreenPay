using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TeamAboutRepository : ITeamAboutRepository
    {
        private GreenPayContext db;

        public TeamAboutRepository(GreenPayContext context)
        {
            db = context;
        }

        public IEnumerable<AboutDescription> GetAllAboutDescriptions()
        {
            return db.AboutDescriptions;
        }

        public AboutDescription GetByIdAboutDescription(int aboutId)
        {
            return db.AboutDescriptions.Find(aboutId);
        }

        public bool InsertAbout(AboutDescription aboutDescription)
        {
            try
            {
                 db.AboutDescriptions.Add(aboutDescription);
                 return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool UpdateAbout(AboutDescription aboutDescription)
        {
            try
            {
                db.Entry(aboutDescription).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteAbout(AboutDescription aboutDescription)
        {
            try
            {
                db.Entry(aboutDescription).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteAbout(int aboutId)
        {
            try
            {
                var about = db.AboutDescriptions.Find(aboutId);
                DeleteAbout(about);
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
