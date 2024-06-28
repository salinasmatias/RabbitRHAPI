using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    job_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    job_title = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: false),
                    min_salary = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    max_salary = table.Column<decimal>(type: "decimal(8,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__jobs__6E32B6A5AE934EA7", x => x.job_id);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    region_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    region_name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__regions__01146BAE0B3A2A43", x => x.region_id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    country_id = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    country_name = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    region_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__countrie__7E8CD055E43A25A5", x => x.country_id);
                    table.ForeignKey(
                        name: "FK__countries__regio__3B75D760",
                        column: x => x.region_id,
                        principalTable: "regions",
                        principalColumn: "region_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    location_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street_address = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    postal_code = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    city = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    state_province = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    country_id = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__location__771831EAE113FD50", x => x.location_id);
                    table.ForeignKey(
                        name: "FK__locations__count__412EB0B6",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    location_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__departme__C2232422DED1761F", x => x.department_id);
                    table.ForeignKey(
                        name: "FK__departmen__locat__48CFD27E",
                        column: x => x.location_id,
                        principalTable: "locations",
                        principalColumn: "location_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    last_name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    hire_date = table.Column<DateTime>(type: "date", nullable: false),
                    job_id = table.Column<int>(type: "int", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    manager_id = table.Column<int>(type: "int", nullable: true),
                    department_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__employee__C52E0BA8FC38C7CD", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK__employees__depar__5070F446",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__employees__job_i__4F7CD00D",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "job_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__employees__manag__5165187F",
                        column: x => x.manager_id,
                        principalTable: "employees",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "dependents",
                columns: table => new
                {
                    dependent_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    relationship = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    employee_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__dependen__F25E28CEC94ABF7D", x => x.dependent_id);
                    table.ForeignKey(
                        name: "FK__dependent__emplo__5441852A",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_countries_region_id",
                table: "countries",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "IX_departments_location_id",
                table: "departments",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_dependents_employee_id",
                table: "dependents",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_department_id",
                table: "employees",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_job_id",
                table: "employees",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_manager_id",
                table: "employees",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_locations_country_id",
                table: "locations",
                column: "country_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dependents");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "regions");
        }
    }
}
