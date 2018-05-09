
using System;

namespace TeduShop.Data.Infrastructure
{
    //B6
    public interface IDbFactory : IDisposable
    {
        TeduShopDbContext Init();
    }
}