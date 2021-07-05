using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstAssignment
{
    [Table("Publisher")]
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PublisherID { get; set; }

        [Column("PublisherName", TypeName ="varchar")]
        [MaxLength(20)]
        public string PublisherName { get; set; }

        [Column("Country", TypeName = "varchar")]
        [MaxLength(20)]
        public string Country { get; set; }

        public ICollection<Book> BookCollection { get; set; }
    }
}
