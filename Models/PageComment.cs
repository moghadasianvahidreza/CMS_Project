using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class PageComment : object
	{
		public PageComment() : base()
		{

		}

		[Key]
		public int PageCommentId { get; set; }

		// **************************************************

		[Display(Name = "خبر")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		public int Pageid { get; set; }

		// **************************************************

		[Display(Name = "نام")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		[StringLength(maximumLength: 150, MinimumLength = 10)]
		public string Name { get; set; }

		// **************************************************

		[Display(Name = "ایمیل آدرس")]
		[StringLength(maximumLength: 150, MinimumLength = 10)]
		public string Email { get; set; }

		[Display(Name = "وب سایت")]
		[StringLength(maximumLength: 150, MinimumLength = 10)]
		public string WebSite { get; set; }

		// **************************************************

		[Display(Name = "نظر")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		[StringLength(maximumLength: 500, MinimumLength = 10)]
		public string Commment { get; set; }

		// **************************************************

		[Display(Name = "تاریخ ثبت")]
		public DateTime CreateDate { get; set; }

		//Navigation Property
		public virtual Page Page { get; set; }
	}
}
