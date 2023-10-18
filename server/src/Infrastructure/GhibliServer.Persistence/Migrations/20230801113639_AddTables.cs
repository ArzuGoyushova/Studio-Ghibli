using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0c2f43c-6c21-4d1d-b9a5-ec5abf1320d4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a7e68797-8604-4489-a927-701f32fc86ea", "100ed727-c09c-4e8c-b9d0-5cd014814901" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ba471750-f051-4599-9a59-18a55567c615", "16988c1f-0675-4837-8d1b-05ed6f30d65d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1436451b-4596-4106-b543-c621c3445596", "fe8d7fe8-2150-493f-841d-d78b57e4601e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1436451b-4596-4106-b543-c621c3445596");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7e68797-8604-4489-a927-701f32fc86ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba471750-f051-4599-9a59-18a55567c615");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "100ed727-c09c-4e8c-b9d0-5cd014814901");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16988c1f-0675-4837-8d1b-05ed6f30d65d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe8d7fe8-2150-493f-841d-d78b57e4601e");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "1436451b-4596-4106-b543-c621c3445596", "f4382db4-2967-4a43-a96b-3324f5b82835", "SuperAdmin", "SUPERADMIN" },
                    { "a7e68797-8604-4489-a927-701f32fc86ea", "e2c38431-1fa6-4618-92a0-bfc2f08f1d14", "Admin", "ADMIN" },
                    { "ba471750-f051-4599-9a59-18a55567c615", "166cba68-176a-4521-962d-3276fee15f71", "SalesManager", "SALESMANAGER" },
                    { "c0c2f43c-6c21-4d1d-b9a5-ec5abf1320d4", "550e290f-c146-413d-9839-f829e64e8a98", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId" },
                values: new object[,]
                {
                    { "100ed727-c09c-4e8c-b9d0-5cd014814901", 0, "6442b42d-c639-4d4a-ac20-755ec8886884", null, "admin@gmail.com", true, "Admin", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEBZH17jeUGzpq47YQt+ZZciU7CRBiEvWj4U6qdXhpldDyV5p+QGhiB7eCtdSIgzm3g==", "+1234567890", true, "72a2915f-d8b7-483c-a61d-20d37eeb2130", false, "admin", "ver2" },
                    { "16988c1f-0675-4837-8d1b-05ed6f30d65d", 0, "22126707-dcc8-43fa-8d39-b20b3bc1b2ef", null, "salesmanager@gmail.com", true, "Sales Manager", false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAEIB96r7f6XZdOTv7Tbu3X9K7/FiaIXUJaLEtI0sRX/ssDRJP70rTMOtpxKnpD6QF6g==", "+0987654323", true, "4c5a8473-1f9e-46fb-9975-4c2ba15684fa", false, "salesmanager", "ver3" },
                    { "fe8d7fe8-2150-493f-841d-d78b57e4601e", 0, "03ce3a53-6e74-490f-8aff-8a658ca1a3de", null, "superadmin@gmail.com", true, "Super Admin", false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEB5t19By3vswm396OiRNJo68H8wmf9NxFNPQbbjpS20CmQWX9W5lV8aZ6k8cF8WH8A==", "+0987654321", true, "7ee18692-010f-423b-a3bc-3d459fc49254", false, "superadmin", "ver1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a7e68797-8604-4489-a927-701f32fc86ea", "100ed727-c09c-4e8c-b9d0-5cd014814901" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ba471750-f051-4599-9a59-18a55567c615", "16988c1f-0675-4837-8d1b-05ed6f30d65d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1436451b-4596-4106-b543-c621c3445596", "fe8d7fe8-2150-493f-841d-d78b57e4601e" });
        }
    }
}
