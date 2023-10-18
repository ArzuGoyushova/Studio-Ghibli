using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class UpdateUserEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_AspNetUsers_AppUserId1",
                table: "UserEvent");

            migrationBuilder.DropIndex(
                name: "IX_UserEvent_AppUserId1",
                table: "UserEvent");

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

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "UserEvent");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "UserEvent",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3acad3ea-6cc7-4b28-a656-71bb01b7fd23", "1d72c3cb-4294-44cb-a003-d0b9e9476237", "Member", "MEMBER" },
                    { "43eb90d9-d97d-45a9-a12f-dfd62f502ace", "d8d2b9ed-1160-4844-83aa-8da6ff4427b1", "SuperAdmin", "SUPERADMIN" },
                    { "98dba622-24f8-43f6-bd0f-8f9939ff51a9", "3c3eed97-45c5-40fe-bbd0-e88bd5833010", "Admin", "ADMIN" },
                    { "cbd5a942-7f67-413d-898a-c24f1b4a4252", "02ba322f-2079-4c4c-a302-1c2744093df7", "SalesManager", "SALESMANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "City", "ConcurrencyStamp", "ConnectionId", "Country", "Email", "EmailConfirmed", "FullName", "ImageUrl", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId", "ZipCode" },
                values: new object[,]
                {
                    { "0208aecd-8207-412b-89d5-bdcc8aa75d88", 0, null, null, null, "2ff451b5-494a-4337-9432-7b67b1126027", null, null, "admin@gmail.com", true, "Admin", null, false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEDxO2UaLO3S9P/lyTm4Mq4uFi0H9MEl1I6yrsq//r4kzXHUl3uWaSOiRPPm4aQ20kA==", "+1234567890", true, "94613ff3-6f68-4df7-b671-91ad3ff4f599", false, "admin", "ver2", null },
                    { "1c27d334-1728-4bec-8ed8-0ce5cba99699", 0, null, null, null, "bc4fdc13-4ed5-4af5-8e92-1506c2450f9a", null, null, "salesmanager@gmail.com", true, "Sales Manager", null, false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAED2MpjyygC3VulfOZdrVlYTtmvQo6pXXyIxlSp+GqeKbiPy5OOiwjPt/+9XsR8C5+Q==", "+0987654323", true, "bd46849a-b9ff-4225-a0aa-72647d65b3ac", false, "salesmanager", "ver3", null },
                    { "93301024-8108-4723-80f0-f638f43e2171", 0, null, null, null, "8eb3a151-1833-493d-9585-8ce1f9ff35eb", null, null, "superadmin@gmail.com", true, "Super Admin", null, false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEGte78nI3yl0L+cCENScP2I87zdZtf9ZO8lWHg4tOo79DKsytURxAiAagRynMU+uqw==", "+0987654321", true, "ada031bb-d128-40ac-830d-dff395bb107b", false, "superadmin", "ver1", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "98dba622-24f8-43f6-bd0f-8f9939ff51a9", "0208aecd-8207-412b-89d5-bdcc8aa75d88" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cbd5a942-7f67-413d-898a-c24f1b4a4252", "1c27d334-1728-4bec-8ed8-0ce5cba99699" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "43eb90d9-d97d-45a9-a12f-dfd62f502ace", "93301024-8108-4723-80f0-f638f43e2171" });

            migrationBuilder.CreateIndex(
                name: "IX_UserEvent_AppUserId",
                table: "UserEvent",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_AspNetUsers_AppUserId",
                table: "UserEvent",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_AspNetUsers_AppUserId",
                table: "UserEvent");

            migrationBuilder.DropIndex(
                name: "IX_UserEvent_AppUserId",
                table: "UserEvent");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3acad3ea-6cc7-4b28-a656-71bb01b7fd23");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "98dba622-24f8-43f6-bd0f-8f9939ff51a9", "0208aecd-8207-412b-89d5-bdcc8aa75d88" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cbd5a942-7f67-413d-898a-c24f1b4a4252", "1c27d334-1728-4bec-8ed8-0ce5cba99699" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "43eb90d9-d97d-45a9-a12f-dfd62f502ace", "93301024-8108-4723-80f0-f638f43e2171" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43eb90d9-d97d-45a9-a12f-dfd62f502ace");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98dba622-24f8-43f6-bd0f-8f9939ff51a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbd5a942-7f67-413d-898a-c24f1b4a4252");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0208aecd-8207-412b-89d5-bdcc8aa75d88");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1c27d334-1728-4bec-8ed8-0ce5cba99699");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93301024-8108-4723-80f0-f638f43e2171");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "UserEvent",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "UserEvent",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserEvent_AppUserId1",
                table: "UserEvent",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_AspNetUsers_AppUserId1",
                table: "UserEvent",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
