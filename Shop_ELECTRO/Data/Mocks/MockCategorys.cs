using Shop_ELECTRO.Data.DataBase;
using Shop_ELECTRO.Data.Interfaces;
using Shop_ELECTRO.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop_ELECTRO.Data.Mocks
{
    public class MockCategorys : ICategorys
    {
        public IEnumerable<Categorys> AllCategorys
        {
            get
            {
                return new List<Categorys>()
                {
                    new Categorys()
                    {
                        Id = 1,
                        Name = "Перифирия",
                        Description = "Предметы для взаимодействия с ПК"
                    },
                    new Categorys()
                    {
                        Id = 2,
                        Name = "Компоненты ПК",
                        Description = "Компоненты из которых состоит ПК"
                    }
                };
            }
        }
    }
}
