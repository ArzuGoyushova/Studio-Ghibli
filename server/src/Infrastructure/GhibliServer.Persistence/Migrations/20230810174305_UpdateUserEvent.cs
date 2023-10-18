using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class UpdateUserEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_AspNetUsers_AppUserId1",
                table: "UserEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_Events_EventId",
                table: "UserEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_Movies_MovieId",
                table: "UserEvent");

            migrationBuilder.DropIndex(
                name: "IX_UserEvent_MovieId",
                table: "UserEvent");

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
                name: "MovieId",
                table: "UserEvent");

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                table: "UserEvent",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId1",
                table: "UserEvent",
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

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_AspNetUsers_AppUserId1",
                table: "UserEvent",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_Events_EventId",
                table: "UserEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_AspNetUsers_AppUserId1",
                table: "UserEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_Events_EventId",
                table: "UserEvent");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                table: "UserEvent",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId1",
                table: "UserEvent",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "MovieId",
                table: "UserEvent",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "IX_UserEvent_MovieId",
                table: "UserEvent",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_AspNetUsers_AppUserId1",
                table: "UserEvent",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_Events_EventId",
                table: "UserEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_Movies_MovieId",
                table: "UserEvent",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
