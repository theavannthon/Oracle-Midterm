using Microsoft.EntityFrameworkCore;
using OracleProjectMiedterm.Data;
using OracleProjectMiedterm.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICustomerService, CustomerServiceImp>();
var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<EntityContext>(options =>
{
    options.UseSqlServer(connectionString);
});


var app = builder.Build();


app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();
