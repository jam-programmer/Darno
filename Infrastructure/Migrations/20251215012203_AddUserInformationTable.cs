using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserInformationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Title",
            //    table: "CategoryArticle");

            //migrationBuilder.DropColumn(
            //    name: "UrlName",
            //    table: "CategoryArticle");

            //migrationBuilder.AddColumn<Guid>(
            //    name: "Id",
            //    table: "BlogCategoryEntity",
            //    type: "uniqueidentifier",
            //    nullable: false,
            //    defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            //migrationBuilder.AddColumn<string>(
            //    name: "Description",
            //    table: "BlogCategoryEntity",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Title",
            //    table: "BlogCategoryEntity",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "UrlName",
            //    table: "BlogCategoryEntity",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
                //name: "IsPublished",
                //table: "Article",
                //type: "bit",
                //nullable: false,
                //defaultValue: false);

            //migrationBuilder.AddPrimaryKey(
                //name: "PK_BlogCategoryEntity",
                //table: "BlogCategoryEntity",
                //column: "Id");

            migrationBuilder.CreateTable(
                name: "UserInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserInformation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Statuscode = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformation", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInformation");

            //migrationBuilder.DropPrimaryKey(
               // name: "PK_BlogCategoryEntity",
              //  table: "BlogCategoryEntity");

            //migrationBuilder.DropColumn(
                //name: "Id",
                //table: "BlogCategoryEntity");

            //migrationBuilder.DropColumn(
                //name: "Description",
                //table: "BlogCategoryEntity");

            //migrationBuilder.DropColumn(
                //name: "Title",
                //table: "BlogCategoryEntity");

            //migrationBuilder.DropColumn(
                //name: "UrlName",
                //table: "BlogCategoryEntity");

            //migrationBuilder.DropColumn(
                //name: "IsPublished",
                //table: "Article");

            //migrationBuilder.AddColumn<string>(
                //name: "Title",
                //table: "CategoryArticle",
                //type: "nvarchar(max)",
                //nullable: true);

            //migrationBuilder.AddColumn<string>(
                //name: "UrlName",
                //table: "CategoryArticle",
                //type: "nvarchar(max)",
                //nullable: true);
        }
    }
}