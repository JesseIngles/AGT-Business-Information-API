using System.Text;
using CrudEmpresas.DAL.CRepository;
using CrudEmpresas.DAL.Database;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
//var key = Encoding.ASCII.GetBytes("tngcaixeilmcpnyzkkvowbzhgckdgmlapitltvfmmhoenpbeuwnzqzeyhzbgraucbbndvqnnaixbqsykhefdmvlkvgxfshlexzdaggrxxcvwbvscobwvwsrjsdtaaqxx");

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
// Add services to the container.
builder.Services.AddTransient<MyDbContext>();
builder.Services.AddTransient<IEmpresa, CEmpresa>();
builder.Services.AddTransient<IAgente, CAgente>();
builder.Services.AddTransient<IFuncionario, CFuncionario>();
builder.Services.AddTransient<IRegime, CRegime>();
builder.Services.AddTransient<ISectorEconomico, CSectorEconomico>();
builder.Services.AddTransient<ITipoEmpresa, CTipoEmpresa>();
builder.Services.AddTransient<IAtividadeEconomica, CAtividadeEconomica>();
builder.Services.AddTransient<IEndereco, CEndereco>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUD_EMPRESAS", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Adicionar a autorização ao cabeçalho
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
                (System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddCors(
    options => options.AddPolicy("BackOfficeAgentes",
        builder =>
        {
            builder
               .AllowAnyHeader()
               .AllowAnyMethod()
               .SetIsOriginAllowed(origin => true)
               .AllowCredentials();
        })
);
builder.Services.AddAuthorization(
    options =>
    {
        options.AddPolicy("SerAgente", policy =>
        {
            policy.RequireClaim("Senha");
        });
        options.AddPolicy("SerAgenteAdmin", policy =>
        {
            policy.RequireClaim("IsAdmin");
        });
    }
);
var app = builder.Build();
app.UseCors("BackOfficeAgentes");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
