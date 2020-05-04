using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public interface IPageCommentRepository : IDisposable
	{
		IEnumerable<PageComment> GetAllPageComment();

		PageComment GetPageCommentById(int pageCommentId);

		bool InsertPageComment(PageComment pageComment);

		bool UpdatePageComment(PageComment pageComment);

		bool DeletePageComment(int pageCommentId);

		bool DeletePageComment(PageComment pageComment);

		void Save();
	}
}
