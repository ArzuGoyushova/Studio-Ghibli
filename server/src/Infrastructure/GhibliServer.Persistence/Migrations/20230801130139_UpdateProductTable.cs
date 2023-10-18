using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class UpdateProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbac9b11-6126-40e8-bcfe-7dde7a0becf6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b6462546-0df8-4688-bb66-71da3f5462b5", "1196eaf0-615e-42c7-928b-feaa196719e5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f2147f29-dbc8-4de1-998c-92f73fc33496", "6318dd0f-0bbc-4f5a-960d-f6ae58d9c015" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9fec31b0-51e0-4532-be43-53c17dbcd2f8", "c08c9aa8-4317-4a41-8374-be2f6f8f20a1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fec31b0-51e0-4532-be43-53c17dbcd2f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6462546-0df8-4688-bb66-71da3f5462b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2147f29-dbc8-4de1-998c-92f73fc33496");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1196eaf0-615e-42c7-928b-feaa196719e5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6318dd0f-0bbc-4f5a-960d-f6ae58d9c015");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c08c9aa8-4317-4a41-8374-be2f6f8f20a1");

            migrationBuilder.AddColumn<string>(
                name: "Availability",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Tax",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "762d9aa5-0413-4f92-8e4c-22037bae6cdf", "7f2b1903-4615-45f4-8848-2e16c0d92805", "SuperAdmin", "SUPERADMIN" },
                    { "b382c59c-6dda-4c40-9030-9b8c6618d5bd", "02e55140-48f4-4fff-80eb-c37fb2b3a604", "SalesManager", "SALESMANAGER" },
                    { "bb92fd17-10ca-4ec4-915c-f03f276782b3", "816bb202-5c63-48aa-abb6-4f7c51d5a3fa", "Member", "MEMBER" },
                    { "cb9a09c8-70f8-44bb-9ceb-7746b7e1fcb3", "0ff989d2-0f07-4fff-95c7-50c8809d1c45", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId" },
                values: new object[,]
                {
                    { "15f3acf0-2712-4bed-bd8c-6613926698e2", 0, "8c903f82-12be-4af9-bda0-ef570553662f", null, "admin@gmail.com", true, "Admin", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEKsuqgEhh89/VdAIn5OPkQ7mcapu+YDnYSUcKuylfJL9Xfei6T46sK41JhW2/0w4hA==", "+1234567890", true, "e3255102-e497-4a74-a2e3-fa016a68e912", false, "admin", "ver2" },
                    { "2463a881-1beb-4c17-99d6-eb211fd8b784", 0, "cd7b1af1-84b3-461a-97a8-5812103c291e", null, "salesmanager@gmail.com", true, "Sales Manager", false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAEHuqN2fFIcCEMKqB/idbNQ9mgKMK5x5qpMEM+EamFgtjK+PUhHkklI34SckoKPTDBA==", "+0987654323", true, "cebf7caf-6942-4724-893d-16612843fa0f", false, "salesmanager", "ver3" },
                    { "70ca44dd-1b90-4b26-b1aa-9e259d0c0b82", 0, "32e15a48-88ed-4760-8eb8-5ab10cbc5015", null, "superadmin@gmail.com", true, "Super Admin", false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEIyGQrt/oY+NbWYG+9enRlODEMKPlDe1+NCym1reHGQCG2T/CatI4GbkUvZ9vFo8bQ==", "+0987654321", true, "aedca48e-f4d4-4d0b-8022-6a87aca245a9", false, "superadmin", "ver1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cb9a09c8-70f8-44bb-9ceb-7746b7e1fcb3", "15f3acf0-2712-4bed-bd8c-6613926698e2" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b382c59c-6dda-4c40-9030-9b8c6618d5bd", "2463a881-1beb-4c17-99d6-eb211fd8b784" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "762d9aa5-0413-4f92-8e4c-22037bae6cdf", "70ca44dd-1b90-4b26-b1aa-9e259d0c0b82" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb92fd17-10ca-4ec4-915c-f03f276782b3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cb9a09c8-70f8-44bb-9ceb-7746b7e1fcb3", "15f3acf0-2712-4bed-bd8c-6613926698e2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b382c59c-6dda-4c40-9030-9b8c6618d5bd", "2463a881-1beb-4c17-99d6-eb211fd8b784" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "762d9aa5-0413-4f92-8e4c-22037bae6cdf", "70ca44dd-1b90-4b26-b1aa-9e259d0c0b82" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "762d9aa5-0413-4f92-8e4c-22037bae6cdf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b382c59c-6dda-4c40-9030-9b8c6618d5bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb9a09c8-70f8-44bb-9ceb-7746b7e1fcb3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15f3acf0-2712-4bed-bd8c-6613926698e2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2463a881-1beb-4c17-99d6-eb211fd8b784");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70ca44dd-1b90-4b26-b1aa-9e259d0c0b82");

            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Availability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9fec31b0-51e0-4532-be43-53c17dbcd2f8", "f994b8ba-cb49-4c6b-a4f2-7a943b51666a", "SalesManager", "SALESMANAGER" },
                    { "b6462546-0df8-4688-bb66-71da3f5462b5", "d81f055c-db1d-4141-9311-468635786728", "Admin", "ADMIN" },
                    { "dbac9b11-6126-40e8-bcfe-7dde7a0becf6", "5cf6e6a8-ca8b-4b9f-8bf6-ce51549837f4", "Member", "MEMBER" },
                    { "f2147f29-dbc8-4de1-998c-92f73fc33496", "8da64915-36f1-4fc1-a7e1-1bae55f319d9", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId" },
                values: new object[,]
                {
                    { "1196eaf0-615e-42c7-928b-feaa196719e5", 0, "3c03f89b-4596-43ff-ab72-cc8219bee5df", null, "admin@gmail.com", true, "Admin", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEDK7QZ9rQEp9c61usoupCAMwQdCdheq48+JKKzsQkwGPmcB6/cFn9yNRwORF4IfOyQ==", "+1234567890", true, "0df2138d-cb16-45fc-94c0-45d2e341d42b", false, "admin", "ver2" },
                    { "6318dd0f-0bbc-4f5a-960d-f6ae58d9c015", 0, "022cabe8-6be7-4b27-a130-c4eb2b3b423b", null, "superadmin@gmail.com", true, "Super Admin", false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEHUOAllnQe7tVcVGBORDXDQ10NRL+1evhdrKv7fGtvxJhhavpyeJ2TgtrkZG4+rBKg==", "+0987654321", true, "bf55ecef-3d7c-494a-8910-78ca1f5dfba0", false, "superadmin", "ver1" },
                    { "c08c9aa8-4317-4a41-8374-be2f6f8f20a1", 0, "364fe52c-673a-406a-9901-4c2f36a8d2dd", null, "salesmanager@gmail.com", true, "Sales Manager", false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAEInPtoYJLogrM54A//RQGlv4HJCF8U3Pxbc8pv+zBHSkrNhfcDfT4bahIjtWXEdRCQ==", "+0987654323", true, "a5dc605a-db2b-4f25-b017-9284a058ca69", false, "salesmanager", "ver3" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b6462546-0df8-4688-bb66-71da3f5462b5", "1196eaf0-615e-42c7-928b-feaa196719e5" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f2147f29-dbc8-4de1-998c-92f73fc33496", "6318dd0f-0bbc-4f5a-960d-f6ae58d9c015" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9fec31b0-51e0-4532-be43-53c17dbcd2f8", "c08c9aa8-4317-4a41-8374-be2f6f8f20a1" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId",
                unique: true);
        }
    }
}
