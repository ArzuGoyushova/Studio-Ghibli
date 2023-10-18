using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class UpdateReservedSeatsValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "817e2ca6-44cd-4066-ad8d-05335c8ce02c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "226cc9d5-f255-47c8-b7e6-75080e982d6e", "5dea6043-8347-40f8-a09d-e45bde282f13" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "46922b21-ce5f-4411-939c-77e346adf6d3", "8a428090-6775-4700-adce-5848b463673c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d43bec7a-c35d-4c7d-baa4-064b9e58ec22", "976254db-13e1-4146-84af-dde37706a91c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "226cc9d5-f255-47c8-b7e6-75080e982d6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46922b21-ce5f-4411-939c-77e346adf6d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d43bec7a-c35d-4c7d-baa4-064b9e58ec22");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5dea6043-8347-40f8-a09d-e45bde282f13");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a428090-6775-4700-adce-5848b463673c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "976254db-13e1-4146-84af-dde37706a91c");

            migrationBuilder.AlterColumn<string>(
                name: "ReservedSeats",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "ReservedSeats",
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
                    { "226cc9d5-f255-47c8-b7e6-75080e982d6e", "fe303407-8dd2-4613-89e5-b8565331b278", "SuperAdmin", "SUPERADMIN" },
                    { "46922b21-ce5f-4411-939c-77e346adf6d3", "c64b3db8-e9f5-4120-b509-890d578c3d8e", "SalesManager", "SALESMANAGER" },
                    { "817e2ca6-44cd-4066-ad8d-05335c8ce02c", "6fe80197-475c-403e-82d9-ab438a2214cb", "Member", "MEMBER" },
                    { "d43bec7a-c35d-4c7d-baa4-064b9e58ec22", "c871a518-bd6a-4a6d-8f13-7e551a898a8e", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "City", "ConcurrencyStamp", "ConnectionId", "Country", "Email", "EmailConfirmed", "FullName", "ImageUrl", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId", "ZipCode" },
                values: new object[,]
                {
                    { "5dea6043-8347-40f8-a09d-e45bde282f13", 0, null, null, null, "fb252db6-47bb-4ac1-87a3-47b0378f5eda", null, null, "superadmin@gmail.com", true, "Super Admin", null, false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEOSVFwVhtRSUQCEKSQAt5V28SQVpKgom2xDYMEYSzmtg8tpHK5RaXTQQJARa7LnaXg==", "+0987654321", true, "874e1bc4-d66f-4141-bfe7-d07a245e6db4", false, "superadmin", "ver1", null },
                    { "8a428090-6775-4700-adce-5848b463673c", 0, null, null, null, "fc17cf55-0ab6-44df-bf29-2baec057f2c4", null, null, "salesmanager@gmail.com", true, "Sales Manager", null, false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAEGhsK9/g751i2rS2co5ayOGrzA8Z3MmQ/sAWeSQ4QVdIkmkWn6toa3jwjUmAy/hXOQ==", "+0987654323", true, "37cea676-bfbe-4ac9-9e82-31e05d0a317b", false, "salesmanager", "ver3", null },
                    { "976254db-13e1-4146-84af-dde37706a91c", 0, null, null, null, "dcae226b-8e4c-4ecd-90a0-a8548a9ca7aa", null, null, "admin@gmail.com", true, "Admin", null, false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEHkEyTJnA7pawR9ipJ4rbB13AIKR8QGM4w8Pq/XW3DgrbVAYHBkT5v0x/a2l4Goeqw==", "+1234567890", true, "b410ea8a-0bb7-4c77-af55-5eb43b718a94", false, "admin", "ver2", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "226cc9d5-f255-47c8-b7e6-75080e982d6e", "5dea6043-8347-40f8-a09d-e45bde282f13" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "46922b21-ce5f-4411-939c-77e346adf6d3", "8a428090-6775-4700-adce-5848b463673c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d43bec7a-c35d-4c7d-baa4-064b9e58ec22", "976254db-13e1-4146-84af-dde37706a91c" });
        }
    }
}
