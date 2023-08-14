using Kino.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kino.Infrastructure.Data;

public partial class KinoContext : DbContext
{
    public KinoContext(DbContextOptions<KinoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Keyword> Keywords { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LanguageRole> LanguageRoles { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieCast> MovieCasts { get; set; }

    public virtual DbSet<MovieCrew> MovieCrews { get; set; }

    public virtual DbSet<MovieLanguage> MovieLanguages { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<ProductionCompany> ProductionCompanies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("country_pkey");

            entity.ToTable("country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryIsoCode).HasColumnName("country_iso_code");
            entity.Property(e => e.CountryName).HasColumnName("country_name");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("department_pkey");

            entity.ToTable("department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartmentName).HasColumnName("department_name");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("gender_pkey");

            entity.ToTable("gender");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Gender1).HasColumnName("gender");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genre_pkey");

            entity.ToTable("genre");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GenreName).HasColumnName("genre_name");
        });

        modelBuilder.Entity<Keyword>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("keyword_pkey");

            entity.ToTable("keyword");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KeywordName).HasColumnName("keyword_name");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("language_pkey");

            entity.ToTable("language");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LanguageCode).HasColumnName("language_code");
            entity.Property(e => e.LanguageName).HasColumnName("language_name");
        });

        modelBuilder.Entity<LanguageRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("language_role_pkey");

            entity.ToTable("language_role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LanguageRole1).HasColumnName("language_role");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movie_pkey");

            entity.ToTable("movie");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AgeRating).HasColumnName("age_rating");
            entity.Property(e => e.Budget).HasColumnName("budget");
            entity.Property(e => e.MediaSource).HasColumnName("media_source");
            entity.Property(e => e.MovieStatus).HasColumnName("movie_status");
            entity.Property(e => e.Overview).HasColumnName("overview");
            entity.Property(e => e.Popularity).HasColumnName("popularity");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.Revenue).HasColumnName("revenue");
            entity.Property(e => e.Runtime).HasColumnName("runtime");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.VoteAverage)
                .HasPrecision(3, 1)
                .HasColumnName("vote_average");
            entity.Property(e => e.VoteCount).HasColumnName("vote_count");

            entity.HasMany(d => d.Companies).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieCompany",
                    r => r.HasOne<ProductionCompany>().WithMany()
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("movie_company_company_id_fkey"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .HasConstraintName("movie_company_movie_id_fkey"),
                    j =>
                    {
                        j.HasKey("MovieId", "CompanyId").HasName("movie_company_pkey");
                        j.ToTable("movie_company");
                        j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                        j.IndexerProperty<int>("CompanyId").HasColumnName("company_id");
                    });

            entity.HasMany(d => d.Countries).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductionCountry",
                    r => r.HasOne<Country>().WithMany()
                        .HasForeignKey("CountryId")
                        .HasConstraintName("production_country_country_id_fkey"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .HasConstraintName("production_country_movie_id_fkey"),
                    j =>
                    {
                        j.HasKey("MovieId", "CountryId").HasName("production_country_pkey");
                        j.ToTable("production_country");
                        j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                        j.IndexerProperty<int>("CountryId").HasColumnName("country_id");
                    });

            entity.HasMany(d => d.Genres).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieGenre",
                    r => r.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .HasConstraintName("movie_genres_genre_id_fkey"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .HasConstraintName("movie_genres_movie_id_fkey"),
                    j =>
                    {
                        j.HasKey("MovieId", "GenreId").HasName("movie_genres_pkey");
                        j.ToTable("movie_genres");
                        j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                        j.IndexerProperty<int>("GenreId").HasColumnName("genre_id");
                    });

            entity.HasMany(d => d.Keywords).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieKeyword",
                    r => r.HasOne<Keyword>().WithMany()
                        .HasForeignKey("KeywordId")
                        .HasConstraintName("movie_keywords_keyword_id_fkey"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .HasConstraintName("movie_keywords_movie_id_fkey"),
                    j =>
                    {
                        j.HasKey("MovieId", "KeywordId").HasName("movie_keywords_pkey");
                        j.ToTable("movie_keywords");
                        j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                        j.IndexerProperty<int>("KeywordId").HasColumnName("keyword_id");
                    });
        });

        modelBuilder.Entity<MovieCast>(entity =>
        {
            entity.HasKey(e => new { e.MovieId, e.PersonId, e.GenderId }).HasName("movie_cast_pkey");

            entity.ToTable("movie_cast");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.CastOrder).HasColumnName("cast_order");
            entity.Property(e => e.CharacterName).HasColumnName("character_name");

            entity.HasOne(d => d.Gender).WithMany(p => p.MovieCasts)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("movie_cast_gender_id_fkey");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieCasts)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("movie_cast_movie_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.MovieCasts)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("movie_cast_person_id_fkey");
        });

        modelBuilder.Entity<MovieCrew>(entity =>
        {
            entity.HasKey(e => new { e.MovieId, e.PersonId, e.DepartmentId }).HasName("movie_crew_pkey");

            entity.ToTable("movie_crew");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");

            entity.HasOne(d => d.Department).WithMany(p => p.MovieCrews)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("movie_crew_department_id_fkey");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieCrews)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("movie_crew_movie_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.MovieCrews)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("movie_crew_person_id_fkey");
        });

        modelBuilder.Entity<MovieLanguage>(entity =>
        {
            entity.HasKey(e => new { e.MovieId, e.LanguageId, e.LanguageRoleId }).HasName("movie_languages_pkey");

            entity.ToTable("movie_languages");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.LanguageRoleId).HasColumnName("language_role_id");

            entity.HasOne(d => d.Language).WithMany(p => p.MovieLanguages)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("movie_languages_language_id_fkey");

            entity.HasOne(d => d.LanguageRole).WithMany(p => p.MovieLanguages)
                .HasForeignKey(d => d.LanguageRoleId)
                .HasConstraintName("movie_languages_language_role_id_fkey");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieLanguages)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("movie_languages_movie_id_fkey");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("person_pkey");

            entity.ToTable("person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PersonName).HasColumnName("person_name");
        });

        modelBuilder.Entity<ProductionCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("production_company_pkey");

            entity.ToTable("production_company");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyName).HasColumnName("company_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
