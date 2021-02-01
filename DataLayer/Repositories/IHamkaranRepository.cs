using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IHamkaranRepository:IDisposable
    {
        IEnumerable<Hamkaran> GetAllHamkarans();

        Hamkaran GetHamkaranById(int hamkaranId);

        bool InsertHamkaran(Hamkaran hamkaran);

        bool UpdateHamkaran(Hamkaran hamkaran);

        bool DeleteHamkaran(Hamkaran hamkaran);

        bool DeleteHamkaran(int hamkaranId);

        void Save();

    }
}
