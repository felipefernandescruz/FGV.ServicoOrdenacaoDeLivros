using FGV.ServicoOrdenacaoDeLivros.Domain;
using FGV.ServicoOrdenacaoDeLivros.Domain.Book;
using FGV.ServicoOrdenacaoDeLivros.Domain.Book.Models.Dto;
using FGV.ServicoOrdenacaoDeLivros.Domain.Book.Validator;
using FGV.ServicoOrneacaoDeLivros.InfraStructure.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IValidator<OrderFilterDTO>, OrderFilterValidator>();
builder.Services.AddScoped<IValidator<BookDTO>, BookValidator>();
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
