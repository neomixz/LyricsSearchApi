using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LyricsSearchAPI.Model;
using LyricsSearchAPI.Client;

namespace LyricsSearchAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistMusicController : ControllerBase
    {
        [HttpGet(Name = "GetAllArtistMusic")]
        public List<ArtistMusicResponseModel> Artist(string Artist)
        {
            LyricsClient1 cc1 = new LyricsClient1();
            return cc1.GetArtistMusicAsync(Artist).Result;
        }

    }
}
