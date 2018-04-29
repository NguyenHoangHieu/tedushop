using System.ComponentModel.DataAnnotations;//khai bao dieu khien bat loi, required
using System.ComponentModel.DataAnnotations.Schema; //khai bao table footer, order

//remove thu vien khong su dung = codemaid => ctrl + M + space

namespace TeduShop.Model.Models
{
    [Table("Footers")]
    public class Footer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Context { get; set; }
    }
}