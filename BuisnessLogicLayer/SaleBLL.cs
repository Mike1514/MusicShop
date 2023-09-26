using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuisnessLogicLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Repository.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BuisnessLogicLayer
{
    public class SaleBLL
    {
        private DataAccessLayer.SaleDAL _saleDAL;
        private Mapper _saleMapper;

        public SaleBLL()
        {
            _saleDAL = new DataAccessLayer.SaleDAL();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Sale, SaleModel>().ReverseMap();
                cfg.CreateMap<Sale, SaleDTO>().ReverseMap();
            });

            _saleMapper = new Mapper(configuration);
        }

        public Sale EditSale([FromBody] SaleDTO sale)
        {
            var Sale =
                _saleMapper.Map<Sale>(sale);
            _saleDAL.EditSale(Sale);
            return Sale;
        }

        public Sale AddSale(SaleDTO a)
        {
            var Sale =
                _saleMapper.Map<Sale>(a);
            _saleDAL.AddSale(Sale);
            return Sale;


        }

        public List<SaleModel> GetAllSale()
        {
            List<Sale> SaleFromDB = _saleDAL.GetAllSale();
            List<SaleModel> SaleModel =
                _saleMapper.Map<List<Sale>, List<SaleModel>>(SaleFromDB);
            return SaleModel;
        }

        public SaleModel GetMediaById(int Id)
        {
            var SaleEntity = _saleDAL.GetMediaById(Id);

            if (SaleEntity == null)
            {
                throw new Exception("Invalid Id");
            }

            SaleModel SaleModel =
                _saleMapper.Map<Sale, SaleModel>(SaleEntity);
            return SaleModel;
        }

        public Sale DeleteSale(int Id)
        {
            return _saleDAL.DeleteSaleById(Id);
        }
    }
}
