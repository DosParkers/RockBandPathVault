using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RB4PV
{
    [Serializable()]
    public class SongData
    {
        public List<Song> Songs { get; set; }
        public String UpdateWeek { get; set; }
        public DateTime TimeOfDownload { get; }

        public SongData()
        {
            Songs = new List<Song>();
            UpdateWeek = "";
            TimeOfDownload = DateTime.Now;
        }

        public List<Song> Filter(String text)
        {
            return Songs.Where(song =>
                    song.Title.ToLower().Contains(text.ToLower()) ||
                    song.Artist.ToLower().Contains(text.ToLower())
                ).ToList();
        }

        public List<Song> SpotlightOnly
        {
            get
            {
                return Songs.Where(song => song.IsSpotlight).ToList();
            }
        }

        public Int32 VocalCount
        {
            get
            {
                return Songs.Where(song => song.VocalPath != "").Count();
            }
        }

        public Int32 DrumCount
        {
            get
            {
                return Songs.Where(song => song.DrumsPath != "").Count();
            }
        }

        public Int32 GuitarCount
        {
            get
            {
                return Songs.Where(song => song.GuitarPath != "").Count();
            }
        }

        public Int32 BassCount
        {
            get
            {
                return Songs.Where(song => song.BassPath != "").Count();
            }
        }

        public Int32 HarmCount
        {
            get
            {
                return Songs.Where(song => song.HarmPath != "").Count();
            }
        }

        public Int32 SpotlightUnique
        {
            get
            {
                return SpotlightTotal - Songs.Where(song => song.IsSpotlight).GroupBy(song => song.Title).Where(song => song.Count() > 1).Count(); ;
            }
        }

        public Int32 SpotlightTotal
        {
            get
            {
                return Songs.Where(song => song.IsSpotlight).Count();
            }
        }

        [Serializable()]
        public class Song
        {
            public String Title { get; set; }
            public String Artist { get; set; }

            public String VocalPath { get; set; }
            public String VocalNotes { get; set; }

            public String DrumsPath { get; set; }
            public String DrumsNotes { get; set; }

            public String GuitarPath { get; set; }
            public String GuitarNotes { get; set; }

            public String BassPath { get; set; }
            public String BassNotes { get; set; }

            public String HarmPath { get; set; }
            public String HarmNotes { get; set; }

            public Boolean IsSpotlight { get; set; }
            
            public Song()
            {
                Title = "";
                Artist = "";
                VocalPath = "";
                VocalNotes = "";
                DrumsPath = "";
                DrumsNotes = "";
                GuitarPath = "";
                GuitarNotes = "";
                BassPath = "";
                BassNotes = "";
                HarmPath = "";
                HarmNotes = "";
                IsSpotlight = false;
            }
        }
    }

    public static class Funct
    { 
        public static SongData GetSongData()
        {
            return ParseFiles(DownloadFiles(null));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="savedFiles">Pass in a null object to force the download. Otherwise, pass in previous downloaded data.</param>
        /// <exception cref="WebException"></exception>
        /// <returns></returns>
        public static List<String[]> DownloadFiles(List<String[]> savedFiles)
        {
            #region links List<string>
            List<String> links = new List<String>
            {
                //0 - Vocals
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=358267987&single=true&output=tsv",
                //1 - Vocals Paths(Old)
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=1849782495&single=true&output=tsv",
                //2 - Drums
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=898076730&single=true&output=tsv",
                //3 - Guitar
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=2031879843&single=true&output=tsv",
                //4 - Bass
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=1635523912&single=true&output=tsv",
                //5 - About
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=157720447&single=true&output=tsv",
                //6 - Vocals Paths (ALL)
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=0&single=true&output=tsv",
                //7 - Harm
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=686163764&single=true&output=tsv",
                //8 - Spotlights
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=1180744761&single=true&output=tsv",
                //9 - VocalsSH
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=1178758294&single=true&output=tsv",
            };
            #endregion

            if (savedFiles == null || savedFiles.Any(file => file == null) || savedFiles.Count != 10)
            {
                savedFiles = new List<String[]>();

                using (var client = new WebClient())
                {
                    links.ForEach(link =>
                        savedFiles.Add(client.DownloadString(link).Split('\n'))
                    );

                    for (Int32 i = 0; i < savedFiles.Last().Count(); i++)
                        savedFiles.Last()[i] = savedFiles.Last()[i].Trim();
                }
            }

            return savedFiles;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static SongData ParseFiles(List<String[]> files)
        {
            var songs = new SongData();

            var spotlights = new SongData();
            #region Get spotlight data from files.
            for (var i = 1; i < files[8].Length; i++)
            {
                var song = files[8][i].Split('\t');

                if (song.Count() > 1)
                {
                    var title = song[0];
                    var artist = song[1];

                    if (title != "-" || title != "")
                    {
                        spotlights.Songs.Add(new SongData.Song
                        {
                            Title = title,
                            Artist = artist,
                        });
                    }
                }
            }
            #endregion
            
            #region Get song list data from files.
            for (var x = 2; x < files[0].Length; x++)
            {
                var title = files[0][x].Split('\t')[0];
                var artist = files[0][x].Split('\t')[1];

                songs.Songs.Add(new SongData.Song
                {
                    Title = title,
                    Artist = artist,
                    VocalPath = files[0][x].Split('\t')[2],
                    VocalNotes = files[0][x].Split('\t')[3],
                    DrumsPath = files[2][x].Split('\t')[2],
                    DrumsNotes = files[2][x].Split('\t')[3],
                    GuitarPath = files[3][x].Split('\t')[2],
                    GuitarNotes = files[3][x].Split('\t')[3],
                    BassPath = files[4][x].Split('\t')[2],
                    BassNotes = files[4][x].Split('\t')[3],
                    HarmPath = files[7][x].Split('\t')[2],
                    HarmNotes = files[7][x].Split('\t')[3],
                });

                if (spotlights.Songs.Exists(song =>
                     song.Title.ToLower() == title.ToLower() &&
                     song.Artist.ToLower() == artist.ToLower())
                    )
                {
                    songs.Songs.Last().IsSpotlight = true;
                }
            }
            #endregion

            var songsALL = new SongData();
            var songsOLD = new SongData();
            var songsScH = new SongData();

            #region Get old vox data.
            String[] lines2 = files[1].Skip(2).Where(line => line != "").ToArray();
            foreach (string line in lines2)
            {
                string[] lineFormat = line.Split('\t');
                songsALL.Songs.Add(new SongData.Song
                {
                    Title = lineFormat[0],
                    Artist = lineFormat[1],
                    VocalPath = lineFormat[2],
                    VocalNotes = ""
                });
            }

            String[] lines3 = files[6].Skip(2).Where(line => line != "").ToArray();
            foreach (var line in lines3)
            {
                var lineFormat = line.Split('\t');
                songsOLD.Songs.Add(new SongData.Song
                {
                    Title = lineFormat[0],
                    Artist = lineFormat[1],
                    VocalPath = lineFormat[2],
                    VocalNotes = lineFormat[3],
                });
            }

            String[] linesSH = files[9].Where(line => line != "").ToArray();
            foreach (var line in linesSH)
            {
                var lineFormat = line.Split(':');
                songsScH.Songs.Add(new SongData.Song
                {
                    Title = lineFormat[0],
                    Artist = "",
                    VocalPath = lineFormat[1],
                });
            }
            #endregion

            //Remove empty paths.
            songsALL.Songs = songsALL.Songs.Where(song => song.VocalPath != "").ToList();
            songsOLD.Songs = songsOLD.Songs.Where(song => song.VocalPath != "").ToList();
            songsScH.Songs = songsScH.Songs.Where(song => song.VocalPath != "").ToList();

            #region Add old vox data to song list.
            for (Int32 i = 0; i < songs.Songs.Count; i++)
            {
                if (songs.Songs[i].VocalPath == "")
                {
                    var songsTemp = new SongData()
                    {
                        Songs = new List<SongData.Song>
                        {
                            songsOLD.Songs.Find(songOld => songOld.Title.ToLower() == songs.Songs[i].Title.ToLower()),
                            songsScH.Songs.Find(songOld => songOld.Title.ToLower() == songs.Songs[i].Title.ToLower() && songs.Songs.Where(song2 => song2.Title.ToLower() == songOld.Title.ToLower()).Count() < 2),
                            songsALL.Songs.Find(songOld => songOld.Title.ToLower() == songs.Songs[i].Title.ToLower())
                        }
                    };

                    songsTemp.Songs = songsTemp.Songs.Where(songTemp => songTemp != null && songTemp.VocalPath != "").ToList();

                    songsTemp.Songs.ForEach(songTemp =>
                    {
                        songs.Songs[i].VocalPath = songTemp.VocalPath;
                        songs.Songs[i].VocalNotes = songTemp.VocalNotes;
                    });

                }
            }
            #endregion

            //Last Time DLC was added.
            songs.UpdateWeek = files[5][1].Split('\t')[2];

            return songs; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="songs"></param>
        /// <returns></returns>
        public static String Serialize(SongData songs)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, songs);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                return Convert.ToBase64String(buffer);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static SongData Deserialize(String data)
        {
            if (data == "")
                return null;

            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(data)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (SongData)bf.Deserialize(ms);
            }
        }
    }
}