var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var marcas = new List<Marca>();

app.MapGet("/marcas/{id}", (int id) =>
{
    var marca = marcas.FirstOrDefault(a => a.Id == id);
    return marca;
});

app.MapPost("/marcas", (Marca marca) =>
{
    marcas.Add(marca);
    return Results.Ok();
});

app.MapPut("/marcas/{id}", (int id, Marca marca) =>
{
    var existingMarca = marcas.FirstOrDefault(a => a.Id == id);
    if (existingMarca != null)
    {
        existingMarca.Nombre = marca.Nombre;
        existingMarca.Descripcion = marca.Descripcion;
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});


app.Run();

internal class Marca
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

}