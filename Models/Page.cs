using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class Page : object
	{
		public Page() : base()
		{

		}

		[Key]
		public int PageId { get; set; }

		// **************************************************

		[Display(Name = "گروه صفحه")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		public int GroupId { get; set; }

		// **************************************************

		[Display(Name = "عنوان")]
		[Required(AllowEmptyStrings = false,ErrorMessage = "لطفا {0} را وارد کنید")]
		[StringLength(maximumLength: 150, MinimumLength = 10)]
		public string Title { get; set; }

		// **************************************************

		[Display(Name = "توضیح مختصر")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		[StringLength(maximumLength: 150, MinimumLength = 10)]
		[DataType(DataType.MultilineText)]
		public string PageDescription { get; set; }

		// **************************************************

		[Display(Name = "متن")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		[StringLength(maximumLength: 150, MinimumLength = 10)]
		[DataType(DataType.MultilineText)]
		public string Text { get; set; }

		// **************************************************

		[Display(Name = "بازید")]
		public int Visit { get; set; }

		// **************************************************

		[Display(Name = "تصویر صفحه")]
		public string ImageName { get; set; }

		// **************************************************

		[Display(Name = "اسلایدر")]
		public bool ShowInSlider { get; set; }

		// **************************************************

		[Display(Name = "تاریخ ایجاد")]
		[DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
		public DateTime CreateDate { get; set; }

		// Navigation Property
		public virtual PageGroup PageGroup { get; set; }

		public virtual List<PageComment> PageComments { get; set; }
	}
}
