namespace DHAUZ_Api.Models
{
    public class MovieVM
    {
        public int Id { get; set; }
        public string? IdImdb { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public bool? Watched { get; set; }
        public double? Score { get; set; }
    }
}
