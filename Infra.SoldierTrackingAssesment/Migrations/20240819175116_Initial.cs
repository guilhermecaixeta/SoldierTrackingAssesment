using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Infra.SoldierTrackingAssesment.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseSensor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseSensor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SensorId = table.Column<int>(type: "int", nullable: false),
                    Coordinates = table.Column<Point>(type: "geography", nullable: false),
                    GeolocalizationSensorId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_BaseSensor_GeolocalizationSensorId",
                        column: x => x.GeolocalizationSensorId,
                        principalTable: "BaseSensor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_BaseSensor_SensorId",
                        column: x => x.SensorId,
                        principalTable: "BaseSensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Soldiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    RankId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soldiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Soldiers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Soldiers_Ranks_RankId",
                        column: x => x.RankId,
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoldierTraining",
                columns: table => new
                {
                    SoldiersId = table.Column<int>(type: "int", nullable: false),
                    TrainingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldierTraining", x => new { x.SoldiersId, x.TrainingsId });
                    table.ForeignKey(
                        name: "FK_SoldierTraining_Soldiers_SoldiersId",
                        column: x => x.SoldiersId,
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoldierTraining_Trainings_TrainingsId",
                        column: x => x.TrainingsId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoldierId = table.Column<int>(type: "int", nullable: false),
                    SensorId = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingDatas_BaseSensor_SensorId",
                        column: x => x.SensorId,
                        principalTable: "BaseSensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingDatas_Soldiers_SoldierId",
                        column: x => x.SoldierId,
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingDatas_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Guid",
                table: "Countries",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_GeolocalizationSensorId",
                table: "Locations",
                column: "GeolocalizationSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Guid",
                table: "Locations",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_SensorId",
                table: "Locations",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_Guid",
                table: "Ranks",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_CountryId",
                table: "Soldiers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_Guid",
                table: "Soldiers",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_RankId",
                table: "Soldiers",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldierTraining_TrainingsId",
                table: "SoldierTraining",
                column: "TrainingsId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDatas_Guid",
                table: "TrainingDatas",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDatas_SensorId_SoldierId_TrainingId",
                table: "TrainingDatas",
                columns: new[] { "SensorId", "SoldierId", "TrainingId" });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDatas_SoldierId",
                table: "TrainingDatas",
                column: "SoldierId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDatas_TrainingId",
                table: "TrainingDatas",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_Guid",
                table: "Trainings",
                column: "Guid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "SoldierTraining");

            migrationBuilder.DropTable(
                name: "TrainingDatas");

            migrationBuilder.DropTable(
                name: "BaseSensor");

            migrationBuilder.DropTable(
                name: "Soldiers");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Ranks");
        }
    }
}
