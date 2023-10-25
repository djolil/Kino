using Kino.API.Options;
using Kino.Core.Interfaces.Repository;
using Kino.Core.Interfaces.Service;
using Kino.Infrastructure.Data;
using Kino.Infrastructure.Repositories;
using Kino.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<KinoContext>(
    options => options.UseNpgsql("name=ConnectionStrings:DefaultConnection"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["TokenSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["TokenSettings:Audience"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenSettings:PrivateKey"])),
            ValidateIssuerSigningKey = true
        };
    });
builder.Services.AddAuthorization();

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddScoped<IMovieCastRepository, MovieCastRepository>();
builder.Services.AddScoped<IMovieCastService, MovieCastService>();

builder.Services.AddScoped<IMovieCrewRepository, MovieCrewRepository>();
builder.Services.AddScoped<IMovieCrewService, MovieCrewService>();

builder.Services.AddScoped<IMovieLanguageRepository, MovieLanguageRepository>();
builder.Services.AddScoped<IMovieLanguageService, MovieLanguageService>();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddScoped<IKeywordRepository, KeywordRepository>();
builder.Services.AddScoped<IKeywordService, KeywordService>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ICryptoService, CryptoService>();

builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<ILanguageRoleRepository, LanguageRoleRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
