using Ardalis.Specification;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BusinessLogic.Specifications
{
    public static class ProductsSpesification
    {
        public class AllWithSort : Specification<Product>
        {
            public AllWithSort()
            {
                Query
                    .OrderByDescending(a => a.Name)
                    .Include(x => x.Category);
            }
        }
        public class ById : Specification<Product>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Category);
            }
        }

        //public class ByIds : Specification<Product>
        //{
        //    public ByIds(int[] ids)
        //    {
        //        Query
        //            .Where(x => ids.Contains(x.Id))
        //            .Include(x => x.Category);
        //    }
        //}
      
    }
}
