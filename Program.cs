using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CategoriaDb>( options => {
    options.UseSqlServer("Server=50.21.176.30; Database=Evaluaciones; User Id=aspirante1; Password=aspirante1; Trusted_Connection=True; TrustServerCertificate=True; Integrated Security=False;");
});

var app = builder.Build();

app.MapGet("/", (CategoriaDb db) => db.Categorias.Where(x => x.Estatus == 1).ToListAsync());

app.MapPost("/", async (Categorias categoria, CategoriaDb db) => {

    categoria.FechaRegistro = new();
    categoria.FechaActualizacion = new();
    categoria.Estatus = 1;

    db.Categorias.Add(categoria);

    await db.SaveChangesAsync();

    return Results.Created();
});

app.MapPut("/{id}", async (int id, Categorias categoria, CategoriaDb db ) => {

    var categoriaF = await  db.Categorias.FindAsync(id);
    if (categoriaF == null) return Results.NotFound();

    categoriaF.Categoria = categoria.Categoria;
    categoriaF.Estatus = categoria.Estatus;
    
    db.Categorias.Update(categoriaF);

    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
