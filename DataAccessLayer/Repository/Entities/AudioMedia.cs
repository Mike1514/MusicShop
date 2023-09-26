using System;
using System.Collections.Generic;
using DataAccessLayer;


namespace DataAccessLayer;

public partial class AudioMedia
{
    public long Id { get; set; }

    public string AlbumName { get; set; } = null!;

    public string Artist { get; set; } = null!;

    public long ReleaseYear { get; set; }

    public string Genre { get; set; } = null!;

    public string MediaType { get; set; } = null!;

    public string? TrackNames { get; set; }
}
