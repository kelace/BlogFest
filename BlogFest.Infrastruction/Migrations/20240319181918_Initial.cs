using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogFest.Infrastruction.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "No");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncodedTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR No"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReactionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("cd6bf86c-5b4e-4fba-b4e8-f0c4a9897448")),
                    UserAuthId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsCommentAllowed = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsCreatePostAllowed = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    No = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR No"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 3, 19, 18, 19, 18, 310, DateTimeKind.Utc).AddTicks(9242))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentHTML = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleSlugify = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR No"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 3, 19, 18, 19, 18, 312, DateTimeKind.Utc).AddTicks(1913))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("d5bb19fd-b8eb-4452-aa5b-df346f21c7d7")),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Choosed = table.Column<bool>(type: "bit", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR No"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFiles_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR No"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 3, 19, 18, 19, 18, 312, DateTimeKind.Utc).AddTicks(7005))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryPosts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR No"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 3, 19, 18, 19, 18, 312, DateTimeKind.Utc).AddTicks(9521))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostFiles_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostFiles_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostReactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReactionTypeId = table.Column<int>(type: "int", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostReactions_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostReactions_ReactionType_ReactionTypeId",
                        column: x => x.ReactionTypeId,
                        principalTable: "ReactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("3e0afaa8-f82a-4b2b-8763-c54733aa423f"), "5d9cc1b3-f4e8-41e3-bb94-797ec6fe8f2d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("84bcbf0f-5fa9-42d6-a043-28b438a66a88"), 0, "75d73fe2-0eff-4c35-b075-5f18603481ca", "", true, false, null, null, "kitty", "AQAAAAIAAYagAAAAEI4vinoh+ho0F4plO+UOmbLDfqLOCq5AFwhaPeqLsEkFkH1uWGSzBlRfBejlbpbRWA==", null, false, "6ab55f36-fc94-425e-81aa-fea1da7b979c", false, "kitty" },
                    { new Guid("f142dc98-4019-460d-a647-07c71916a596"), 0, "121ac447-f1e4-41e2-b10e-1c524a8a3ba3", "", true, false, null, null, "admin", "AQAAAAIAAYagAAAAEF6KuH0DQha+5Kf+zkJKKi3v626EgGmHMr2yAYD2S9YGDsXNo81Zkw8J2380wYUGnw==", null, false, "12e4e489-7294-40a2-94a5-fcf2ff1cf916", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreated", "Enabled", "EncodedTitle", "Title" },
                values: new object[,]
                {
                    { new Guid("0aab209a-ac78-4d5b-95e7-35777d0d9db3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Languages", "Languages" },
                    { new Guid("55fcaf16-fa4b-40b0-8ee5-770e2ef3a5fe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Сooking", "Сooking" },
                    { new Guid("635cba95-c664-4737-a84b-70ef45f8ccd7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sport", "Sport" },
                    { new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Hobbie", "Hobbie" },
                    { new Guid("90be5de8-b658-423a-b7c6-48acec0fa330"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Music", "Music" },
                    { new Guid("ca5b5e71-b89e-4e7b-8836-5b6e459a5997"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Finance", "Finance" },
                    { new Guid("e21d36ce-8150-4b18-843f-c4daa580f3d1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Animals", "Animals" }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "DateCreated", "Name", "No", "Path", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("a7efe72c-314b-4331-82cd-10dba83a2286"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default-image-title-preview", 0, "Images\\default-image-title-preview.jpg", 1, null },
                    { new Guid("cfa390bf-0b35-4b13-9be9-5f439dd11687"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default-Image", 0, "Images\\default-user-img.jpeg", 0, null }
                });

            migrationBuilder.InsertData(
                table: "ReactionType",
                columns: new[] { "Id", "DateCreated", "Description", "No" },
                values: new object[,]
                {
                    { 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Like", 0 },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dislike", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Bio", "DateCreated", "FirstName", "IsCommentAllowed", "IsCreatePostAllowed", "LastName", "Name", "No", "UserAuthId" },
                values: new object[,]
                {
                    { new Guid("84bcbf0f-5fa9-42d6-a043-28b438a66a88"), true, "I am Martin Fowler: an author, speaker… essentially a loud-mouthed pundit on the topic of software development, primarily for Enterprise Applications", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin", true, true, "Fowler", "kitty", 0, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("f142dc98-4019-460d-a647-07c71916a596"), true, "Administrator of this wonderful site. I’m also a .net developer and write about clean architecture, domain driven design.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", true, true, "admin", "admin", 0, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("3e0afaa8-f82a-4b2b-8763-c54733aa423f"), new Guid("f142dc98-4019-460d-a647-07c71916a596") });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "ContentHTML", "ContentText", "PostStatus", "Slug", "Title", "TitleSlugify", "UserId" },
                values: new object[,]
                {
                    { new Guid("5b5264ae-b7d6-468d-ab25-7a0c6459f889"), "What Is Borscht? Borscht is a sour soup that is traditionally made with meat stock and boiled vegetables. The Ukrainian version, which features beets, is perhaps the most well known type — but varieties of borscht can be found throughout Central and Eastern Europe and Northern Asia. Borscht Ingredients These are the ingredients you’ll need to make this top-rated borscht recipe: Sausage: This Ukrainian borscht recipe starts with a pound of pork sausage. Vegetables: You’ll need beets, carrots, baking potatoes, cabbage, and an onion. Canned tomatoes: Use drained diced tomatoes and canned tomato paste. Vegetable oil: Cook the onion in oil. Water: You’ll need almost nine cups of water for this big-batch soup. Garlic: Three cloves of garlic add bold flavor. Sugar: A teaspoon of white sugar lends subtle sweetness. Seasonings: Season the borscht with salt and pepper to taste. Sour cream: Top the borscht with sour cream. Fresh herbs: Garnish the soup with fresh parsley or dill. How to Make Borscht You’ll find the full, step-by-step recipe below — but here’s a brief overview of what you can expect when you make Ukrainian borscht: Cook the sausage and set aside. Boil water, add the sausage, then add the vegetables and diced tomatoes. Cook the onion, stir in the tomato paste, and thin with water. Transfer to the pot. Add the garlic, cover, and turn off the heat. Stir in the sugar and seasonings. Ladle into bowls and garnish with sour cream and fresh herbs. Tip from recipe creator Patti: “This soup can be served vegetarian-style by omitting the sausage.” How to Store Borscht Store leftover borscht in an airtight container in the refrigerator for up to three days. Reheat in the microwave or on the stove. Can You Freeze Borscht? Yes, borscht freezes well! When you add it to your freezer-safe containers, make sure to leave an inch or two of space at the top to allow for expansion. Freeze the borscht for up to two months. Thaw in the refrigerator overnight, then reheat in the microwave or on the stove. Allrecipes Community Tips and Praise “This was the first time I've had borscht and now I see why so many people love it,” says one Allrecipes community member. “I can't believe how good it is.” “Just perfect,” raves Olechka. “Classic recipe, great taste, my favorite.” “BEST BORSCHT EVER,” according to KLaura Anderson-Bradfield. “I have made many different beet soup recipes over the years. The addition of an acidic ingredient (tomato) still allowed the beets to shine but removed the heavy, sometimes too earthy taste common to borscht.”", "What Is Borscht? Borscht is a sour soup that is traditionally made with meat stock and boiled vegetables. The Ukrainian version, which features beets, is perhaps the most well known type — but varieties of borscht can be found throughout Central and Eastern Europe and Northern Asia. Borscht Ingredients These are the ingredients you’ll need to make this top-rated borscht recipe: Sausage: This Ukrainian borscht recipe starts with a pound of pork sausage. Vegetables: You’ll need beets, carrots, baking potatoes, cabbage, and an onion. Canned tomatoes: Use drained diced tomatoes and canned tomato paste. Vegetable oil: Cook the onion in oil. Water: You’ll need almost nine cups of water for this big-batch soup. Garlic: Three cloves of garlic add bold flavor. Sugar: A teaspoon of white sugar lends subtle sweetness. Seasonings: Season the borscht with salt and pepper to taste. Sour cream: Top the borscht with sour cream. Fresh herbs: Garnish the soup with fresh parsley or dill. How to Make Borscht You’ll find the full, step-by-step recipe below — but here’s a brief overview of what you can expect when you make Ukrainian borscht: Cook the sausage and set aside. Boil water, add the sausage, then add the vegetables and diced tomatoes. Cook the onion, stir in the tomato paste, and thin with water. Transfer to the pot. Add the garlic, cover, and turn off the heat. Stir in the sugar and seasonings. Ladle into bowls and garnish with sour cream and fresh herbs. Tip from recipe creator Patti: “This soup can be served vegetarian-style by omitting the sausage.” How to Store Borscht Store leftover borscht in an airtight container in the refrigerator for up to three days. Reheat in the microwave or on the stove. Can You Freeze Borscht? Yes, borscht freezes well! When you add it to your freezer-safe containers, make sure to leave an inch or two of space at the top to allow for expansion. Freeze the borscht for up to two months. Thaw in the refrigerator overnight, then reheat in the microwave or on the stove. Allrecipes Community Tips and Praise “This was the first time I've had borscht and now I see why so many people love it,” says one Allrecipes community member. “I can't believe how good it is.” “Just perfect,” raves Olechka. “Classic recipe, great taste, my favorite.” “BEST BORSCHT EVER,” according to KLaura Anderson-Bradfield. “I have made many different beet soup recipes over the years. The addition of an acidic ingredient (tomato) still allowed the beets to shine but removed the heavy, sometimes too earthy taste common to borscht.”", "Published", "ukrainian-red-borscht-soup", "Ukrainian Red Borscht Soup", "ukrainian-red-borscht-soup", new Guid("f142dc98-4019-460d-a647-07c71916a596") },
                    { new Guid("62a37d63-b02a-4a2b-8b27-ed42ac3e6c4c"), "Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design. Diagram illustrating the components and relationships of Event Sourcing and Command Query Responsibility Segregation (CQRS) in an ASP.NET Core application. Basic CQRS Representation In this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions. Introduction to Event Sourcing Event Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state. What is CQRS? Command Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.", "Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design. Diagram illustrating the components and relationships of Event Sourcing and Command Query Responsibility Segregation (CQRS) in an ASP.NET Core application. Basic CQRS Representation In this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions. Introduction to Event Sourcing Event Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state. What is CQRS? Command Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.", "Hidden", "implementing-event-sourcing", "Implementing Event Sourcing", "implementing-event-sourcing", new Guid("f142dc98-4019-460d-a647-07c71916a596") },
                    { new Guid("766b7995-dd2c-42d3-b2aa-9b75de70a818"), "Dear reader, we will not sail on the surface, we will dive into this learning experience covering the Basics, until we touch the floor. In this journey we will figure out how well we know, the basic stuff we are used to when talking about .NET C#, so here’s my question to you, as an experienced sailor:\r\n\r\nEmployee employee1 = new(1, \"Alex Villegas C\");\r\nEmployee employee2 = employee1;\r\nemployee1 = null;\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nTake your time…\r\n\r\nWhen you create Objects you’re dealing with reference types.\r\n\r\nemployee2 = employee1;\r\nSo here (above), we will pass a reference (Not a value), in other words, now both variables share the same reference to a single object. So if you modify a property of employee2 this changes employee1 as well.\r\n\r\nSo, please see here (below):\r\n\r\nemployee1 = null;\r\nIf you pass a Null value to an object, just like in the example.\r\n\r\nWhat would happen? This is a great question…\r\n\r\nIt will remove the reference between employee1 and the actual Employee object. So our variable employee1 now has no reference, but what about employee2… let me ask you again:\r\n\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nWill the employee2 variable be Null as well?\r\n\r\nIf you thought employee2 value was Null you are wrong 👀\r\nRemember, Both variables have reference types, but each individual variable is different, and if we remove the reference from the first variable, this change will not affect the 2nd one.", "Dear reader, we will not sail on the surface, we will dive into this learning experience covering the Basics, until we touch the floor. In this journey we will figure out how well we know, the basic stuff we are used to when talking about .NET C#, so here’s my question to you, as an experienced sailor:\r\n\r\nEmployee employee1 = new(1, \"Alex Villegas C\");\r\nEmployee employee2 = employee1;\r\nemployee1 = null;\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nTake your time…\r\n\r\nWhen you create Objects you’re dealing with reference types.\r\n\r\nemployee2 = employee1;\r\nSo here (above), we will pass a reference (Not a value), in other words, now both variables share the same reference to a single object. So if you modify a property of employee2 this changes employee1 as well.\r\n\r\nSo, please see here (below):\r\n\r\nemployee1 = null;\r\nIf you pass a Null value to an object, just like in the example.\r\n\r\nWhat would happen? This is a great question…\r\n\r\nIt will remove the reference between employee1 and the actual Employee object. So our variable employee1 now has no reference, but what about employee2… let me ask you again:\r\n\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nWill the employee2 variable be Null as well?\r\n\r\nIf you thought employee2 value was Null you are wrong 👀\r\nRemember, Both variables have reference types, but each individual variable is different, and if we remove the reference from the first variable, this change will not affect the 2nd one.", "Published", "the-architecture-of-a-modern-startup", "The Architecture of a Modern Startup", "the-architecture-of-a-modern-startup", new Guid("84bcbf0f-5fa9-42d6-a043-28b438a66a88") },
                    { new Guid("a6470270-a886-4cbb-b5df-ffc779ee1dc9"), "In this deep dive, we’ll go through the API design, starting from the basics and advancing towards the best practices that define exceptional APIs.\r\n\r\nAs a developer, you’re likely familiar with many of these concepts, but I’ll provide a detailed explanation to deepen your understanding.\r\n\r\nAPI Design: An E-commerce Example\r\nLet’s consider an API for an e-commerce platform like Shopify, which, if you’re not familiar with is a well-known e-commerce platform that allows businesses to set up online stores.\r\n\r\nIn API design, we’re concerned with defining the inputs (like product details for a new product) and outputs (like the information returned when someone queries a product) of an API.\r\n\r\n\r\nThis means that we focus on the interface rather than the low-level implementation\r\n\r\nAPI Design and CRUD:\r\nSo, the focus is mainly on defining how the CRUD operations are exposed to the user or system interacting with your e-commerce API.\r\n\r\nCRUD Stands for Create, Read, Update, Delete. These are the basic operations of any data-driven application.\r\n\r\n\r\nFor example, to add a new product (Create), you would make a POST request to /api/products where the product details are sent in the request body.\r\n\r\nTo retrieve products (Read), you need to fetch data with a GET request from /products.\r\n\r\nFor updating product information (Update), we use PUT or PATCH requests to /products/:id, where id is the id of a product we need to update.\r\n\r\nRemoving is similar to updating; we make a DELETE request to /products/:id where id is the product we need to remove (Delete).", "In this deep dive, we’ll go through the API design, starting from the basics and advancing towards the best practices that define exceptional APIs.\r\n\r\nAs a developer, you’re likely familiar with many of these concepts, but I’ll provide a detailed explanation to deepen your understanding.\r\n\r\nAPI Design: An E-commerce Example\r\nLet’s consider an API for an e-commerce platform like Shopify, which, if you’re not familiar with is a well-known e-commerce platform that allows businesses to set up online stores.\r\n\r\nIn API design, we’re concerned with defining the inputs (like product details for a new product) and outputs (like the information returned when someone queries a product) of an API.\r\n\r\n\r\nThis means that we focus on the interface rather than the low-level implementation\r\n\r\nAPI Design and CRUD:\r\nSo, the focus is mainly on defining how the CRUD operations are exposed to the user or system interacting with your e-commerce API.\r\n\r\nCRUD Stands for Create, Read, Update, Delete. These are the basic operations of any data-driven application.\r\n\r\n\r\nFor example, to add a new product (Create), you would make a POST request to /api/products where the product details are sent in the request body.\r\n\r\nTo retrieve products (Read), you need to fetch data with a GET request from /products.\r\n\r\nFor updating product information (Update), we use PUT or PATCH requests to /products/:id, where id is the id of a product we need to update.\r\n\r\nRemoving is similar to updating; we make a DELETE request to /products/:id where id is the product we need to remove (Delete).", "Published", "api-design-101-from-basics-to-best-practices", "API Design 101: From Basics to Best Practices", "api-design-101-from-basics-to-best-practices", new Guid("f142dc98-4019-460d-a647-07c71916a596") },
                    { new Guid("aac2e4e5-4372-4571-9bb7-9f3918d02013"), "Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design. Diagram illustrating the components and relationships of Event Sourcing and Command Query Responsibility Segregation (CQRS) in an ASP.NET Core application. Basic CQRS Representation In this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions. Introduction to Event Sourcing Event Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state. What is CQRS? Command Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.", "Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design. Diagram illustrating the components and relationships of Event Sourcing and Command Query Responsibility Segregation (CQRS) in an ASP.NET Core application. Basic CQRS Representation In this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions. Introduction to Event Sourcing Event Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state. What is CQRS? Command Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.", "Draft", "implementing-event-sourcing-2", "Implementing Event Sourcing", "implementing-event-sourcing", new Guid("f142dc98-4019-460d-a647-07c71916a596") },
                    { new Guid("ec5f0508-ba97-471d-abae-101d885ab075"), "Dear reader, we will not sail on the surface, we will dive into this learning experience covering the Basics, until we touch the floor. In this journey we will figure out how well we know, the basic stuff we are used to when talking about .NET C#, so here’s my question to you, as an experienced sailor:\r\n\r\nEmployee employee1 = new(1, \"Alex Villegas C\");\r\nEmployee employee2 = employee1;\r\nemployee1 = null;\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nTake your time…\r\n\r\nWhen you create Objects you’re dealing with reference types.\r\n\r\nemployee2 = employee1;\r\nSo here (above), we will pass a reference (Not a value), in other words, now both variables share the same reference to a single object. So if you modify a property of employee2 this changes employee1 as well.\r\n\r\nSo, please see here (below):\r\n\r\nemployee1 = null;\r\nIf you pass a Null value to an object, just like in the example.\r\n\r\nWhat would happen? This is a great question…\r\n\r\nIt will remove the reference between employee1 and the actual Employee object. So our variable employee1 now has no reference, but what about employee2… let me ask you again:\r\n\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nWill the employee2 variable be Null as well?\r\n\r\nIf you thought employee2 value was Null you are wrong 👀\r\nRemember, Both variables have reference types, but each individual variable is different, and if we remove the reference from the first variable, this change will not affect the 2nd one.", "Dear reader, we will not sail on the surface, we will dive into this learning experience covering the Basics, until we touch the floor. In this journey we will figure out how well we know, the basic stuff we are used to when talking about .NET C#, so here’s my question to you, as an experienced sailor:\r\n\r\nEmployee employee1 = new(1, \"Alex Villegas C\");\r\nEmployee employee2 = employee1;\r\nemployee1 = null;\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nTake your time…\r\n\r\nWhen you create Objects you’re dealing with reference types.\r\n\r\nemployee2 = employee1;\r\nSo here (above), we will pass a reference (Not a value), in other words, now both variables share the same reference to a single object. So if you modify a property of employee2 this changes employee1 as well.\r\n\r\nSo, please see here (below):\r\n\r\nemployee1 = null;\r\nIf you pass a Null value to an object, just like in the example.\r\n\r\nWhat would happen? This is a great question…\r\n\r\nIt will remove the reference between employee1 and the actual Employee object. So our variable employee1 now has no reference, but what about employee2… let me ask you again:\r\n\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nWill the employee2 variable be Null as well?\r\n\r\nIf you thought employee2 value was Null you are wrong 👀\r\nRemember, Both variables have reference types, but each individual variable is different, and if we remove the reference from the first variable, this change will not affect the 2nd one.", "Published", "net-fundamentals-for-senior-devs", ".NET/C# Fundamentals for Senior Devs", "net-fundamentals-for-senior-devs", new Guid("f142dc98-4019-460d-a647-07c71916a596") }
                });

            migrationBuilder.InsertData(
                table: "CategoryPosts",
                columns: new[] { "Id", "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("1590f682-68b3-4062-a83e-85688c65feff"), new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new Guid("aac2e4e5-4372-4571-9bb7-9f3918d02013") },
                    { new Guid("1a5a0912-37fe-4f16-ae40-d7a6fa4b7583"), new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new Guid("ec5f0508-ba97-471d-abae-101d885ab075") },
                    { new Guid("28de7b3c-3adc-4d2c-94b0-d9d2891d04b0"), new Guid("55fcaf16-fa4b-40b0-8ee5-770e2ef3a5fe"), new Guid("5b5264ae-b7d6-468d-ab25-7a0c6459f889") },
                    { new Guid("73d2e37f-f1ba-422b-956c-2d6de273798c"), new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new Guid("766b7995-dd2c-42d3-b2aa-9b75de70a818") },
                    { new Guid("7ec70157-dcfe-4f7a-a5e9-87b72d6cff43"), new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new Guid("62a37d63-b02a-4a2b-8b27-ed42ac3e6c4c") },
                    { new Guid("8bdb8cce-00db-402c-8087-50e17188ca86"), new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new Guid("a6470270-a886-4cbb-b5df-ffc779ee1dc9") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPosts_CategoryId",
                table: "CategoryPosts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPosts_PostId",
                table: "CategoryPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserId",
                table: "Files",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostFiles_FileId",
                table: "PostFiles",
                column: "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostFiles_PostId",
                table: "PostFiles",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_PostId",
                table: "PostReactions",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_ReactionTypeId",
                table: "PostReactions",
                column: "ReactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_UserId",
                table: "PostReactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Slug",
                table: "Posts",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_FileId",
                table: "UserFiles",
                column: "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_UserId",
                table: "UserFiles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CategoryPosts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PostFiles");

            migrationBuilder.DropTable(
                name: "PostReactions");

            migrationBuilder.DropTable(
                name: "UserFiles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "ReactionType");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropSequence(
                name: "No");
        }
    }
}
