﻿// <auto-generated />
using System;
using Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RecipesDbContext))]
    partial class RecipesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Base.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<long>("LikeCount")
                        .HasColumnType("bigint")
                        .HasColumnName("like_count");

                    b.Property<DateTime?>("ModifiedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_on");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("character varying(10000)")
                        .HasColumnName("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("comment_type_discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)")
                        .HasColumnName("comment_type_discriminator");

                    b.HasKey("Id")
                        .HasName("pk_comments");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_comments_user_id");

                    b.ToTable("comments", (string)null);

                    b.HasDiscriminator<string>("comment_type_discriminator").HasValue("Comment");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Base.LemonChefFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<long?>("Duration")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("duration");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Duration"));

                    b.Property<int>("FileFormat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("file_format");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FileFormat"));

                    b.Property<string>("FileName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("file_name");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("file_path");

                    b.Property<int>("FileSizeInBytes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("file_size_in_bytes");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FileSizeInBytes"));

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("file_type_discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)")
                        .HasColumnName("file_type_discriminator");

                    b.HasKey("Id")
                        .HasName("pk_files");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_files_user_id");

                    b.ToTable("files", (string)null);

                    b.HasDiscriminator<string>("file_type_discriminator").HasValue("LemonChefFile");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Base.Like", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("like_type_discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)")
                        .HasColumnName("like_type_discriminator");

                    b.HasKey("Id")
                        .HasName("pk_likes");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_likes_user_id");

                    b.ToTable("likes", (string)null);

                    b.HasDiscriminator<string>("like_type_discriminator").HasValue("Like");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<DateTime?>("ModifiedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_on");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid")
                        .HasColumnName("recipe_id");

                    b.Property<int?>("Unit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("unit");

                    b.HasKey("Id")
                        .HasName("pk_ingredients");

                    b.HasIndex("RecipeId")
                        .HasDatabaseName("ix_ingredients_recipe_id");

                    b.ToTable("ingredients", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<long>("CommentCount")
                        .HasColumnType("bigint")
                        .HasColumnName("comment_count");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<long>("LikeCount")
                        .HasColumnType("bigint")
                        .HasColumnName("like_count");

                    b.Property<string>("Link")
                        .HasColumnType("text")
                        .HasColumnName("link");

                    b.Property<DateTime?>("ModifiedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_on");

                    b.Property<int?>("PreparationTime")
                        .HasColumnType("integer")
                        .HasColumnName("preparation_time");

                    b.Property<int?>("Servings")
                        .HasColumnType("integer")
                        .HasColumnName("servings");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<long>("ViewCount")
                        .HasColumnType("bigint")
                        .HasColumnName("view_count");

                    b.HasKey("Id")
                        .HasName("pk_recipes");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_recipes_user_id");

                    b.HasIndex("PreparationTime", "Servings", "Title", "Link", "Description")
                        .IsUnique()
                        .HasDatabaseName("ix_recipes_preparation_time_servings_title_link_description");

                    b.ToTable("recipes", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end");

                    b.Property<DateTime?>("ModifiedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_on");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("user_name");

                    b.Property<long>("ViewCount")
                        .HasColumnType("bigint")
                        .HasColumnName("view_count");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_role_claims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_role_claims_role_id");

                    b.ToTable("roleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_claims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_claims_user_id");

                    b.ToTable("userClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_user_logins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_logins_user_id");

                    b.ToTable("userLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_user_roles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_user_roles_role_id");

                    b.ToTable("userRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_user_tokens");

                    b.ToTable("userTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RecipeComment", b =>
                {
                    b.HasBaseType("Domain.Entities.Base.Comment");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid")
                        .HasColumnName("recipe_id");

                    b.HasIndex("RecipeId")
                        .HasDatabaseName("ix_comments_recipe_id");

                    b.ToTable("comments", (string)null);

                    b.HasDiscriminator().HasValue("RecipeComment");
                });

            modelBuilder.Entity("Domain.Entities.CommentFile", b =>
                {
                    b.HasBaseType("Domain.Entities.Base.LemonChefFile");

                    b.Property<Guid>("CommentId")
                        .HasColumnType("uuid")
                        .HasColumnName("comment_id");

                    b.HasIndex("CommentId")
                        .HasDatabaseName("ix_files_comment_id");

                    b.ToTable("files", (string)null);

                    b.HasDiscriminator().HasValue("CommentFile");
                });

            modelBuilder.Entity("Domain.Entities.IngredientFile", b =>
                {
                    b.HasBaseType("Domain.Entities.Base.LemonChefFile");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uuid")
                        .HasColumnName("ingredient_id");

                    b.HasIndex("IngredientId")
                        .HasDatabaseName("ix_files_ingredient_id");

                    b.ToTable("files", (string)null);

                    b.HasDiscriminator().HasValue("IngredientFile");
                });

            modelBuilder.Entity("Domain.Entities.RecipeFile", b =>
                {
                    b.HasBaseType("Domain.Entities.Base.LemonChefFile");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid")
                        .HasColumnName("recipe_id");

                    b.HasIndex("RecipeId")
                        .HasDatabaseName("ix_files_recipe_id");

                    b.ToTable("files", (string)null);

                    b.HasDiscriminator().HasValue("RecipeFile");
                });

            modelBuilder.Entity("Domain.Entities.CommentLike", b =>
                {
                    b.HasBaseType("Domain.Entities.Base.Like");

                    b.Property<Guid>("CommentId")
                        .HasColumnType("uuid")
                        .HasColumnName("comment_id");

                    b.HasIndex("CommentId")
                        .HasDatabaseName("ix_likes_comment_id");

                    b.ToTable("likes", (string)null);

                    b.HasDiscriminator().HasValue("CommentLike");
                });

            modelBuilder.Entity("Domain.Entities.RecipeLike", b =>
                {
                    b.HasBaseType("Domain.Entities.Base.Like");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid")
                        .HasColumnName("recipe_id");

                    b.HasIndex("RecipeId")
                        .HasDatabaseName("ix_likes_recipe_id");

                    b.HasIndex("UserId", "RecipeId")
                        .IsUnique()
                        .HasDatabaseName("ix_likes_user_id_recipe_id");

                    b.ToTable("likes", (string)null);

                    b.HasDiscriminator().HasValue("RecipeLike");
                });

            modelBuilder.Entity("Domain.Entities.RecipeCommentLike", b =>
                {
                    b.HasBaseType("Domain.Entities.CommentLike");

                    b.Property<Guid>("RecipeCommentId")
                        .HasColumnType("uuid")
                        .HasColumnName("recipe_comment_id");

                    b.HasIndex("RecipeCommentId")
                        .HasDatabaseName("ix_likes_recipe_comment_id");

                    b.HasIndex("UserId", "RecipeCommentId")
                        .IsUnique()
                        .HasDatabaseName("ix_likes_user_id_recipe_comment_id");

                    b.ToTable("likes", (string)null);

                    b.HasDiscriminator().HasValue("RecipeCommentLike");
                });

            modelBuilder.Entity("Domain.Entities.Base.Comment", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_comments_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Base.LemonChefFile", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserFiles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_files_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Base.Like", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_likes_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Ingredient", b =>
                {
                    b.HasOne("Domain.Entities.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_ingredients_recipes_recipe_id");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Domain.Entities.Recipe", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_recipes_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_claims_asp_net_roles_role_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_claims_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_logins_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_roles_roles_role_id");

                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_roles_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_tokens_asp_net_users_user_id");
                });

            modelBuilder.Entity("Domain.Entities.RecipeComment", b =>
                {
                    b.HasOne("Domain.Entities.Recipe", "Recipe")
                        .WithMany("Comments")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_comments_recipes_recipe_id");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Domain.Entities.CommentFile", b =>
                {
                    b.HasOne("Domain.Entities.Base.Comment", "Comment")
                        .WithMany("Files")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_files_comments_comment_id");

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("Domain.Entities.IngredientFile", b =>
                {
                    b.HasOne("Domain.Entities.Ingredient", "Ingredient")
                        .WithMany("Files")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_files_ingredients_ingredient_id");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Domain.Entities.RecipeFile", b =>
                {
                    b.HasOne("Domain.Entities.Recipe", "Recipe")
                        .WithMany("Files")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_files_recipes_recipe_id");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Domain.Entities.CommentLike", b =>
                {
                    b.HasOne("Domain.Entities.Base.Comment", "Comment")
                        .WithMany("Likes")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_likes_comments_comment_id");

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("Domain.Entities.RecipeLike", b =>
                {
                    b.HasOne("Domain.Entities.Recipe", "Recipe")
                        .WithMany("Likes")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_likes_recipes_recipe_id");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Domain.Entities.RecipeCommentLike", b =>
                {
                    b.HasOne("Domain.Entities.RecipeComment", "RecipeComment")
                        .WithMany("RecipeCommentLikes")
                        .HasForeignKey("RecipeCommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_likes_comments_recipe_comment_id");

                    b.Navigation("RecipeComment");
                });

            modelBuilder.Entity("Domain.Entities.Base.Comment", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("Domain.Entities.Ingredient", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("Domain.Entities.Recipe", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Files");

                    b.Navigation("Ingredients");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("Recipes");

                    b.Navigation("UserFiles");
                });

            modelBuilder.Entity("Domain.Entities.RecipeComment", b =>
                {
                    b.Navigation("RecipeCommentLikes");
                });
#pragma warning restore 612, 618
        }
    }
}
