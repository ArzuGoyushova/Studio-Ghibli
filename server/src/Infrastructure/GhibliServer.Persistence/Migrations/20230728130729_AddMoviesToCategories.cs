using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class AddMoviesToCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc02e94a-714b-448c-9c92-a4f99a729c55");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3949e5ef-8132-489f-8069-0bd428963150", "670975b7-612d-4367-995d-6f580c058ef2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "38189ca9-3ce0-4486-a4e8-f7ff65d7647e", "69ef0a54-25cd-414f-b319-ebf6febf898f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d639e5ac-909b-424e-8685-81a952697419", "6d08d581-cef4-44d9-8883-29cd9922efb7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38189ca9-3ce0-4486-a4e8-f7ff65d7647e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3949e5ef-8132-489f-8069-0bd428963150");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d639e5ac-909b-424e-8685-81a952697419");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "670975b7-612d-4367-995d-6f580c058ef2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69ef0a54-25cd-414f-b319-ebf6febf898f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d08d581-cef4-44d9-8883-29cd9922efb7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1436451b-4596-4106-b543-c621c3445596", "f4382db4-2967-4a43-a96b-3324f5b82835", "SuperAdmin", "SUPERADMIN" },
                    { "a7e68797-8604-4489-a927-701f32fc86ea", "e2c38431-1fa6-4618-92a0-bfc2f08f1d14", "Admin", "ADMIN" },
                    { "ba471750-f051-4599-9a59-18a55567c615", "166cba68-176a-4521-962d-3276fee15f71", "SalesManager", "SALESMANAGER" },
                    { "c0c2f43c-6c21-4d1d-b9a5-ec5abf1320d4", "550e290f-c146-413d-9839-f829e64e8a98", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId" },
                values: new object[,]
                {
                    { "100ed727-c09c-4e8c-b9d0-5cd014814901", 0, "6442b42d-c639-4d4a-ac20-755ec8886884", null, "admin@gmail.com", true, "Admin", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEBZH17jeUGzpq47YQt+ZZciU7CRBiEvWj4U6qdXhpldDyV5p+QGhiB7eCtdSIgzm3g==", "+1234567890", true, "72a2915f-d8b7-483c-a61d-20d37eeb2130", false, "admin", "ver2" },
                    { "16988c1f-0675-4837-8d1b-05ed6f30d65d", 0, "22126707-dcc8-43fa-8d39-b20b3bc1b2ef", null, "salesmanager@gmail.com", true, "Sales Manager", false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAEIB96r7f6XZdOTv7Tbu3X9K7/FiaIXUJaLEtI0sRX/ssDRJP70rTMOtpxKnpD6QF6g==", "+0987654323", true, "4c5a8473-1f9e-46fb-9975-4c2ba15684fa", false, "salesmanager", "ver3" },
                    { "fe8d7fe8-2150-493f-841d-d78b57e4601e", 0, "03ce3a53-6e74-490f-8aff-8a658ca1a3de", null, "superadmin@gmail.com", true, "Super Admin", false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEB5t19By3vswm396OiRNJo68H8wmf9NxFNPQbbjpS20CmQWX9W5lV8aZ6k8cF8WH8A==", "+0987654321", true, "7ee18692-010f-423b-a3bc-3d459fc49254", false, "superadmin", "ver1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a7e68797-8604-4489-a927-701f32fc86ea", "100ed727-c09c-4e8c-b9d0-5cd014814901" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ba471750-f051-4599-9a59-18a55567c615", "16988c1f-0675-4837-8d1b-05ed6f30d65d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1436451b-4596-4106-b543-c621c3445596", "fe8d7fe8-2150-493f-841d-d78b57e4601e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0c2f43c-6c21-4d1d-b9a5-ec5abf1320d4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a7e68797-8604-4489-a927-701f32fc86ea", "100ed727-c09c-4e8c-b9d0-5cd014814901" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ba471750-f051-4599-9a59-18a55567c615", "16988c1f-0675-4837-8d1b-05ed6f30d65d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1436451b-4596-4106-b543-c621c3445596", "fe8d7fe8-2150-493f-841d-d78b57e4601e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1436451b-4596-4106-b543-c621c3445596");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7e68797-8604-4489-a927-701f32fc86ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba471750-f051-4599-9a59-18a55567c615");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "100ed727-c09c-4e8c-b9d0-5cd014814901");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16988c1f-0675-4837-8d1b-05ed6f30d65d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe8d7fe8-2150-493f-841d-d78b57e4601e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38189ca9-3ce0-4486-a4e8-f7ff65d7647e", "ee58f7dc-b6b4-4034-bdbf-7df09a300cff", "SuperAdmin", "SUPERADMIN" },
                    { "3949e5ef-8132-489f-8069-0bd428963150", "5f7c9a03-0d46-4068-a028-36de14fb28c6", "SalesManager", "SALESMANAGER" },
                    { "cc02e94a-714b-448c-9c92-a4f99a729c55", "529d8957-beb7-48bb-aaef-6a80dd5f61bc", "Member", "MEMBER" },
                    { "d639e5ac-909b-424e-8685-81a952697419", "ac441f32-3520-492e-a1c6-59340bc6ebe5", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId" },
                values: new object[,]
                {
                    { "670975b7-612d-4367-995d-6f580c058ef2", 0, "fb3a92e9-5348-4e1e-a81e-85f10dc6d4ac", null, "salesmanager@gmail.com", true, "Sales Manager", false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAEPyzfFXBya0fbZp5vPzZV4zNUlhysSKaQ1a5Uin5stShBYcdzh6b14IlbaXlQwwGew==", "+0987654323", true, "d1c2220f-e976-430f-a6d6-d920a774cfed", false, "salesmanager", "ver3" },
                    { "69ef0a54-25cd-414f-b319-ebf6febf898f", 0, "466c1477-0a26-4b7a-8d0d-ade95e9719e9", null, "superadmin@gmail.com", true, "Super Admin", false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEFWUr6s32my0KhRH+iyVO+k23PfwxIaJlqyNQ127V7rGF3gWxfmOLv2zxlQcPRQBKg==", "+0987654321", true, "73318cac-5ed5-4fc8-8572-ede7220938a8", false, "superadmin", "ver1" },
                    { "6d08d581-cef4-44d9-8883-29cd9922efb7", 0, "155ad3cd-b3e7-4441-a974-ab0f7dd7a9b8", null, "admin@gmail.com", true, "Admin", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEDxF/AX0/a/cmrN/CVa2GM4IKSWOww4RS7ag3JOND+UzQFo2kxxBFgcMpq0cpiW7nQ==", "+1234567890", true, "0e7c3921-4792-4af3-af5e-5f511388b5d0", false, "admin", "ver2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3949e5ef-8132-489f-8069-0bd428963150", "670975b7-612d-4367-995d-6f580c058ef2" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "38189ca9-3ce0-4486-a4e8-f7ff65d7647e", "69ef0a54-25cd-414f-b319-ebf6febf898f" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d639e5ac-909b-424e-8685-81a952697419", "6d08d581-cef4-44d9-8883-29cd9922efb7" });
        }
    }
}
