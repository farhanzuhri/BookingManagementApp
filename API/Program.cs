using System.Net;
using System.Reflection;
using API.Contracts;
using API.Data;
using API.DTOs.Employees;
using API.Repositories;
using API.Utilities.Handler;
using API.Utilities.Validations.Employees;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Utilities.Validations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BookingManagementDbContext>(options => options.UseSqlServer(connectionString));

// Add Email Service to the container.
builder.Services.AddTransient<IEmailHandler, EmailHandler>(_ => new EmailHandler(
    builder.Configuration["SmtpService:Server"],
    int.Parse(builder.Configuration["SmtpService:Port"]),
    builder.Configuration["SmtpService:FromEmailAddress"]
    ));

//Add repositories to container
builder.Services.AddScoped<IUniversityRepository, UniversityRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountRoleRepository, AccountRoleRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IEducationRepository, EducationRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

builder.Services.AddControllers()
       .ConfigureApiBehaviorOptions(options =>
        {
    // Custom validation response
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(v => v.ErrorMessage);

        return new BadRequestObjectResult(new ResponseValidatorHandler(errors));
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add FluentValidation Services
builder.Services.AddFluentValidationAutoValidation()
       .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

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