using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public IActionResult Index()
        {
            var items = _context.Items;
            return View("Index", items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        
        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var deleteItem = _context.Items.Find(id);
            _context.Items.Remove(deleteItem);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
