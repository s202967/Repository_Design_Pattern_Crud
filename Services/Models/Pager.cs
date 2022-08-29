using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    internal class Pager
    {
        public int TotalItems { get; set; }
        public int CurrentPage{ get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPages{ get; set; }
        public int EndPage { get; set; }

        public Pager()
        {

        }
         public Pager(int totalItems, int currentPage, int pageSize = 10)
        {
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            int startPage = currentPage - 5;
        }
    }
}
