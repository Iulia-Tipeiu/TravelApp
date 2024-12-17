using FluentValidation;
using Microsoft.Extensions.Options;
using TravelAPI.Models.Requests;
using TravelAPI.Models.Validators;
using TravelAPI.Models;
using TravelAPI.Services;
using TravelAPI.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection(nameof(MongoDBSettings)));
builder.Services.AddSingleton<MongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);
builder.Services.AddSingleton<TripService>();

builder.Services.AddScoped<IValidator<TripNote>, TripNoteValidator>();
builder.Services.AddScoped<IValidator<UpdateTripNoteRequest>, UpdateTripNoteRequestValidator>();
builder.Services.AddScoped<IValidator<GetTripNoteRequest>, GetTripNoteRequestValidator>();
builder.Services.AddScoped<IValidator<CreateTripNoteRequest>, CreateTripNoteRequestValidator>();
builder.Services.AddScoped<IValidator<DeleteTripNoteRequest>, DeleteTripNoteRequestValidator>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200")
                .SetPreflightMaxAge(TimeSpan.FromSeconds(3600));
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
