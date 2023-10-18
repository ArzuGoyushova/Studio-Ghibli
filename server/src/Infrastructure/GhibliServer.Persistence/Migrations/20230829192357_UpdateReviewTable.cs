using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class UpdateReviewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dcb6ccc-3c6a-4414-861a-b67cb6ca2235");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "451750c0-d760-48e1-bd46-ba72bfbf8c7f", "8941cf4d-58d8-42bc-9051-4c28bbf8d26b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5be2b684-df3d-424e-a211-f9500888af50", "c71dd372-688a-45d8-ba70-da69bafb481e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2cc5c84d-491d-46ac-88c6-55aab381f7ef", "ea4a98b4-86a0-4f5d-adff-7c93ffdd90e6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cc5c84d-491d-46ac-88c6-55aab381f7ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "451750c0-d760-48e1-bd46-ba72bfbf8c7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5be2b684-df3d-424e-a211-f9500888af50");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8941cf4d-58d8-42bc-9051-4c28bbf8d26b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c71dd372-688a-45d8-ba70-da69bafb481e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea4a98b4-86a0-4f5d-adff-7c93ffdd90e6");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Reviews",
                newName: "Username");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Reviews",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2cc5c84d-491d-46ac-88c6-55aab381f7ef", "1b312fe4-7b32-4230-bc99-d29fcd72486d", "Admin", "ADMIN" },
                    { "451750c0-d760-48e1-bd46-ba72bfbf8c7f", "1c5c3a18-84f0-4801-b345-1e04097ec465", "SalesManager", "SALESMANAGER" },
                    { "5be2b684-df3d-424e-a211-f9500888af50", "98999e42-36c6-4df2-84d1-53ea112075fa", "SuperAdmin", "SUPERADMIN" },
                    { "9dcb6ccc-3c6a-4414-861a-b67cb6ca2235", "5e994977-0c55-402a-960e-a3ad5751ed2a", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "City", "ConcurrencyStamp", "ConnectionId", "Country", "Email", "EmailConfirmed", "FullName", "ImageUrl", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId", "ZipCode" },
                values: new object[,]
                {
                    { "8941cf4d-58d8-42bc-9051-4c28bbf8d26b", 0, null, null, null, "e8da61e1-5939-4e5e-b64b-3079442546e3", null, null, "salesmanager@gmail.com", true, "Sales Manager", "salesmanager.jpg", false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAEP5nmv/4YIfIV2c/onRSo38Q/jA/QhMp+aVgcq/g0yx3mG//A4z5vHGQUQ1kuw4Fhg==", "+0987654323", true, "412af171-6de6-4b54-97f6-34c69b02e5d2", false, "salesmanager", "ver3", null },
                    { "c71dd372-688a-45d8-ba70-da69bafb481e", 0, null, null, null, "9d8c7e21-49b5-4e27-81d3-93c87f8919c4", null, null, "superadmin@gmail.com", true, "Super Admin", "superadmin.jpg", false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEFUbMqeLECnxZyJZp/XDjmQSo2cY2ISawaU2tFdjTyfkTzqZNqTWphu1cFINkunQgA==", "+0987654321", true, "f42a7948-cd68-4405-977f-475faa20d917", false, "superadmin", "ver1", null },
                    { "ea4a98b4-86a0-4f5d-adff-7c93ffdd90e6", 0, null, null, null, "53d77a88-2e43-4766-89be-c8fad42e22a0", null, null, "admin@gmail.com", true, "Admin", "admin.jpg", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAECP8/o/L79tWcRc1htOYbm5V2U6uGXpStval8UShBdJ07Mu2+HOP9E91iginb3CTlA==", "+1234567890", true, "b20fd96c-e66c-4998-93f1-d3a5c6d456dd", false, "admin", "ver2", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "451750c0-d760-48e1-bd46-ba72bfbf8c7f", "8941cf4d-58d8-42bc-9051-4c28bbf8d26b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5be2b684-df3d-424e-a211-f9500888af50", "c71dd372-688a-45d8-ba70-da69bafb481e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2cc5c84d-491d-46ac-88c6-55aab381f7ef", "ea4a98b4-86a0-4f5d-adff-7c93ffdd90e6" });
        }
    }
}
