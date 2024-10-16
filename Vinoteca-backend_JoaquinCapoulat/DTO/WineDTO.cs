namespace VinotecaBackend.DTOs
{
    public class WineDTO
    {
        internal int id;
        public required string Name { get; set; }
        public required string Variety { get; set; }
        public int Year { get; set; }
        public required string Region { get; set; }
        public int Stock { get; set; }
    }
}
