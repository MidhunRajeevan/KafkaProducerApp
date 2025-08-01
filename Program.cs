using Confluent.Kafka;
using kafkaproducerapp.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ProducerConfig>(builder.Configuration.GetSection("Kafka"));

builder.Services.AddSingleton<IProducer<string, string>>(sp =>
{
    var config = sp.GetRequiredService<IOptions<ProducerConfig>>().Value;
    return new ProducerBuilder<string, string>(config).Build();
});

builder.Services.AddScoped<IOrderService, OrderService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapControllers();
app.Run();