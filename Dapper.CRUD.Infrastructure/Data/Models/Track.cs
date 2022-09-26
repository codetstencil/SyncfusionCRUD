namespace Dapper.CRUD.Data.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public string? Name { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int GenreId { get; set; }
        public string? Composer { get; set; }
        public int Miliseconds { get; set; }
        public int Bytes { get; set; }
        public int UnitPrice { get; set; }
        public int PlayListTrackId { get; set; }
    }
}
