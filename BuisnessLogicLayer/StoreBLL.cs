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
    public class StoreBLL
    {
        private DataAccessLayer.StoreDAL _storeDAL;
        private Mapper _storeMapper;

        public StoreBLL()
        {
            _storeDAL = new DataAccessLayer.StoreDAL();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Store, StoreModel>().ReverseMap();
                cfg.CreateMap<Store, StoreDTO>().ReverseMap();
            });

            _storeMapper = new Mapper(configuration);
        }

        public Store EditStore([FromBody] StoreDTO store)
        {
            var Store =
                _storeMapper.Map<Store>(store);
            _storeDAL.EditStore(Store);
            return Store;
        }

        public Store AddStore(StoreDTO store)
        {
            var Store =
                _storeMapper.Map<Store>(store);
            _storeDAL.AddStore(Store);
            return Store;


        }

        public List<StoreModel> GetAllStore()
        {
            List<Store> StoreFromDB = _storeDAL.GetAllStore();
            List<StoreModel> StoreModel =
                _storeMapper.Map<List<Store>, List<StoreModel>>(StoreFromDB);
            return StoreModel;
        }

        public StoreModel GetMediaById(int Id)
        {
            var StoreEntity = _storeDAL.GetMediaById(Id);

            if (StoreEntity == null)
            {
                throw new Exception("Invalid Id");
            }

            StoreModel StoreModel =
                _storeMapper.Map<Store, StoreModel>(StoreEntity);
            return StoreModel;
        }

        public Store DeleteStore(int Id)
        {
            return _storeDAL.DeleteStoreById(Id);
        }
    }
}
