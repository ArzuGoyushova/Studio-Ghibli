using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class UpdateAppUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17aa952e-05d6-4f4e-97f9-cd2b14bfcb8a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "70442834-1556-42c4-805d-e0d9456bca90", "d77d3676-3cd9-4037-a9c5-5a53597426b9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4c557dfc-c6a4-4e5c-8e1a-af0ac82b6a31", "d98dbc14-9c28-4a27-93a5-02b94f285d8a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9e12b11a-1ca1-4654-821c-059f0b51e3b4", "ef5bc954-631d-42e5-a6f8-7d49b3f95400" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c557dfc-c6a4-4e5c-8e1a-af0ac82b6a31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70442834-1556-42c4-805d-e0d9456bca90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e12b11a-1ca1-4654-821c-059f0b51e3b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d77d3676-3cd9-4037-a9c5-5a53597426b9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d98dbc14-9c28-4a27-93a5-02b94f285d8a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef5bc954-631d-42e5-a6f8-7d49b3f95400");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEvent_AspNetUsers_AppUserId1",
                        column: x => x.AppUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserEvent_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMovie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMovie_AspNetUsers_AppUserId1",
                        column: x => x.AppUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2292d905-ca6b-46d7-9ae1-fcb5eda5585f", "36e6e628-a882-4521-9831-d56d39c6405e", "SalesManager", "SALESMANAGER" },
                    { "811c3b28-2429-4d10-8023-10f61098d50f", "bc02191e-1b6b-425c-a570-968ba350c482", "Member", "MEMBER" },
                    { "9b35fb7e-df55-4e7c-a986-abec96d2de70", "6926c2e9-91e7-4646-a693-141e972fb2bd", "SuperAdmin", "SUPERADMIN" },
                    { "fcdb89f7-d58c-4e35-a8cb-0e02e130b373", "b0b36a33-0c65-4b61-a93b-849ed55534f1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "City", "ConcurrencyStamp", "ConnectionId", "Country", "Email", "EmailConfirmed", "FullName", "ImageUrl", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId", "ZipCode" },
                values: new object[,]
                {
                    { "22667024-5bbc-4436-8ac1-e7eabc1cd33c", 0, null, null, null, "90ef1d4b-f467-4404-94c4-ab51e0b728c9", null, null, "salesmanager@gmail.com", true, "Sales Manager", null, false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAEMSSraIpUKiZr0v2F89FyS0xWa420QA9SUWeOXyrNEV+RWYSV499GdddIZ8wR+g1/w==", "+0987654323", true, "2cc52fe6-61a7-4f21-a5dd-ee63e2d77696", false, "salesmanager", "ver3", null },
                    { "28789366-9c28-406e-b649-6a390dc074e7", 0, null, null, null, "0f936b04-1e0e-49bd-9660-6eca8a5f44dc", null, null, "superadmin@gmail.com", true, "Super Admin", null, false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAECrXKNNplyJDhrMJAnbOWJJj5oEocVV0QoeuA0PksBU5qa36B7ewI+x7YJP/ScDTlg==", "+0987654321", true, "21ba1ea4-173c-4b65-aeba-22dddbe4e6ae", false, "superadmin", "ver1", null },
                    { "76dd65aa-2a39-4825-b522-85d115814e85", 0, null, null, null, "d43f4fd0-c85b-440c-9bf9-119e90f96498", null, null, "admin@gmail.com", true, "Admin", null, false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEIrCahltq5WAmejqTJmcmo3QzAKSF/QtTLxxbRXmV/+c+eBKwH9ODaNUT2eMsELs3w==", "+1234567890", true, "91607cc2-a54a-46ab-b095-3c31b996bc9c", false, "admin", "ver2", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2292d905-ca6b-46d7-9ae1-fcb5eda5585f", "22667024-5bbc-4436-8ac1-e7eabc1cd33c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9b35fb7e-df55-4e7c-a986-abec96d2de70", "28789366-9c28-406e-b649-6a390dc074e7" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fcdb89f7-d58c-4e35-a8cb-0e02e130b373", "76dd65aa-2a39-4825-b522-85d115814e85" });

            migrationBuilder.CreateIndex(
                name: "IX_UserEvent_AppUserId1",
                table: "UserEvent",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvent_EventId",
                table: "UserEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvent_MovieId",
                table: "UserEvent",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovie_AppUserId1",
                table: "UserMovie",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovie_MovieId",
                table: "UserMovie",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEvent");

            migrationBuilder.DropTable(
                name: "UserMovie");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811c3b28-2429-4d10-8023-10f61098d50f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2292d905-ca6b-46d7-9ae1-fcb5eda5585f", "22667024-5bbc-4436-8ac1-e7eabc1cd33c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9b35fb7e-df55-4e7c-a986-abec96d2de70", "28789366-9c28-406e-b649-6a390dc074e7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fcdb89f7-d58c-4e35-a8cb-0e02e130b373", "76dd65aa-2a39-4825-b522-85d115814e85" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2292d905-ca6b-46d7-9ae1-fcb5eda5585f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b35fb7e-df55-4e7c-a986-abec96d2de70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcdb89f7-d58c-4e35-a8cb-0e02e130b373");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22667024-5bbc-4436-8ac1-e7eabc1cd33c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28789366-9c28-406e-b649-6a390dc074e7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76dd65aa-2a39-4825-b522-85d115814e85");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17aa952e-05d6-4f4e-97f9-cd2b14bfcb8a", "839a7356-7f0d-483f-8ffc-af07a53f7b84", "Member", "MEMBER" },
                    { "4c557dfc-c6a4-4e5c-8e1a-af0ac82b6a31", "c6a98855-31a4-40fa-ab08-b8bd05ba3e8c", "Admin", "ADMIN" },
                    { "70442834-1556-42c4-805d-e0d9456bca90", "6f9a9402-0e17-4602-aa93-d22a440a84d1", "SuperAdmin", "SUPERADMIN" },
                    { "9e12b11a-1ca1-4654-821c-059f0b51e3b4", "75ed0281-5004-44f1-9526-9c3a087c2546", "SalesManager", "SALESMANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId" },
                values: new object[,]
                {
                    { "d77d3676-3cd9-4037-a9c5-5a53597426b9", 0, "a6e6c4aa-522c-4fc3-b7d7-4bb18d34e989", null, "superadmin@gmail.com", true, "Super Admin", false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEPL0r42f1N52HInZgOI/6HGKkVxy9opVnCw8ShcjbG47cUofbOqOYygVw+2pYQhDbQ==", "+0987654321", true, "002b4093-498d-4384-83bd-5768f0cd1c81", false, "superadmin", "ver1" },
                    { "d98dbc14-9c28-4a27-93a5-02b94f285d8a", 0, "434221d2-3fc1-4402-b358-9e18839edb34", null, "admin@gmail.com", true, "Admin", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEG/vYgDW+aSFU2QGoSklEiQiUMG7+i7szSl/GKs/WYOTjUhu8X/4SpRy+ePsCu2ttQ==", "+1234567890", true, "b492cc95-89a3-4658-ae68-9115ceb6d14d", false, "admin", "ver2" },
                    { "ef5bc954-631d-42e5-a6f8-7d49b3f95400", 0, "56ba3944-5497-469b-aff2-23af23eea050", null, "salesmanager@gmail.com", true, "Sales Manager", false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAENk9V7R6674g2UE5yo5BoMm540B2ElNJOQnkjTdHmCSsVXOBbTAfUVGNo/QtFI5Htg==", "+0987654323", true, "2f3693ab-7a3d-451d-a35a-8b0268f96619", false, "salesmanager", "ver3" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "70442834-1556-42c4-805d-e0d9456bca90", "d77d3676-3cd9-4037-a9c5-5a53597426b9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4c557dfc-c6a4-4e5c-8e1a-af0ac82b6a31", "d98dbc14-9c28-4a27-93a5-02b94f285d8a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9e12b11a-1ca1-4654-821c-059f0b51e3b4", "ef5bc954-631d-42e5-a6f8-7d49b3f95400" });
        }
    }
}
