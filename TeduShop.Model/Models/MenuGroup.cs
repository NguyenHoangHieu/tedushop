using System.Collections.Generic;//khai bao ham` chua' khoa chinh va khoa ngoai
using System.ComponentModel.DataAnnotations;//khai bao dieu khien bat loi, required
using System.ComponentModel.DataAnnotations.Schema; //khai bao table footer, order

namespace TeduShop.Model.Models
{
    [Table("MenuGroups")]
    public class MenuGroup
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<Menu> Menus { get; set; } //khai bao cho cha biet thang con
    }
}
