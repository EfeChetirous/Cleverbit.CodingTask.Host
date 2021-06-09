using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cleverbit.CodingTask.Host.Migrations
{
    public partial class sqlchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMatch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstUserId = table.Column<int>(type: "int", nullable: false),
                    SecondUserId = table.Column<int>(type: "int", nullable: false),
                    MatchExpireSecond = table.Column<int>(type: "int", nullable: false),
                    FirstUserAccepted = table.Column<bool>(type: "bit", nullable: false),
                    SecondUserAccepted = table.Column<bool>(type: "bit", nullable: false),
                    FirstUserPoint = table.Column<int>(type: "int", nullable: false),
                    SecondUserPoint = table.Column<int>(type: "int", nullable: false),
                    WinnerUserId = table.Column<int>(type: "int", nullable: false),
                    MatchEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMatch_User_FirstUserId",
                        column: x => x.FirstUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMatch_User_SecondUserId",
                        column: x => x.SecondUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, null, null, "123456", "User1" },
                    { 2, null, null, "123456", "User2" },
                    { 3, null, null, "123456", "User3" },
                    { 4, null, null, "123456", "User4" }
                });

            migrationBuilder.InsertData(
                table: "UserMatch",
                columns: new[] { "Id", "FirstUserAccepted", "FirstUserId", "FirstUserPoint", "MatchEndDate", "MatchExpireSecond", "SecondUserAccepted", "SecondUserId", "SecondUserPoint", "WinnerUserId" },
                values: new object[] { 1, false, 1, 0, new DateTime(2021, 6, 10, 3, 32, 40, 843, DateTimeKind.Local).AddTicks(3729), 30, false, 2, 0, 0 });

            migrationBuilder.InsertData(
                table: "UserMatch",
                columns: new[] { "Id", "FirstUserAccepted", "FirstUserId", "FirstUserPoint", "MatchEndDate", "MatchExpireSecond", "SecondUserAccepted", "SecondUserId", "SecondUserPoint", "WinnerUserId" },
                values: new object[] { 2, false, 3, 0, new DateTime(2021, 6, 10, 3, 32, 40, 845, DateTimeKind.Local).AddTicks(787), 30, false, 4, 0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_UserMatch_FirstUserId",
                table: "UserMatch",
                column: "FirstUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMatch_SecondUserId",
                table: "UserMatch",
                column: "SecondUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMatch");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
