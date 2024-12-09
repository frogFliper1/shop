using Shop_ELECTRO.Data.Models;
using System.Collections.Generic;

namespace Shop_ELECTRO.Data.Interfaces
{
    public interface ICategorys
    {
        public IEnumerable<Categorys> AllCategorys { get; }
    }
}
