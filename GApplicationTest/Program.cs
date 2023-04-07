using FluentValidation;
using FluentValidation.AspNetCore;
using GApplication.DATA.BaseRepositry;
using GApplication.DATA.EFContext;
using GApplication.DATA.Model;
using GApplication.DATA.ViewModel;
using GApplication.Service.Repository;
using GApplication.Service.Repository.Interface;
using GApplication.Service.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IEmployeesServices, EmployeesServices>();
builder.Services.AddTransient<IDepartmentServices, DepartmentServices>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddValidatorsFromAssemblyContaining<EmployeesValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DepartmentValidator>();
builder.Services.AddScoped<IValidator<EmployeesVM>, EmployeesValidator>();
builder.Services.AddScoped<IValidator<Department>, DepartmentValidator>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()); ;

app.UseAuthorization();

app.MapControllers();

app.Run();
