using data.Infrastructure;
using core.Infrastructure;
using wash_back.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddWebApiServices(builder.Configuration);
builder.Services.AddCoreServices();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseCors("AllowMobileApp");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
