using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StockRoom11net.Data.Entities;

namespace StockRoom11net.Data;

public partial class ProductionInventoryContext : DbContext
{
    public ProductionInventoryContext(DbContextOptions<ProductionInventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Table_Address_Book> Table_Address_Books { get; set; }

    public virtual DbSet<Table_Employee> Table_Employees { get; set; }

    public virtual DbSet<Table_Employees_TreeView> Table_Employees_TreeViews { get; set; }

    public virtual DbSet<Table_Labels_SMT> Table_Labels_SMTs { get; set; }

    public virtual DbSet<Table_Location> Table_Locations { get; set; }

    public virtual DbSet<Table_Location_TreeView> Table_Location_TreeViews { get; set; }

    public virtual DbSet<Table_Marshall> Table_Marshalls { get; set; }

    public virtual DbSet<Table_Marshall_TreeView> Table_Marshall_TreeViews { get; set; }

    public virtual DbSet<Table_Project> Table_Projects { get; set; }

    public virtual DbSet<Table_Projects_TreeView> Table_Projects_TreeViews { get; set; }

    public virtual DbSet<Table_Status> Table_Statuses { get; set; }

    public virtual DbSet<Table_StockRoom> Table_StockRooms { get; set; }

    public virtual DbSet<Table_StockRoom_TreeView> Table_StockRoom_TreeViews { get; set; }

    public virtual DbSet<Table_TimeLine> Table_TimeLines { get; set; }

    public virtual DbSet<Table_TimeLine_TreeView> Table_TimeLine_TreeViews { get; set; }

    public virtual DbSet<__EFMigrationsLock> __EFMigrationsLocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table_Employee>(entity =>
        {
            entity.Property(e => e.Index).ValueGeneratedNever();
        });

        modelBuilder.Entity<Table_Employees_TreeView>(entity =>
        {
            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.BackgroundColor).HasDefaultValue("Color [White]");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.EndDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.EndTime).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.FinishPanel).HasDefaultValue(0);
            entity.Property(e => e.ImageAlign).HasDefaultValue("West");
            entity.Property(e => e.ItemCount).HasDefaultValue(0);
            entity.Property(e => e.MinuteEndTop).HasDefaultValue(0);
            entity.Property(e => e.MinuteStartTop).HasDefaultValue(0);
            entity.Property(e => e.MyChildIs).HasDefaultValue(-1234);
            entity.Property(e => e.MyFatherIs).HasDefaultValue(-1234);
            entity.Property(e => e.MyGrandFatherIs).HasDefaultValue(0);
            entity.Property(e => e.PCBComment).HasDefaultValue("New PCB, coment this as best profecional.");
            entity.Property(e => e.PCBName).HasDefaultValue("Name the new PCB");
            entity.Property(e => e.PCBNumber).HasDefaultValue("110-");
            entity.Property(e => e.Pattern).HasDefaultValue("");
            entity.Property(e => e.PatternColor).HasDefaultValue("Color [Red]");
            entity.Property(e => e.Pcs_Panel).HasDefaultValue(0);
            entity.Property(e => e.QtyProduced).HasDefaultValue(0);
            entity.Property(e => e.QtyProjectPlaned).HasDefaultValue(0);
            entity.Property(e => e.QtyProjectProduced).HasDefaultValue(0);
            entity.Property(e => e.QtyProjectRemaining).HasDefaultValue(0);
            entity.Property(e => e.StartDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.StartPanel).HasDefaultValue(0);
            entity.Property(e => e.StartTime).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.TextItem).HasDefaultValue("Undefined");
            entity.Property(e => e.TotalPanel).HasDefaultValue(0);
        });

        modelBuilder.Entity<Table_Labels_SMT>(entity =>
        {
            entity.Property(e => e.BackUpField2).HasDefaultValue(0);
            entity.Property(e => e.Darkness).HasDefaultValue(10);
            entity.Property(e => e.QuantityToPrint).HasDefaultValue(2);
            entity.Property(e => e.StartingValue).HasDefaultValue(1);
        });

        modelBuilder.Entity<Table_Location>(entity =>
        {
            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Properties).HasDefaultValue("");
        });

        modelBuilder.Entity<Table_Location_TreeView>(entity =>
        {
            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Created_by).HasDefaultValue("");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Description_Expand).HasDefaultValue("");
            entity.Property(e => e.Description_Short).HasDefaultValue("");
            entity.Property(e => e.Image).HasDefaultValue("No_Picture_Found");
            entity.Property(e => e.Message_String).HasDefaultValue("");
            entity.Property(e => e.Properties).HasDefaultValue("");
            entity.Property(e => e.Status).HasDefaultValue("");
            entity.Property(e => e.String_Filter).HasDefaultValue("");
            entity.Property(e => e.Text_Name).HasDefaultValue("");
        });

        modelBuilder.Entity<Table_Marshall>(entity =>
        {
            entity.Property(e => e.Comp_On_Hand).HasDefaultValue(0);
            entity.Property(e => e.Comp_for_Production).HasDefaultValue(0);
            entity.Property(e => e.IndexRecord_Project).HasDefaultValue(0);
            entity.Property(e => e.Max_Possible_Quantity).HasDefaultValue(0);
            entity.Property(e => e.Message_String).HasDefaultValue("");
            entity.Property(e => e.Number_of_Placements).HasDefaultValue(0);
            entity.Property(e => e.StockRoom_OnHold).HasDefaultValue(0);
            entity.Property(e => e.StockRoom_OnHold_Remain).HasDefaultValue(0);
        });

        modelBuilder.Entity<Table_Marshall_TreeView>(entity =>
        {
            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Created_by).HasDefaultValue("");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Description_Expand).HasDefaultValue("");
            entity.Property(e => e.Description_Short).HasDefaultValue("");
            entity.Property(e => e.Image).HasDefaultValue("No_Picture_Found");
            entity.Property(e => e.Message_String).HasDefaultValue("");
            entity.Property(e => e.Parent_ID).HasDefaultValue(0);
            entity.Property(e => e.Properties).HasDefaultValue("");
            entity.Property(e => e.Status).HasDefaultValue("Locked:True;Selected:False;Unerasable:True");
            entity.Property(e => e.String_Filter).HasDefaultValue("");
            entity.Property(e => e.Text_Name).HasDefaultValue("");
        });

        modelBuilder.Entity<Table_Project>(entity =>
        {
            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Description).HasDefaultValue("Project Name");
            entity.Property(e => e.ProjectionDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.ProjectionGroup).HasDefaultValue(0);
            entity.Property(e => e.Projects).HasDefaultValue("Project Name");
            entity.Property(e => e.Quantity).HasDefaultValue(1);
        });

        modelBuilder.Entity<Table_Projects_TreeView>(entity =>
        {
            entity.Property(e => e.BackgroundColor).HasDefaultValue("Color [White]");
            entity.Property(e => e.Created_by).HasDefaultValue("");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Description_Expand).HasDefaultValue("");
            entity.Property(e => e.Description_Short).HasDefaultValue("");
            entity.Property(e => e.EndDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.EndTime).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.FinishPanel).HasDefaultValue(0);
            entity.Property(e => e.Image).HasDefaultValue("No_Picture_Found");
            entity.Property(e => e.ImageAlign).HasDefaultValue("West");
            entity.Property(e => e.MachineLine).HasDefaultValue("");
            entity.Property(e => e.Message_String).HasDefaultValue("");
            entity.Property(e => e.MinuteEndTop).HasDefaultValue(0);
            entity.Property(e => e.MinuteStartTop).HasDefaultValue(0);
            entity.Property(e => e.MyChildIs).HasDefaultValue(-1234);
            entity.Property(e => e.MyFatherIs).HasDefaultValue(-1234);
            entity.Property(e => e.MyGrandFatherIs).HasDefaultValue(0);
            entity.Property(e => e.PCBComment).HasDefaultValue("New PCB, coment this as best profecional.");
            entity.Property(e => e.PCBName).HasDefaultValue("Name the new PCB");
            entity.Property(e => e.PCBNumber).HasDefaultValue("110-");
            entity.Property(e => e.PWBSide).HasDefaultValue("Top");
            entity.Property(e => e.Pattern).HasDefaultValue("");
            entity.Property(e => e.PatternColor).HasDefaultValue("Color [Red]");
            entity.Property(e => e.Pcs_Panel).HasDefaultValue(0);
            entity.Property(e => e.ProjectName).HasDefaultValue("");
            entity.Property(e => e.QtyProduced).HasDefaultValue(0);
            entity.Property(e => e.QtyProjectPlaned).HasDefaultValue(0);
            entity.Property(e => e.QtyProjectProduced).HasDefaultValue(0);
            entity.Property(e => e.QtyProjectRemaining).HasDefaultValue(0);
            entity.Property(e => e.StartDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.StartPanel).HasDefaultValue(0);
            entity.Property(e => e.StartTime).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Status).HasDefaultValue("");
            entity.Property(e => e.String_Filter).HasDefaultValue("");
            entity.Property(e => e.TextItem).HasDefaultValue("Undefined");
            entity.Property(e => e.Text_Name).HasDefaultValue("");
            entity.Property(e => e.TotalPanel).HasDefaultValue(0);
        });

        modelBuilder.Entity<Table_Status>(entity =>
        {
            entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Table_StockRoom>(entity =>
        {
            entity.Property(e => e.CountDoc).HasDefaultValue(0);
            entity.Property(e => e.CountDocx).HasDefaultValue(0);
            entity.Property(e => e.CountPDF).HasDefaultValue(0);
            entity.Property(e => e.CountTxT).HasDefaultValue(0);
            entity.Property(e => e.LTime).HasDefaultValue(3);
            entity.Property(e => e.MaxQty).HasDefaultValue(20000);
            entity.Property(e => e.MinQty).HasDefaultValue(2000);
            entity.Property(e => e.OnAvailable).HasDefaultValue(0);
            entity.Property(e => e.OnDemand).HasDefaultValueSql("0");
            entity.Property(e => e.OnHand).HasDefaultValue(0);
            entity.Property(e => e.OnHold).HasDefaultValue(0);
            entity.Property(e => e.OnHoldBy).HasDefaultValue("0");
            entity.Property(e => e.OnOrder).HasDefaultValue(0);
            entity.Property(e => e.PrevQty).HasDefaultValue(0);
            entity.Property(e => e.SalePrice).HasDefaultValue(0);
            entity.Property(e => e.Weight).HasDefaultValue(0.0);
        });

        modelBuilder.Entity<Table_StockRoom_TreeView>(entity =>
        {
            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.ItemOpen).HasDefaultValueSql("false");
            entity.Property(e => e.Parent_ID).HasDefaultValue(0);

            // NULL → "" converters: IsRequired(false) tells EF Core to call IsDBNull
            // before GetString, so the null-coalescing converter is actually reached.
            entity.Property(e => e.Code)               .IsRequired(false).HasConversion(v => v, v => v ?? "");
            entity.Property(e => e.Range)              .IsRequired(false).HasConversion(v => v, v => v ?? "");
            entity.Property(e => e.Text_Name)          .IsRequired(false).HasConversion(v => v, v => v ?? "");
            entity.Property(e => e.Node_PDF)           .IsRequired(false).HasConversion(v => v, v => v ?? "");
            entity.Property(e => e.Node_Picture)       .IsRequired(false).HasConversion(v => v, v => v ?? "");
            entity.Property(e => e.Description_Short)  .IsRequired(false).HasConversion(v => v, v => v ?? "");
            entity.Property(e => e.Description_Expand) .IsRequired(false).HasConversion(v => v, v => v ?? "");
            entity.Property(e => e.Image)              .IsRequired(false).HasDefaultValueSql("'No_Picture_Found'").HasConversion(v => v, v => v ?? "");
            entity.Property(e => e.String_Filter)      .IsRequired(false).HasConversion(v => v, v => v ?? "");
            entity.Property(e => e.DateCreated)        .IsRequired(false).HasConversion(v => v, v => v ?? "");
            entity.Property(e => e.Created_by)         .IsRequired(false).HasConversion(v => v, v => v ?? "");
            entity.Property(e => e.AvailableDepartments).IsRequired(false).HasConversion(v => v, v => v ?? "");
            entity.Property(e => e.Properties)         .IsRequired(false).HasConversion(v => v, v => v ?? "");
            entity.Property(e => e.Message_String)     .IsRequired(false).HasConversion(v => v, v => v ?? "");
            entity.Property(e => e.Status)             .IsRequired(false).HasConversion(v => v, v => v ?? "");
        });

        modelBuilder.Entity<Table_TimeLine>(entity =>
        {
            entity.Property(e => e.AltText).HasDefaultValueSql("0");
            entity.Property(e => e.Background).HasDefaultValueSql("0");
            entity.Property(e => e.DisplayDate).HasDefaultValueSql("0");
            entity.Property(e => e.EndDate).HasDefaultValueSql("0");
            entity.Property(e => e.EndTime).HasDefaultValueSql("0");
            entity.Property(e => e.Group).HasDefaultValueSql("0");
            entity.Property(e => e.HeadLine).HasDefaultValueSql("0");
            entity.Property(e => e.ItemText).HasDefaultValueSql("0");
            entity.Property(e => e.Media).HasDefaultValueSql("0");
            entity.Property(e => e.MediaCaption).HasDefaultValueSql("0");
            entity.Property(e => e.MediaCredit).HasDefaultValueSql("0");
            entity.Property(e => e.MediaThumbnail).HasDefaultValueSql("0");
            entity.Property(e => e.StartDate).HasDefaultValueSql("0");
            entity.Property(e => e.StartTime).HasDefaultValueSql("0");
            entity.Property(e => e.Type).HasDefaultValueSql("0");
        });

        modelBuilder.Entity<Table_TimeLine_TreeView>(entity =>
        {
            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.AvailableDepartments).HasDefaultValueSql("AvailableDepartments");
            entity.Property(e => e.Code).HasDefaultValueSql("0");
            entity.Property(e => e.Created_by).HasDefaultValueSql("\"Name user\"");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("\"Date created\"");
            entity.Property(e => e.Description_Expand).HasDefaultValueSql("\"Expand desc\"");
            entity.Property(e => e.Description_Short).HasDefaultValueSql("\"Short Desc\"");
            entity.Property(e => e.Image).HasDefaultValueSql("No_Picture_Found");
            entity.Property(e => e.Message_String).HasDefaultValueSql("\"Message info\"");
            entity.Property(e => e.Node_PDF).HasDefaultValueSql("\"PDF Info\"");
            entity.Property(e => e.Node_Picture).HasDefaultValueSql("\"Node Icon\"");
            entity.Property(e => e.Properties).HasDefaultValueSql("Properties");
            entity.Property(e => e.Range).HasDefaultValueSql("0");
            entity.Property(e => e.Status).HasDefaultValueSql("\"Locked␟True␞Selected␟False␞Unerasable␟True␞Color␟-36865␞Note␟Null␞HeaderInf␟Null␞DisplayStatus␟Ite,Med,4,4␞\"");
            entity.Property(e => e.String_Filter).HasDefaultValueSql("\"String filter\"");
            entity.Property(e => e.Text_Name).HasDefaultValueSql("\"Name here\"");
        });

        modelBuilder.Entity<__EFMigrationsLock>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
