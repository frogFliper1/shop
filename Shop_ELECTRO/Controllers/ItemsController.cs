﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using Shop_ELECTRO.Data.Interfaces;
using Shop_ELECTRO.Data.ViewModell;
using Shop_ELECTRO.Data.Models;
using System.Linq;

namespace Shop_ELECTRO.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private IItems IAllItems;
        private ICategorys IAllCategorys;
        VMItems VMItems = new VMItems();


        public ItemsController(IItems IAllItems, ICategorys IAllCategorys, IHostingEnvironment environment)
        {
            this.IAllItems = IAllItems;
            this.IAllCategorys = IAllCategorys;
            this.hostingEnvironment = environment;
        }

        public ViewResult List(int id = 0)
        {
            ViewBag.Title = "Страница с предметами";
            VMItems.Items = IAllItems.AllItems;
            VMItems.Categorys = IAllCategorys.AllCategorys;
            VMItems.SelectCategory = id;
            return View(VMItems);
        }
        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Categorys> Categorys = IAllCategorys.AllCategorys;
            return View(Categorys);
        }
        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int idCategory)
        {
            if (files != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            Items newItems = new Items();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = files.FileName;
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Categorys()
            {
                Id = idCategory
            };
            int id = IAllItems.Add(newItems);
            return Redirect("/Items/Update?id=" + id);
        }
        public ActionResult Basket(int idItem = -1)
        {
            if (idItem != -1)
            {
                Startup.BasketItem.Add(new ItemsBasket(1, IAllItems.AllItems.Where(x => x.Id == idItem).First()));
            }
            return Json(Startup.BasketItem);
        }

        public ActionResult BasketCount(int idItem = -1, int count = -1)
        {
            if (idItem != -1)
            {
                if (count == 0)
                {
                    Startup.BasketItem.Remove(Startup.BasketItem.Find(x => x.Id == idItem));
                }
                else
                {
                    Startup.BasketItem.Find(x => x.Id == idItem).Count = count;
                }
            }
            return Json(Startup.BasketItem);
        }
    }
}
