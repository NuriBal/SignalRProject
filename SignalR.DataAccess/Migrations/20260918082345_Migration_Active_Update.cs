using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Migration_Active_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Testimonials",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "SocialMedias",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "SocialMedias",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Products",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Features",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Features",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Discounts",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Discounts",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Contacts",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Contacts",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Categories",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Bookings",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Abouts",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Abouts",
                newName: "IsActive");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Testimonials",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Testimonials",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "SocialMedias",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "SocialMedias",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Products",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Features",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Features",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Discounts",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Discounts",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Contacts",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Contacts",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Categories",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Bookings",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Abouts",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Abouts",
                newName: "Status");
        }
    }
}
