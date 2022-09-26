using Dapper.CRUD.Data;
using Dapper.CRUD.Data.DAL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AlbumDataAccessLayer>();
builder.Services.AddScoped<ArtistDataAccessLayer>();
builder.Services.AddScoped<GenreDataAccessLayer>();
builder.Services.AddScoped<MediaTypeDataAccessLayer>();
builder.Services.AddScoped<PlayListDataAccessLayer>();
builder.Services.AddScoped<TrackDataAccessLayer>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<AlbumDataAdaptor>();
builder.Services.AddScoped<ArtistDataAdaptor>();
builder.Services.AddScoped<GenreDataAdaptor>();
builder.Services.AddScoped<MediaTypeDataAdaptor>();
builder.Services.AddScoped<PlayListDataAdaptor>();
builder.Services.AddScoped<TrackDataAdaptor>();

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
