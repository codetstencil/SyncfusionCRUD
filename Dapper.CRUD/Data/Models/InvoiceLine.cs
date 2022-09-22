namespace Dapper.CRUD.Data.Models
{
    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
