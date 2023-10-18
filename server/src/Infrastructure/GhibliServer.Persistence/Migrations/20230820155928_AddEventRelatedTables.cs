using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class AddEventRelatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EventType",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxSeats",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Events",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ReservedSeats",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TicketOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketOrders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: true),
                    TicketOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketOrders_TicketOrderId",
                        column: x => x.TicketOrderId,
                        principalTable: "TicketOrders",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrders_AppUserId",
                table: "TicketOrders",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AppUserId",
                table: "Tickets",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketOrderId",
                table: "Tickets",
                column: "TicketOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "TicketOrders");

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

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventType",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MaxSeats",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ReservedSeats",
                table: "Events");

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
        }
    }
}
