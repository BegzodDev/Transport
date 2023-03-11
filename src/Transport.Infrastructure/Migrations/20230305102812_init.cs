using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Transport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Flight_From = table.Column<string>(type: "text", nullable: true),
                    Flight_For = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Count_Business_Class_Place = table.Column<int>(type: "integer", nullable: true),
                    Count_Econom_Class_Place = table.Column<int>(type: "integer", nullable: true),
                    Count_VIP_Class_Place = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airlines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    From = table.Column<string>(type: "text", nullable: true),
                    For = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: true),
                    OrderForBusId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    From = table.Column<string>(type: "text", nullable: true),
                    For = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Count_Business_Class_Place = table.Column<int>(type: "integer", nullable: true),
                    Count_Econom_Class_Place = table.Column<int>(type: "integer", nullable: true),
                    Count_VIP_Class_Place = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "placeAirlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Place_in_Ticket = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    AirlineId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_placeAirlines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_placeAirlines_airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "airlines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "placeTrains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Place_in_Ticket = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    TrainId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_placeTrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_placeTrains_trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "trains",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_users_Id",
                        column: x => x.Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticketBuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Sum = table.Column<double>(type: "double precision", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    BusId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticketBuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticketBuses_bus_BusId",
                        column: x => x.BusId,
                        principalTable: "bus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ticketBuses_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ticketAirlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dateTime = table.Column<DateOnly>(type: "date", nullable: true),
                    From = table.Column<string>(type: "text", nullable: true),
                    For = table.Column<string>(type: "text", nullable: true),
                    PasportSeries = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    PlaceAirlineId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticketAirlines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticketAirlines_placeAirlines_PlaceAirlineId",
                        column: x => x.PlaceAirlineId,
                        principalTable: "placeAirlines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ticketAirlines_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ticketTrains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PassergerForTrainId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    PlaceTrainId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticketTrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticketTrains_placeTrains_PlaceTrainId",
                        column: x => x.PlaceTrainId,
                        principalTable: "placeTrains",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ticketTrains_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_placeAirlines_AirlineId",
                table: "placeAirlines",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_placeTrains_TrainId",
                table: "placeTrains",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_ticketAirlines_PlaceAirlineId",
                table: "ticketAirlines",
                column: "PlaceAirlineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ticketAirlines_UserId",
                table: "ticketAirlines",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ticketBuses_BusId",
                table: "ticketBuses",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_ticketBuses_UserId",
                table: "ticketBuses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ticketTrains_PlaceTrainId",
                table: "ticketTrains",
                column: "PlaceTrainId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ticketTrains_UserId",
                table: "ticketTrains",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "ticketAirlines");

            migrationBuilder.DropTable(
                name: "ticketBuses");

            migrationBuilder.DropTable(
                name: "ticketTrains");

            migrationBuilder.DropTable(
                name: "placeAirlines");

            migrationBuilder.DropTable(
                name: "bus");

            migrationBuilder.DropTable(
                name: "placeTrains");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "airlines");

            migrationBuilder.DropTable(
                name: "trains");
        }
    }
}
