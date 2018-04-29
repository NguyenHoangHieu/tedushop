using System;
using System.ComponentModel.DataAnnotations;

namespace TeduShop.Model.Abstract
{
    public abstract class Auditable : IAuditable //khi da ke thua thi phai khai bao tu khoa PUBLIC
    {
        public DateTime? CreatedDate { get; set; }
        [MaxLength(256)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [MaxLength(256)]
        public string UpdatedBy { get; set; }

        //ISeoable
        [MaxLength(256)]
        public string MetaKeyword { get; set; }
        [MaxLength(256)]
        public string MetaDescription { get; set; }

        //ISwitchable
        public bool Status { get; set; }
    }
}