using SongDetailsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongDetailsAPI.Repository
{
    public class SongDetailsRepos : ISongDetailsRepos
    {
        private readonly SpotifyDemoDbContext _context;

        public SongDetailsRepos(SpotifyDemoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SongDetails> GetAllSongsDetails()
        {
            return _context.SongDetails.ToList(); 
        }

        public SongDetails GetSongDetailsById(int id)
        {
            SongDetails songDetails = _context.SongDetails.Find(id);
            return songDetails;
        }

        public async Task<SongDetails> PostSongDetails(SongDetails item)
        {
            SongDetails songDetails = null;
            if(item == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                songDetails = new SongDetails() { Songname = item.Songname, Artistname = item.Artistname, Songdescription = item.Songdescription, Albumname = item.Albumname, Genre = item.Genre, Songpath = item.Songpath, Lyrics = item.Lyrics, Songplaycounter = 0};
                await _context.SongDetails.AddAsync(songDetails);
                await _context.SaveChangesAsync();

            }
            return songDetails;
        }

        public async Task<SongDetails> UpdateSongDetails(int id,SongDetails item)
        {
            SongDetails songDetails = await _context.SongDetails.FindAsync(id);
            songDetails.Songname = item.Songname;
            songDetails.Artistname = item.Artistname;
            songDetails.Songdescription = item.Songdescription;
            songDetails.Albumname = item.Albumname;
            songDetails.Genre = item.Genre;
            songDetails.Lyrics = item.Lyrics;
            songDetails.Songplaycounter = item.Songplaycounter;

            await _context.SaveChangesAsync();
            return songDetails;

        }

        public async Task<SongDetails> DeleteSong(int id)
        {
            SongDetails songDetails = await _context.SongDetails.FindAsync(id);
            if(songDetails == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _context.SongDetails.Remove(songDetails);
                await _context.SaveChangesAsync();
            }
            return songDetails;
        }
    }
}
