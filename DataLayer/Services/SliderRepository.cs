using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SliderRepository : ISliderRepository
    {
        private GreenPayContext db;

        public SliderRepository(GreenPayContext context)
        {
            this.db = context;
        }
        public IEnumerable<Slider> GetAllSlider()
        {
            return db.Sliders;
        }

        public Slider GetSliderById(int sliderId)
        {
            return db.Sliders.Find(sliderId);
        }

        public bool InsertSlider(Slider slider)
        {
            try
            {
                db.Sliders.Add(slider);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            throw new NotImplementedException();
        }

        public bool UpdateSlider(int slider)
        {
            try
            {
                db.Entry(slider).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteSlider(Slider slider)
        {
            try
            {
                db.Entry(slider).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSlider(int sliderId)
        {
            try
            {
                var slid = db.Sliders.Find(sliderId);
                DeleteSlider(slid);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
           db.Dispose();
        }

      

        public void Save()
        {
            db.SaveChanges();
        }

    
    }
}
