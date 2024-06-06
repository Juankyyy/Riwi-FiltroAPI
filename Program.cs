using Microsoft.EntityFrameworkCore;
using FiltroApi.Data;
using FiltroApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Servicio de los controladores
builder.Services.AddControllers();

// Cors
builder.Services.AddCors(options=>{
    options.AddPolicy("AllowAnyOrigin",builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

// Config DB
builder.Services.AddDbContext<FiltroApiContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("FiltroApiConnection"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

// Scopes de cada Repository
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

var app = builder.Build();

// Cors
app.UseCors("AllowAnyOrigin");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapear Controladores
app.MapControllers();

app.Run();