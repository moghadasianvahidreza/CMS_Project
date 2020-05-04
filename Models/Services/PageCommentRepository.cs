using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Models
{
	public class PageCommentRepository : IPageCommentRepository
	{
		public PageCommentRepository(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		//DatabaseContext databaseContext = new DatabaseContext();
		private DatabaseContext databaseContext { get; set; }

		public IEnumerable<PageComment> GetAllPageComment()
		{
			return databaseContext.PageComments;
		}

		public PageComment GetPageCommentById(int pageCommentId)
		{
			return databaseContext.PageComments.Find(pageCommentId);
		}

		public bool InsertPageComment(PageComment pageComment)
		{
			try
			{
				databaseContext.PageComments.Add(pageComment);
				return true;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public bool UpdatePageComment(PageComment pageComment)
		{
			try
			{
				databaseContext.Entry(pageComment).State = EntityState.Modified;
				return true;
			}
			catch (Exception)
			{

				throw;
			}	
		}

		public bool DeletePageComment(int pageCommentId)
		{
			var pageComments = GetPageCommentById(pageCommentId);
			DeletePageComment(pageComments);
			return true;
		}

		public bool DeletePageComment(PageComment pageComment)
		{
			try
			{
				databaseContext.Entry(pageComment).State = EntityState.Deleted;
				return true;
			}
			catch (Exception)
			{

				throw;
			}
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
