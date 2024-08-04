using E_commrec.Services;
using E_commrec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using E_commrec.ViewModel;
//

namespace E_commrec.Controllers
{
    //product
    public class ShoppingController : Controller
    {

      public IproductReposatrycs prorepo;
        public Context Context;


        public ShoppingController(IproductReposatrycs _repo,Context _context)
        {

            prorepo = _repo;
            Context = _context;

        }
       

        public IActionResult viewproduct()
        {
            return View();

        }
        //بسبب 
        [Authorize]
        [HttpPost]
        public IActionResult Add(Proudctvm repo)
        {

            Prouduct prouduct = new Prouduct();

            if(ModelState.IsValid)
            {
                prouduct.Name=repo.Name;
                //prouduct.Id=repo.Id;
                prouduct.Price=repo.Price;
                prouduct.Image=repo.Image;  
                prouduct.Color=repo.Color;               
                prorepo.Create(prouduct);
                return View(prouduct);
            }
            else
            {
                return RedirectToAction("Index");

            }

        }
        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {

            return View();

        }


        [Authorize]
        public IActionResult Update(int id,Prouduct proud)
        {
            Prouduct prouduct = new Prouduct();
            var res = prorepo.Update(id, proud);
            Prouduct pr=Context.prouducts.Find(id);


            if (ModelState.IsValid)
            {
                
                if (pr!= null)
                {
                    // save it
                    prouduct.Name = pr.Name;
                    prouduct.Price = pr.Price;
                    prouduct.Color = pr.Color;
                    Context.prouducts.Update(pr);
                    Context.SaveChanges();

                  // Context.SaveChanges();
                    
                      /*
                    res=prorepo.Update(id, proud);
                    prouduct.Price=res;
                      */
                     

                }
                else
                {
                    //sent a message or do a business logic 

                    ModelState.AddModelError("", "Enter Data True");




                }
            } 
               
                
              
            return View(res);


        }
        [Authorize]
        public int Delete(int id)
        {
            Prouduct prouduct = Context.prouducts.FirstOrDefault(s => s.Id == id);
            Context.prouducts.Remove(prouduct);

            int raw = Context.SaveChanges();
            return raw;

        }



        public IActionResult Index()
        {
            return View();
        }

      
    }
}
