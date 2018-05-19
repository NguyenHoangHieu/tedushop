using System;

namespace TeduShop.Model.Abstract
{
    public interface IAuditable
    {
        //interface dung de su dung lai cac thuoc tinh bi trung => class Auditbale
        //de su dung cac thuoc tinh nay
        //ISeoable, IAuditable, ISwitchable trong C# khong cho ke thua 3 lop, 
        //vi the ta gom cac thuoc tinh vao chung 1 Interface & 1 Class laf IAudiable

        DateTime? CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }

        //ISeoable
        string MetaKeyword { get; set; }
        string MetaDescription { get; set; }

        //ISwitchable
        bool Status { get; set; }
    }
}