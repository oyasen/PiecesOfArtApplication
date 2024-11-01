using Microsoft.EntityFrameworkCore;
using PiecesOfArt_Application_Assignment.Data;
using PiecesOfArt_Application_Assignment.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicatioDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepo, UserRepo>();  
builder.Services.AddScoped<ILoyaltyCardRepo, LoyaltyCardRepo>();  
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();  
builder.Services.AddScoped<IPieceOfArtRepo, PieceOfArtRepo>();  
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
