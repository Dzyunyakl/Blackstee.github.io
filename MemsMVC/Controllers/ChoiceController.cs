using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MemsMVC.Models;
using MemsMVC.Services;

namespace MemsMVC.Controllers
{
    
    public class ChoiceController : Controller
    {
        Random random = new Random();
        MemesContext _context;
        public ChoiceController(MemesContext context)
        {
            _context = context;
        }
        // GET: Choice
        public ActionResult Index()
        {
            var index1 = _context.Memes.FirstOrDefault().Id;
            var index2 = _context.Memes.LastOrDefault().Id;
            var r1 = random.Next(index1, index2);
            var r2 = random.Next(index1, index2);
            do
            {
                r2 = random.Next(index1, index2);
            } while (r1.Equals(r2));
            var item1 = _context.Memes.Where(item => item.Id == r1).FirstOrDefault();
            var item2 = _context.Memes.Where(item => item.Id == r2).FirstOrDefault();
            ViewBag.First = item1;
            ViewBag.Second = item2;
            MemeSetter._item1 = item1;
            MemeSetter._item2 = item2;
            return View();
        }
        public ActionResult WinFirst()
        {
            MemeSetter._winner = MemeSetter._item1;
            MemeSetter._loser = MemeSetter._item2;

            var winner = _context.Memes.Where(item => item.Id == MemeSetter._item1.Id).Select(item => item.Result).FirstOrDefault();
            var loser = _context.Memes.Where(item => item.Id == MemeSetter._item2.Id).Select(item => item.Result).FirstOrDefault();

            var results = Algorithm.updateR((double)winner, (double)loser);

            var winnerResult = results.First();
            var loserResult = results.Last();

            var item1 = _context.Memes.FirstOrDefault(item => item.Id == MemeSetter._item1.Id);
            item1.Result = winnerResult;

            var item2 = _context.Memes.FirstOrDefault(item => item.Id == MemeSetter._item2.Id);
            item2.Result = loserResult;
            _context.SaveChanges();

            return RedirectToAction("Index","Choice");//TODO: redirect to main page;
        }
        public ActionResult WinSecond()
        {
            MemeSetter._winner = MemeSetter._item2;
            MemeSetter._loser = MemeSetter._item1;

            var winner = _context.Memes.Where(item => item.Id == MemeSetter._item2.Id).Select(item => item.Result).FirstOrDefault();
            var loser = _context.Memes.Where(item => item.Id == MemeSetter._item1.Id).Select(item => item.Result).FirstOrDefault();

            var results = Algorithm.updateR((double)winner, (double)loser);

            var winnerResult = results.First();
            var loserResult = results.Last();

            var item1 = _context.Memes.FirstOrDefault(item => item.Id == MemeSetter._item2.Id);
            item1.Result = winnerResult;

            var item2 = _context.Memes.FirstOrDefault(item => item.Id == MemeSetter._item1.Id);
            item2.Result = loserResult;

            _context.SaveChanges();            

            return RedirectToAction("Index", "Choice");//TODO: redirect to main page;
        }
    }
}