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
                return Songs.Count(song => song.IsSpotlight);
            }
        }

        public Int32 SpotlightTotal
        {
            get
            {
                return Songs.Sum(song => song.SpotlightCount);
            }
        }

        [Serializable()]
        public class Song
        {
            public String Title { get; set; }
            public String Artist { get; set; }

            public String VocalPath { get; set; }
            public String VocalNotes { get; set; }
            public String VocalPathReduced { get; set; }

            public String DrumsPath { get; set; }
            public String DrumsNotes { get; set; }

            public String GuitarPath { get; set; }
            public String GuitarNotes { get; set; }

            public String BassPath { get; set; }
            public String BassNotes { get; set; }

            public String HarmPath { get; set; }
            public String HarmNotes { get; set; }

            public Boolean IsSpotlight { get { return SpotlightCount > 0; } }
            public Int32 SpotlightCount { get; set; }

            public Boolean IsTalky { get; set; }
            public String TalkyPath { get; set; }
            public String TalkyNotes { get; set; }

            public Boolean IsEpic { get; set; }
            
            public Song()
            {
                Title = "";
                Artist = "";
                VocalPath = "";
                VocalNotes = "";
                VocalPathReduced = "";
                DrumsPath = "";
                DrumsNotes = "";
                GuitarPath = "";
                GuitarNotes = "";
                BassPath = "";
                BassNotes = "";
                HarmPath = "";
                HarmNotes = "";
                TalkyPath = "";
                TalkyNotes = "";
                SpotlightCount = 0;
                IsEpic = false;
                IsTalky = false;
            }
        }
    }

    public static class Funct
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SongData GetSongData()
        {
            return ParseFiles(DownloadFiles());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="WebException"></exception>
        /// <returns></returns>
        private static List<String[]> DownloadFiles()
        {
            List<String> links = new List<String>
            {
                //0 - Vocals
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=358267987&single=true&output=tsv",
                //1 - Vocals Paths(ALL)
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=1849782495&single=true&output=tsv",
                //2 - Drums
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=898076730&single=true&output=tsv",
                //3 - Guitar
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=2031879843&single=true&output=tsv",
                //4 - Bass
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=1635523912&single=true&output=tsv",
                //5 - About
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=157720447&single=true&output=tsv",
                //6 - Vocals Paths (OLD)
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=0&single=true&output=tsv",
                //7 - Harm
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=686163764&single=true&output=tsv",
                //8 - Spotlights
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=1180744761&single=true&output=tsv",
                //9 - VocalsSH
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=1178758294&single=true&output=tsv",
                //10 - Vocal/Talky/Brutal
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=417970423&single=true&output=tsv",
                //11 - Vocal/Epic/Taps
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=1894013534&single=true&output=tsv",
            };

            var files = new List<String[]>();

            using (var client = new WebClient() { Encoding = Encoding.UTF8 })
            {
                links.ForEach(link =>
                    files.Add(client.DownloadString(link)
                        .Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                        .Where(line => !String.IsNullOrWhiteSpace(line))
                        .Select(line => line.Trim())
                        .ToArray())
                );
            }

            return files;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        private static SongData ParseFiles(List<String[]> files)
        {
            var spotlights = new SongData();
            for (var i = 1; i < files[8].Length; i++)
            {
                var song = files[8][i].Split('\t');

                var title = song[0];
                var artist = song[1];

                if (title != "-" && title != "")
                {
                    spotlights.Songs.Add(new SongData.Song
                    {
                        Title = title,
                        Artist = artist,
                    });
                }
            }

            var talkyOnly = new SongData();
            for (var i = 1; i < files[10].Length; i++)
            {
                var song = files[10][i].Split('\t');

                var title = song[0];
                var artist = song[1];
                var path = song[2];
                var notes = song[3];

                if (title != "-" && title != "")
                {
                    talkyOnly.Songs.Add(new SongData.Song
                    {
                        Title = title,
                        Artist = artist,
                        TalkyPath = path,
                        TalkyNotes = notes,
                    });
                }
            }

            var epicOnly = new SongData();
            for (var i = 1; i < files[11].Length; i++)
            {
                var song = files[11][i].Split('\t');

                var title = song[0];
                var artist = song[1];
                var path = (song.Count() > 2) ? song[2] : "";
                var notes = (song.Count() > 3) ? song[3] : "";

                if (title != "-" && title != "")
                {
                    epicOnly.Songs.Add(new SongData.Song
                    {
                        Title = title,
                        Artist = artist,
                        TalkyPath = path,
                        TalkyNotes = notes,
                    });
                }
            }

            var songs = new SongData();
            for (var i = 2; i < files[0].Length; i++)
            {
                var vocalLine = files[0][i].Split('\t').ToList();
                var drumsLine = files[2][i].Split('\t').ToList();
                var guitarLine = files[3][i].Split('\t').ToList();
                var bassLine = files[4][i].Split('\t').ToList();
                var harmLine = files[7][i].Split('\t').ToList();
                
                var title = vocalLine[0];
                var artist = vocalLine[1];

                songs.Songs.Add(new SongData.Song
                {
                    Title = title,
                    Artist = artist,
                    VocalPath = (vocalLine.Count > 2) ? vocalLine[2] : "",
                    VocalNotes = (vocalLine.Count > 3) ? vocalLine[3] : "",
                    DrumsPath = (drumsLine.Count > 2) ? drumsLine[2] : "",
                    DrumsNotes = (drumsLine.Count > 3) ? drumsLine[3] : "",
                    GuitarPath = (guitarLine.Count > 2) ? guitarLine[2] : "",
                    GuitarNotes = (guitarLine.Count > 3) ? guitarLine[3] : "",
                    BassPath = (bassLine.Count > 2) ? bassLine[2] : "",
                    BassNotes = (bassLine.Count > 3) ? bassLine[3] : "",
                    HarmPath = (harmLine.Count > 2) ? harmLine[2] : "",
                    HarmNotes = (harmLine.Count > 3) ? harmLine[3] : "",
                });
            }

            var spotlightError = new SongData();
            spotlights.Songs.ForEach(x =>
            {
                var index = songs.Songs.FindIndex(song => song.Title.ToLower() == x.Title.ToLower() && song.Artist.ToLower() == x.Artist.ToLower());

                if (index != -1)
                {
                    songs.Songs[index].SpotlightCount++;
                }
                else
                {
                    spotlightError.Songs.Add(new SongData.Song() { Title = x.Title, Artist = x.Artist });
                }
            });

            var talkyError = new SongData();
            talkyOnly.Songs.ForEach(x =>
            {
                var index = songs.Songs.FindIndex(song => song.Title.ToLower() == x.Title.ToLower() && song.Artist.ToLower() == x.Artist.ToLower());

                if (index != -1)
                {
                    songs.Songs[index].IsTalky = true;
                    songs.Songs[index].TalkyPath = x.TalkyPath;
                    songs.Songs[index].TalkyNotes = x.TalkyNotes;
                }
                else
                {
                    talkyError.Songs.Add(new SongData.Song() { Title = x.Title, Artist = x.Artist });
                }
            });

            var epicError = new SongData();
            epicOnly.Songs.ForEach(x =>
            {
                var index = songs.Songs.FindIndex(song => song.Title.ToLower() == x.Title.ToLower() && song.Artist.ToLower() == x.Artist.ToLower());

                if (index != -1)
                {
                    songs.Songs[index].IsEpic = true;

                    songs.Songs[index].TalkyPath += x.TalkyPath;

                    if (songs.Songs[index].TalkyNotes != "")
                        songs.Songs[index].TalkyNotes += " ";
                    songs.Songs[index].TalkyNotes += x.TalkyNotes;
                }
                else
                {
                    epicError.Songs.Add(new SongData.Song() { Title = x.Title, Artist = x.Artist });
                }
            });

            if (spotlightError.Songs.Count > 0)
                System.Windows.Forms.MessageBox.Show(spotlightError.Songs.ToString(), "Spotlight Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            if (talkyError.Songs.Count > 0)
                System.Windows.Forms.MessageBox.Show(talkyError.Songs.ToString(), "Talky Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            if (epicError.Songs.Count > 0)
                System.Windows.Forms.MessageBox.Show(epicError.Songs.ToString(), "Epic Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);

            var songsALL = new SongData();
            var songsOLD = new SongData();
            var songsScH = new SongData();
            
            String[] lines2 = files[1].Skip(2).ToArray();
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

            String[] lines3 = files[6].Skip(2).ToArray();
            foreach (var line in lines3)
            {
                var lineFormat = line.Split('\t').ToList();
                songsOLD.Songs.Add(new SongData.Song
                {
                    Title = lineFormat[0],
                    Artist = lineFormat[1],
                    VocalPath = (lineFormat.Count > 2) ? lineFormat[2] : "",
                    VocalNotes = (lineFormat.Count > 3) ? lineFormat[3] : "",
                });
            }

            String[] linesSH = files[9].ToArray();
            foreach (var line in linesSH)
            {
                var lineFormat = line.Split(':');
                songsScH.Songs.Add(new SongData.Song
                {
                    Title = lineFormat[0].Trim(),
                    Artist = "",
                    VocalPath = lineFormat[1].Trim(),
                });
            }

            //Remove empty paths.
            songsALL.Songs = songsALL.Songs.Where(song => song.VocalPath != "").ToList();
            songsOLD.Songs = songsOLD.Songs.Where(song => song.VocalPath != "").ToList();
            songsScH.Songs = songsScH.Songs.Where(song => song.VocalPath != "").ToList();
            
            //Add all vocal paths together.
            for (Int32 i = 0; i < songs.Songs.Count; i++)
            {
                if (songs.Songs[i].VocalPath == "")
                {
                    var songsTemp = new SongData()
                    {
                        Songs = new List<SongData.Song>
                        {
                            songsALL.Songs.Find(songOld => songOld.Title.ToLower() == songs.Songs[i].Title.ToLower()),
                            songsScH.Songs.Find(songOld => songOld.Title.ToLower() == songs.Songs[i].Title.ToLower() && songs.Songs.Where(song2 => song2.Title.ToLower() == songOld.Title.ToLower()).Count() < 2),
                            songsOLD.Songs.Find(songOld => songOld.Title.ToLower() == songs.Songs[i].Title.ToLower()),
                        }
                    };

                    songsTemp.Songs
                        .Where(songTemp => songTemp != null && songTemp.VocalPath != "")
                        .ToList()
                        .ForEach(songTemp =>
                        {
                            songs.Songs[i].VocalPath = songTemp.VocalPath;
                            songs.Songs[i].VocalNotes = songTemp.VocalNotes;
                        }
                    );

                }
            }

            for(Int32 i = 0; i < songs.Songs.Count; i++)
            {
                songs.Songs[i].VocalPathReduced = ReduceVocalPath(songs.Songs[i].VocalPath);
            }

            //Last Time DLC was added.
            songs.UpdateWeek = files[5][1].Split('\t')[2];

            songs.Songs = songs.Songs.OrderBy(song => song.Title).ToList();

            return songs; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static String ReduceVocalPath(String path)
        {
            if (String.IsNullOrEmpty(path))
                return "";

            if (!path.Contains("/"))
                return path;

            //Not implemented.
            return path;

            var newPath = "";
            var pathSplit = path
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            pathSplit.ForEach(part =>
                {
                    var part1 = part.ToList().Find(parts => Char.IsDigit(parts));
                    var part2 = part.Split('/').Count() > 1 ? part.Split('/')[1] : " ";
                    newPath += part1 + "/";
                    if (part2.Count() > 0 && part2[0] == 'B')
                        newPath += part2[0];
                    newPath += ", ";
                }
            );
            
            return newPath;
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