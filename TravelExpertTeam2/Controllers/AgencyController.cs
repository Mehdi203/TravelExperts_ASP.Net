using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpertTeam2.Models;



namespace TravelExpertsTeam2.Controllers
{
    public class AgencyController : Controller
    {
        private IRepository<Agency> data;
        public AgencyController(IRepository<Agency> rep)
        {
            data = rep;
        }


        // GET: AgencyController
        public ActionResult Index()
        {
            var agcy = new QueryOptions<Agency>();
            agcy.OrderBy = s => s.AgencyId;
            //agcy.Include = "Agent";
            //agcy.Where = s => s.Agents.agentId == 2;
            var agencies = data.List(agcy);
            return View(agencies);
        }



        // GET: AgencyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: AgencyController/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: AgencyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: AgencyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }



        // POST: AgencyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: AgencyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }



        // POST: AgencyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}