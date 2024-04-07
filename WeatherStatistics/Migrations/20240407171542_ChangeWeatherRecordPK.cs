using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WeatherStatistics.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWeatherRecordPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherRecords",
                table: "WeatherRecords");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WeatherRecords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherRecords",
                table: "WeatherRecords",
                columns: new[] { "Date", "Time" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherRecords",
                table: "WeatherRecords");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WeatherRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherRecords",
                table: "WeatherRecords",
                column: "Id");
        }
    }
}
