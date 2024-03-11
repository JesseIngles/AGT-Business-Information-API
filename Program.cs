using CrudEmpresas.DAL.CRepository;
using CrudEmpresas.DAL.Database;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<MyDbContext>();
builder.Services.AddTransient<IEmpresa, CEmpresa>();
builder.Services.AddTransient<IAgente, CAgente>();
builder.Services.AddTransient<IFuncionario, CFuncionario>();
builer.Services.AddTransient<IRegime, CRegime>();
builer.Services.AddTransient<ICargo, CCargo>();
builder.Services.AddTransient<IRegime, CRegime>();
builder.Services.AddTransient<ISectorEconomico, CSectorEconomico>();
builder.Services.AddTransient<ITipoEmpresa, CTipoEmpresa>();
builder.Services.AddTransient<IAtividadeEconomica, CAtividadeEconomica>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUD_EMPRESAS", Version = "v1" });
    // Adicionar o campo para inserir o token
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
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
/*builder.Services.AddAuthorization(
    options =>
    {
        options.AddPolicy("RequiredClaims", policy =>
        {
            policy.RequireClaim("Senha");
        });
    }
);*/
app.MapControllers();

app.Run();
