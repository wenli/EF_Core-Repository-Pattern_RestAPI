using BrandApplication.Business.Mappings;
using BrandApplication.Business.Services.IServices;
using BrandApplication.Business.Services;
using BrandApplication.DataAccess;
using BrandApplication.DataAccess.Contexts; // Added for ShiDbContext
using BrandApplication.DataAccess.Interfaces;
using BrandApplication.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using BrandApplication.Business.Services.IServices.IServiceMappings;
using BrandApplication.Business.Services.Services; // For BtStrategyEntityService


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


///// Data Base Configuration
// builder.Services.AddScoped<BrandDbContext>();

// builder.Services.AddDbContext<BrandDbContext>(options =>
// {
//     options.UseSqlServer(
//         builder.Configuration.GetConnectionString("DefaultConnection"),
//         sqlServerOptionsAction: sqlOptions =>
//         {
//             sqlOptions.MigrationsAssembly("BrandApplication.DataAccess");
//         });
// });

// Shi DbContext Configuration
builder.Services.AddDbContext<ShiDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ShiConnection")));


//// AutoMapper Configuration
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Unit of Work specific to ShiDbContext
builder.Services.AddScoped<IUnitOfWork>(sp => new EFUnitOfWork(sp.GetRequiredService<ShiDbContext>()));

// Generic Repository (if to be used directly, ensure context is handled or it's used via UoW)
// If EFGenericRepository is resolved directly, it needs a DbContext.
// For BtStrategyService, it gets the repository from IUnitOfWork, which is already configured with ShiDbContext.
// So, this line makes IRepository<T> available if other services need it directly.
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFGenericRepository<>));

// Application Services
builder.Services.AddScoped<IBtStrategyService, BtStrategyEntityService>();

//// Generic Repository & Unit of Work
// builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); // Keep original commented if not used, or remove if replaced
// builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // Keep original commented if not used, or remove if replaced

//// Generic Services
// builder.Services.AddScoped(typeof(IReadServiceAsync<,>), typeof(ReadServiceAsync<,>));
// builder.Services.AddScoped(typeof(IGenericServiceAsync<,>), typeof(GenericServiceAsync<,>));

//////////////////////////////////// Services ////////////////////////////////////

// Asset Mappings
// builder.Services.AddScoped(typeof(IBrandService), typeof(BrandService));


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
