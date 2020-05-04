using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace MyApplication.Areas.Administrator.Controllers
{
	public class PagesController : Controller
	{
		public PagesController() : base()
		{
			pageRepository = new PageRepository(databaseContext);

			pageGroupRepository = new PageGroupRepository(databaseContext);
		}

		private IPageRepository pageRepository;

		private IPageGroupRepository pageGroupRepository;

		private DatabaseContext databaseContext = new DatabaseContext();

		// **************************************************
		// **************************************************

		// GET: Administrator/Pages
		public ActionResult Index()
		{
			return View(pageRepository.GetAllPages());
		}

		// GET: Administrator/Pages/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Page page = pageRepository.GetPageById(id.Value);

			if (page == null)
			{
				return HttpNotFound();
			}

			return View(page);
		}

		// **************************************************
		// **************************************************

		// GET: Administrator/Pages/Create
		public ActionResult Create()
		{
			ViewBag.GroupId = new SelectList(pageGroupRepository.GetAllGroups(), "GroupId", "GroupTitle");
			return View();
		}

		// **************************************************

		// POST: Administrator/Pages/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "PageId,GroupId,Title,PageDescription,Text,Visit,ImageName,ShowInSlider,CreateDate")] Page page, HttpPostedFileBase imgUp)
		{
			if (ModelState.IsValid)
			{
				page.Visit = 0;
				page.CreateDate = DateTime.Now;

				if (imgUp != null)
				{
					page.ImageName = Guid.NewGuid() + System.IO.Path.GetExtension(imgUp.FileName);
					imgUp.SaveAs(Server.MapPath("/PageImages" + page.ImageName));
				}

				pageRepository.InsertPage(page);
				pageRepository.Save();
				return RedirectToAction("Index");
			}

			ViewBag.GroupId = new SelectList(pageRepository.GetAllPages(), "GroupId", "GroupTitle", page.GroupId);
			return View(page);
		}

		// **************************************************
		// **************************************************

		// GET: Administrator/Pages/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Page page = pageRepository.GetPageById(id.Value);
			if (page == null)
			{
				return HttpNotFound();
			}
			ViewBag.GroupId = new SelectList(pageRepository.GetAllPages(), "GroupId", "GroupTitle", page.GroupId);
			return View(page);
		}

		// **************************************************

		// POST: Administrator/Pages/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "PageId,GroupId,Title,PageDescription,Text,Visit,ImageName,ShowInSlider,CreateDate")] Page page, HttpPostedFileBase imgUp)
		{
			if (ModelState.IsValid)
			{
				if (imgUp != null)
				{
					if (page.ImageName != null)
					{
						System.IO.File.Delete(Server.MapPath("/PageImages" + page.ImageName));
					}

					page.ImageName = Guid.NewGuid() + System.IO.Path.GetExtension(imgUp.FileName);
					imgUp.SaveAs(Server.MapPath("/PageImages" + page.ImageName));
				}

				pageRepository.UpdatePage(page);
				pageRepository.Save();
				return RedirectToAction("Index");
			}
			ViewBag.GroupId = new SelectList(pageRepository.GetAllPages(), "GroupId", "GroupTitle", page.GroupId);
			return View(page);
		}

		// **************************************************
		// **************************************************

		// GET: Administrator/Pages/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Page page = pageRepository.GetPageById(id.Value);

			if (page == null)
			{
				return HttpNotFound();
			}

			return View(page);
		}

		// **************************************************

		// POST: Administrator/Pages/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var page = databaseContext.Pages.Where(current => current.GroupId == id).FirstOrDefault();
			if (page.ImageName != null)
			{
				System.IO.File.Delete(Server.MapPath("/PageImages" + page.ImageName));
			}
			pageRepository.DeletePage(page);
			pageRepository.Save();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				pageGroupRepository.Dispose();
				pageRepository.Dispose();
				databaseContext.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
