using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockRoom11net.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeLineEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Table_Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Department = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Table_Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Building = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Table_Marshall",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Marshall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Table_Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Table_StockRoom",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_StockRoom", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Table_TimeLine",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Text_Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Parent_ID = table.Column<int>(type: "INTEGER", nullable: true),
                    Node_PDF = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Node_Picture = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Description_Short = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Description_Expand = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Image = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    String_Filter = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ItemCount = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    ItemOpen = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETDATE()"),
                    Created_by = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Properties = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Message_String = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false, defaultValue: "Active")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_TimeLine", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Table_TimeLine_Table_TimeLine_Parent_ID",
                        column: x => x.Parent_ID,
                        principalTable: "Table_TimeLine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Table_Employees_EmployeeName",
                table: "Table_Employees",
                column: "EmployeeName");

            migrationBuilder.CreateIndex(
                name: "IX_Table_Projects_ProjectName",
                table: "Table_Projects",
                column: "ProjectName");

            migrationBuilder.CreateIndex(
                name: "IX_Table_StockRoom_Description",
                table: "Table_StockRoom",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_Table_StockRoom_PartNumber",
                table: "Table_StockRoom",
                column: "PartNumber");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLine_DateCreated",
                table: "Table_TimeLine",
                column: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLine_Index",
                table: "Table_TimeLine",
                column: "Index");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLine_ParentID",
                table: "Table_TimeLine",
                column: "Parent_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Table_Employees");

            migrationBuilder.DropTable(
                name: "Table_Locations");

            migrationBuilder.DropTable(
                name: "Table_Marshall");

            migrationBuilder.DropTable(
                name: "Table_Projects");

            migrationBuilder.DropTable(
                name: "Table_StockRoom");

            migrationBuilder.DropTable(
                name: "Table_TimeLine");
        }
    }
}
