using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MVC.Filters;
using MVC.Middleware;
using MVC.Models;
using MVC.Repositories.Implementations;
using MVC.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);


//  controllers
builder.Services.AddControllersWithViews();

// Roles ristrictions 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        //in case of no login
        options.LoginPath = "/Account/Login";

        // when access role denied 
        options.AccessDeniedPath = "/Shared/AccessDenied"; 
    });

//  DbContext
builder.Services.AddDbContext<ITIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  repositories
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

// add a session
builder.Services.AddSession();

// order is important 


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

//  session middleware
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
