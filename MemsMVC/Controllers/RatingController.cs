using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemsMVC.Controllers
{
    public class RatingController : Controller
    {
        readonly MemesContext _context;
        public RatingController(MemesContext context)
        {
            _context = context;
        }
        // GET: Rating
        public ActionResult Index()
        {
            var data = _context.Memes.OrderByDescending(opt => opt.Result).ToList();
            
            ViewBag.First = data.FirstOrDefault();
            data.RemoveAt(0);
            ViewBag.Second = data.FirstOrDefault();
            data.RemoveAt(0);
            ViewBag.Third = data.FirstOrDefault();
            data.RemoveAt(0);

            return View(data);
        }
        //Filling the DB fields with MEMES data.

        //[HttpPost]
        //public ActionResult PostData()
        //{
        //    string text = System.IO.File.ReadAllText(@"C:\Users\dzyun\source\repos\Blackstee.github.io\list_urls.txt");
        //    IEnumerable<String> lines = System.IO.File.ReadLines(@"C:\Users\dzyun\source\repos\Blackstee.github.io\list_urls.txt");

        //    foreach (var line in lines)
        //    {
        //        _context.Memes.Add(new Models.Meme
        //        {
        //            Source = line
        //        });
        //    }

        //    _context.SaveChanges();

        //    return Ok();
        //}
    }
}