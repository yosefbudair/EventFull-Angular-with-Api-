using LearningHub.core.Common;
using LearningHub.Core.repository;
using LearningHub.Core.Services;
using LearningHub.infra.Common;
using LearningHub.Infra.repository;
using LearningHub.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(corsOptions =>
{
    corsOptions.AddPolicy("policy",
    builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});


builder.Services.AddScoped<IDbContext,DbContext>();

//--------------------------------------------------------------------- Repository -----------------------------------------------------------------------

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddScoped<IVisaRepository, VisaRepository>();
builder.Services.AddScoped<IUserReviewEventRepository, UserReviewEventRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IimageEventRepository, imageEventRepository>();
builder.Services.AddScoped<IRoleRepository , RoleRepository>();
builder.Services.AddScoped<IJWTRepository, JWTRepository>();
builder.Services.AddScoped<IHomeRepository, HomeRepository>();
builder.Services.AddScoped<IServicesRepository, ServicesRepository>();
builder.Services.AddScoped<IContactUsRepository, ContactUsRepository>();
builder.Services.AddScoped<IAboutUsRepository, AboutUsRepository>();

//--------------------------------------------------------------------- Service -----------------------------------------------------------------------

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITestimonialService,TestimonialService >();
builder.Services.AddScoped<IVisaService, VisaService>();
builder.Services.AddScoped<IUserReviewEventService, UserReviewEventService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IimageEventService, imageEventService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IServicesService, ServicesService>();
builder.Services.AddScoped<IContactUsService, ContactUsService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAboutUsService, AboutUsService>();


builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SECRET USED TO SIGN AND VERIFY JWT TOKEN"))
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

app.UseCors("policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
