using Microsoft.EntityFrameworkCore;
using UserRoleModel.DAL;
using UserRoleRespository.BLL.Abstract;
using UserRoleRespository.BLL.Concrete;
using UserRoleRespository.BLL.Mapper;
using UserRoleRespository.DAL.Abstract;
using UserRoleRespository.DAL.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("AppDb"));
});

builder.Services.AddAutoMapper(typeof(AutomapperProfiles));
builder.Services.AddScoped<IUserRepository, UserRepisotory>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();

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
