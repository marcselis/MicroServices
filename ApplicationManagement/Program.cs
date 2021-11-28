using Microsoft.EntityFrameworkCore;
using ApplicationsService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("Applications"));
builder.Services.AddScoped<IApplicationsRepo, ApplicationsRepo>();
builder.Services.AddControllers();
builder.Services.AddGrpc();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGrpcService<ApplicationManagement.Services.ApplicationsService>();
app.MapGet("protos/applications.proto", async context =>
{
  await context.Response.WriteAsync(File.ReadAllText("Protos/Applications.proto"));
});

SetupDb.Prepare(app);

app.Run();
