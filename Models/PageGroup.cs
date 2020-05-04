using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class PageGroup : object
	{
		public PageGroup() : base()
		{

		}

		[Key]
		public int GroupId { get; set; }

		// **************************************************

		[Display(Name = "عنوان گروه")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		[StringLength
			(maximumLength: 150, MinimumLength = 5 , ErrorMessage = ".عنوان گروه بایستی یک رشته ای از حداقل ۱۰ حرف تا حداکثر ۱۵۰ حرف باشد")]
		public string GroupTitle { get; set; }

		// Navigation Property
		public virtual List<Page> Pages { get; set; }
	}
}
