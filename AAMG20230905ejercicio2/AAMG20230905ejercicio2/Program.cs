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

var proveedores = new List<Proveedor>();

app.MapGet("/proveedores", () =>
{
    return proveedores;
});

app.MapPost("/proveedores", (Proveedor proveedor) =>
{
    proveedores.Add(proveedor);
    return Results.Ok();
});

app.MapDelete("/proveedores/{id}", (int id) =>
{
    var existingProveedor = proveedores.FirstOrDefault(a => a.Id == id);
    if (existingProveedor != null)
    {
        proveedores.Remove(existingProveedor);
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

app.Run();

internal class Proveedor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int telephone { get; set; }



}
