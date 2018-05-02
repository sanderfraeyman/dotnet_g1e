using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dotnet_g1e.Data.Migrations
{
    public partial class fixRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "AccessCodes",
                columns: table => new
                {
                    AccessCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessCodes", x => x.AccessCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Breakoutboxes",
                columns: table => new
                {
                    BreakoutboxId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InActiveUse = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakoutboxes", x => x.BreakoutboxId);
                });

            migrationBuilder.CreateTable(
                name: "Classgroups",
                columns: table => new
                {
                    ClassGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassgroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classgroups", x => x.ClassGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Modifiers",
                columns: table => new
                {
                    ModifierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modifiers", x => x.ModifierId);
                });

            migrationBuilder.CreateTable(
                name: "PlayGroups",
                columns: table => new
                {
                    PlayGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayGroups", x => x.PlayGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Pupils",
                columns: table => new
                {
                    PupilId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupils", x => x.PupilId);
                });

            migrationBuilder.CreateTable(
                name: "Result<string>",
                columns: table => new
                {
                    ResultId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result<string>", x => x.ResultId);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    ActionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodeAccessCodeId = table.Column<int>(nullable: true),
                    Instruction = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.ActionId);
                    table.ForeignKey(
                        name: "FK_Actions_AccessCodes_CodeAccessCodeId",
                        column: x => x.CodeAccessCodeId,
                        principalTable: "AccessCodes",
                        principalColumn: "AccessCodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BreakoutboxAccessCode",
                columns: table => new
                {
                    AccessCodeId = table.Column<int>(nullable: false),
                    BreakoutboxId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakoutboxAccessCode", x => new { x.AccessCodeId, x.BreakoutboxId });
                    table.ForeignKey(
                        name: "FK_BreakoutboxAccessCode_AccessCodes_AccessCodeId",
                        column: x => x.AccessCodeId,
                        principalTable: "AccessCodes",
                        principalColumn: "AccessCodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreakoutboxAccessCode_Breakoutboxes_BreakoutboxId",
                        column: x => x.BreakoutboxId,
                        principalTable: "Breakoutboxes",
                        principalColumn: "BreakoutboxId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActiveSession = table.Column<bool>(nullable: false),
                    BreakoutboxId = table.Column<int>(nullable: true),
                    ClassGroupId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Sessions_Breakoutboxes_BreakoutboxId",
                        column: x => x.BreakoutboxId,
                        principalTable: "Breakoutboxes",
                        principalColumn: "BreakoutboxId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_Classgroups_ClassGroupId",
                        column: x => x.ClassGroupId,
                        principalTable: "Classgroups",
                        principalColumn: "ClassGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassGroupPupil",
                columns: table => new
                {
                    ClassGroupId = table.Column<int>(nullable: false),
                    PupilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassGroupPupil", x => new { x.ClassGroupId, x.PupilId });
                    table.ForeignKey(
                        name: "FK_ClassGroupPupil_Classgroups_ClassGroupId",
                        column: x => x.ClassGroupId,
                        principalTable: "Classgroups",
                        principalColumn: "ClassGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassGroupPupil_Pupils_PupilId",
                        column: x => x.PupilId,
                        principalTable: "Pupils",
                        principalColumn: "PupilId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayGroupPupil",
                columns: table => new
                {
                    PlayGroupId = table.Column<int>(nullable: false),
                    PupilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayGroupPupil", x => new { x.PlayGroupId, x.PupilId });
                    table.ForeignKey(
                        name: "FK_PlayGroupPupil_PlayGroups_PlayGroupId",
                        column: x => x.PlayGroupId,
                        principalTable: "PlayGroups",
                        principalColumn: "PlayGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayGroupPupil_Pupils_PupilId",
                        column: x => x.PupilId,
                        principalTable: "Pupils",
                        principalColumn: "PupilId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Course = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    InActiveUse = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ResultId = table.Column<int>(nullable: true),
                    TimeLimit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                    table.ForeignKey(
                        name: "FK_Exercises_Result<string>_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Result<string>",
                        principalColumn: "ResultId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BreakoutboxAction",
                columns: table => new
                {
                    BreakoutboxId = table.Column<int>(nullable: false),
                    ActionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakoutboxAction", x => new { x.BreakoutboxId, x.ActionId });
                    table.ForeignKey(
                        name: "FK_BreakoutboxAction_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "ActionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreakoutboxAction_Breakoutboxes_BreakoutboxId",
                        column: x => x.BreakoutboxId,
                        principalTable: "Breakoutboxes",
                        principalColumn: "BreakoutboxId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionPlayGroup",
                columns: table => new
                {
                    PlayGroupId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionPlayGroup", x => new { x.PlayGroupId, x.SessionId });
                    table.ForeignKey(
                        name: "FK_SessionPlayGroup_PlayGroups_PlayGroupId",
                        column: x => x.PlayGroupId,
                        principalTable: "PlayGroups",
                        principalColumn: "PlayGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionPlayGroup_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreakoutboxExercise",
                columns: table => new
                {
                    BreakoutboxId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakoutboxExercise", x => new { x.BreakoutboxId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_BreakoutboxExercise_Breakoutboxes_BreakoutboxId",
                        column: x => x.BreakoutboxId,
                        principalTable: "Breakoutboxes",
                        principalColumn: "BreakoutboxId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreakoutboxExercise_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseModifier",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false),
                    ModifierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseModifier", x => new { x.ExerciseId, x.ModifierId });
                    table.ForeignKey(
                        name: "FK_ExerciseModifier_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseModifier_Modifiers_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Modifiers",
                        principalColumn: "ModifierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_CodeAccessCodeId",
                table: "Actions",
                column: "CodeAccessCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_BreakoutboxAccessCode_BreakoutboxId",
                table: "BreakoutboxAccessCode",
                column: "BreakoutboxId");

            migrationBuilder.CreateIndex(
                name: "IX_BreakoutboxAction_ActionId",
                table: "BreakoutboxAction",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_BreakoutboxExercise_ExerciseId",
                table: "BreakoutboxExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassGroupPupil_PupilId",
                table: "ClassGroupPupil",
                column: "PupilId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseModifier_ModifierId",
                table: "ExerciseModifier",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ResultId",
                table: "Exercises",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroupPupil_PupilId",
                table: "PlayGroupPupil",
                column: "PupilId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionPlayGroup_SessionId",
                table: "SessionPlayGroup",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_BreakoutboxId",
                table: "Sessions",
                column: "BreakoutboxId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ClassGroupId",
                table: "Sessions",
                column: "ClassGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BreakoutboxAccessCode");

            migrationBuilder.DropTable(
                name: "BreakoutboxAction");

            migrationBuilder.DropTable(
                name: "BreakoutboxExercise");

            migrationBuilder.DropTable(
                name: "ClassGroupPupil");

            migrationBuilder.DropTable(
                name: "ExerciseModifier");

            migrationBuilder.DropTable(
                name: "PlayGroupPupil");

            migrationBuilder.DropTable(
                name: "SessionPlayGroup");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Modifiers");

            migrationBuilder.DropTable(
                name: "Pupils");

            migrationBuilder.DropTable(
                name: "PlayGroups");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "AccessCodes");

            migrationBuilder.DropTable(
                name: "Result<string>");

            migrationBuilder.DropTable(
                name: "Breakoutboxes");

            migrationBuilder.DropTable(
                name: "Classgroups");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
