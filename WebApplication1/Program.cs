using Business.Implements;
using Business.Interfaces;
using Data.Implements.BaseData;
using Data.Interface;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Utilities.Mappers.Profiles;

var builder = WebApplication.CreateBuilder(args);


// Add controllers
builder.Services.AddControllers();

// Register AutoMapper with explicit profiles
builder.Services.AddAutoMapper(typeof(StudentProfile), typeof(CourseProfile));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


// Add Swagger documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Sistema de Gestión", Version = "v1" });
});

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register generic repositories and business logic
builder.Services.AddScoped(typeof(IBaseModelData<>), typeof(BaseModelData<>));
builder.Services.AddScoped(typeof(IBaseBusiness<,>), typeof(BaseBusiness<,>));

// Register Student-specific services
builder.Services.AddScoped<IStudentData, StudentData>();
builder.Services.AddScoped<IStudentBusiness, StudentBusiness>();

// Register Course-specific services
builder.Services.AddScoped<ICourseData, CourseData>();
builder.Services.AddScoped<ICourseBusiness, CourseBusiness>();

// Register Tuition-specific services
builder.Services.AddScoped<ITuitionData, TuitionData>();
builder.Services.AddScoped<ITuitionBusiness, TuitionBusiness>();

// Configure CORS
var origenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(";");
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(optionsCORS =>
    {
        optionsCORS.WithOrigins(origenesPermitidos)
                   .AllowAnyMethod()
                   .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Sistema de Gestión v1");
        c.RoutePrefix = string.Empty;
    });
}

// Enable CORS
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Initialize database and apply migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
        logger.LogInformation("Migraciones aplicadas exitosamente en ApplicationDbContext.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error al aplicar migraciones en ApplicationDbContext.");
    }
}

app.Run();
