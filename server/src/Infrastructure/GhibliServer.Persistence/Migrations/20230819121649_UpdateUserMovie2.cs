using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class UpdateUserMovie2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_AspNetUsers_AppUserId",
                table: "UserMovie");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3d5d42b-11d5-4f85-9b13-4d2ec2fe8d36");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d51ac72b-221c-4766-b647-b9619c0bb16c", "0feddba7-ca66-4c7e-ad70-2daebab20ab5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04eb8eab-5212-4da3-b73e-94677f94a3cd", "b0d26f18-c35c-4047-b66d-8fc3069e2351" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b95d1740-640e-4a4d-9b65-71db1ca88913", "b4071d26-64ca-4137-b6a3-af6cc453fc5a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04eb8eab-5212-4da3-b73e-94677f94a3cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b95d1740-640e-4a4d-9b65-71db1ca88913");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d51ac72b-221c-4766-b647-b9619c0bb16c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0feddba7-ca66-4c7e-ad70-2daebab20ab5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0d26f18-c35c-4047-b66d-8fc3069e2351");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4071d26-64ca-4137-b6a3-af6cc453fc5a");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "04eb8eab-5212-4da3-b73e-94677f94a3cd", "0c70bb86-b375-4586-a4ea-78b3ba252f07", "SuperAdmin", "SUPERADMIN" },
                    { "b95d1740-640e-4a4d-9b65-71db1ca88913", "0af4f8bf-2421-46c8-bc09-36d36bb7a939", "Admin", "ADMIN" },
                    { "d51ac72b-221c-4766-b647-b9619c0bb16c", "628916fe-ccb6-40d9-a9ce-41fadf75781a", "SalesManager", "SALESMANAGER" },
                    { "e3d5d42b-11d5-4f85-9b13-4d2ec2fe8d36", "4fc69ed4-c2e3-4b1f-baa3-b44703e24043", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "City", "ConcurrencyStamp", "ConnectionId", "Country", "Email", "EmailConfirmed", "FullName", "ImageUrl", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId", "ZipCode" },
                values: new object[,]
                {
                    { "0feddba7-ca66-4c7e-ad70-2daebab20ab5", 0, null, null, null, "3fce2b3a-58aa-4a77-8078-4c39375ea45e", null, null, "salesmanager@gmail.com", true, "Sales Manager", null, false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAEAN2vOmFWq9btTRVgOKoNWEM/uokz5sMKjdIgy9QpHW1zUORsqmYO0ilDpv4Vf2KVQ==", "+0987654323", true, "549250dc-c469-4eb8-8eb5-458fd57e665a", false, "salesmanager", "ver3", null },
                    { "b0d26f18-c35c-4047-b66d-8fc3069e2351", 0, null, null, null, "82444866-7991-4a00-9947-fa29755cf1cc", null, null, "superadmin@gmail.com", true, "Super Admin", null, false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEL1+8LBOaE63dc3h6PWA41a2w+u7H3DfxcuDHbQvYSlflYR9hW+y+3s8B3Ef0ZdZ6Q==", "+0987654321", true, "287da79e-0749-4c17-8f84-7992915cf827", false, "superadmin", "ver1", null },
                    { "b4071d26-64ca-4137-b6a3-af6cc453fc5a", 0, null, null, null, "a8643c19-6699-401b-bf74-3672271c9c44", null, null, "admin@gmail.com", true, "Admin", null, false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEAunrfYCVWJucYJUZxcqXxIR2w3rjrBkqObDNSHTpuXpvK9Wp1LS7A5WMwb2oo5qng==", "+1234567890", true, "592c7e8f-a619-44f0-83f4-fd10cd2fbe4c", false, "admin", "ver2", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d51ac72b-221c-4766-b647-b9619c0bb16c", "0feddba7-ca66-4c7e-ad70-2daebab20ab5" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "04eb8eab-5212-4da3-b73e-94677f94a3cd", "b0d26f18-c35c-4047-b66d-8fc3069e2351" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b95d1740-640e-4a4d-9b65-71db1ca88913", "b4071d26-64ca-4137-b6a3-af6cc453fc5a" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_AspNetUsers_AppUserId",
                table: "UserMovie",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
