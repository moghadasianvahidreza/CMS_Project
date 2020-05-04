using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Models
{
	public class PageGroupRepository : IPageGroupRepository
	{
		public PageGroupRepository(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		private DatabaseContext databaseContext { get; set; }

		// **************************************************

		public IEnumerable<PageGroup> GetAllGroups()
		{
			//return DatabaseContext.PageGroups.ToList();
			return databaseContext.PageGroups;
		}

		// **************************************************

		public PageGroup GetGroupById(int groupId)
		{
			//return DatabaseContext.PageGroups.Where(current => current.GroupId == groupId).FirstOrDefault();
			return databaseContext.PageGroups.Find(groupId);
		}

		// **************************************************

		public bool InsertGroup(PageGroup pageGroup)
		{
			try
			{
				databaseContext.PageGroups.Add(pageGroup);
				return true;
			}
			catch (Exception)
			{

				throw;
			}
		}

		// **************************************************

		public bool UpdateGroup(PageGroup pageGroup)
		{
			try
			{
				databaseContext.Entry(pageGroup).State = EntityState.Modified;
				return true;
			}
			catch (Exception)
			{

				throw;
			}
		}

		// **************************************************

		public bool DeleteGroup(int groupId)
		{
			var group = GetGroupById(groupId);
			DeleteGroup(group);
			return true;
		}

		// **************************************************

		public bool DeleteGroup(PageGroup pageGroup)
		{
			try
			{
				databaseContext.Entry(pageGroup).State = EntityState.Deleted;
				return true;
			}
			catch (Exception)
			{

				throw;
			}
		}

		// **************************************************

		public void Save()
		{
			databaseContext.SaveChanges();
		}

		// **************************************************

		public void Dispose()
		{
			databaseContext.Dispose();
		}
	}
}
