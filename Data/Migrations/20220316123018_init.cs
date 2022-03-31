using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    Categorytype = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    IdFunction = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.IdFunction);
                });

            migrationBuilder.CreateTable(
                name: "Organisme",
                columns: table => new
                {
                    OrganismeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisme", x => x.OrganismeId);
                });

            migrationBuilder.CreateTable(
                name: "typeRequests",
                columns: table => new
                {
                    RequestTypeId = table.Column<Guid>(nullable: false),
                    RequestTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeRequests", x => x.RequestTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryFunction",
                columns: table => new
                {
                    CategoryFunctionid = table.Column<Guid>(nullable: false),
                    Fk_IdFunction = table.Column<Guid>(nullable: false),
                    Fk_CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFunction", x => x.CategoryFunctionid);
                    table.ForeignKey(
                        name: "FK_CategoryFunction_Categories_Fk_CategoryId",
                        column: x => x.Fk_CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryFunction_Functions_Fk_IdFunction",
                        column: x => x.Fk_IdFunction,
                        principalTable: "Functions",
                        principalColumn: "IdFunction",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FunctionofUser",
                columns: table => new
                {
                    IdFunctionofUser = table.Column<Guid>(nullable: false),
                    Fk_User = table.Column<Guid>(nullable: false),
                    Fk_Function = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionofUser", x => x.IdFunctionofUser);
                    table.ForeignKey(
                        name: "FK_FunctionofUser_Functions_Fk_Function",
                        column: x => x.Fk_Function,
                        principalTable: "Functions",
                        principalColumn: "IdFunction",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<Guid>(nullable: false),
                    state = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    RequestDescription = table.Column<string>(nullable: true),
                    fk_Filliale = table.Column<Guid>(nullable: false),
                    Fk_User = table.Column<Guid>(nullable: false),
                    fk_RequestType = table.Column<Guid>(nullable: false),
                    fk_Organisme = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Requests_Organisme_fk_Organisme",
                        column: x => x.fk_Organisme,
                        principalTable: "Organisme",
                        principalColumn: "OrganismeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_typeRequests_fk_RequestType",
                        column: x => x.fk_RequestType,
                        principalTable: "typeRequests",
                        principalColumn: "RequestTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "typerequestCatg",
                columns: table => new
                {
                    typerequestCatgID = table.Column<Guid>(nullable: false),
                    Fk_CategoryId = table.Column<Guid>(nullable: false),
                    FK_typeRequest = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typerequestCatg", x => x.typerequestCatgID);
                    table.ForeignKey(
                        name: "FK_typerequestCatg_typeRequests_FK_typeRequest",
                        column: x => x.FK_typeRequest,
                        principalTable: "typeRequests",
                        principalColumn: "RequestTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_typerequestCatg_Categories_Fk_CategoryId",
                        column: x => x.Fk_CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pieces",
                columns: table => new
                {
                    PieceId = table.Column<Guid>(nullable: false),
                    path = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    fk_Request = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pieces", x => x.PieceId);
                    table.ForeignKey(
                        name: "FK_Pieces_Requests_fk_Request",
                        column: x => x.fk_Request,
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFunction_Fk_CategoryId",
                table: "CategoryFunction",
                column: "Fk_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFunction_Fk_IdFunction",
                table: "CategoryFunction",
                column: "Fk_IdFunction");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionofUser_Fk_Function",
                table: "FunctionofUser",
                column: "Fk_Function");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_fk_Request",
                table: "Pieces",
                column: "fk_Request");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_fk_Organisme",
                table: "Requests",
                column: "fk_Organisme");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_fk_RequestType",
                table: "Requests",
                column: "fk_RequestType");

            migrationBuilder.CreateIndex(
                name: "IX_typerequestCatg_FK_typeRequest",
                table: "typerequestCatg",
                column: "FK_typeRequest");

            migrationBuilder.CreateIndex(
                name: "IX_typerequestCatg_Fk_CategoryId",
                table: "typerequestCatg",
                column: "Fk_CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryFunction");

            migrationBuilder.DropTable(
                name: "FunctionofUser");

            migrationBuilder.DropTable(
                name: "Pieces");

            migrationBuilder.DropTable(
                name: "typerequestCatg");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Organisme");

            migrationBuilder.DropTable(
                name: "typeRequests");
        }
    }
}
