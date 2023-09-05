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

var categories = new List<Categori>();

for (var c = 1; c <= 5; c++)
{
    Categori categori = new();
    categori.Id = c;
    categori.Name = $"Categori {c}";
    categories.Add(categori);
}

app.MapGet("/categories", () =>
{
    return categories;
});



app.Run();

internal class Categori
{
    public int Id { get; set; }
    public string Name { get; set; }

}