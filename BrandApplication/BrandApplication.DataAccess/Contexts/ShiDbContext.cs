using System;
using System.Collections.Generic;
using BrandApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrandApplication.DataAccess.Contexts;

public partial class ShiDbContext : DbContext
{
    public ShiDbContext()
    {
    }

    public ShiDbContext(DbContextOptions<ShiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BtStrategy> BtStrategies { get; set; }

    public virtual DbSet<Future> Futures { get; set; }

    public virtual DbSet<Futures15k> Futures15ks { get; set; }

    public virtual DbSet<Futures1d> Futures1ds { get; set; }

    public virtual DbSet<Futures1k> Futures1ks { get; set; }

    public virtual DbSet<Futures30k> Futures30ks { get; set; }

    public virtual DbSet<Futures5k> Futures5ks { get; set; }

    public virtual DbSet<Futures60k> Futures60ks { get; set; }

    public virtual DbSet<SkStock> SkStocks { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Stocks15k> Stocks15ks { get; set; }

    public virtual DbSet<Stocks1d> Stocks1ds { get; set; }

    public virtual DbSet<Stocks1k> Stocks1ks { get; set; }

    public virtual DbSet<Stocks30k> Stocks30ks { get; set; }

    public virtual DbSet<Stocks5k> Stocks5ks { get; set; }

    public virtual DbSet<Stocks60k> Stocks60ks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BtStrategy>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("bt_strategy");

            entity.Property(e => e.Balance).HasColumnName("balance");
            entity.Property(e => e.Contract).HasColumnName("contract");
            entity.Property(e => e.DfTimeframe).HasColumnName("df_timeframe");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.RsDate).HasColumnName("rs_date");
            entity.Property(e => e.RsTimeframe).HasColumnName("rs_timeframe");
            entity.Property(e => e.SlAmount).HasColumnName("sl_amount");
            entity.Property(e => e.SlCount).HasColumnName("sl_count");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Strategy).HasColumnName("strategy");
            entity.Property(e => e.Symbol).HasColumnName("symbol");
            entity.Property(e => e.TpAmount).HasColumnName("tp_amount");
            entity.Property(e => e.TpCount).HasColumnName("tp_count");
            entity.Property(e => e.TranTotal).HasColumnName("tran_total");
            entity.Property(e => e.WinRate).HasColumnName("win_rate");
        });

        modelBuilder.Entity<Future>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("futures");

            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.DeliveryMonth).HasColumnName("delivery_month");
            entity.Property(e => e.LimitDown).HasColumnName("limit_down");
            entity.Property(e => e.LimitUp).HasColumnName("limit_up");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Reference).HasColumnName("reference");
            entity.Property(e => e.Symbol).HasColumnName("symbol");
            entity.Property(e => e.TargetCode).HasColumnName("target_code");
            entity.Property(e => e.UnderlyingCode).HasColumnName("underlying_code");
            entity.Property(e => e.UnderlyingKind).HasColumnName("underlying_kind");
            entity.Property(e => e.Unit).HasColumnName("unit");
            entity.Property(e => e.UpdateDate).HasColumnName("update_date");
        });

        modelBuilder.Entity<Futures15k>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("futures15k");

            entity.HasIndex(e => new { e.Code, e.Ts }, "index_f15k_codets");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Ts)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("ts");
        });

        modelBuilder.Entity<Futures1d>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("futures1d");

            entity.HasIndex(e => new { e.Code, e.Ts }, "index_f1d_codets");

            entity.Property(e => e.Bartypes).HasColumnName("bartypes");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Ts)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("ts");
            entity.Property(e => e.ValidDate).HasColumnType("TIMESTAMP");
        });

        modelBuilder.Entity<Futures1k>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("futures1k");

            entity.HasIndex(e => new { e.Ts, e.Code }, "ix_stocks1k");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Ts)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("ts");
        });

        modelBuilder.Entity<Futures30k>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("futures30k");

            entity.HasIndex(e => new { e.Code, e.Ts }, "index_f30k_codets");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Ts)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("ts");
        });

        modelBuilder.Entity<Futures5k>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("futures5k");

            entity.HasIndex(e => new { e.Code, e.Ts }, "index_f5k_codets");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Ts)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("ts");
        });

        modelBuilder.Entity<Futures60k>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("futures60k");

            entity.HasIndex(e => new { e.Code, e.Ts }, "index_f60k_codets");

            entity.Property(e => e.Bartypes).HasColumnName("bartypes");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Ts)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("ts");
            entity.Property(e => e.ValidDate).HasColumnType("TIMESTAMP");
        });

        modelBuilder.Entity<SkStock>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("sk_stocks");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("stocks");

            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Currency).HasColumnName("currency");
            entity.Property(e => e.DayTrade).HasColumnName("day_trade");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.DeliveryMonth).HasColumnName("delivery_month");
            entity.Property(e => e.Exchange).HasColumnName("exchange");
            entity.Property(e => e.LimitDown).HasColumnName("limit_down");
            entity.Property(e => e.LimitUp).HasColumnName("limit_up");
            entity.Property(e => e.MarginTradingBalance).HasColumnName("margin_trading_balance");
            entity.Property(e => e.Multiplier).HasColumnName("multiplier");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.OptionRight).HasColumnName("option_right");
            entity.Property(e => e.Reference).HasColumnName("reference");
            entity.Property(e => e.SecurityType).HasColumnName("security_type");
            entity.Property(e => e.ShortSellingBalance).HasColumnName("short_selling_balance");
            entity.Property(e => e.StrikePrice).HasColumnName("strike_price");
            entity.Property(e => e.Symbol).HasColumnName("symbol");
            entity.Property(e => e.UnderlyingCode).HasColumnName("underlying_code");
            entity.Property(e => e.UnderlyingKind).HasColumnName("underlying_kind");
            entity.Property(e => e.Unit).HasColumnName("unit");
            entity.Property(e => e.Unnamed0).HasColumnName("Unnamed: 0");
            entity.Property(e => e.UpdateDate).HasColumnName("update_date");
        });

        modelBuilder.Entity<Stocks15k>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("stocks15k");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Ts).HasColumnName("ts");
        });

        modelBuilder.Entity<Stocks1d>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("stocks1d");

            entity.Property(e => e.Bartypes).HasColumnName("bartypes");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Ts).HasColumnName("ts");
            entity.Property(e => e.ValidDate).HasColumnType("TIMESTAMP");
        });

        modelBuilder.Entity<Stocks1k>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("stocks1k");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Ts)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("ts");
        });

        modelBuilder.Entity<Stocks30k>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("stocks30k");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Ts).HasColumnName("ts");
        });

        modelBuilder.Entity<Stocks5k>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("stocks5k");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Ts).HasColumnName("ts");
        });

        modelBuilder.Entity<Stocks60k>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("stocks60k");

            entity.Property(e => e.Bartypes).HasColumnName("bartypes");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.High).HasColumnType("NUMERIC");
            entity.Property(e => e.Ts).HasColumnName("ts");
            entity.Property(e => e.ValidDate).HasColumnType("TIMESTAMP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
