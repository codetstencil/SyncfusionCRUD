using Dapper.CRUD.Data.DAL;
using Dapper.CRUD.Data.Models;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;

namespace Dapper.CRUD.Pages
{
    public partial class AlbumComponent : ComponentBase
    {
        [Inject]
        public ArtistDataAccessLayer? artistDataAccessLayer { get; set; }

        public List<Artist> artistList = new List<Artist>();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                artistList = await artistDataAccessLayer!.GetArtistAsync();
            }
        }
    }
}
