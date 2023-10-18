using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class UpdateEventRelatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55918127-3586-4b04-9c0d-decd12d6615f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c78fdd2c-1f1b-427e-9564-b010f52ce9d4", "34516ee4-7702-435c-91d8-e090ad4991c4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cd34e10a-1ca2-41fe-87a4-765a12e8c89c", "9dae5757-760a-4411-8cad-ba9be67d59ea" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c4826942-14fd-4bc9-9735-1a4858596ada", "b4691395-4c18-4750-a88b-6f81016fb5a9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4826942-14fd-4bc9-9735-1a4858596ada");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c78fdd2c-1f1b-427e-9564-b010f52ce9d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd34e10a-1ca2-41fe-87a4-765a12e8c89c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34516ee4-7702-435c-91d8-e090ad4991c4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dae5757-760a-4411-8cad-ba9be67d59ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4691395-4c18-4750-a88b-6f81016fb5a9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2cc5c84d-491d-46ac-88c6-55aab381f7ef", "1b312fe4-7b32-4230-bc99-d29fcd72486d", "Admin", "ADMIN" },
                    { "451750c0-d760-48e1-bd46-ba72bfbf8c7f", "1c5c3a18-84f0-4801-b345-1e04097ec465", "SalesManager", "SALESMANAGER" },
                    { "5be2b684-df3d-424e-a211-f9500888af50", "98999e42-36c6-4df2-84d1-53ea112075fa", "SuperAdmin", "SUPERADMIN" },
                    { "9dcb6ccc-3c6a-4414-861a-b67cb6ca2235", "5e994977-0c55-402a-960e-a3ad5751ed2a", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "City", "ConcurrencyStamp", "ConnectionId", "Country", "Email", "EmailConfirmed", "FullName", "ImageUrl", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId", "ZipCode" },
                values: new object[,]
                {
                    { "8941cf4d-58d8-42bc-9051-4c28bbf8d26b", 0, null, null, null, "e8da61e1-5939-4e5e-b64b-3079442546e3", null, null, "salesmanager@gmail.com", true, "Sales Manager", "salesmanager.jpg", false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAEP5nmv/4YIfIV2c/onRSo38Q/jA/QhMp+aVgcq/g0yx3mG//A4z5vHGQUQ1kuw4Fhg==", "+0987654323", true, "412af171-6de6-4b54-97f6-34c69b02e5d2", false, "salesmanager", "ver3", null },
                    { "c71dd372-688a-45d8-ba70-da69bafb481e", 0, null, null, null, "9d8c7e21-49b5-4e27-81d3-93c87f8919c4", null, null, "superadmin@gmail.com", true, "Super Admin", "superadmin.jpg", false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEFUbMqeLECnxZyJZp/XDjmQSo2cY2ISawaU2tFdjTyfkTzqZNqTWphu1cFINkunQgA==", "+0987654321", true, "f42a7948-cd68-4405-977f-475faa20d917", false, "superadmin", "ver1", null },
                    { "ea4a98b4-86a0-4f5d-adff-7c93ffdd90e6", 0, null, null, null, "53d77a88-2e43-4766-89be-c8fad42e22a0", null, null, "admin@gmail.com", true, "Admin", "admin.jpg", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAECP8/o/L79tWcRc1htOYbm5V2U6uGXpStval8UShBdJ07Mu2+HOP9E91iginb3CTlA==", "+1234567890", true, "b20fd96c-e66c-4998-93f1-d3a5c6d456dd", false, "admin", "ver2", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "451750c0-d760-48e1-bd46-ba72bfbf8c7f", "8941cf4d-58d8-42bc-9051-4c28bbf8d26b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5be2b684-df3d-424e-a211-f9500888af50", "c71dd372-688a-45d8-ba70-da69bafb481e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2cc5c84d-491d-46ac-88c6-55aab381f7ef", "ea4a98b4-86a0-4f5d-adff-7c93ffdd90e6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dcb6ccc-3c6a-4414-861a-b67cb6ca2235");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "451750c0-d760-48e1-bd46-ba72bfbf8c7f", "8941cf4d-58d8-42bc-9051-4c28bbf8d26b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5be2b684-df3d-424e-a211-f9500888af50", "c71dd372-688a-45d8-ba70-da69bafb481e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2cc5c84d-491d-46ac-88c6-55aab381f7ef", "ea4a98b4-86a0-4f5d-adff-7c93ffdd90e6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cc5c84d-491d-46ac-88c6-55aab381f7ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "451750c0-d760-48e1-bd46-ba72bfbf8c7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5be2b684-df3d-424e-a211-f9500888af50");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8941cf4d-58d8-42bc-9051-4c28bbf8d26b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c71dd372-688a-45d8-ba70-da69bafb481e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea4a98b4-86a0-4f5d-adff-7c93ffdd90e6");

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Movies_MovieId",
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
                    { "55918127-3586-4b04-9c0d-decd12d6615f", "0466cdbd-4d9b-4457-8661-423adb458f3c", "Member", "MEMBER" },
                    { "c4826942-14fd-4bc9-9735-1a4858596ada", "5ce5f99f-af3d-4fff-bd1d-ae050c306018", "Admin", "ADMIN" },
                    { "c78fdd2c-1f1b-427e-9564-b010f52ce9d4", "14831f5e-c86b-4a83-84b3-7d3be7a42c34", "SalesManager", "SALESMANAGER" },
                    { "cd34e10a-1ca2-41fe-87a4-765a12e8c89c", "93bfc051-3b81-479b-9ffc-460ad6339596", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "City", "ConcurrencyStamp", "ConnectionId", "Country", "Email", "EmailConfirmed", "FullName", "ImageUrl", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId", "ZipCode" },
                values: new object[,]
                {
                    { "34516ee4-7702-435c-91d8-e090ad4991c4", 0, null, null, null, "63db318e-79e8-4142-9f8e-5c6b6d2de418", null, null, "salesmanager@gmail.com", true, "Sales Manager", null, false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAEAwOQKIlPZQL9RnGALi88yBXqn6l9pk1tgLKwOnUSoKfJ7O3emAMEssX8F3T1nj1cw==", "+0987654323", true, "c2819f72-bb37-462a-8258-d01bb6d0a555", false, "salesmanager", "ver3", null },
                    { "9dae5757-760a-4411-8cad-ba9be67d59ea", 0, null, null, null, "04b1d5a2-3a24-401f-978a-1667a439ba18", null, null, "superadmin@gmail.com", true, "Super Admin", null, false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEO4u1SuVBSHrmsb36JCrRI/knREWxRCyqcdcKjOJPIPaxOODb+5TtOmVyKDNZqeitQ==", "+0987654321", true, "2fc04af1-b9d5-40a8-834a-f784f07742b0", false, "superadmin", "ver1", null },
                    { "b4691395-4c18-4750-a88b-6f81016fb5a9", 0, null, null, null, "2390e7b6-37b4-434c-8308-5ea133554a15", null, null, "admin@gmail.com", true, "Admin", null, false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEE6HWyeAhOxbkUDag43ld9UtLTGVkBkBvh5IQ5+gt8bqLzzDEt7kzefThXWrWEB7eA==", "+1234567890", true, "b45634a8-53a9-46c7-b506-9d9f951c1e1c", false, "admin", "ver2", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c78fdd2c-1f1b-427e-9564-b010f52ce9d4", "34516ee4-7702-435c-91d8-e090ad4991c4" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cd34e10a-1ca2-41fe-87a4-765a12e8c89c", "9dae5757-760a-4411-8cad-ba9be67d59ea" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c4826942-14fd-4bc9-9735-1a4858596ada", "b4691395-4c18-4750-a88b-6f81016fb5a9" });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MovieId",
                table: "Characters",
                column: "MovieId");
        }
    }
}
