using CalculoInvestimento.Domain.Service;
using CalculoInvestimento.Domain.Strategy;
using CalculoInvestimento.WebApi.CalcularCdb;
using CalculoInvestimento.WebApi.Factory;
using CalculoInvestimento.WebApi.Options;
using CalculoInvestimento.WebApi.Service;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(Program).Assembly);
});

builder.Services.Configure<BancoTaxaCdbOptions>(builder.Configuration.GetSection("BancoTaxaCdbOptions"));

builder.Services.AddScoped<IImpostoStrategy, ImpostoCdbStrategy>();
builder.Services.AddScoped<ICalcularCdbStrategy, CalcularCdbStrategy>();
builder.Services.AddScoped<ICdbTaxaProvider, CdbTaxaConfigProvider>();
builder.Services.AddScoped<IInvestimentoFactory, InvestimentoFactory>();
builder.Services.AddScoped<CalcularCdbService>();
builder.Services.AddScoped<ICalcularCdbService>(sp =>
    new CalcularCdbCacheDecorator(
        sp.GetRequiredService<CalcularCdbService>(),
        sp.GetRequiredService<IMemoryCache>()));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CalcularCdbHandler).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Minimal API endpoint for CDB calculation
app.MapPost("/api/cdb/calcular", async Task<IResult> (CalcularCdbCommand command, IMediator mediator, CancellationToken cancellationToken) =>
{
    var validator = new CalcularCdbValidator();
    var validationResult = await validator.ValidateAsync(command, cancellationToken);
    if (!validationResult.IsValid)
        return Results.BadRequest(validationResult.Errors);

    var result = await mediator.Send(command);
    return Results.Ok(result);
})
.WithName("CalcularCdb");

app.Run();
