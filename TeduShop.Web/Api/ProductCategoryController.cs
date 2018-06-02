using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
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

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listProductCategory = _productCategoryService.GetAll();

                //edit cho - AutoMapper
                var listProductCategoryVm = Mapper.Map<List<ProductCategoryViewModel>>(listProductCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listProductCategoryVm);

                return response;
            });
        }
    }
}