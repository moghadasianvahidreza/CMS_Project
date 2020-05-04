using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Models
{
	
	public class PageRepository : IPageRepository
	{
		public PageRepository(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public DatabaseContext databaseContext { get; set; }

		public IEnumerable<Page> GetAllPages()
		{
			return databaseContext.Pages.ToList();
		}

		public Page GetPageById(int pageId)
		{
			return databaseContext.Pages.Find(pageId);
		}

		public bool InsertPage(Page page)
		{
			try
			{
				databaseContext.Pages.Add(page);
				return true;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public bool UpdatePage(Page page)
		{
			try
			{
				databaseContext.Entry(page).State = EntityState.Modified;
				return true;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public bool DeletePage(int pageId)
		{
			var page = GetPageById(pageId);
			DeletePage(page);
			return true;
		}

		public bool DeletePage(Page page)
		{
			databaseContext.Entry(page).State = EntityState.Deleted;
			return true;
		}

		public void Save()
		{
			databaseContext.SaveChanges();
		}

		public void Dispose()
		{
			databaseContext.Dispose();
		}
	}
}
