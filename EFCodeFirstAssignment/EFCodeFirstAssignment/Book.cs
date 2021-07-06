using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstAssignment
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookID { get; set; }
        
        [Column("BookName",TypeName="varchar")]
        [MaxLength(20)]
        [Required]
        public string BookName { get; set; }

        [ForeignKey("Publisher")]
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
    }
}
