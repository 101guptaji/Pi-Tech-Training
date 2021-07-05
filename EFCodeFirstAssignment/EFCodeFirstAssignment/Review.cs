using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstAssignment
{
    [Table("Review")]
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReviewID { get; set; }

        [Column("ReviewText", TypeName = "varchar")]
        [MaxLength(50)]
        public string ReviewText { get; set; }

        [ForeignKey("Book1")]
        public int BookID { get; set; }
        
        [ForeignKey("Member1")]
        public int MemberID { get; set; }
       
        public Book Book1 { get; set; }
        public Member Member1 { get; set; }
    }
}
