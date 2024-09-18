using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

//add CORS policy access : mo quyen truy cap api cho fe
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        //policy.WithOrigin("http://localhost:3000");
        policy.AllowAnyOrigin();
        //policy.WithMethods("POST");
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

//add AUTH JWT Bearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
        options =>
        {
            string key = "dawdwdsdw2wdadw2vx9809adsdf902asdawbvncm";
            string issuer = "T2305M_SEm3";
            string audience = "T2305M_ASPNET";
            int lifeTime = 360;

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };
        }
);
//add auhtozire policy
builder.Services.AddAuthorization(options =>
{
    //options.AddPolicy("ADMIN", policy => policy.RequireClaim(Cl));
    options.AddPolicy("AUTH", policy => policy.RequireClaim(ClaimTypes.NameIdentifier));
});

//connect db
Rapid_Rescue.Entities.RapidRescueDbContext.ConnectionString = builder.Configuration.GetConnectionString("RapidRescue_API");
builder.Services.AddDbContext<Rapid_Rescue.Entities.RapidRescueDbContext>(
    options => options.UseSqlServer(Rapid_Rescue.Entities.RapidRescueDbContext.ConnectionString)
);



builder.Services.AddControllers();
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

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
