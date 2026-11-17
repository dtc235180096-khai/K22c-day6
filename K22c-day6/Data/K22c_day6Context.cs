using Microsoft.EntityFrameworkCore;

public class K22c_day6Context(DbContextOptions<K22c_day6Context> options) : DbContext(options)
{
    public DbSet<K22c_day6.Models.Genre> Genre { get; set; } = default!;
    public DbSet<K22c_day6.Models.Movies> Movies { get; set; } = default!;
}
