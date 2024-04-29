using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using StudentData.Business.Business;
using StudentData.Business.Contract;
using StudentData.Entity.Models;
using StudentData.Repository.Common;
using StudentData.Repository.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StudentMasterContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDataConnectionString"));
});
builder.Services.AddScoped<DbContext, StudentMasterContext>();
builder.Services.AddScoped<IStudentBusiness, StudentBusiness>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddAutoMapper(c =>
{
    c.AddExpressionMapping();
}, typeof(StudentRepository).Assembly);

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
