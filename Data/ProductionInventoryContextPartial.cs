using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockRoom11net.Data.Entities;
using System.Globalization;

namespace StockRoom11net.Data;

public partial class ProductionInventoryContext
{
    // Class-level — accessible from static methods
    private static readonly string[] _dateFormats =
    [
        "yyyy-MM-dd HH:mm:ss",
        "yyyy-MM-dd",
        "M/d/yyyy",
        "M/d/yyyy H:mm:ss",
        "MM/dd/yyyy",
        "MM/dd/yyyy HH:mm:ss"
    ];

    // string? -> DateTime?  (reading from SQLite)
    private static DateTime? ParseDateTimeFromDb(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        return DateTime.TryParseExact(
                    value,
                    _dateFormats,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var parsed)
               ? parsed
               : null;
    }

    // DateTime? -> string?  (writing to SQLite)
    private static string? FormatDateTimeToDb(DateTime? value)
        => value.HasValue
            ? value.Value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            : null;

    // int? -> int?  null (C#) <-> NULL/DBNull (SQLite)
    // 0 or negative values are treated as null (root nodes have no parent)
    private static DBNull ParseParentIdFromDb(int? value)
        => (DBNull)(value is null or <= 0 ? DBNull.Value : (object)value);

    private static int? FormatParentIdToDb(int? value)
        => value.HasValue ? value : null;   // null -> SQL NULL (DBNull equivalent)

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        // Value converter for EndTime column
        var dateTimeConverter = new ValueConverter<DateTime?, string>
        (
            v => v.HasValue ? v.Value.ToString("yyyy-MM-dd HH:mm:ss") : null,
            v => string.IsNullOrEmpty(v) ? null : DateTime.Parse(v)
        );

        // string? (entity) <-> DateTime? (provider)
        var dateTimeConverter1 = new ValueConverter<string?, DateTime?>(
            toDb => ParseDateTimeFromDb(toDb),      // string?  -> DateTime?
            fromDb => FormatDateTimeToDb(fromDb)    // DateTime? -> string?
        );

        // int? (entity) <-> int? (SQLite)  null <-> SQL NULL / DBNull
        var parentIdConverter = new ValueConverter<int?, int?>(
            toDb => toDb > 0 ? toDb : (int?)null,   // null/<=0 -> SQL NULL
            fromDb => fromDb > 0 ? fromDb : (int?)null    // SQL NULL/<=0 -> null
        );

        modelBuilder.Entity<Table_TimeLine>(entity =>
        {
            // Apply converter to problematic columns
           // entity.Property(e => e.EndTime)
            //      .HasConversion(dateTimeConverter);

         //   entity.Property(e => e.StartTime)
         //         .HasConversion(dateTimeConverter);

            // Default values
         //   entity.Property(e => e.StartDate)
         //         .HasDefaultValueSql("CURRENT_TIMESTAMP");

         //   entity.Property(e => e.EndDate)
         //         .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Indexes
         //   entity.HasIndex(e => new { e.StartDate, e.EndDate });

        });
        
        modelBuilder.Entity<Table_TimeLine_TreeView>(entity =>
        {
            entity.Property(e => e.DateCreated)
                  .HasConversion(dateTimeConverter1)
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // null <-> SQL NULL (DBNull.Value equivalent in ADO.NET)
        //    entity.Property(e => e.Parent_ID)
         //         .HasConversion(parentIdConverter)
         //         .HasDefaultValue(null);
        });
    }
}