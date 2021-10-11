using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpertTeam2.Models;



namespace TravelExpertsTeam2.Controllers
{
    public class AgentController : Controller
    {
        private IRepository<Agent> data;
        public AgentController(IRepository<Agent> rep)
        {
            data = rep;
        }


        // GET: AgentController
        public ActionResult Index()
        {
            var agt = new QueryOptions<Agent>();
            agt.OrderBy = s => s.AgentId;
            //agcy.Include = "Agent";
            //agcy.Where = s => s.Agents.agentId == 2;
            var agents = data.List(agt);
            return View(agents);
        }



        // GET: AgentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: AgentController/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: AgentController/Create
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



        // GET: AgentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }



        // POST: AgentController/Edit/5
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



        // GET: AgentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }



        // POST: AgentController/Delete/5
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