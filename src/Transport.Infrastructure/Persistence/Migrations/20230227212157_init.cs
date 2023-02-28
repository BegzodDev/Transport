using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Transport.Infrastructure.Persistence.Migrations
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
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Count_Business_Class_Place = table.Column<int>(type: "integer", nullable: true),
                    Count_Econom_Class_Place = table.Column<int>(type: "integer", nullable: true),
                    Count_VIP_Class_Place = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airlines", x => x.Id);
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
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
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
                name: "ordersForAirlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Total_Sum = table.Column<double>(type: "double precision", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordersForAirlines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ordersForAirlines_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ordersForBuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Total_Sum = table.Column<double>(type: "double precision", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordersForBuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ordersForBuses_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ordersForTrains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Total_Sum = table.Column<double>(type: "double precision", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordersForTrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ordersForTrains_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "orderTicketAirlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderForAirlineId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderTicketAirlines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderTicketAirlines_ordersForAirlines_OrderForAirlineId",
                        column: x => x.OrderForAirlineId,
                        principalTable: "ordersForAirlines",
                        principalColumn: "Id");
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
                    table.ForeignKey(
                        name: "FK_bus_ordersForBuses_OrderForBusId",
                        column: x => x.OrderForBusId,
                        principalTable: "ordersForBuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "orderTicketTrains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrederForTrainId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderTicketTrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderTicketTrains_ordersForTrains_OrederForTrainId",
                        column: x => x.OrederForTrainId,
                        principalTable: "ordersForTrains",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "passengerForAirlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pasport_Series = table.Column<string>(type: "text", nullable: true),
                    SHJR = table.Column<string>(type: "text", nullable: true),
                    OrderTicketAirlineId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passengerForAirlines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_passengerForAirlines_orderTicketAirlines_OrderTicketAirline~",
                        column: x => x.OrderTicketAirlineId,
                        principalTable: "orderTicketAirlines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "passengerForTrains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pasport_Series = table.Column<string>(type: "text", nullable: true),
                    SHJR = table.Column<string>(type: "text", nullable: true),
                    OrderTicketTrainId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passengerForTrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_passengerForTrains_orderTicketTrains_OrderTicketTrainId",
                        column: x => x.OrderTicketTrainId,
                        principalTable: "orderTicketTrains",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ticketAirlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PassengerForAirlineId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticketAirlines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticketAirlines_passengerForAirlines_PassengerForAirlineId",
                        column: x => x.PassengerForAirlineId,
                        principalTable: "passengerForAirlines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ticketTrains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PassergerForTrainId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticketTrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticketTrains_passengerForTrains_PassergerForTrainId",
                        column: x => x.PassergerForTrainId,
                        principalTable: "passengerForTrains",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "placeAirlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Place_in_Ticket = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    AirlineId = table.Column<int>(type: "integer", nullable: true),
                    TicketAirlineId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_placeAirlines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_placeAirlines_airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "airlines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_placeAirlines_ticketAirlines_TicketAirlineId",
                        column: x => x.TicketAirlineId,
                        principalTable: "ticketAirlines",
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
                    TrainId = table.Column<int>(type: "integer", nullable: true),
                    TicketTrainId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_placeTrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_placeTrains_ticketTrains_TicketTrainId",
                        column: x => x.TicketTrainId,
                        principalTable: "ticketTrains",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_placeTrains_trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "trains",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bus_OrderForBusId",
                table: "bus",
                column: "OrderForBusId");

            migrationBuilder.CreateIndex(
                name: "IX_ordersForAirlines_UserId",
                table: "ordersForAirlines",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ordersForBuses_UserId",
                table: "ordersForBuses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ordersForTrains_UserId",
                table: "ordersForTrains",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_orderTicketAirlines_OrderForAirlineId",
                table: "orderTicketAirlines",
                column: "OrderForAirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_orderTicketTrains_OrederForTrainId",
                table: "orderTicketTrains",
                column: "OrederForTrainId");

            migrationBuilder.CreateIndex(
                name: "IX_passengerForAirlines_OrderTicketAirlineId",
                table: "passengerForAirlines",
                column: "OrderTicketAirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_passengerForTrains_OrderTicketTrainId",
                table: "passengerForTrains",
                column: "OrderTicketTrainId");

            migrationBuilder.CreateIndex(
                name: "IX_placeAirlines_AirlineId",
                table: "placeAirlines",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_placeAirlines_TicketAirlineId",
                table: "placeAirlines",
                column: "TicketAirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_placeTrains_TicketTrainId",
                table: "placeTrains",
                column: "TicketTrainId");

            migrationBuilder.CreateIndex(
                name: "IX_placeTrains_TrainId",
                table: "placeTrains",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_ticketAirlines_PassengerForAirlineId",
                table: "ticketAirlines",
                column: "PassengerForAirlineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ticketTrains_PassergerForTrainId",
                table: "ticketTrains",
                column: "PassergerForTrainId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "bus");

            migrationBuilder.DropTable(
                name: "placeAirlines");

            migrationBuilder.DropTable(
                name: "placeTrains");

            migrationBuilder.DropTable(
                name: "ordersForBuses");

            migrationBuilder.DropTable(
                name: "airlines");

            migrationBuilder.DropTable(
                name: "ticketAirlines");

            migrationBuilder.DropTable(
                name: "ticketTrains");

            migrationBuilder.DropTable(
                name: "trains");

            migrationBuilder.DropTable(
                name: "passengerForAirlines");

            migrationBuilder.DropTable(
                name: "passengerForTrains");

            migrationBuilder.DropTable(
                name: "orderTicketAirlines");

            migrationBuilder.DropTable(
                name: "orderTicketTrains");

            migrationBuilder.DropTable(
                name: "ordersForAirlines");

            migrationBuilder.DropTable(
                name: "ordersForTrains");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
