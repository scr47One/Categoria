
using Microsoft.EntityFrameworkCore;

public class CategoriaDb(DbContextOptions<CategoriaDb> options): DbContext(options) {
    public DbSet<Categorias> Categorias { get; set; }
}