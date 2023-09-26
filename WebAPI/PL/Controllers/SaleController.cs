using BuisnessLogicLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Repository.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        private BuisnessLogicLayer.SaleBLL _saleBll;

        public SaleController()
        {
            _saleBll = new BuisnessLogicLayer.SaleBLL();
        }

        [HttpGet]
        [Route("GetAllSale")]

        public List<SaleModel> GetAllSale()
        {
            return _saleBll.GetAllSale();
        }


        [HttpPost]
        [Route("AddSale")]
        public Sale AddSale([FromBody] SaleDTO a)
        {
            return _saleBll.AddSale(a);
        }

        [HttpGet]
        [Route("GetSaleById")]
        public SaleModel GetMediaById(int Id)
        {
            return _saleBll.GetMediaById(Id);
        }


        [HttpPut]
        [Route("EditSaleById")]
        public Sale EditSale([FromBody] SaleDTO a)
        {
            return _saleBll.EditSale(a);
        }


        [HttpDelete]
        [Route("DeleteSaleById")]
        public Sale DeleteSaleById(int Id)
        {
            return _saleBll.DeleteSale(Id);
        }


    }
}
