using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SicopataSchool.API.IoC;
using SicopataSchool.Bl.IoC;
using SicopataSchool.Core.IoC;
using SicopataSchool.Model.Contexts.SicopataSchool;
using SicopataSchool.Model.Entities;
using SicopataSchool.Model.IoC;
using SicopataSchool.Services.IoC;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.GetConfigurationSections(builder.Configuration);
builder.Services.AddApiRegistry();
builder.Services.AddServicesRegistry();
builder.Services.AddBlRegistry(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddModelRegistry();
builder.Services.AddCoreRegistry();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
builder.Services.AddCors(op =>
{
    op.AddPolicy("AllowPolicy", builder =>
    {
        builder.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
        builder.SetIsOriginAllowed(x => true);
    });
});

string myAppDbContextConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SicopataSchoolDbContext>(op => op.UseSqlServer(myAppDbContextConnection),
    ServiceLifetime.Transient);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.EnableEndpointRouting = false;
}).AddFluentValidation().AddOData(opt => opt.Expand().Select().Count().SetMaxTop(25).Filter().OrderBy()).AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    swagger =>
    {
        //This is to generate the Default UI of Swagger Documentation  
        swagger.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "JWT Token Authentication API",
            Description = "Sicopata School Auth"
        });
        // To Enable authorization using Swagger (JWT)  
        swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
        });
        swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
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

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = false,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});

var app = builder.Build();

/// Wrong
//string myAppDbContextConnection = app.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<NotasWorkshopDbContext>(op => op.UseSqlServer(myAppDbContextConnection),
//    ServiceLifetime.Transient);
/// 

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
