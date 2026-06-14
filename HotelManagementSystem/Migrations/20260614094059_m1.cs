using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rooms_guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestStaff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    guestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestStaff", x => new { x.StaffId, x.guestsId });
                    table.ForeignKey(
                        name: "FK_GuestStaff_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestStaff_guests_guestsId",
                        column: x => x.guestsId,
                        principalTable: "guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "first", "Food" },
                    { 2, "Second", "Wash" }
                });

            migrationBuilder.InsertData(
                table: "guests",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "jana@gmail.com", "Jana" },
                    { 2, "mohammed@gmail.com", "Mohammed" },
                    { 3, "rawan@gmail.com", "Rawan" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "DepartmentId", "Email", "Name", "phone" },
                values: new object[,]
                {
                    { 1, 1, "mo3az@gmail.com", "Mo3az", "01234567890" },
                    { 2, 1, "mai@gmail.com", "Mai", "01234567890" },
                    { 3, 2, "eman@gmail.com", "Eman", "01234567890" }
                });

            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "Id", "GuestId", "RoomNumber", "Type" },
                values: new object[,]
                {
                    { 1, 1, "101", "Single" },
                    { 2, 3, "102", "Single" },
                    { 3, 2, "103", "Double" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestStaff_guestsId",
                table: "GuestStaff",
                column: "guestsId");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_GuestId",
                table: "rooms",
                column: "GuestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rooms_RoomNumber",
                table: "rooms",
                column: "RoomNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_DepartmentId",
                table: "Staff",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestStaff");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "guests");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
