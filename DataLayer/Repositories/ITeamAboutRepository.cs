using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ITeamAboutRepository:IDisposable
    {
        IEnumerable<AboutDescription> GetAllAboutDescriptions();

        AboutDescription GetByIdAboutDescription(int aboutId);

        bool InsertAbout(AboutDescription aboutDescription);

        bool UpdateAbout(AboutDescription aboutDescription);

        bool DeleteAbout(AboutDescription aboutDescription);

        bool DeleteAbout(int aboutId);

        void Save();

    }
}
