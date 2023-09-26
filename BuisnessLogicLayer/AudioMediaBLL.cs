using DataAccessLayer;
using BuisnessLogicLayer;
using DataAccessLayer;
using AutoMapper;
using BuisnessLogicLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuisnessLogicLayer
{
    public class AudioMediaBLL
    {
        private DataAccessLayer.AudioMediaDAL _audioMediaDAL;
        private Mapper _audioMediaMapper;

        public AudioMediaBLL()
        {
            _audioMediaDAL = new DataAccessLayer.AudioMediaDAL();
            var _configureAudioMedia =
                new MapperConfiguration(cfg => cfg.CreateMap<AudioMedia, AudioMediaModel>().ReverseMap());
            _audioMediaMapper = new Mapper(_configureAudioMedia);
        }

        public AudioMedia EditAudioMedia([FromBody] AudioMedia audio)
        {
            return _audioMediaDAL.EditAudioMedia(audio);
        }

        public AudioMedia AddAudioMedia(AudioMedia a)
        {
            return _audioMediaDAL.AddAudioMedia(a);

        }

        public List<AudioMediaModel> GetAllAudioMedia()
        {
            List<AudioMedia> audioMediaFromDB = _audioMediaDAL.GetAllAudioMedia();
            List<AudioMediaModel> audioMediaModel =
                _audioMediaMapper.Map<List<AudioMedia>, List<AudioMediaModel>>(audioMediaFromDB);
            return audioMediaModel;
        }

        public AudioMediaModel GetMediaById(int Id)
        {
            var AudioMediaEntity = _audioMediaDAL.GetMediaById(Id);

            if (AudioMediaEntity == null)
            {
                throw new Exception("Invalid Id");
            }

            AudioMediaModel audioMediaModel =
                _audioMediaMapper.Map<AudioMedia, AudioMediaModel>(AudioMediaEntity);
            return audioMediaModel;
        }

        public AudioMedia DeleteAudioMedia(int Id)
        {
            return _audioMediaDAL.DeleteAudioMediaById(Id);
        }
    
}
}