using api.Data;
using api.IRepositories;
using api.Model;
using api.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<MyDbcontext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DBCS")));
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
// builder.Services.AddIdentity<AppUser, IdentityRole>(op => { op.Password.RequiredLength = 8; }).AddEntityFrameworkStores<MyDbcontext>();
// builder.Services.AddAuthentication(op =>
// {
//     op.DefaultAuthenticateScheme =
//     op.DefaultForbidScheme =
//     op.DefaultChallengeScheme =
//      op.DefaultSignInScheme =
//      op.DefaultScheme =
//      op.DefaultSignOutScheme =
//       JwtBearerDefaults.AuthenticationScheme;


// }).AddJwtBearer(op =>
// {
//     op.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidIssuer = builder.Configuration["JWT:Issuer"],
//         ValidateAudience = true,
//         ValidAudience = builder.Configuration["JWT:Audience"],
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(s: builder.Configuration["JWT:SigningKey"]))
//     };
// });

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();

