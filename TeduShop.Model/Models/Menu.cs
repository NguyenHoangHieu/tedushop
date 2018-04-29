using System.ComponentModel.DataAnnotations;//khai bao dieu khien bat loi, required
using System.ComponentModel.DataAnnotations.Schema; //khai bao table footer, order

namespace TeduShop.Model.Models
{
    [Table("Menus")]
    public class Menu
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string URL { get; set; }

        public int? DisplayOrder { get; set; }

        [Required]
        public int GroupID { get; set; }

        //==========b1.cach tao khoa ngoai , b2: qua MenuGroup khai bao
        [ForeignKey("GroupID")]
        public virtual MenuGroup MenuGroup { get; set; }

        public string Target { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
