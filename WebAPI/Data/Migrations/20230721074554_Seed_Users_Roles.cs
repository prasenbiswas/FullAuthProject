using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Seed_Users_Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bfd6530-b810-4464-9ad7-b2b7a3806c71", "5629e5d6-0e0c-4322-bf61-3d466276aa8c", "Admin", "ADMIN" },
                    { "f3b613cf-91a2-4d06-835b-59cd4e5f2ba7", "21353f25-5cc7-4e18-af28-8c7b6140c0fd", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e2318be1-de4c-443f-a838-0190b4f6ba7b", 0, "7e122015-d57a-4d72-ba81-f1e4d2a239f2", "User@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAEAACcQAAAAEND7lwxf/S+qdnDuOELZy3cv2VJA7TDO/wIK7HBfIb7IozRe1ieQMvReYDgjPlWl8w==", null, false, "13768a84-7012-421d-b0d4-079afaf83233", false, "User@gmail.com" },
                    { "f2a3afce-0795-4ab8-93ce-8059df50d3e8", 0, "fb5a17ad-ffbd-46cc-a36a-0c0ed6d0777a", "Admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEPGO8yC5VbmqRJ3+mTCa+4jw8ZWiP9hE5CnRbz2mp3+drD5Qd4u3TpP6d33VK6sE5g==", null, false, "82ff559a-6701-4602-8f15-2e9ed7edaac0", false, "Admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f3b613cf-91a2-4d06-835b-59cd4e5f2ba7", "e2318be1-de4c-443f-a838-0190b4f6ba7b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1bfd6530-b810-4464-9ad7-b2b7a3806c71", "f2a3afce-0795-4ab8-93ce-8059df50d3e8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f3b613cf-91a2-4d06-835b-59cd4e5f2ba7", "e2318be1-de4c-443f-a838-0190b4f6ba7b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1bfd6530-b810-4464-9ad7-b2b7a3806c71", "f2a3afce-0795-4ab8-93ce-8059df50d3e8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bfd6530-b810-4464-9ad7-b2b7a3806c71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3b613cf-91a2-4d06-835b-59cd4e5f2ba7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2318be1-de4c-443f-a838-0190b4f6ba7b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2a3afce-0795-4ab8-93ce-8059df50d3e8");
        }
    }
}
