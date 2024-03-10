using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Utility
{
    public class PaginationEntityDto<TEntity>
    {
        public List<TEntity> Entities { get; set; }
        public int Count { get; set; }
    }
}
