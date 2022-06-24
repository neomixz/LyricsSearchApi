using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.IO;
using LyricsSearchAPI.Model;
using LyricsSearchAPI.Client;


namespace LyricsSearchAPI.Controllers
{
    [Route("[controller]")]
    public class LyricsController : ControllerBase
    {
        [HttpGet(Name = "GetLyrics")]
        public string Lyric(string Artist, string SongName)
        {
            LyricsClient1 cc1 = new LyricsClient1();

            var songName_editing = SongName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string edited_songName = "";
            for (int i = 0; i < songName_editing.Length; i++)
            {
                edited_songName += songName_editing[i];
                if (i != songName_editing.Length - 1)
                    edited_songName += "-";
            }


            var lyric_editing = cc1.GetLyricsAsync(Artist, edited_songName.ToLower()).Result[0].songLyric.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string edited_lyric = "";
            int n = 0;
            for (int i = 0; i < lyric_editing.Length; i++)
            {                
                if (n == 5)
                {
                    edited_lyric += lyric_editing[i] + " \n";
                    n = 0;
                }
                else
                {
                    edited_lyric += lyric_editing[i] + " ";
                }
                n++;
            }

            return edited_lyric;
        }


        [HttpPost(Name = "SaveLyrics")]
        public string SaveLyric(string Artist, string SongName)
        {
            LyricsClient1 cc1 = new LyricsClient1();

            var songName_editing = SongName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string edited_songName = "";
            for (int i = 0; i < songName_editing.Length; i++)
            {
                edited_songName += songName_editing[i];
                if (i != songName_editing.Length - 1)
                    edited_songName += "-";
            }


            var lyric_editing = cc1.GetLyricsAsync(Artist, edited_songName.ToLower()).Result[0].songLyric.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string edited_lyric = "";
            int n = 0;
            for (int i = 0; i < lyric_editing.Length; i++)
            {
                if (n == 5)
                {
                    edited_lyric += lyric_editing[i] + " \n";
                    n = 0;
                }
                else
                {
                    edited_lyric += lyric_editing[i] + " ";
                }
                n++;                       
            }

            string file_name = Artist.ToLower() + " - " + SongName.ToLower();
            string path = $@"D:\programing\LyricsSearchAPI\LyricsSearchAPI\Lyrics\{file_name}.txt";

            using (var sw = new StreamWriter(path, false))
            {
                sw.WriteLine(edited_lyric);
            }

            return "Lyrics is saved!!";
        }


        [HttpDelete(Name = "DeleteLyrics")]
        public string DeleteLyric(string Artist, string SongName)
        {
            string path = @"D:\programing\LyricsSearchAPI\LyricsSearchAPI\Lyrics";
           
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                if(Path.GetFileName(file.ToLower()).Contains(Artist.ToLower() + " - " + SongName.ToLower()))
                {
                    var fileInfo = new FileInfo($@"D:\programing\LyricsSearchAPI\LyricsSearchAPI\Lyrics\{Artist.ToLower() + " - " + SongName.ToLower()}.txt");
                    fileInfo.Delete();
                }
            }

            return "Song Lyric is Deleted!!";
        }


        [HttpPut(Name = "ChangeLyrics")]
        public string ChangeLyric(string Old_Artist, string Old_SongName, string New_Artist, string New_SongName)
        {
            string path = @"D:\programing\LyricsSearchAPI\LyricsSearchAPI\Lyrics";

            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                if (Path.GetFileName(file.ToLower()).Contains(Old_Artist.ToLower() + " - " + Old_SongName.ToLower()))
                {
                    var fileInfo = new FileInfo($@"D:\programing\LyricsSearchAPI\LyricsSearchAPI\Lyrics\{Old_Artist.ToLower() + " - " + Old_SongName.ToLower()}.txt");
                    fileInfo.Delete();
                }
            }




            LyricsClient1 cc1 = new LyricsClient1();

            var songName_editing = New_SongName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string edited_songName = "";
            for (int i = 0; i < songName_editing.Length; i++)
            {
                edited_songName += songName_editing[i];
                if (i != songName_editing.Length - 1)
                    edited_songName += "-";
            }

            var lyric_editing = cc1.GetLyricsAsync(New_Artist, edited_songName.ToLower()).Result[0].songLyric.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string edited_lyric = "";
            int n = 0;
            for (int i = 0; i < lyric_editing.Length; i++)
            {
                if (n == 5)
                {
                    edited_lyric += lyric_editing[i] + " \n";
                    n = 0;
                }
                else
                {
                    edited_lyric += lyric_editing[i] + " ";
                }
                n++;
            }

            string file_name = New_Artist.ToLower() + " - " + New_SongName.ToLower();
            string path1 = $@"D:\programing\LyricsSearchAPI\LyricsSearchAPI\Lyrics\{file_name}.txt";

            using (var sw = new StreamWriter(path1, false))
            {
                sw.WriteLine(edited_lyric);
            }

            return "Song Lyric is Changed!!";
        }
    }
}
