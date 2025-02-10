using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BO;

public partial class PhonesManagementContext : DbContext
{
    public PhonesManagementContext()
    {
    }

    public PhonesManagementContext(DbContextOptions<PhonesManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCart> TblCarts { get; set; }

    public virtual DbSet<TblInvDetail> TblInvDetails { get; set; }

    public virtual DbSet<TblInvoice> TblInvoices { get; set; }

    public virtual DbSet<TblMobile> TblMobiles { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblWishlist> TblWishlists { get; set; }

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

        return strConn;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCart>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.MobileId }).HasName("PK tbl_Cart");

            entity.ToTable("tbl_Cart");

            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasColumnName("userId");
            entity.Property(e => e.MobileId)
                .HasMaxLength(10)
                .HasColumnName("mobileId");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.Images).HasColumnName("images");
            entity.Property(e => e.MobileName)
                .HasMaxLength(20)
                .HasColumnName("mobileName");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.YearOfProduction).HasColumnName("yearOfProduction");
        });

        modelBuilder.Entity<TblInvDetail>(entity =>
        {
            entity.HasKey(e => new { e.InvId, e.UserId, e.MobileId }).HasName("PK tbl_InvDetails");

            entity.ToTable("tbl_InvDetails");

            entity.Property(e => e.InvId)
                .HasMaxLength(50)
                .HasColumnName("invId");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("userID");
            entity.Property(e => e.MobileId)
                .HasMaxLength(10)
                .HasColumnName("mobileId");
            entity.Property(e => e.MobileName)
                .HasMaxLength(20)
                .HasColumnName("mobileName");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Total).HasColumnName("total");
        });

        modelBuilder.Entity<TblInvoice>(entity =>
        {
            entity.HasKey(e => e.InvId).HasName("PK tbl_Invoice");

            entity.ToTable("tbl_Invoice");

            entity.Property(e => e.InvId)
                .HasMaxLength(50)
                .HasColumnName("invId");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.DateBuy)
                .HasColumnType("datetime")
                .HasColumnName("dateBuy");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("userID");
        });

        modelBuilder.Entity<TblMobile>(entity =>
        {
            entity.HasKey(e => e.MobileId);

            entity.ToTable("tbl_Mobile");

            entity.Property(e => e.MobileId)
                .HasMaxLength(10)
                .HasColumnName("mobileId");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.Images).HasColumnName("images");
            entity.Property(e => e.MobileName)
                .HasMaxLength(20)
                .HasColumnName("mobileName");
            entity.Property(e => e.NotSale).HasColumnName("notSale");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.YearOfProduction).HasColumnName("yearOfProduction");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("tbl_Users");

            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasColumnName("userId");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("fullName");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
        });

        modelBuilder.Entity<TblWishlist>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.MobileId }).HasName("PK tbl_Wishlist");

            entity.ToTable("tbl_Wishlist");

            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasColumnName("userId");
            entity.Property(e => e.MobileId)
                .HasMaxLength(10)
                .HasColumnName("mobileId");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.Images).HasColumnName("images");
            entity.Property(e => e.MobileName)
                .HasMaxLength(20)
                .HasColumnName("mobileName");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.YearOfProduction).HasColumnName("yearOfProduction");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
