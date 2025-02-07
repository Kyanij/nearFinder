using Microsoft.EntityFrameworkCore;
using NearFinder.Persistance;
using System.Reflection;
using System.Runtime.ConstrainedExecution;


Assembly[] applicationAssembliesFromOtherProject = { typeof(NearFinder.Messaging.Location.UserLocationHandler).Assembly,
                                                    };


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(
       o =>
       {
           o.RegisterServicesFromAssemblies(applicationAssembliesFromOtherProject);
       }
   );

builder.Services.AddDbContextFactory<NearFinderDbContext>(
    o =>
    {
        o.UseNpgsql(builder.Configuration.GetConnectionString("NearFinder"), b => b.MigrationsAssembly("NearFinder"))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .EnableSensitiveDataLogging(false);
    }
    );
     

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
