using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MVC.Filters;
using MVC.Middleware;
using MVC.Models;
using MVC.Repositories.Implementations;
using MVC.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// ----------------------
// Add services to the container (ALL services must be added BEFORE Build)
// ----------------------

// Add controllers
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<ITIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repositories
builder.Services.AddScoped<IReadableRepository<Student>, StudentRepository>();
builder.Services.AddScoped<IWritableRepository<Student>, StudentRepository>();

builder.Services.AddScoped<IReadableRepository<Department>, DepartmentRepository>();
builder.Services.AddScoped<IWritableRepository<Department>, DepartmentRepository>();

builder.Services.AddScoped<IReadableRepository<Course>, CourseRepository>();
builder.Services.AddScoped<IWritableRepository<Course>, CourseRepository>();

builder.Services.AddScoped<IReadableRepository<Instructor>, InstructorRepository>();
builder.Services.AddScoped<IWritableRepository<Instructor>, InstructorRepository>();

builder.Services.AddScoped<IReadableRepository<CourseStudents>, CourseStudentsRepository>();
builder.Services.AddScoped<IWritableRepository<CourseStudents>, CourseStudentsRepository>();

//filter
builder.Services.AddScoped<AuthorizeStudentFilter>();

// Add Authentication (Cookie)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
    });

// Add Session
builder.Services.AddSession();

var app = builder.Build();

// ----------------------
// Configure the HTTP request pipeline
// ----------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Enable session middleware
app.UseSession();

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// Custom middleware
app.UseMiddleware<RequestLoggingMiddleware>();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
