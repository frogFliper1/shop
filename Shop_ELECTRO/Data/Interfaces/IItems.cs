using Shop_ELECTRO.Data.DataBase;
using Shop_ELECTRO.Data.Models;
using System.Collections.Generic;

namespace Shop_ELECTRO.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Items> AllItems { get; }
        public int Add(Items Item);
    }
}
