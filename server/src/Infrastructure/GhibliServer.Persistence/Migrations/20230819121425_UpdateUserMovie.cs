using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class UpdateUserMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_AspNetUsers_AppUserId1",
                table: "UserMovie");

            migrationBuilder.DropIndex(
                name: "IX_UserMovie_AppUserId1",
                table: "UserMovie");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43207836-6f1a-4714-8025-085570d13f97");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c105d661-5c90-4c35-9a10-329491fb8dee", "4581f6a1-2ab9-437d-a9c2-b2b22b39a44d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bee5ee01-6754-487e-8ccd-197e74cce4b8", "984693f3-39ef-4d77-adfd-31a859bfd373" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "10fc5bf7-010a-4bac-8d34-cbb191fa563d", "acc0208f-f7f9-4302-a526-3e2def6df98c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10fc5bf7-010a-4bac-8d34-cbb191fa563d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bee5ee01-6754-487e-8ccd-197e74cce4b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c105d661-5c90-4c35-9a10-329491fb8dee");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4581f6a1-2ab9-437d-a9c2-b2b22b39a44d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "984693f3-39ef-4d77-adfd-31a859bfd373");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acc0208f-f7f9-4302-a526-3e2def6df98c");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "UserMovie");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "UserMovie",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserMovie_AppUserId",
                table: "UserMovie",
                column: "AppUserId");

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

            migrationBuilder.DropIndex(
                name: "IX_UserMovie_AppUserId",
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

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "UserMovie",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "UserMovie",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10fc5bf7-010a-4bac-8d34-cbb191fa563d", "8922732f-4213-4b25-9d59-5e70711b85b7", "SuperAdmin", "SUPERADMIN" },
                    { "43207836-6f1a-4714-8025-085570d13f97", "19397f71-8276-4f60-93d8-b14b957eaa4e", "Member", "MEMBER" },
                    { "bee5ee01-6754-487e-8ccd-197e74cce4b8", "74c2308f-20f9-47a1-b90e-5ad36856d4f9", "Admin", "ADMIN" },
                    { "c105d661-5c90-4c35-9a10-329491fb8dee", "81565c92-2491-4abc-9e2d-54c662c923ef", "SalesManager", "SALESMANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "City", "ConcurrencyStamp", "ConnectionId", "Country", "Email", "EmailConfirmed", "FullName", "ImageUrl", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId", "ZipCode" },
                values: new object[,]
                {
                    { "4581f6a1-2ab9-437d-a9c2-b2b22b39a44d", 0, null, null, null, "733ba30e-ec1a-4fc4-9f02-a19b51fdac1b", null, null, "salesmanager@gmail.com", true, "Sales Manager", null, false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAEJNzwzyfnaetYh/v2zZLw+VzyhYOjKwqo/o3Sn0KCmgDc+/4Tn5qFccOo3tZioqBFw==", "+0987654323", true, "9d057c6d-bd0e-4ecb-b4c4-14f6e5eba213", false, "salesmanager", "ver3", null },
                    { "984693f3-39ef-4d77-adfd-31a859bfd373", 0, null, null, null, "8161dfcb-9dde-45dd-9142-0cb6ba00900d", null, null, "admin@gmail.com", true, "Admin", null, false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEFIIGQHPAMTRXOJwyQ6wFS7KVGaz5VhP7+EGRpz/jTHap8rrhDtMfiYa6hjROE5Y9w==", "+1234567890", true, "679a300b-195d-4ab3-ac2e-cf6fb53f9dd4", false, "admin", "ver2", null },
                    { "acc0208f-f7f9-4302-a526-3e2def6df98c", 0, null, null, null, "5649fb04-6429-49e1-a9b1-ef5461099b03", null, null, "superadmin@gmail.com", true, "Super Admin", null, false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEG5prAXDd/DOg3Yw6qSx64/AN6xm/NCrkDeJRYFJmJbQxPKp+1sCemk0HtVsLpB0uw==", "+0987654321", true, "fcc7302d-94fd-42e6-b8f6-1c91add0241b", false, "superadmin", "ver1", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c105d661-5c90-4c35-9a10-329491fb8dee", "4581f6a1-2ab9-437d-a9c2-b2b22b39a44d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bee5ee01-6754-487e-8ccd-197e74cce4b8", "984693f3-39ef-4d77-adfd-31a859bfd373" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "10fc5bf7-010a-4bac-8d34-cbb191fa563d", "acc0208f-f7f9-4302-a526-3e2def6df98c" });

            migrationBuilder.CreateIndex(
                name: "IX_UserMovie_AppUserId1",
                table: "UserMovie",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_AspNetUsers_AppUserId1",
                table: "UserMovie",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
