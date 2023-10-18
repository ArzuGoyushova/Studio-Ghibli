using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class UpdateMoviesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "763af52e-880d-47a7-820a-fb849e7426de");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f82f3d30-8171-41b4-9e56-365258d9dc72", "4a734431-562d-41e7-9604-3e576c66c1bd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "589d4fe4-4eb6-41a2-a4d8-84624ec4e439", "7fb50cda-1672-4132-9dbf-05a7a1fc421f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94157c34-ed5c-4111-a511-5f991105f844", "c61e35ed-0584-4ded-bd7d-985939d71354" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "589d4fe4-4eb6-41a2-a4d8-84624ec4e439");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94157c34-ed5c-4111-a511-5f991105f844");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f82f3d30-8171-41b4-9e56-365258d9dc72");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a734431-562d-41e7-9604-3e576c66c1bd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fb50cda-1672-4132-9dbf-05a7a1fc421f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c61e35ed-0584-4ded-bd7d-985939d71354");

            migrationBuilder.AddColumn<double>(
                name: "ImdbRating",
                table: "Movies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17aa952e-05d6-4f4e-97f9-cd2b14bfcb8a", "839a7356-7f0d-483f-8ffc-af07a53f7b84", "Member", "MEMBER" },
                    { "4c557dfc-c6a4-4e5c-8e1a-af0ac82b6a31", "c6a98855-31a4-40fa-ab08-b8bd05ba3e8c", "Admin", "ADMIN" },
                    { "70442834-1556-42c4-805d-e0d9456bca90", "6f9a9402-0e17-4602-aa93-d22a440a84d1", "SuperAdmin", "SUPERADMIN" },
                    { "9e12b11a-1ca1-4654-821c-059f0b51e3b4", "75ed0281-5004-44f1-9526-9c3a087c2546", "SalesManager", "SALESMANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId" },
                values: new object[,]
                {
                    { "d77d3676-3cd9-4037-a9c5-5a53597426b9", 0, "a6e6c4aa-522c-4fc3-b7d7-4bb18d34e989", null, "superadmin@gmail.com", true, "Super Admin", false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEPL0r42f1N52HInZgOI/6HGKkVxy9opVnCw8ShcjbG47cUofbOqOYygVw+2pYQhDbQ==", "+0987654321", true, "002b4093-498d-4384-83bd-5768f0cd1c81", false, "superadmin", "ver1" },
                    { "d98dbc14-9c28-4a27-93a5-02b94f285d8a", 0, "434221d2-3fc1-4402-b358-9e18839edb34", null, "admin@gmail.com", true, "Admin", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEG/vYgDW+aSFU2QGoSklEiQiUMG7+i7szSl/GKs/WYOTjUhu8X/4SpRy+ePsCu2ttQ==", "+1234567890", true, "b492cc95-89a3-4658-ae68-9115ceb6d14d", false, "admin", "ver2" },
                    { "ef5bc954-631d-42e5-a6f8-7d49b3f95400", 0, "56ba3944-5497-469b-aff2-23af23eea050", null, "salesmanager@gmail.com", true, "Sales Manager", false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAENk9V7R6674g2UE5yo5BoMm540B2ElNJOQnkjTdHmCSsVXOBbTAfUVGNo/QtFI5Htg==", "+0987654323", true, "2f3693ab-7a3d-451d-a35a-8b0268f96619", false, "salesmanager", "ver3" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "70442834-1556-42c4-805d-e0d9456bca90", "d77d3676-3cd9-4037-a9c5-5a53597426b9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4c557dfc-c6a4-4e5c-8e1a-af0ac82b6a31", "d98dbc14-9c28-4a27-93a5-02b94f285d8a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9e12b11a-1ca1-4654-821c-059f0b51e3b4", "ef5bc954-631d-42e5-a6f8-7d49b3f95400" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17aa952e-05d6-4f4e-97f9-cd2b14bfcb8a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "70442834-1556-42c4-805d-e0d9456bca90", "d77d3676-3cd9-4037-a9c5-5a53597426b9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4c557dfc-c6a4-4e5c-8e1a-af0ac82b6a31", "d98dbc14-9c28-4a27-93a5-02b94f285d8a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9e12b11a-1ca1-4654-821c-059f0b51e3b4", "ef5bc954-631d-42e5-a6f8-7d49b3f95400" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c557dfc-c6a4-4e5c-8e1a-af0ac82b6a31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70442834-1556-42c4-805d-e0d9456bca90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e12b11a-1ca1-4654-821c-059f0b51e3b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d77d3676-3cd9-4037-a9c5-5a53597426b9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d98dbc14-9c28-4a27-93a5-02b94f285d8a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef5bc954-631d-42e5-a6f8-7d49b3f95400");

            migrationBuilder.DropColumn(
                name: "ImdbRating",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "589d4fe4-4eb6-41a2-a4d8-84624ec4e439", "d674409c-2608-44b6-a0f3-265770e550fb", "SuperAdmin", "SUPERADMIN" },
                    { "763af52e-880d-47a7-820a-fb849e7426de", "1aa1b484-1b1a-4003-af1c-881f491ac64d", "Member", "MEMBER" },
                    { "94157c34-ed5c-4111-a511-5f991105f844", "d890d7e6-6b43-440e-8b88-7d797693cc27", "Admin", "ADMIN" },
                    { "f82f3d30-8171-41b4-9e56-365258d9dc72", "192a74fe-58f8-4abd-bd2c-e7faa36653eb", "SalesManager", "SALESMANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerificationRequestId" },
                values: new object[,]
                {
                    { "4a734431-562d-41e7-9604-3e576c66c1bd", 0, "c367c39e-8100-45ac-a643-20934b932539", null, "salesmanager@gmail.com", true, "Sales Manager", false, false, null, "SALESMANAGER@GMAIL.COM", "SALESMANAGER", "111115", "AQAAAAEAACcQAAAAECV7pqkMRLFyl3iblAnosRyIcH7PNvsuXyNDmMwMm0ILjX1ToEYL9Ga5UOouVJ945g==", "+0987654323", true, "6369aa87-2a1a-4c60-b948-280a81612af8", false, "salesmanager", "ver3" },
                    { "7fb50cda-1672-4132-9dbf-05a7a1fc421f", 0, "a38a1b60-00a0-4f4a-8dd3-3871d723ba03", null, "superadmin@gmail.com", true, "Super Admin", false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "111113", "AQAAAAEAACcQAAAAEOBGdE2zecdVVvNgnKYmb8X1wS3LfIxmHr7NBhtclGTpDIzGOajZ3JpZkELxqa8GdA==", "+0987654321", true, "cc4014de-abd1-47e8-b1b9-d76faae8a2cb", false, "superadmin", "ver1" },
                    { "c61e35ed-0584-4ded-bd7d-985939d71354", 0, "2175db55-a109-4ab2-924f-a96a139a9355", null, "admin@gmail.com", true, "Admin", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "111114", "AQAAAAEAACcQAAAAEA6CUWUVVPyKaW6CiC5yjpKVekFg+EcO7EK806diD6bnImzcvUJk+Mw/bEpzcVE3PQ==", "+1234567890", true, "64081dde-2e72-41bb-ba70-6b642023e253", false, "admin", "ver2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f82f3d30-8171-41b4-9e56-365258d9dc72", "4a734431-562d-41e7-9604-3e576c66c1bd" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "589d4fe4-4eb6-41a2-a4d8-84624ec4e439", "7fb50cda-1672-4132-9dbf-05a7a1fc421f" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "94157c34-ed5c-4111-a511-5f991105f844", "c61e35ed-0584-4ded-bd7d-985939d71354" });
        }
    }
}
