using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectType = table.Column<int>(type: "int", nullable: false),
                    PlatformType = table.Column<int>(type: "int", nullable: false),
                    IsOnlinePaymentGateway = table.Column<bool>(type: "bit", nullable: false),
                    IsMultilingual = table.Column<bool>(type: "bit", nullable: false),
                    IsSms = table.Column<bool>(type: "bit", nullable: false),
                    IsOnlineChat = table.Column<bool>(type: "bit", nullable: false),
                    IsBlog = table.Column<bool>(type: "bit", nullable: false),
                    IsReport = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    IsPwa = table.Column<bool>(type: "bit", nullable: false),
                    HaveHost = table.Column<bool>(type: "bit", nullable: false),
                    HaveDomain = table.Column<bool>(type: "bit", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedInUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelegramUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutUs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Setting",
                columns: new[] { "Id", "AboutUs", "Address", "Email", "InstagramUrl", "LinkedInUrl", "PhoneNumber", "TelegramUrl" },
                values: new object[] { new Guid("20ea895d-b448-4e02-9c8a-cd40f871c372"), "", "", "", "", "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Setting");
        }
    }
}
