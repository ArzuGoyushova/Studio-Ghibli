using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class AddNewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f55988f4-25dd-4dc4-a0b9-d7a0c195ec9c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "59ac684e-296b-4799-be9d-006c8c32356d", "7a56aead-ea08-4ddd-84d5-e74efd7c3d0c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95b7126e-c65a-485b-9ae9-32189f896442", "97cf0443-994b-4ca2-9a97-69f15c7271ad" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d4436ac6-40de-40aa-871f-c88848092f6e", "d7715690-91f1-4f19-92b8-844dd3e02823" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59ac684e-296b-4799-be9d-006c8c32356d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95b7126e-c65a-485b-9ae9-32189f896442");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4436ac6-40de-40aa-871f-c88848092f6e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a56aead-ea08-4ddd-84d5-e74efd7c3d0c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97cf0443-994b-4ca2-9a97-69f15c7271ad");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7715690-91f1-4f19-92b8-844dd3e02823");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59ac684e-296b-4799-be9d-006c8c32356d", "773d123e-3b13-420b-adbd-8d56e28db9c4", "Admin", "ADMIN" },
                    { "95b7126e-c65a-485b-9ae9-32189f896442", "52e075a6-6a5e-43c8-9adb-cd50a4eb0395", "SuperAdmin", "SUPERADMIN" },
                    { "d4436ac6-40de-40aa-871f-c88848092f6e", "3587fe38-545a-4667-9adc-f32ae2b52745", "SalesManager", "SALESMANAGER" },
                    { "f55988f4-25dd-4dc4-a0b9-d7a0c195ec9c", "57629121-ea8d-445b-aa9e-c5f566f3416c", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId" },
                values: new object[,]
                {
                    { "7a56aead-ea08-4ddd-84d5-e74efd7c3d0c", 0, "7efa1d23-437c-4b9a-97d0-ec2f3a860a6e", null, "admin@gmail.com", true, "Admin", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEKfvwsSz5seVv+nxaVcfwFpQ8HpdgdCAMlAhSBM9LD49RSvwOd+Z5EPXVYlskdhDkQ==", "+1234567890", true, "d6d6f899-6e85-45e3-8849-021b95841b5d", false, "admin", "ver2" },
                    { "97cf0443-994b-4ca2-9a97-69f15c7271ad", 0, "b0a31726-b08c-4802-9d1e-48ac94d69856", null, "superadmin@gmail.com", true, "Super Admin", false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEFeGPO2mRLag5xqZyYfpHAhwx9AlzkbpJxhpRPRr4Pm4xy5QSxmc6c05Url9zddVnw==", "+0987654321", true, "54fd85ef-08d6-482a-be33-94aef08c9e0a", false, "superadmin", "ver1" },
                    { "d7715690-91f1-4f19-92b8-844dd3e02823", 0, "c16bea19-875e-4075-a6b8-7287d437e607", null, "salesmanager@gmail.com", true, "Sales Manager", false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAEGXVlo2CJsHbBLtM9hxRt1ZMjODRGTHIf2rSzAZVB/A++YB2ibnA63bMaeq/dsB41w==", "+0987654323", true, "6f0b2f02-a222-4cec-aed2-573e07381b24", false, "salesmanager", "ver3" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "59ac684e-296b-4799-be9d-006c8c32356d", "7a56aead-ea08-4ddd-84d5-e74efd7c3d0c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "95b7126e-c65a-485b-9ae9-32189f896442", "97cf0443-994b-4ca2-9a97-69f15c7271ad" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d4436ac6-40de-40aa-871f-c88848092f6e", "d7715690-91f1-4f19-92b8-844dd3e02823" });
        }
    }
}
