using SongDetailsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongDetailsAPI.Repository
{
    public interface ISongDetailsRepos
    {
        IEnumerable<SongDetails> GetAllSongsDetails();
        SongDetails GetSongDetailsById(int id);
        Task<SongDetails> PostSongDetails(SongDetails item);
        Task<SongDetails> UpdateSongDetails(int id, SongDetails item);
        Task<SongDetails> DeleteSong(int id);

    }
}
