using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class AddSubscriptionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "088b8458-4ca0-4411-935a-395f4bc77475");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "de036b5b-8eb7-496d-bba1-bb468d32e116", "02c2dc35-a5dd-419d-a909-882c5b9fabe0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4fe7b760-c94a-422d-a54c-b04661f9d733", "9481354c-cfec-479f-a8bc-36a9bbdd50ca" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d5612421-381c-4f69-8bc5-bfd0ffb254f6", "976b2592-6b9c-4c7e-b47a-f3a0d98e21ae" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fe7b760-c94a-422d-a54c-b04661f9d733");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5612421-381c-4f69-8bc5-bfd0ffb254f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de036b5b-8eb7-496d-bba1-bb468d32e116");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02c2dc35-a5dd-419d-a909-882c5b9fabe0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9481354c-cfec-479f-a8bc-36a9bbdd50ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "976b2592-6b9c-4c7e-b47a-f3a0d98e21ae");

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3933e18b-ad43-4c15-b4d0-1c43c37081d4", "c06745cd-26ad-431e-a63a-1fa8ec054c42", "SuperAdmin", "SUPERADMIN" },
                    { "413cc2c4-231d-4111-a4b6-a1bc30023c0d", "8c039c18-50b0-4023-9d4a-b3547933e288", "SalesManager", "SALESMANAGER" },
                    { "5eca27d1-0456-469e-84f1-21e744d28603", "cdcd8d16-de34-45cd-b0d2-591b99e7663c", "Member", "MEMBER" },
                    { "7ca709d8-ad4d-4091-b53e-626ded09e4e5", "0ab65c97-e953-4117-9c57-0c0cc7caa49b", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "City", "ConcurrencyStamp", "ConnectionId", "Country", "Email", "EmailConfirmed", "FullName", "ImageUrl", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId", "ZipCode" },
                values: new object[,]
                {
                    { "0a4d07e9-abc7-432d-bc39-9692fd8736f8", 0, null, null, null, "b5fcac57-b7a2-4c6c-ac6b-e4d0126920d6", null, null, "salesmanager@gmail.com", true, "Sales Manager", "salesmanager.jpg", false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAELzZ8jm5a13x2NOT4CMCfQvbIH3+sdsFqCWMUSeYYKUNnIRwD7iIEEZTNj9kn+cXfw==", "+0987654323", true, "25bc0f78-5eb0-4557-916c-271d57af0632", false, "salesmanager", "ver3", null },
                    { "c247aef9-6e4f-40f3-bc03-421219638cf9", 0, null, null, null, "0b7d1516-8082-4b1f-9990-9718863722b6", null, null, "superadmin@gmail.com", true, "Super Admin", "superadmin.jpg", false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAENn6VLtG+RB14rekox1TqfG2SbW7by80+q5ejnFMlNxa42im6Humd68jIFinZXxu3Q==", "+0987654321", true, "c43c4173-3d17-4e12-977c-cb1ba4a84d4c", false, "superadmin", "ver1", null },
                    { "ed0f470f-3a85-41d0-9672-21ddcfd9a7aa", 0, null, null, null, "c68a28cc-8c68-49b0-9fa4-e83c5cab0b8a", null, null, "admin@gmail.com", true, "Admin", "admin.jpg", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEPh0N7m+kGbk+4OiRnEpMrOy5IW5WjyP2KPNoh6dEd+78EA/ppmSsXFiKmQx94RaPQ==", "+1234567890", true, "b9e20946-19e1-4fb0-b345-755dec57036e", false, "admin", "ver2", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "413cc2c4-231d-4111-a4b6-a1bc30023c0d", "0a4d07e9-abc7-432d-bc39-9692fd8736f8" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3933e18b-ad43-4c15-b4d0-1c43c37081d4", "c247aef9-6e4f-40f3-bc03-421219638cf9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7ca709d8-ad4d-4091-b53e-626ded09e4e5", "ed0f470f-3a85-41d0-9672-21ddcfd9a7aa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5eca27d1-0456-469e-84f1-21e744d28603");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "413cc2c4-231d-4111-a4b6-a1bc30023c0d", "0a4d07e9-abc7-432d-bc39-9692fd8736f8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3933e18b-ad43-4c15-b4d0-1c43c37081d4", "c247aef9-6e4f-40f3-bc03-421219638cf9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7ca709d8-ad4d-4091-b53e-626ded09e4e5", "ed0f470f-3a85-41d0-9672-21ddcfd9a7aa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3933e18b-ad43-4c15-b4d0-1c43c37081d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "413cc2c4-231d-4111-a4b6-a1bc30023c0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ca709d8-ad4d-4091-b53e-626ded09e4e5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a4d07e9-abc7-432d-bc39-9692fd8736f8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c247aef9-6e4f-40f3-bc03-421219638cf9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed0f470f-3a85-41d0-9672-21ddcfd9a7aa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "088b8458-4ca0-4411-935a-395f4bc77475", "47a05e73-ef8a-463d-a0c0-64087a54325c", "Member", "MEMBER" },
                    { "4fe7b760-c94a-422d-a54c-b04661f9d733", "6f28d1ba-e599-4e08-b824-874e4620c6f0", "Admin", "ADMIN" },
                    { "d5612421-381c-4f69-8bc5-bfd0ffb254f6", "dd6e0c78-92b5-46d2-a9e5-ac9dee1e8139", "SalesManager", "SALESMANAGER" },
                    { "de036b5b-8eb7-496d-bba1-bb468d32e116", "bcd950db-1221-41e1-b741-2f11a8377f26", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "City", "ConcurrencyStamp", "ConnectionId", "Country", "Email", "EmailConfirmed", "FullName", "ImageUrl", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId", "ZipCode" },
                values: new object[,]
                {
                    { "02c2dc35-a5dd-419d-a909-882c5b9fabe0", 0, null, null, null, "5d0b203e-41b1-4206-ae1e-98af2995fd07", null, null, "superadmin@gmail.com", true, "Super Admin", "superadmin.jpg", false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEO51RFNSANs0HXat0cM9dqWLCZ/uqIt/KTR0oRE+OYpv5XBm1PeXb+tdtqEWfwvIXg==", "+0987654321", true, "81735b37-9cd6-49fc-b25e-a59d17c5d4ef", false, "superadmin", "ver1", null },
                    { "9481354c-cfec-479f-a8bc-36a9bbdd50ca", 0, null, null, null, "d455d805-fc0c-4d93-b6d0-d5d5b04f32ca", null, null, "admin@gmail.com", true, "Admin", "admin.jpg", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEEV1MOjpe4xfIWxWIk6H3D8AOIdL3MZasHwf+mnfYsw+36P4rXveXtYPzjOqAXqxNQ==", "+1234567890", true, "a63de7ce-d30b-4280-bc87-97e3eb102c8b", false, "admin", "ver2", null },
                    { "976b2592-6b9c-4c7e-b47a-f3a0d98e21ae", 0, null, null, null, "f64b1941-d063-48e4-bada-031a5a7e08bd", null, null, "salesmanager@gmail.com", true, "Sales Manager", "salesmanager.jpg", false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAECfXogPh3bxTNgfuCdYs03bIZBrCS/XwYn4HWf/YqLQ75svxERZ6YvKD6tsGx3t5qQ==", "+0987654323", true, "d8b63a14-0236-4322-a022-7037f30291ec", false, "salesmanager", "ver3", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "de036b5b-8eb7-496d-bba1-bb468d32e116", "02c2dc35-a5dd-419d-a909-882c5b9fabe0" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4fe7b760-c94a-422d-a54c-b04661f9d733", "9481354c-cfec-479f-a8bc-36a9bbdd50ca" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d5612421-381c-4f69-8bc5-bfd0ffb254f6", "976b2592-6b9c-4c7e-b47a-f3a0d98e21ae" });
        }
    }
}
