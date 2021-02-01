using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{
    public class TeamMemberRepository : ITeamRepositoru
    {
        private GreenPayContext db;

        public TeamMemberRepository(GreenPayContext context)
        {
            this.db = context;
        }


        public IEnumerable<TeamMember> GetAllTeamMembers()
        {
            return db.TeamMembers;
        }

        public TeamMember GetByIdTeamMember(int teamId)
        {
            return db.TeamMembers.Find(teamId);
        }

        public bool InsertMember(TeamMember teamMember)
        {
            try
            {
                db.TeamMembers.Add(teamMember);
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool UpdateMember(TeamMember teamMember)
        {
            try
            {
                db.Entry(teamMember).State = EntityState.Modified;
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
        public bool DeleteMember(TeamMember teamMember)
        {
            try
            {
                db.Entry(teamMember).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteMember(int teamId)
        {
            try
            {
                var member = db.TeamMembers.Find(teamId);
                DeleteMember(member);
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
