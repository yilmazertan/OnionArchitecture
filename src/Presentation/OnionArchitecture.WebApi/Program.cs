using FluentValidation;
using FluentValidation.AspNetCore;
using OnionArchitecture.Application;
using OnionArchitecture.Application.Validator.Product;
using OnionArchitecture.Persistance;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(v => v.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>());
       // .ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);

 


//builder.Services.AddControllersWithViews().AddFluentValidation(fv =>
//{
//    fv.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>();
//});


//builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>());

//builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
////// or
//services.AddValidatorsFromAssemblyContaining(typeof(SomeValidator));
//// or
//services.AddValidatorsFromAssembly(typeof(SomeValidator).Assembly);



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

#region Service Registration
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
#endregion



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
