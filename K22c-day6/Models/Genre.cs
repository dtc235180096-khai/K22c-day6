namespace K22c_day6.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        //Navigation property

        public ICollection<Movies>? Movies { get; set; }

    }
}
