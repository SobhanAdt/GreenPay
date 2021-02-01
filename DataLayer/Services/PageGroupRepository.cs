using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
    public class PageGroupRepository : IPageGroupRepository
    {
        private GreenPayContext db;

        public PageGroupRepository(GreenPayContext context)
        {
            this.db = context;
        }
        public IEnumerable<PageGroup> GetAllGroups()
        {
            return db.PageGroups;
        }

        public PageGroup GetGroupById(int groupId)
        {
            return db.PageGroups.Find(groupId);
        }

        public bool InsertGroup(PageGroup pageGroup)
        {
            try
            {
                db.PageGroups.Add(pageGroup);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteGroup(int groupId)
        {
            try
            {
                var group = db.PageGroups.Find(groupId);
                DeleteGroup(group);
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

        public IEnumerable<ShowGroupViewModel> GetGroupForview()
        {
            return db.PageGroups.Select(g => new ShowGroupViewModel()
            {
                GroupID = g.GroupID,
                GroupTitle = g.GroupTitle,
                PageCount = g.Pages.Count
            });
        }
    }
}
