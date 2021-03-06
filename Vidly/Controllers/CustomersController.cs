﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(s => s.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var model = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(s => s.Id == id);

            if (model == null)
                return HttpNotFound();

            return View(model);
        }

    }
}