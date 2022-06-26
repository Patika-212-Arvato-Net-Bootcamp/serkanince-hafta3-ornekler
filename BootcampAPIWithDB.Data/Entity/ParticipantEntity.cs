using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampAPIWithDB.Data.Entity
{
    public class ParticipantEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BootcampId { get; set; }
        public int StudentId { get; set; }

        public virtual BootcampEntity Bootcamp { get; set; }
        public virtual StudentEntity Student { get; set; }
    }
}
