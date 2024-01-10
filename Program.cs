using API.Entities;
using API.Models;
using API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowSpecificOrigin",
        builder =>
            builder
                .WithOrigins("http://localhost:5233") // Adicione aqui o endereço do seu aplicativo Blazor
                .AllowAnyMethod()
                .AllowAnyHeader()
    );
});

builder.Services.AddDbContext<BdContext>();
builder.Services.AddScoped<IDetalhesServices, Detalhes>();
builder.Services.AddScoped<ITipoFinanciamentoServices, TiposFinanciamentos>();
builder.Services.AddScoped<ITipoFinanciadorServices, TiposFinanciadores>();
builder.Services.AddScoped<IVerificacoesServices, Verificacoes>();
builder.Services.AddScoped<ITiposProjectoServices, TiposProjectos>();
builder.Services.AddScoped<IRealizadorServices, Realizadores>();
builder.Services.AddScoped<IFinanciamentoProjectoServices, Financiamentos>();
builder.Services.AddScoped<IFinanciadorServices, Financiadores>();
builder.Services.AddScoped<IContaServices, Contas>();
builder.Services.AddScoped<IProjectoServices, Projectos>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
