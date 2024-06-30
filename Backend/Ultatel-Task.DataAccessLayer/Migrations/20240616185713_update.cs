using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ultatel_Task.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminStudent_Admins_AdminsAdmin_ID",
                table: "AdminStudent");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminStudent",
                table: "AdminStudent");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdminsAdmin_ID",
                table: "AdminStudent");

            migrationBuilder.AlterColumn<string>(
                name: "Student_Email",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastAuditedBy",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AdminName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdminsId",
                table: "AdminStudent",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminStudent",
                table: "AdminStudent",
                columns: new[] { "AdminsId", "StudentsStudent_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Student_Email",
                table: "Students",
                column: "Student_Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminStudent_AspNetUsers_AdminsId",
                table: "AdminStudent",
                column: "AdminsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminStudent_AspNetUsers_AdminsId",
                table: "AdminStudent");

            migrationBuilder.DropIndex(
                name: "IX_Students_Student_Email",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminStudent",
                table: "AdminStudent");

            migrationBuilder.DropColumn(
                name: "AdminName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdminsId",
                table: "AdminStudent");

            migrationBuilder.AlterColumn<string>(
                name: "Student_Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LastAuditedBy",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AdminsAdmin_ID",
                table: "AdminStudent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminStudent",
                table: "AdminStudent",
                columns: new[] { "AdminsAdmin_ID", "StudentsStudent_ID" });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Admin_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Admin_ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AdminStudent_Admins_AdminsAdmin_ID",
                table: "AdminStudent",
                column: "AdminsAdmin_ID",
                principalTable: "Admins",
                principalColumn: "Admin_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
