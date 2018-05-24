using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.UnitTest.RepositoryTest
{
    [TestClass]//B1
    public class PostCategoryRepositoryTest
    {
        private IDbFactory dbFactory;
        private IPostCategoryRepository objRepository;
        private IUnitOfWork unitOfWork;

        [TestInitialize]//B2
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        //B3 tiến hành tạo cũng phương thức Test
        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "test dong 2";
            category.Alias = "test-dong-2";
            category.Status = true;

            var result = objRepository.Add(category);//phương thức CRUD
            unitOfWork.Commit();// dùng để save value

            Assert.IsNotNull(result);
            //Assert.AreEqual(1, category.ID);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(2, list.Count);
        }
    }
}