using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CountryClubAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bookings_facilities_facility_id",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "fk_bookings_members_member_id",
                table: "bookings");

            migrationBuilder.AlterColumn<int>(
                name: "member_id",
                table: "bookings",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "facility_id",
                table: "bookings",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_bookings_facilities_facility_id",
                table: "bookings",
                column: "facility_id",
                principalTable: "facilities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_bookings_members_member_id",
                table: "bookings",
                column: "member_id",
                principalTable: "members",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bookings_facilities_facility_id",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "fk_bookings_members_member_id",
                table: "bookings");

            migrationBuilder.AlterColumn<int>(
                name: "member_id",
                table: "bookings",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "facility_id",
                table: "bookings",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_bookings_facilities_facility_id",
                table: "bookings",
                column: "facility_id",
                principalTable: "facilities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_bookings_members_member_id",
                table: "bookings",
                column: "member_id",
                principalTable: "members",
                principalColumn: "id");
        }
    }
}
