using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhibliServer.Persistence.Migrations
{
    public partial class AddCharactersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MovieId",
                table: "Characters",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

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
    }
}
