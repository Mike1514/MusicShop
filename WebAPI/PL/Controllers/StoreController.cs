using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using BuisnessLogicLayer;
using BuisnessLogicLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Repository.DTO;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private BuisnessLogicLayer.StoreBLL _StoreBll;

        public StoreController()
        {
            _StoreBll = new BuisnessLogicLayer.StoreBLL();
        }

        [HttpGet]
        [Route("GetAllStore")]

        public List<StoreModel> GetAllStore()
        {
            return _StoreBll.GetAllStore();
        }


        [HttpPost]
        [Route("AddStore")]
        public Store AddStore([FromBody] StoreDTO a)
        {
            return _StoreBll.AddStore(a);
        }

        [HttpGet]
        [Route("GetStoreById")]
        public StoreModel GetMediaById(int Id)
        {
            return _StoreBll.GetMediaById(Id);
        }


        [HttpPut]
        [Route("EditStoreById")]
        public Store EditStore([FromBody] StoreDTO a)
        {
            return _StoreBll.EditStore(a);
        }


        [HttpDelete]
        [Route("DeleteStoreById")]
        public Store DeleteStoreById(int Id)
        {
            return _StoreBll.DeleteStore(Id);
        }


    }
}
