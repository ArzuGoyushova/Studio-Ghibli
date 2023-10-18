using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class UpdateTicketCodeLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrders_AspNetUsers_AppUserId",
                table: "TicketOrders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7a7c23e-615d-4e0f-8158-73dfec5c075a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4c201d33-c6d2-447b-af9f-9c4fe1ff4c51", "426a2329-5033-493c-bdd0-c5a4e8ad8152" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f1e19e05-8cda-45d6-9e1e-a95bafb3e2ea", "47d1ba1f-2d0d-4020-a290-a1665d961959" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "845829c1-c38a-45ad-83d4-84e4261471e2", "a30b766e-e935-4f59-b295-ff82b19e0853" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c201d33-c6d2-447b-af9f-9c4fe1ff4c51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "845829c1-c38a-45ad-83d4-84e4261471e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1e19e05-8cda-45d6-9e1e-a95bafb3e2ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "426a2329-5033-493c-bdd0-c5a4e8ad8152");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47d1ba1f-2d0d-4020-a290-a1665d961959");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a30b766e-e935-4f59-b295-ff82b19e0853");

            migrationBuilder.AlterColumn<string>(
                name: "TicketCode",
                table: "Tickets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "TicketOrders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "TicketOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrders_AspNetUsers_AppUserId",
                table: "TicketOrders",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrders_AspNetUsers_AppUserId",
                table: "TicketOrders");

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

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "TicketOrders");

            migrationBuilder.AlterColumn<string>(
                name: "TicketCode",
                table: "Tickets",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "TicketOrders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Events",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c201d33-c6d2-447b-af9f-9c4fe1ff4c51", "2651838e-507e-4c2c-8afa-f0c5fcf74a6c", "Admin", "ADMIN" },
                    { "845829c1-c38a-45ad-83d4-84e4261471e2", "ca38ff5a-a36a-49f9-bb56-c797b3a79805", "SalesManager", "SALESMANAGER" },
                    { "f1e19e05-8cda-45d6-9e1e-a95bafb3e2ea", "886cb4e7-1e1c-4acf-912a-c43885077d0c", "SuperAdmin", "SUPERADMIN" },
                    { "f7a7c23e-615d-4e0f-8158-73dfec5c075a", "0f886bd9-f2ef-489c-aebc-b503f3ad8f70", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "City", "ConcurrencyStamp", "ConnectionId", "Country", "Email", "EmailConfirmed", "FullName", "ImageUrl", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId", "ZipCode" },
                values: new object[,]
                {
                    { "426a2329-5033-493c-bdd0-c5a4e8ad8152", 0, null, null, null, "b1bd620f-4d51-4408-9314-e75d6830800a", null, null, "admin@gmail.com", true, "Admin", null, false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEFl3DaKb/oNS1BSuNYTrqo4glwiXKqVNt9rqzUcBCjbEVXqIFFUIMtcNoSMXJVvD7Q==", "+1234567890", true, "c3a2acff-2b9e-48bc-ac85-e70b37751711", false, "admin", "ver2", null },
                    { "47d1ba1f-2d0d-4020-a290-a1665d961959", 0, null, null, null, "caeb3178-e359-4ce1-99c9-ee2ce0e19c82", null, null, "superadmin@gmail.com", true, "Super Admin", null, false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEFooyVmnIGlcG9uJNLZ30VM1zMHriuxwfdlNIBDetm5U1/uqOVULwT8BG/antUpbUQ==", "+0987654321", true, "b69bf351-7478-4963-bd0f-c4686509ef25", false, "superadmin", "ver1", null },
                    { "a30b766e-e935-4f59-b295-ff82b19e0853", 0, null, null, null, "2cc222b4-17b5-4efa-b82d-1d04d533549e", null, null, "salesmanager@gmail.com", true, "Sales Manager", null, false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAEI4m0UCJ5G95G6G1a/f3pZ+fXsPtp+Ev3kAbfzDzqTkzg2GWS9BNd2FGYDy+o3y7EA==", "+0987654323", true, "457e8561-8e8a-4704-b241-256425b4f0ab", false, "salesmanager", "ver3", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4c201d33-c6d2-447b-af9f-9c4fe1ff4c51", "426a2329-5033-493c-bdd0-c5a4e8ad8152" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f1e19e05-8cda-45d6-9e1e-a95bafb3e2ea", "47d1ba1f-2d0d-4020-a290-a1665d961959" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "845829c1-c38a-45ad-83d4-84e4261471e2", "a30b766e-e935-4f59-b295-ff82b19e0853" });

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrders_AspNetUsers_AppUserId",
                table: "TicketOrders",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
