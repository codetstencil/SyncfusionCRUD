using Dapper.CRUD.Data.DAL;
using Dapper.CRUD.Data.Models;
using Microsoft.AspNetCore.Components;

namespace Dapper.CRUD.Pages
{
    public partial class TrackComponent : ComponentBase
    {
        [Inject]
        public AlbumDataAccessLayer albumDataAccessLayer { get; set; }

        [Inject]
        public MediaTypeDataAccessLayer mediaTypeDataAccessLayer { get; set; }
        [Inject]
        public GenreDataAccessLayer genreDataAccessLayer { get; set; }
        [Inject]
        public PlayListDataAccessLayer playListDataAccessLayer { get; set; }

        public List<Album> albumList = new List<Album>();
        public List<MediaType> mediatypeList = new List<MediaType>();
        public List<Genre> genreList = new List<Genre>();
        public List<PlayList> playLists = new List<PlayList>();
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                albumList = await albumDataAccessLayer.GetAlbumAsync();
                mediatypeList = await mediaTypeDataAccessLayer.GetMediaTypeAsync();
                genreList = await genreDataAccessLayer.GetGenreAsync();
                playLists = await playListDataAccessLayer.GetPlayListAsync();
            }
        }
    }
}
