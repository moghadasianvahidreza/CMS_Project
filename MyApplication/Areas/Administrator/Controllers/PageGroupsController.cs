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
	public class PageGroupsController : Controller
	{
		public PageGroupsController()
		{
			pageGroupRepository = new PageGroupRepository(databaseContext);
		}

		private IPageGroupRepository pageGroupRepository;

		DatabaseContext databaseContext = new DatabaseContext();

		// **************************************************
		// **************************************************

		// GET: Administrator/PageGroups
		public ActionResult Index()
		{
			return View(pageGroupRepository.GetAllGroups());
		}

		// **************************************************
		// **************************************************

		// GET: Administrator/PageGroups/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			PageGroup pageGroup = pageGroupRepository.GetGroupById(id.Value);

			if (pageGroup == null)
			{
				return HttpNotFound();
			}
			return View(pageGroup);
		}

		// **************************************************
		// **************************************************

		// GET: Administrator/PageGroups/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Administrator/PageGroups/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "GroupId,GroupTitle")] PageGroup pageGroup)
		{
			if (ModelState.IsValid)
			{
				pageGroupRepository.InsertGroup(pageGroup);
				pageGroupRepository.Save();
				return RedirectToAction("Index");
			}

			return View(pageGroup);
		}

		// **************************************************
		// **************************************************

		// GET: Administrator/PageGroups/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			PageGroup pageGroup = pageGroupRepository.GetGroupById(id.Value);

			if (pageGroup == null)
			{
				return HttpNotFound();
			}

			return View(pageGroup);
		}

		// **************************************************

		// POST: Administrator/PageGroups/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "GroupId,GroupTitle")] PageGroup pageGroup)
		{
			if (ModelState.IsValid)
			{
				pageGroupRepository.UpdateGroup(pageGroup);
				pageGroupRepository.Save();
				return RedirectToAction("Index");
			}
			return View(pageGroup);
		}

		// **************************************************
		// **************************************************

		// GET: Administrator/PageGroups/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			PageGroup pageGroup = pageGroupRepository.GetGroupById(id.Value);

			if (pageGroup == null)
			{
				return HttpNotFound();
			}

			return View(pageGroup);
		}

		// **************************************************

		// POST: Administrator/PageGroups/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			pageGroupRepository.DeleteGroup(id);
			pageGroupRepository.Save();

			return RedirectToAction("Index");
		}

		// **************************************************
		// **************************************************

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				pageGroupRepository.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
