using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase//ke thua tu thang Core
    {
        private IProductCategoryService _productCategoryService;

        //la co the the bat loi ok
        //b1: tao 4 phuong thuc, GET, POST, PUT, DELETE
        //b2: tao cac RoutePrefix
        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService)
            : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        //[Route("getall")]
        //public HttpResponseMessage Get(HttpRequestMessage request)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        var listProductCategory = _productCategoryService.GetAll();

        //        //edit cho - AutoMapper
        //        var listProductCategoryVm = Mapper.Map<List<ProductCategoryViewModel>>(listProductCategory);

        //        HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listProductCategoryVm);

        //        return response;
        //    });
        //}

        //ap dung cho phan trang bai 25
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keywork, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _productCategoryService.GetAll(keywork);//truyen tu khoa - bai 26

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                //edit cho - AutoMapper
                var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return response;
            });
        }
    }
}