using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;
using Infrastructure.Dal.Repositories;
using LemonChefApi.Identity;
using LemonChefApi.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace LemonChefApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
            options.Password.RequireLowercase = true;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.SignIn.RequireConfirmedAccount = false;
            options.User.RequireUniqueEmail = true;
        });

        builder.Services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "ExamApi", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection(nameof(EmailSettings)));

        builder.Services.AddTransient<IIngredientService, IngredientService>();
        builder.Services.AddTransient<IRepository<Ingredient>, IngredientRepository>();

        builder.Services.AddTransient<ICommentFileService, CommentFileService>();
        builder.Services.AddTransient<IRepository<CommentFile>, CommentFileRepository>();

        builder.Services.AddTransient<IIngredientFileService, IngredientFileService>();
        builder.Services.AddTransient<IRepository<IngredientFile>, IngredientFileRepository>();

        builder.Services.AddTransient<IRecipeCommentLikeService, RecipeCommentLikeService>();
        builder.Services.AddTransient<IRepository<RecipeCommentLike>, RecipeCommentLikeRepository>();

        builder.Services.AddTransient<IRecipeCommentService, RecipeCommentService>();
        builder.Services.AddTransient<IRepository<RecipeComment>, RecipeCommentRepository>();

        builder.Services.AddTransient<IRecipeFileService, RecipeFileService>();
        builder.Services.AddTransient<IRepository<RecipeFile>, RecipeFileRepository>();

        builder.Services.AddTransient<IRecipeLikeService, RecipeLikeService>();
        builder.Services.AddTransient<IRepository<RecipeLike>, RecipeLikeRepository>();

        builder.Services.AddTransient<IRecipeService, RecipeService>();
        builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();

        builder.Services.AddTransient<IEmailSender, EmailSender>();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<RecipesDbContext>()
            .AddDefaultTokenProviders();


        builder.Services.AddDbContext<RecipesDbContext>
        (options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            .UseSnakeCaseNamingConvention());

        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapGroup("api/auth")
            .MapIdentityApi<User>();

        app.MapControllers();

        app.Run();
    }
}