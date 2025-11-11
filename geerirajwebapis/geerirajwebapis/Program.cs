using geerirajwebapis.Context;
using geerirajwebapis.Repositories;
using geerirajwebapis.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);



// ✅ Increase max request body size for Kestrel (local web server)
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = long.MaxValue; // unlimited
});

// ✅ If using IIS Express, increase its limit too
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = int.MaxValue;
});

builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<IProductAsyncRepository,ProductAsyncRepository>();
builder.Services.AddSingleton<ICommanDropAsync,CommonDropAsync>();
builder.Services.AddSingleton<IUserRepositoryAsync,UserRepositoryAsync>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()    // Allow any origin (for testing)
            .AllowAnyHeader()
            .AllowAnyMethod());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
