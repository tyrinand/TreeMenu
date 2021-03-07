using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var companis = new List<Company>()
            {
                new Company() {id = "1", Name = "Аэрофлот"},
                new Company() {id = "0", Name = "Компания без меню "}

            };

            return View(companis);
        }

        public JsonResult GetMenu(string id)
        {
            if (id == "1")
            {
                var menuRoot = new MenuItem("root-1", "Аэрофлот", "alert(\"AFLT\");");

                var activeCheck = new MenuItem("active-check", "Активные проверки", "alert(\"Активные\");");
                
                var achtiveCheck1 = new MenuItem("active-check1", "Акт. пр. 1");
                var achtiveCheck2 = new MenuItem("active-check2", "Акт. пр. 2");

                activeCheck.Children.Add(achtiveCheck1);
                activeCheck.Children.Add(achtiveCheck2);


                var notActiveCheck = new MenuItem("ar-check", "Архивыне проверки ", "alert(\"Архивыне\");");

                var notActiveCheck1 = new MenuItem("active-check1", "Арх. пр. 1");
                var notActiveCheck2 = new MenuItem("active-check2", "Арх. пр. 2");

                notActiveCheck.Children.Add(notActiveCheck1);
                notActiveCheck.Children.Add(notActiveCheck2);


                menuRoot.Children.Add(activeCheck);
                menuRoot.Children.Add(notActiveCheck);

                return Json(menuRoot, JsonRequestBehavior.AllowGet);
            }


            var menuRoot2 = new MenuItem("root-0", "Компания без меню", "alert(\"Компания без меню\");");

            return Json(menuRoot2, JsonRequestBehavior.AllowGet);
        }


        public ActionResult About()
        {
            return View();
        }
    }
}