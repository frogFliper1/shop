﻿using Shop_ELECTRO.Data.Models;
using System.Collections.Generic;

namespace Shop_ELECTRO.Data.ViewModell
{
    public class VMItems
    {
        public IEnumerable<Items> Items { get; set; }
        public IEnumerable<Categorys> Categorys { get; set; }
        public int SelectCategory = 0;
    }
}
