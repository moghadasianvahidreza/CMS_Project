using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public interface IPageRepository : IDisposable
	{
		IEnumerable<Page> GetAllPages();

		Page GetPageById(int pageId);

		bool InsertPage(Page page);

		bool UpdatePage(Page page);

		bool DeletePage(int pageId);

		bool DeletePage(Page page);

		void Save();
	}
}
