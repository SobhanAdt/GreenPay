using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
    public class PageRepository : IPageRepository
    {
        private GreenPayContext db;
        public PageRepository(GreenPayContext context)
        {
            this.db = context;
        }

        public IEnumerable<Page> GetAllPage()
        {
            return db.Pages;
        }

        public Page GetPageById(int pageId)
        {
            return db.Pages.Find(pageId);
        }

        public bool InsertPage(Page page)
        {
            try
            {
                db.Pages.Add(page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdatePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }


        public bool DeletePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePage(int pageId)
        {
            try
            {
                var page = db.Pages.Find(pageId);
                DeletePage(page);
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

        public IEnumerable<Page> TopNews(int take = 4)
        {
            return db.Pages.OrderByDescending(p => p.Visit).Take(take);
        }

        public IEnumerable<Page> LastNews(int take = 4)
        {
            return db.Pages.OrderByDescending(p => p.CreateDate).Take(take);
        }

        public IEnumerable<Page> ShowPageByGroup(int groupId)
        {
            return db.Pages.Where(p => p.GroupID == groupId);


        }

        public IEnumerable<Page> SearchPage(string parmeter)
        {
            return db.Pages.Where(p =>
                p.Title.Contains(parmeter) || p.Text.Contains(parmeter) || p.ShortDescription.Contains(parmeter) || p.Tags.Contains(parmeter)).Distinct();
        }



    }
}
