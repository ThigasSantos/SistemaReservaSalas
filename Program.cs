using SistemaReservaSalas.Data;
using Microsoft.EntityFrameworkCore;
using SistemaReservaSalas.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<StateContainer>();
builder.Services.AddDbContext<SalaDbContext>
(options =>{
options.UseSqlite("Data Source=Salas.db");
});
builder.Services.AddScoped<SalaServices>();
builder.Services.AddDbContext<UserDbContext>
(options =>{
options.UseSqlite("Data Source=Users.db");
});
builder.Services.AddScoped<UserServices>();
builder.Services.AddDbContext<ReservaDbContext>
(options =>{
options.UseSqlite("Data Source=Reserva.db");
});
builder.Services.AddScoped<ReservaServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
