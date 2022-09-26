using Dapper.CRUD.Data.DAL;
using Dapper.CRUD.Data.Models;
using Microsoft.AspNetCore.Components;

namespace Dapper.CRUD.Pages
{
    public partial class PlayListComponent : ComponentBase
    {
        [Inject]
        public TrackDataAccessLayer? trackDataAccessLayer { get; set; }

        public List<Track> trackList = new List<Track>();
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                trackList = await trackDataAccessLayer!.GetTrackAsync();
            }
        }
    }
}
