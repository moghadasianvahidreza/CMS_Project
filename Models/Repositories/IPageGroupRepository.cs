using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public interface IPageGroupRepository: IDisposable
	{

		IEnumerable<PageGroup> GetAllGroups();

		PageGroup GetGroupById(int pageGroup);

		bool InsertGroup(PageGroup pageGroup);

		bool UpdateGroup(PageGroup pageGroup);

		bool DeleteGroup(int groupId);

		bool DeleteGroup(PageGroup pageGroup);

		void Save();
	}
}
