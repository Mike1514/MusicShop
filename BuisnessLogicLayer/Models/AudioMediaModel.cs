using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BuisnessLogicLayer.Models
{
    public class AudioMediaModel
    {
            public long Id { get; set; }

            public string AlbumName { get; set; } = null!;

            public string Artist { get; set; } = null!;

            public long ReleaseYear { get; set; }

            public string Genre { get; set; } = null!;

            public string MediaType { get; set; } = null!;

            [JsonIgnore]
            public string? TrackNames { get; set; }
        
    }
}
