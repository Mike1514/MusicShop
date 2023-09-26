using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using BuisnessLogicLayer;
using BuisnessLogicLayer.Models;
using DataAccessLayer;
using Newtonsoft.Json;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AudioMediaController : ControllerBase
    {
        private BuisnessLogicLayer.AudioMediaBLL _audioMediaBll;

        public AudioMediaController()
        {
            _audioMediaBll = new BuisnessLogicLayer.AudioMediaBLL();
        }

        [HttpGet]
        [Route("GetAllAudioMedia")]

        public List<AudioMediaModel> GetAllAudioMedia()
        {
            return _audioMediaBll.GetAllAudioMedia();
        }


        [HttpPost]
        [Route("AddAudioMedia")]
        public AudioMedia AddAudioMedia([FromBody] AudioMedia a)
        {
            return  _audioMediaBll.AddAudioMedia(a);
        }

        [HttpGet]
        [Route("GetAudioMediaById")]
        
        public AudioMediaModel GetMediaById(int Id)
        {
            return _audioMediaBll.GetMediaById(Id);
        }


        [HttpPut]
        [Route("EditAudioMediaById")]
        public AudioMedia EditAudioMedia([FromBody] AudioMedia audio)
        {
            return _audioMediaBll.EditAudioMedia(audio);
        }


        [HttpDelete]
        [Route("DeleteAudioMediaById")]
        public AudioMedia DeleteAudioMediaById(int Id)
        {
            return _audioMediaBll.DeleteAudioMedia(Id);
        }


    }
}

