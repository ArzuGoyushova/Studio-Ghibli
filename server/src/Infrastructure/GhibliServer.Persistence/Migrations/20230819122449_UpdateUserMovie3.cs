using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class UpdateUserMovie3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_AspNetUsers_AppUserId",
                table: "UserMovie");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12da0499-3c74-474e-87da-699fbaf0493b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cba3cda2-8ed4-4d96-9e89-dcfae695ee62", "1e58bed5-b5c8-4ea9-8a47-60fb4ebb3ce3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "12109eae-bd4c-47b9-8e23-788ab848dee3", "5110937f-dd12-46a4-ba0a-05ec7f1bdfcc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eff5e922-594e-4c36-85bd-fd6fc27cac51", "b8b8385c-b1f8-454c-9d59-159b9f7e543f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12109eae-bd4c-47b9-8e23-788ab848dee3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cba3cda2-8ed4-4d96-9e89-dcfae695ee62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff5e922-594e-4c36-85bd-fd6fc27cac51");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e58bed5-b5c8-4ea9-8a47-60fb4ebb3ce3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5110937f-dd12-46a4-ba0a-05ec7f1bdfcc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8b8385c-b1f8-454c-9d59-159b9f7e543f");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "UserMovie",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a91b9b3-de88-4b50-aa35-7854168ab2de", "2d999b07-1097-4de8-857c-869cf0b666e0", "SalesManager", "SALESMANAGER" },
                    { "4b40a4c6-2eb8-42fd-a9c2-53d4b2f13d1f", "2556b164-2d9b-46b3-9081-a8549dbb7dbe", "Admin", "ADMIN" },
                    { "6ef2f81a-622a-4b3e-aa0c-b83cf9b9ba29", "d7925d7b-4be0-4307-9c49-2e8ea53996e3", "Member", "MEMBER" },
                    { "a73a8579-fcb4-4e90-914e-49bd1ff84edf", "d275de2d-90d7-4505-9cee-7b9d4e4e303d", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "City", "ConcurrencyStamp", "ConnectionId", "Country", "Email", "EmailConfirmed", "FullName", "ImageUrl", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId", "ZipCode" },
                values: new object[,]
                {
                    { "91475f4f-4b5f-4234-b4f8-ff09f523660d", 0, null, null, null, "6a1ac374-e940-4de7-adf6-37e557626cae", null, null, "superadmin@gmail.com", true, "Super Admin", null, false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEO5Hyrzce4m7TGI7difjEq0fNzUMzormpaA+wCsbch+3XrRGsW/Sh95OM7OTGE5hMw==", "+0987654321", true, "4acb2df6-3e5f-489c-bc3b-9408b6b351f7", false, "superadmin", "ver1", null },
                    { "bc4e663f-a04d-4ab6-9aee-fd7121f0b0b0", 0, null, null, null, "c191e94a-1b25-4e7f-a17f-07aa473b4c4f", null, null, "admin@gmail.com", true, "Admin", null, false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAENfMc+6SmMor1xM52qWQPykPq0h2LksBJV8+oyj7+LzadBax5PJn/hgTtEHalHXJbA==", "+1234567890", true, "25749da5-9a9a-41c1-94ab-8eb13e1c7da0", false, "admin", "ver2", null },
                    { "f8fdea90-e95b-485c-859a-2edae49e5abe", 0, null, null, null, "dd2713bb-a90c-4335-8653-0a4619d5a87d", null, null, "salesmanager@gmail.com", true, "Sales Manager", null, false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAECa3LZeE5YyDhXGC3Xpw9d0mqHhUhqiiCD1sAeG9QcDSBdAKrAOK6io5nu/jA5AokQ==", "+0987654323", true, "1aaf8994-188a-4a9c-9585-d7cb6ac41df2", false, "salesmanager", "ver3", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a73a8579-fcb4-4e90-914e-49bd1ff84edf", "91475f4f-4b5f-4234-b4f8-ff09f523660d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4b40a4c6-2eb8-42fd-a9c2-53d4b2f13d1f", "bc4e663f-a04d-4ab6-9aee-fd7121f0b0b0" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0a91b9b3-de88-4b50-aa35-7854168ab2de", "f8fdea90-e95b-485c-859a-2edae49e5abe" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_AspNetUsers_AppUserId",
                table: "UserMovie",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_AspNetUsers_AppUserId",
                table: "UserMovie");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ef2f81a-622a-4b3e-aa0c-b83cf9b9ba29");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a73a8579-fcb4-4e90-914e-49bd1ff84edf", "91475f4f-4b5f-4234-b4f8-ff09f523660d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4b40a4c6-2eb8-42fd-a9c2-53d4b2f13d1f", "bc4e663f-a04d-4ab6-9aee-fd7121f0b0b0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0a91b9b3-de88-4b50-aa35-7854168ab2de", "f8fdea90-e95b-485c-859a-2edae49e5abe" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a91b9b3-de88-4b50-aa35-7854168ab2de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b40a4c6-2eb8-42fd-a9c2-53d4b2f13d1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a73a8579-fcb4-4e90-914e-49bd1ff84edf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91475f4f-4b5f-4234-b4f8-ff09f523660d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc4e663f-a04d-4ab6-9aee-fd7121f0b0b0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8fdea90-e95b-485c-859a-2edae49e5abe");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "UserMovie",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12109eae-bd4c-47b9-8e23-788ab848dee3", "c9ebd693-7272-4e44-8fbf-1def40d2aa62", "Admin", "ADMIN" },
                    { "12da0499-3c74-474e-87da-699fbaf0493b", "86d437dd-4567-4a58-b7d3-0de0eb577142", "Member", "MEMBER" },
                    { "cba3cda2-8ed4-4d96-9e89-dcfae695ee62", "6e10a268-18d3-4b2d-8fb3-1f7baa7f93d9", "SalesManager", "SALESMANAGER" },
                    { "eff5e922-594e-4c36-85bd-fd6fc27cac51", "2f9fc547-f97f-4dc3-96c8-6f9b0f5d6e50", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "City", "ConcurrencyStamp", "ConnectionId", "Country", "Email", "EmailConfirmed", "FullName", "ImageUrl", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId", "ZipCode" },
                values: new object[,]
                {
                    { "1e58bed5-b5c8-4ea9-8a47-60fb4ebb3ce3", 0, null, null, null, "5160505b-177a-4b27-87a6-86fcc7fa5ac3", null, null, "salesmanager@gmail.com", true, "Sales Manager", null, false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAEN6gBJz19Ice8GbGRq0Es6JJGV82TYsKthvjGrSTj10iSF8I2M7fXhLs/sAVcj5eWw==", "+0987654323", true, "9e86af89-bd08-4f3e-8ac3-ee07d85b2394", false, "salesmanager", "ver3", null },
                    { "5110937f-dd12-46a4-ba0a-05ec7f1bdfcc", 0, null, null, null, "075a0240-f0df-4ae8-9a1f-5e7b04275355", null, null, "admin@gmail.com", true, "Admin", null, false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEBLToVi2ljjYAXl2iub2KLGaChBrihkKf1A3g8TiTrdbOOViDTAtbBovZin914FTgA==", "+1234567890", true, "17a90c55-f63a-4c04-95f3-cb7ccf8c5370", false, "admin", "ver2", null },
                    { "b8b8385c-b1f8-454c-9d59-159b9f7e543f", 0, null, null, null, "46b7cc87-0d1a-4a7e-8cf1-adeb9c2a9129", null, null, "superadmin@gmail.com", true, "Super Admin", null, false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEH78TuBi1c19faopGa0nQGh7TF/eT48wreesnX/aCUilP5BwQOTYcA98C27huC+F6A==", "+0987654321", true, "9c36a09d-113f-4f1c-841f-20d5ca83f580", false, "superadmin", "ver1", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cba3cda2-8ed4-4d96-9e89-dcfae695ee62", "1e58bed5-b5c8-4ea9-8a47-60fb4ebb3ce3" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "12109eae-bd4c-47b9-8e23-788ab848dee3", "5110937f-dd12-46a4-ba0a-05ec7f1bdfcc" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "eff5e922-594e-4c36-85bd-fd6fc27cac51", "b8b8385c-b1f8-454c-9d59-159b9f7e543f" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_AspNetUsers_AppUserId",
                table: "UserMovie",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
