using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampAPIWithDB.Data.Entity
{
    public class BootcampEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImageURL { get; set; }

    }
}
