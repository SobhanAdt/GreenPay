using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ISliderRepository:IDisposable
    {
        IEnumerable<Slider> GetAllSlider();

        Slider GetSliderById(int sliderId);

        bool InsertSlider(Slider slider);

        bool UpdateSlider(int slider);

        bool DeleteSlider(Slider slider);

        bool DeleteSlider(int sliderId);

        void Save();
    }
}
