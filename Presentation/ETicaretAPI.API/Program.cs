using ETicaretAPI.Application.Validators.Products;
using ETicaretAPI.Persistance;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistanceServices();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));

//Fluent validation registry made !
builder.Services.AddControllers()
       .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
