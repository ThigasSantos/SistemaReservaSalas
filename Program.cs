using SistemaReservaSalas.Data;
using Microsoft.EntityFrameworkCore;
using SistemaReservaSalas.Shared;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<StateContainer>();
builder.Services.AddDbContext<SistemaDbContext>
(options =>{
options.UseSqlite("Data Source=Salas.db");
});
builder.Services.AddScoped<SalaServices>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<ReservaServices>();
builder.Services.AddScoped<ReservaSalaAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<ReservaSalaAuthenticationStateProvider>());

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
