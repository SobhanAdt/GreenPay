using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ITeamRepositoru:IDisposable
    {
        IEnumerable<TeamMember> GetAllTeamMembers();

        TeamMember GetByIdTeamMember(int teamId);

        bool InsertMember(TeamMember teamMember);

        bool UpdateMember(TeamMember teamMember);

        bool DeleteMember(TeamMember teamMember);

        bool DeleteMember(int teamId);

        void Save();


    }
}
