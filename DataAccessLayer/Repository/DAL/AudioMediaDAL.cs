using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace DataAccessLayer
{
    public class AudioMediaDAL
    {

        public AudioMedia AddAudioMedia([FromBody] AudioMedia a)
        {
            var db = new DotNetLabDbContext();
            db.Add(a);
            db.SaveChanges();
            return a;

        }

        public AudioMedia EditAudioMedia([FromBody] AudioMedia audio)
        {
            var db = new DotNetLabDbContext();
        AudioMedia a = new AudioMedia();
        a = db.AudioMedia.FirstOrDefault(x => x.Id == audio.Id);
        if (a != null)
        {
            a.AlbumName = audio.AlbumName;
            a.Artist = audio.Artist;
            a.Genre = audio.Genre;
            a.MediaType = audio.MediaType;
            a.ReleaseYear = audio.ReleaseYear;   
            a.TrackNames = audio.TrackNames;
        }
        db.SaveChangesAsync();
        return audio;
        }

        public List<AudioMedia> GetAllAudioMedia()
        {
            var db = new DotNetLabDbContext();
            return db.AudioMedia.ToList();
        }

        public AudioMedia GetMediaById(int Id)
        {
            var db = new DotNetLabDbContext();
            AudioMedia a = new AudioMedia();
            a = db.AudioMedia.FirstOrDefault(x => x.Id == Id);
            return a;
        }

        public AudioMedia DeleteAudioMediaById(int Id)
        {
            var db = new DotNetLabDbContext();
            AudioMedia a = db.AudioMedia.FirstOrDefault(x => x.Id == Id);

            if (Id != null)
            {
                db.AudioMedia.Remove(a);
            }
            db.SaveChanges();
            return a ;
        }
    }
}
