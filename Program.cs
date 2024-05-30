using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.Citas;
using Services.Email;
using Services.Login;
using Services.MyDbContext;
using Services.Pacientes;
using Services.Rols;
using Services.Sucursales;
using Services.TipoCitas;
using Services.Users;
using System.Text;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MyContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Development"));

});

builder.Services.AddTransient<ISvEmail, SvEmail>();
builder.Services.Configure<GmailSettings>(builder.Configuration.GetSection("GmailSettings"));

builder.Services.AddScoped<ISvLogin, SvLogin>();
builder.Services.AddScoped<ISvPaciente, PacienteService>(); 
builder.Services.AddScoped<ISvCita, CitaService>(); 
builder.Services.AddScoped<ISvSucursal, SucursalService>(); 
builder.Services.AddScoped<ISvUser, UserService>(); 
builder.Services.AddScoped<ISvRol, RolService>(); 
builder.Services.AddScoped<ISvTipoCita, TipoCitaService>();


builder.Services.AddAuthentication("Bearer").AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]!)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});



builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Admin", policy => policy.RequireRole("Admin"))
    .AddPolicy("User", policy => policy.RequireRole("User"));



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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
