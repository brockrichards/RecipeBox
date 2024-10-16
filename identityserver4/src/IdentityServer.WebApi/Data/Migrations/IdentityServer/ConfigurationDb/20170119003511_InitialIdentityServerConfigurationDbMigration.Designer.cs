using System;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.WebApi.Data.Migrations.IdentityServer.ConfigurationDb {
    [DbContext(typeof(ConfigurationDbContext))]
    [Migration("20170119003511_InitialIdentityServerConfigurationDbMigration")]
    partial class InitialIdentityServerConfigurationDbMigration {
        protected override void BuildTargetModel(ModelBuilder modelBuilder) {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResource", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Description")
                    .HasAnnotation("MaxLength", 1000);

                b.Property<string>("DisplayName")
                    .HasAnnotation("MaxLength", 200);

                b.Property<bool>("Enabled");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 200);

                b.HasKey("Id");

                b.HasIndex("Name")
                    .IsUnique();

                b.ToTable("ApiResources");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceClaim", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int?>("ApiResourceId")
                    .IsRequired();

                b.Property<string>("Type")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 200);

                b.HasKey("Id");

                b.HasIndex("ApiResourceId");

                b.ToTable("ApiClaims");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScope", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int?>("ApiResourceId")
                    .IsRequired();

                b.Property<string>("Description")
                    .HasAnnotation("MaxLength", 1000);

                b.Property<string>("DisplayName")
                    .HasAnnotation("MaxLength", 200);

                b.Property<bool>("Emphasize");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 200);

                b.Property<bool>("Required");

                b.Property<bool>("ShowInDiscoveryDocument");

                b.HasKey("Id");

                b.HasIndex("ApiResourceId");

                b.HasIndex("Name")
                    .IsUnique();

                b.ToTable("ApiScopes");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScopeClaim", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int?>("ApiScopeId")
                    .IsRequired();

                b.Property<string>("Type")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 200);

                b.HasKey("Id");

                b.HasIndex("ApiScopeId");

                b.ToTable("ApiScopeClaims");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiSecret", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int?>("ApiResourceId")
                    .IsRequired();

                b.Property<string>("Description")
                    .HasAnnotation("MaxLength", 1000);

                b.Property<DateTime?>("Expiration");

                b.Property<string>("Type")
                    .HasAnnotation("MaxLength", 250);

                b.Property<string>("Value")
                    .HasAnnotation("MaxLength", 2000);

                b.HasKey("Id");

                b.HasIndex("ApiResourceId");

                b.ToTable("ApiSecrets");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.Client", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int>("AbsoluteRefreshTokenLifetime");

                b.Property<int>("AccessTokenLifetime");

                b.Property<int>("AccessTokenType");

                b.Property<bool>("AllowAccessTokensViaBrowser");

                b.Property<bool>("AllowOfflineAccess");

                b.Property<bool>("AllowPlainTextPkce");

                b.Property<bool>("AllowRememberConsent");

                b.Property<bool>("AlwaysIncludeUserClaimsInIdToken");

                b.Property<bool>("AlwaysSendClientClaims");

                b.Property<int>("AuthorizationCodeLifetime");

                b.Property<string>("ClientId")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 200);

                b.Property<string>("ClientName")
                    .HasAnnotation("MaxLength", 200);

                b.Property<string>("ClientUri")
                    .HasAnnotation("MaxLength", 2000);

                b.Property<bool>("EnableLocalLogin");

                b.Property<bool>("Enabled");

                b.Property<int>("IdentityTokenLifetime");

                b.Property<bool>("IncludeJwtId");

                b.Property<string>("LogoUri");

                b.Property<bool>("LogoutSessionRequired");

                b.Property<string>("LogoutUri");

                b.Property<bool>("PrefixClientClaims");

                b.Property<string>("ProtocolType")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 200);

                b.Property<int>("RefreshTokenExpiration");

                b.Property<int>("RefreshTokenUsage");

                b.Property<bool>("RequireClientSecret");

                b.Property<bool>("RequireConsent");

                b.Property<bool>("RequirePkce");

                b.Property<int>("SlidingRefreshTokenLifetime");

                b.Property<bool>("UpdateAccessTokenClaimsOnRefresh");

                b.HasKey("Id");

                b.HasIndex("ClientId")
                    .IsUnique();

                b.ToTable("Clients");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientClaim", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int?>("ClientId")
                    .IsRequired();

                b.Property<string>("Type")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 250);

                b.Property<string>("Value")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 250);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientClaims");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientCorsOrigin", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int?>("ClientId")
                    .IsRequired();

                b.Property<string>("Origin")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 150);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientCorsOrigins");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientGrantType", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int?>("ClientId")
                    .IsRequired();

                b.Property<string>("GrantType")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 250);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientGrantTypes");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientIdPRestriction", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int?>("ClientId")
                    .IsRequired();

                b.Property<string>("Provider")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 200);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientIdPRestrictions");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientPostLogoutRedirectUri", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int?>("ClientId")
                    .IsRequired();

                b.Property<string>("PostLogoutRedirectUri")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 2000);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientPostLogoutRedirectUris");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientRedirectUri", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int?>("ClientId")
                    .IsRequired();

                b.Property<string>("RedirectUri")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 2000);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientRedirectUris");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientScope", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int?>("ClientId")
                    .IsRequired();

                b.Property<string>("Scope")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 200);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientScopes");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientSecret", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int?>("ClientId")
                    .IsRequired();

                b.Property<string>("Description")
                    .HasAnnotation("MaxLength", 2000);

                b.Property<DateTime?>("Expiration");

                b.Property<string>("Type")
                    .HasAnnotation("MaxLength", 250);

                b.Property<string>("Value")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 2000);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientSecrets");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityClaim", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int?>("IdentityResourceId")
                    .IsRequired();

                b.Property<string>("Type")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 200);

                b.HasKey("Id");

                b.HasIndex("IdentityResourceId");

                b.ToTable("IdentityClaims");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityResource", b => {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Description")
                    .HasAnnotation("MaxLength", 1000);

                b.Property<string>("DisplayName")
                    .HasAnnotation("MaxLength", 200);

                b.Property<bool>("Emphasize");

                b.Property<bool>("Enabled");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 200);

                b.Property<bool>("Required");

                b.Property<bool>("ShowInDiscoveryDocument");

                b.HasKey("Id");

                b.HasIndex("Name")
                    .IsUnique();

                b.ToTable("IdentityResources");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceClaim", b => {
                b.HasOne("IdentityServer4.EntityFramework.Entities.ApiResource", "ApiResource")
                    .WithMany("UserClaims")
                    .HasForeignKey("ApiResourceId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScope", b => {
                b.HasOne("IdentityServer4.EntityFramework.Entities.ApiResource", "ApiResource")
                    .WithMany("Scopes")
                    .HasForeignKey("ApiResourceId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScopeClaim", b => {
                b.HasOne("IdentityServer4.EntityFramework.Entities.ApiScope", "ApiScope")
                    .WithMany("UserClaims")
                    .HasForeignKey("ApiScopeId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiSecret", b => {
                b.HasOne("IdentityServer4.EntityFramework.Entities.ApiResource", "ApiResource")
                    .WithMany("Secrets")
                    .HasForeignKey("ApiResourceId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientClaim", b => {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("Claims")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientCorsOrigin", b => {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("AllowedCorsOrigins")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientGrantType", b => {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("AllowedGrantTypes")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientIdPRestriction", b => {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("IdentityProviderRestrictions")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientPostLogoutRedirectUri", b => {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("PostLogoutRedirectUris")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientRedirectUri", b => {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("RedirectUris")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientScope", b => {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("AllowedScopes")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientSecret", b => {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("ClientSecrets")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityClaim", b => {
                b.HasOne("IdentityServer4.EntityFramework.Entities.IdentityResource", "IdentityResource")
                    .WithMany("UserClaims")
                    .HasForeignKey("IdentityResourceId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

