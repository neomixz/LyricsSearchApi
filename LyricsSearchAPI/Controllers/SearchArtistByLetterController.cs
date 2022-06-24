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
    public class SearchArtistByWordController : ControllerBase
    {
        [HttpGet(Name = "GetArtistByWord")]
        public List<ArtistByLetterResponseModel> Word(string OneWord)
        {
            LyricsClient1 cc1 = new LyricsClient1();
            return cc1.GetArtistByLetterAsync(OneWord).Result;
        }
    }
}
