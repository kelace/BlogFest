using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogFest.Infrastruction.Migrations
{
    public partial class ContentChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryPosts",
                keyColumn: "Id",
                keyValue: new Guid("1590f682-68b3-4062-a83e-85688c65feff"));

            migrationBuilder.DeleteData(
                table: "CategoryPosts",
                keyColumn: "Id",
                keyValue: new Guid("1a5a0912-37fe-4f16-ae40-d7a6fa4b7583"));

            migrationBuilder.DeleteData(
                table: "CategoryPosts",
                keyColumn: "Id",
                keyValue: new Guid("28de7b3c-3adc-4d2c-94b0-d9d2891d04b0"));

            migrationBuilder.DeleteData(
                table: "CategoryPosts",
                keyColumn: "Id",
                keyValue: new Guid("73d2e37f-f1ba-422b-956c-2d6de273798c"));

            migrationBuilder.DeleteData(
                table: "CategoryPosts",
                keyColumn: "Id",
                keyValue: new Guid("7ec70157-dcfe-4f7a-a5e9-87b72d6cff43"));

            migrationBuilder.DeleteData(
                table: "CategoryPosts",
                keyColumn: "Id",
                keyValue: new Guid("8bdb8cce-00db-402c-8087-50e17188ca86"));

            migrationBuilder.AlterColumn<int>(
                name: "No",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR NO",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 23, 13, 21, 11, 259, DateTimeKind.Utc).AddTicks(8068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ad3ea5a1-fb1d-45a0-a68b-91d07f82995d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cd6bf86c-5b4e-4fba-b4e8-f0c4a9897448"));

            migrationBuilder.AlterColumn<int>(
                name: "No",
                table: "UserFiles",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR NO",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR No");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "UserFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 23, 13, 21, 11, 261, DateTimeKind.Utc).AddTicks(8534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4819f80c-2575-4fcb-9217-32ab071e8733"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d5bb19fd-b8eb-4452-aa5b-df346f21c7d7"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 23, 13, 21, 11, 260, DateTimeKind.Utc).AddTicks(3519),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 19, 18, 19, 18, 312, DateTimeKind.Utc).AddTicks(1913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 23, 13, 21, 11, 259, DateTimeKind.Utc).AddTicks(672),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 19, 18, 19, 18, 310, DateTimeKind.Utc).AddTicks(9242));

            migrationBuilder.AlterColumn<int>(
                name: "No",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR NO",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 23, 13, 21, 11, 261, DateTimeKind.Utc).AddTicks(3415),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 23, 13, 21, 11, 261, DateTimeKind.Utc).AddTicks(994),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 19, 18, 19, 18, 312, DateTimeKind.Utc).AddTicks(9521));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CategoryPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 23, 13, 21, 11, 260, DateTimeKind.Utc).AddTicks(8408),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 19, 18, 19, 18, 312, DateTimeKind.Utc).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3e0afaa8-f82a-4b2b-8763-c54733aa423f"),
                column: "ConcurrencyStamp",
                value: "2248c950-8e27-4439-982f-9e434640ba25");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84bcbf0f-5fa9-42d6-a043-28b438a66a88"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ede7cd72-4e1e-461b-b5ca-4edaba9c99ce", "marty", "AQAAAAIAAYagAAAAENd/LuHwXl1zBUshz18gxpuXu2tvq132nV0VLuNE3cnLB3QJHaPv/vC9FaOjyQ4xUA==", "872bcf3a-bef5-47a6-b5bb-b0496a4560e6", "marty" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f142dc98-4019-460d-a647-07c71916a596"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e11f844d-9586-494d-bffd-f1ee5c999e46", "AQAAAAIAAYagAAAAEJ0ElxlloHUF8e7l7HBvwaHAfcgTl69ygGqClOX1PzcRIfXIYx4jcz6RPAuHDn/h6w==", "435c69b3-0889-4294-b46f-71d204109376" });

            migrationBuilder.InsertData(
                table: "CategoryPosts",
                columns: new[] { "Id", "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("521da6cc-3ac6-44eb-920d-9dfe7b4184f7"), new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new Guid("62a37d63-b02a-4a2b-8b27-ed42ac3e6c4c") },
                    { new Guid("774f1b97-14be-4ee4-b324-bdabcad6f96b"), new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new Guid("a6470270-a886-4cbb-b5df-ffc779ee1dc9") },
                    { new Guid("867258b6-9ad3-44ba-9a74-c47ca6d37e52"), new Guid("55fcaf16-fa4b-40b0-8ee5-770e2ef3a5fe"), new Guid("5b5264ae-b7d6-468d-ab25-7a0c6459f889") },
                    { new Guid("931c5eba-3986-48e4-8567-a040053e3994"), new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new Guid("766b7995-dd2c-42d3-b2aa-9b75de70a818") },
                    { new Guid("ad461b17-232f-46d6-a563-3f5efdd96375"), new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new Guid("ec5f0508-ba97-471d-abae-101d885ab075") },
                    { new Guid("f690af47-04c5-44e3-bc89-6d94cee2348d"), new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new Guid("aac2e4e5-4372-4571-9bb7-9f3918d02013") }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("5b5264ae-b7d6-468d-ab25-7a0c6459f889"),
                columns: new[] { "ContentHTML", "ContentText" },
                values: new object[] { "<h2><strong>What Is Borscht?&nbsp;</strong></h2><p>Borscht is a sour soup that is traditionally made with meat stock and boiled vegetables. The Ukrainian version, which features beets, is perhaps the most well known type — but varieties of borscht can be found throughout Central and Eastern Europe and Northern Asia.&nbsp;</p><h2><strong>Borscht Ingredients</strong></h2><p>These are the ingredients you’ll need to make this top-rated borscht recipe:&nbsp;</p><ul><li><strong>Sausage</strong>: This Ukrainian borscht recipe starts with a pound of pork sausage.&nbsp;</li><li><strong>Vegetables</strong>: You’ll need beets, carrots, baking potatoes, cabbage, and an onion.&nbsp;</li><li><strong>Canned tomatoes</strong>: Use drained diced tomatoes and canned tomato paste.&nbsp;</li><li><strong>Vegetable oil</strong>: Cook the onion in oil.&nbsp;</li><li><strong>Water</strong>: You’ll need almost nine cups of water for this big-batch soup.&nbsp;</li><li><strong>Garlic</strong>: Three cloves of garlic add bold flavor.&nbsp;</li><li><strong>Sugar</strong>: A teaspoon of white sugar lends subtle sweetness.&nbsp;</li><li><strong>Seasonings</strong>: Season the borscht with salt and pepper to taste.&nbsp;</li><li><strong>Sour cream</strong>: Top the borscht with sour cream.&nbsp;</li><li><strong>Fresh herbs</strong>: Garnish the soup with fresh parsley or dill.&nbsp;</li></ul><h2><strong>How to Make Borscht</strong></h2><p>You’ll find the full, step-by-step recipe below — but here’s a brief overview of what you can expect when you make Ukrainian borscht:&nbsp;</p><ol><li>Cook the sausage and set aside.&nbsp;</li><li>Boil water, add the sausage, then add the vegetables and diced tomatoes.&nbsp;</li><li>Cook the onion, stir in the tomato paste, and thin with water. Transfer to the pot.&nbsp;</li><li>Add the garlic, cover, and turn off the heat. Stir in the sugar and seasonings.&nbsp;</li><li>Ladle into bowls and garnish with sour cream and fresh herbs.&nbsp;</li></ol><p><br></p>", "What Is Borscht? \r\n\r\nBorscht is a sour soup that is traditionally made with meat stock and boiled vegetables. The Ukrainian version, which features beets, is perhaps the most well known type — but varieties of borscht can be found throughout Central and Eastern Europe and Northern Asia. \r\n\r\nBorscht Ingredients\r\n\r\nThese are the ingredients you’ll need to make this top-rated borscht recipe: \r\n\r\nSausage: This Ukrainian borscht recipe starts with a pound of pork sausage. \r\nVegetables: You’ll need beets, carrots, baking potatoes, cabbage, and an onion. \r\nCanned tomatoes: Use drained diced tomatoes and canned tomato paste. \r\nVegetable oil: Cook the onion in oil. \r\nWater: You’ll need almost nine cups of water for this big-batch soup. \r\nGarlic: Three cloves of garlic add bold flavor. \r\nSugar: A teaspoon of white sugar lends subtle sweetness. \r\nSeasonings: Season the borscht with salt and pepper to taste. \r\nSour cream: Top the borscht with sour cream. \r\nFresh herbs: Garnish the soup with fresh parsley or dill. \r\nHow to Make Borscht\r\n\r\nYou’ll find the full, step-by-step recipe below — but here’s a brief overview of what you can expect when you make Ukrainian borscht: \r\n\r\nCook the sausage and set aside. \r\nBoil water, add the sausage, then add the vegetables and diced tomatoes. \r\nCook the onion, stir in the tomato paste, and thin with water. Transfer to the pot. \r\nAdd the garlic, cover, and turn off the heat. Stir in the sugar and seasonings. \r\nLadle into bowls and garnish with sour cream and fresh herbs. \r\n\r\n\r\n" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("62a37d63-b02a-4a2b-8b27-ed42ac3e6c4c"),
                columns: new[] { "ContentHTML", "ContentText" },
                values: new object[] { "<p>Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design.</p><p>Basic CQRS Representation</p><p>In this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions.</p><h1>Introduction to Event Sourcing</h1><p>Event Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state.</p><p><br></p><h1>What is CQRS?</h1><p>Command Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.</p><h2>Benefits of Event Sourcing and CQRS in Microservices</h2><p>The combination of Event Sourcing and CQRS offers several advantages when applied to microservices-based applications:</p><p><br></p><ol><li><strong>Historical Transparency:</strong>&nbsp;Event Sourcing ensures a comprehensive record of all state changes, providing historical transparency for auditing, compliance, and debugging purposes.</li><li><strong>Flexibility in Query Optimization:</strong>&nbsp;CQRS empowers you to optimize read and write paths differently. This means you can tailor the read path for query performance while optimizing the write path for high throughput.</li><li><strong>Scalability and Performance:</strong>&nbsp;Microservices architectures demand efficient scaling. Event Sourcing and CQRS allow you to scale different parts of your application independently, enhancing overall performance.</li><li><strong>Resilience and Fault Tolerance:</strong>&nbsp;Event Sourcing enhances resilience by allowing the reconstruction of application state after a failure. CQRS helps isolate errors and failures in the write path from affecting the read path.</li><li><strong>Support for Complex Domains:</strong>&nbsp;Event Sourcing allows you to capture complex domain behavior accurately by recording fine-grained events. CQRS then enables tailored views of this data for various use cases.</li></ol><h2>Getting Started with ASP.NET Core Microservices</h2><p>Setting the Foundation: Creating an ASP.NET Core Microservices Solution</p><p><br></p><p>To implement Event Sourcing and Command Query Responsibility Segregation (CQRS) in ASP.NET Core microservices, you’ll first need to set up your development environment and create the necessary solution structure. Here’s a step-by-step guide to get you started:</p><p><strong>1. Install .NET Core SDK:</strong>&nbsp;Make sure you have the latest .NET Core SDK installed on your machine. You can download it from the official&nbsp;<a href=\"https://dotnet.microsoft.com/download\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">Microsoft website</a>.</p><p><strong>2. Create a New Solution:&nbsp;</strong>Open your command-line interface and navigate to the directory where you want to create your solution. Use the following command to create a new ASP.NET Core solution:</p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet new sln -n MicroservicesSolution\r\n</pre><p><strong>3. Create Microservices Projects:</strong>&nbsp;Inside your solution folder, create individual projects for each microservice. For example, you can create projects named&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">OrderService</code>,&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">PaymentService</code>, and&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">NotificationService</code>:</p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet new webapi -n OrderService\r\ndotnet new webapi -n PaymentService\r\ndotnet new webapi -n NotificationService\r\n</pre><p><strong>4. Add Projects to Solution:</strong>&nbsp;Add the microservices projects to the solution using the following command:</p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet sln MicroservicesSolution.sln add OrderService\\OrderService.csproj\r\ndotnet sln MicroservicesSolution.sln add PaymentService\\PaymentService.csproj\r\ndotnet sln MicroservicesSolution.sln add NotificationService\\NotificationService.csproj\r\n</pre><h2>Defining Domain Events and Commands</h2><p>With your solution structure in place, you’re ready to define the core building blocks of Event Sourcing and CQRS: domain events and commands.</p><p><br></p><ul><li><strong>Create a Shared Library:</strong>&nbsp;To avoid duplicating domain-related code, create a shared library that contains common classes like domain events, commands, and value objects. Use the following command to create a class library project:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet new classlib -n SharedDomain\r\n</pre><ul><li><strong>Add the Shared Library to Solution:</strong>&nbsp;Add the shared library project to the solution:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet sln MicroservicesSolution.sln add SharedDomain\\SharedDomain.csproj\r\n</pre><ul><li><strong>Define Domain Events and Commands:</strong>&nbsp;Inside the&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">SharedDomain</code>&nbsp;project, define your domain events and commands as C# classes. For example:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">public class OrderPlacedEvent\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public DateTime Timestamp { get; set; }\r\n}\r\n\r\npublic class ProcessPaymentCommand\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public decimal Amount { get; set; }\r\n}\r\n</pre><ul><li><strong>Reference the Shared Library:</strong>&nbsp;In each microservice project, add a reference to the&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">SharedDomain</code>&nbsp;library:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet add OrderService\\OrderService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add PaymentService\\PaymentService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add NotificationService\\NotificationService.csproj reference SharedDomai\r\n</pre><p><br></p>", "Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design.\r\n\r\nBasic CQRS Representation\r\n\r\nIn this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions.\r\n\r\nIntroduction to Event Sourcing\r\n\r\nEvent Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state.\r\n\r\n\r\n\r\n\r\nWhat is CQRS?\r\n\r\nCommand Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.\r\n\r\nBenefits of Event Sourcing and CQRS in Microservices\r\n\r\nThe combination of Event Sourcing and CQRS offers several advantages when applied to microservices-based applications:\r\n\r\n\r\n\r\n\r\nHistorical Transparency: Event Sourcing ensures a comprehensive record of all state changes, providing historical transparency for auditing, compliance, and debugging purposes.\r\nFlexibility in Query Optimization: CQRS empowers you to optimize read and write paths differently. This means you can tailor the read path for query performance while optimizing the write path for high throughput.\r\nScalability and Performance: Microservices architectures demand efficient scaling. Event Sourcing and CQRS allow you to scale different parts of your application independently, enhancing overall performance.\r\nResilience and Fault Tolerance: Event Sourcing enhances resilience by allowing the reconstruction of application state after a failure. CQRS helps isolate errors and failures in the write path from affecting the read path.\r\nSupport for Complex Domains: Event Sourcing allows you to capture complex domain behavior accurately by recording fine-grained events. CQRS then enables tailored views of this data for various use cases.\r\nGetting Started with ASP.NET Core Microservices\r\n\r\nSetting the Foundation: Creating an ASP.NET Core Microservices Solution\r\n\r\n\r\n\r\n\r\nTo implement Event Sourcing and Command Query Responsibility Segregation (CQRS) in ASP.NET Core microservices, you’ll first need to set up your development environment and create the necessary solution structure. Here’s a step-by-step guide to get you started:\r\n\r\n1. Install .NET Core SDK: Make sure you have the latest .NET Core SDK installed on your machine. You can download it from the official Microsoft website.\r\n\r\n2. Create a New Solution: Open your command-line interface and navigate to the directory where you want to create your solution. Use the following command to create a new ASP.NET Core solution:\r\n\r\ndotnet new sln -n MicroservicesSolution\r\n\r\n\r\n3. Create Microservices Projects: Inside your solution folder, create individual projects for each microservice. For example, you can create projects named OrderService, PaymentService, and NotificationService:\r\n\r\ndotnet new webapi -n OrderService\r\ndotnet new webapi -n PaymentService\r\ndotnet new webapi -n NotificationService\r\n\r\n\r\n4. Add Projects to Solution: Add the microservices projects to the solution using the following command:\r\n\r\ndotnet sln MicroservicesSolution.sln add OrderService\\OrderService.csproj\r\ndotnet sln MicroservicesSolution.sln add PaymentService\\PaymentService.csproj\r\ndotnet sln MicroservicesSolution.sln add NotificationService\\NotificationService.csproj\r\n\r\nDefining Domain Events and Commands\r\n\r\nWith your solution structure in place, you’re ready to define the core building blocks of Event Sourcing and CQRS: domain events and commands.\r\n\r\n\r\n\r\n\r\nCreate a Shared Library: To avoid duplicating domain-related code, create a shared library that contains common classes like domain events, commands, and value objects. Use the following command to create a class library project:\r\n\r\n\r\n\r\n\r\ndotnet new classlib -n SharedDomain\r\n\r\nAdd the Shared Library to Solution: Add the shared library project to the solution:\r\n\r\n\r\n\r\n\r\ndotnet sln MicroservicesSolution.sln add SharedDomain\\SharedDomain.csproj\r\n\r\nDefine Domain Events and Commands: Inside the SharedDomain project, define your domain events and commands as C# classes. For example:\r\n\r\n\r\n\r\n\r\npublic class OrderPlacedEvent\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public DateTime Timestamp { get; set; }\r\n}\r\n\r\npublic class ProcessPaymentCommand\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public decimal Amount { get; set; }\r\n}\r\n\r\nReference the Shared Library: In each microservice project, add a reference to the SharedDomain library:\r\n\r\n\r\n\r\n\r\ndotnet add OrderService\\OrderService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add PaymentService\\PaymentService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add NotificationService\\NotificationService.csproj reference SharedDomai\r\n\r\n\r\n\r\n" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("766b7995-dd2c-42d3-b2aa-9b75de70a818"),
                columns: new[] { "ContentHTML", "ContentText" },
                values: new object[] { "<p>The Tech side of startups can sometimes be very fluid and contain a lot of unknowns. What tech stack to use? Which components might be&nbsp;overkill&nbsp;for now but worth keeping an eye on in the future? How to balance the pace of business features development while keeping the quality bar high enough to have a maintainable codebase?</p><p><br></p><p>Here I want to share our experience building&nbsp;from the ground up — how we shaped our processes based on needs and how our processes evolved as we extended our tech stack with new components.</p><p>Businesses want to conquer the market and engineers — try cool stuff and stretch their brains. Meanwhile, the industry produces new languages, frameworks, and libraries in such quantities that you will not be able to check them all. And, usually, if you scratch the shiny surface of the Next Big Thing, you will find a good old concept. </p><p><br></p><p>Good, if you are lucky.</p><p>One of the most exciting topics to argue about is the processes — whether you rely on&nbsp;<a href=\"https://trunkbaseddevelopment.com/\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">trunk-based development</a>, prefer a more monstrous&nbsp;<a href=\"https://www.endoflineblog.com/gitflow-considered-harmful\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">GitHub flow</a>, are a fan of&nbsp;<a href=\"https://www.agilealliance.org/glossary/mob-programming/\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">mobbing</a>, or find it more efficient to spend time in&nbsp;<a href=\"https://trunkbaseddevelopment.com/short-lived-feature-branches/\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">PR-based</a>&nbsp;code reviews.</p><p>I have experience working in an environment where artifacts were thrown away on users without any standardized process. In case of issues, developers had a lot of fun (nope!) trying to figure out what version of components was actually deployed.</p><p>On another spectrum is the never-ending queue to CI. After you create PR you have to entertain yourself in the nearest 30 minutes by betting whether the CI cluster will find a resource to run tests over your changes. Sometimes the platform team introduces new, exciting, and useful features that might break compatibility with existing boilerplate for CI. These may result in failing all your checks at the last minute, after an hour of waiting.</p>", "The Tech side of startups can sometimes be very fluid and contain a lot of unknowns. What tech stack to use? Which components might be overkill for now but worth keeping an eye on in the future? How to balance the pace of business features development while keeping the quality bar high enough to have a maintainable codebase?\r\n\r\n\r\n\r\n\r\nHere I want to share our experience building from the ground up — how we shaped our processes based on needs and how our processes evolved as we extended our tech stack with new components.\r\n\r\nBusinesses want to conquer the market and engineers — try cool stuff and stretch their brains. Meanwhile, the industry produces new languages, frameworks, and libraries in such quantities that you will not be able to check them all. And, usually, if you scratch the shiny surface of the Next Big Thing, you will find a good old concept. \r\n\r\n\r\n\r\n\r\nGood, if you are lucky.\r\n\r\nOne of the most exciting topics to argue about is the processes — whether you rely on trunk-based development, prefer a more monstrous GitHub flow, are a fan of mobbing, or find it more efficient to spend time in PR-based code reviews.\r\n\r\nI have experience working in an environment where artifacts were thrown away on users without any standardized process. In case of issues, developers had a lot of fun (nope!) trying to figure out what version of components was actually deployed.\r\n\r\nOn another spectrum is the never-ending queue to CI. After you create PR you have to entertain yourself in the nearest 30 minutes by betting whether the CI cluster will find a resource to run tests over your changes. Sometimes the platform team introduces new, exciting, and useful features that might break compatibility with existing boilerplate for CI. These may result in failing all your checks at the last minute, after an hour of waiting." });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("a6470270-a886-4cbb-b5df-ffc779ee1dc9"),
                columns: new[] { "ContentHTML", "ContentText", "Title" },
                values: new object[] { "<p>The Tech side of startups can sometimes be very fluid and contain a lot of unknowns. What tech stack to use? Which components might be&nbsp;overkill&nbsp;for now but worth keeping an eye on in the future? How to balance the pace of business features development while keeping the quality bar high enough to have a maintainable codebase?</p><p><br></p><p>Here I want to share our experience building&nbsp;from the ground up — how we shaped our processes based on needs and how our processes evolved as we extended our tech stack with new components.</p><p>Businesses want to conquer the market and engineers — try cool stuff and stretch their brains. Meanwhile, the industry produces new languages, frameworks, and libraries in such quantities that you will not be able to check them all. And, usually, if you scratch the shiny surface of the Next Big Thing, you will find a good old concept. </p><p><br></p><p>Good, if you are lucky.</p><p>One of the most exciting topics to argue about is the processes — whether you rely on&nbsp;<a href=\"https://trunkbaseddevelopment.com/\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">trunk-based development</a>, prefer a more monstrous&nbsp;<a href=\"https://www.endoflineblog.com/gitflow-considered-harmful\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">GitHub flow</a>, are a fan of&nbsp;<a href=\"https://www.agilealliance.org/glossary/mob-programming/\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">mobbing</a>, or find it more efficient to spend time in&nbsp;<a href=\"https://trunkbaseddevelopment.com/short-lived-feature-branches/\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">PR-based</a>&nbsp;code reviews.</p><p>I have experience working in an environment where artifacts were thrown away on users without any standardized process. In case of issues, developers had a lot of fun (nope!) trying to figure out what version of components was actually deployed.</p><p>On another spectrum is the never-ending queue to CI. After you create PR you have to entertain yourself in the nearest 30 minutes by betting whether the CI cluster will find a resource to run tests over your changes. Sometimes the platform team introduces new, exciting, and useful features that might break compatibility with existing boilerplate for CI. These may result in failing all your checks at the last minute, after an hour of waiting.</p>", "The Tech side of startups can sometimes be very fluid and contain a lot of unknowns. What tech stack to use? Which components might be overkill for now but worth keeping an eye on in the future? How to balance the pace of business features development while keeping the quality bar high enough to have a maintainable codebase?\r\n\r\n\r\n\r\n\r\nHere I want to share our experience building from the ground up — how we shaped our processes based on needs and how our processes evolved as we extended our tech stack with new components.\r\n\r\nBusinesses want to conquer the market and engineers — try cool stuff and stretch their brains. Meanwhile, the industry produces new languages, frameworks, and libraries in such quantities that you will not be able to check them all. And, usually, if you scratch the shiny surface of the Next Big Thing, you will find a good old concept. \r\n\r\n\r\n\r\n\r\nGood, if you are lucky.\r\n\r\nOne of the most exciting topics to argue about is the processes — whether you rely on trunk-based development, prefer a more monstrous GitHub flow, are a fan of mobbing, or find it more efficient to spend time in PR-based code reviews.\r\n\r\nI have experience working in an environment where artifacts were thrown away on users without any standardized process. In case of issues, developers had a lot of fun (nope!) trying to figure out what version of components was actually deployed.\r\n\r\nOn another spectrum is the never-ending queue to CI. After you create PR you have to entertain yourself in the nearest 30 minutes by betting whether the CI cluster will find a resource to run tests over your changes. Sometimes the platform team introduces new, exciting, and useful features that might break compatibility with existing boilerplate for CI. These may result in failing all your checks at the last minute, after an hour of waiting.", "API Design 101: Best Practices" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("aac2e4e5-4372-4571-9bb7-9f3918d02013"),
                columns: new[] { "ContentHTML", "ContentText", "TitleSlugify" },
                values: new object[] { "<p>Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design.</p><p>Basic CQRS Representation</p><p>In this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions.</p><h1>Introduction to Event Sourcing</h1><p>Event Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state.</p><p><br></p><h1>What is CQRS?</h1><p>Command Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.</p><h2>Benefits of Event Sourcing and CQRS in Microservices</h2><p>The combination of Event Sourcing and CQRS offers several advantages when applied to microservices-based applications:</p><p><br></p><ol><li><strong>Historical Transparency:</strong>&nbsp;Event Sourcing ensures a comprehensive record of all state changes, providing historical transparency for auditing, compliance, and debugging purposes.</li><li><strong>Flexibility in Query Optimization:</strong>&nbsp;CQRS empowers you to optimize read and write paths differently. This means you can tailor the read path for query performance while optimizing the write path for high throughput.</li><li><strong>Scalability and Performance:</strong>&nbsp;Microservices architectures demand efficient scaling. Event Sourcing and CQRS allow you to scale different parts of your application independently, enhancing overall performance.</li><li><strong>Resilience and Fault Tolerance:</strong>&nbsp;Event Sourcing enhances resilience by allowing the reconstruction of application state after a failure. CQRS helps isolate errors and failures in the write path from affecting the read path.</li><li><strong>Support for Complex Domains:</strong>&nbsp;Event Sourcing allows you to capture complex domain behavior accurately by recording fine-grained events. CQRS then enables tailored views of this data for various use cases.</li></ol><h2>Getting Started with ASP.NET Core Microservices</h2><p>Setting the Foundation: Creating an ASP.NET Core Microservices Solution</p><p><br></p><p>To implement Event Sourcing and Command Query Responsibility Segregation (CQRS) in ASP.NET Core microservices, you’ll first need to set up your development environment and create the necessary solution structure. Here’s a step-by-step guide to get you started:</p><p><strong>1. Install .NET Core SDK:</strong>&nbsp;Make sure you have the latest .NET Core SDK installed on your machine. You can download it from the official&nbsp;<a href=\"https://dotnet.microsoft.com/download\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">Microsoft website</a>.</p><p><strong>2. Create a New Solution:&nbsp;</strong>Open your command-line interface and navigate to the directory where you want to create your solution. Use the following command to create a new ASP.NET Core solution:</p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet new sln -n MicroservicesSolution\r\n</pre><p><strong>3. Create Microservices Projects:</strong>&nbsp;Inside your solution folder, create individual projects for each microservice. For example, you can create projects named&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">OrderService</code>,&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">PaymentService</code>, and&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">NotificationService</code>:</p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet new webapi -n OrderService\r\ndotnet new webapi -n PaymentService\r\ndotnet new webapi -n NotificationService\r\n</pre><p><strong>4. Add Projects to Solution:</strong>&nbsp;Add the microservices projects to the solution using the following command:</p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet sln MicroservicesSolution.sln add OrderService\\OrderService.csproj\r\ndotnet sln MicroservicesSolution.sln add PaymentService\\PaymentService.csproj\r\ndotnet sln MicroservicesSolution.sln add NotificationService\\NotificationService.csproj\r\n</pre><h2>Defining Domain Events and Commands</h2><p>With your solution structure in place, you’re ready to define the core building blocks of Event Sourcing and CQRS: domain events and commands.</p><p><br></p><ul><li><strong>Create a Shared Library:</strong>&nbsp;To avoid duplicating domain-related code, create a shared library that contains common classes like domain events, commands, and value objects. Use the following command to create a class library project:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet new classlib -n SharedDomain\r\n</pre><ul><li><strong>Add the Shared Library to Solution:</strong>&nbsp;Add the shared library project to the solution:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet sln MicroservicesSolution.sln add SharedDomain\\SharedDomain.csproj\r\n</pre><ul><li><strong>Define Domain Events and Commands:</strong>&nbsp;Inside the&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">SharedDomain</code>&nbsp;project, define your domain events and commands as C# classes. For example:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">public class OrderPlacedEvent\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public DateTime Timestamp { get; set; }\r\n}\r\n\r\npublic class ProcessPaymentCommand\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public decimal Amount { get; set; }\r\n}\r\n</pre><ul><li><strong>Reference the Shared Library:</strong>&nbsp;In each microservice project, add a reference to the&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">SharedDomain</code>&nbsp;library:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet add OrderService\\OrderService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add PaymentService\\PaymentService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add NotificationService\\NotificationService.csproj reference SharedDomai\r\n</pre><p><br></p>", "Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design.\r\n\r\nBasic CQRS Representation\r\n\r\nIn this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions.\r\n\r\nIntroduction to Event Sourcing\r\n\r\nEvent Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state.\r\n\r\n\r\n\r\n\r\nWhat is CQRS?\r\n\r\nCommand Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.\r\n\r\nBenefits of Event Sourcing and CQRS in Microservices\r\n\r\nThe combination of Event Sourcing and CQRS offers several advantages when applied to microservices-based applications:\r\n\r\n\r\n\r\n\r\nHistorical Transparency: Event Sourcing ensures a comprehensive record of all state changes, providing historical transparency for auditing, compliance, and debugging purposes.\r\nFlexibility in Query Optimization: CQRS empowers you to optimize read and write paths differently. This means you can tailor the read path for query performance while optimizing the write path for high throughput.\r\nScalability and Performance: Microservices architectures demand efficient scaling. Event Sourcing and CQRS allow you to scale different parts of your application independently, enhancing overall performance.\r\nResilience and Fault Tolerance: Event Sourcing enhances resilience by allowing the reconstruction of application state after a failure. CQRS helps isolate errors and failures in the write path from affecting the read path.\r\nSupport for Complex Domains: Event Sourcing allows you to capture complex domain behavior accurately by recording fine-grained events. CQRS then enables tailored views of this data for various use cases.\r\nGetting Started with ASP.NET Core Microservices\r\n\r\nSetting the Foundation: Creating an ASP.NET Core Microservices Solution\r\n\r\n\r\n\r\n\r\nTo implement Event Sourcing and Command Query Responsibility Segregation (CQRS) in ASP.NET Core microservices, you’ll first need to set up your development environment and create the necessary solution structure. Here’s a step-by-step guide to get you started:\r\n\r\n1. Install .NET Core SDK: Make sure you have the latest .NET Core SDK installed on your machine. You can download it from the official Microsoft website.\r\n\r\n2. Create a New Solution: Open your command-line interface and navigate to the directory where you want to create your solution. Use the following command to create a new ASP.NET Core solution:\r\n\r\ndotnet new sln -n MicroservicesSolution\r\n\r\n\r\n3. Create Microservices Projects: Inside your solution folder, create individual projects for each microservice. For example, you can create projects named OrderService, PaymentService, and NotificationService:\r\n\r\ndotnet new webapi -n OrderService\r\ndotnet new webapi -n PaymentService\r\ndotnet new webapi -n NotificationService\r\n\r\n\r\n4. Add Projects to Solution: Add the microservices projects to the solution using the following command:\r\n\r\ndotnet sln MicroservicesSolution.sln add OrderService\\OrderService.csproj\r\ndotnet sln MicroservicesSolution.sln add PaymentService\\PaymentService.csproj\r\ndotnet sln MicroservicesSolution.sln add NotificationService\\NotificationService.csproj\r\n\r\nDefining Domain Events and Commands\r\n\r\nWith your solution structure in place, you’re ready to define the core building blocks of Event Sourcing and CQRS: domain events and commands.\r\n\r\n\r\n\r\n\r\nCreate a Shared Library: To avoid duplicating domain-related code, create a shared library that contains common classes like domain events, commands, and value objects. Use the following command to create a class library project:\r\n\r\n\r\n\r\n\r\ndotnet new classlib -n SharedDomain\r\n\r\nAdd the Shared Library to Solution: Add the shared library project to the solution:\r\n\r\n\r\n\r\n\r\ndotnet sln MicroservicesSolution.sln add SharedDomain\\SharedDomain.csproj\r\n\r\nDefine Domain Events and Commands: Inside the SharedDomain project, define your domain events and commands as C# classes. For example:\r\n\r\n\r\n\r\n\r\npublic class OrderPlacedEvent\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public DateTime Timestamp { get; set; }\r\n}\r\n\r\npublic class ProcessPaymentCommand\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public decimal Amount { get; set; }\r\n}\r\n\r\nReference the Shared Library: In each microservice project, add a reference to the SharedDomain library:\r\n\r\n\r\n\r\n\r\ndotnet add OrderService\\OrderService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add PaymentService\\PaymentService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add NotificationService\\NotificationService.csproj reference SharedDomai\r\n\r\n\r\n\r\n", "AAC2E4E5-4372-4571-9BB7-9F3918D02013" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("ec5f0508-ba97-471d-abae-101d885ab075"),
                columns: new[] { "ContentHTML", "ContentText" },
                values: new object[] { "<p>Dear reader, we will not sail on the surface, we will dive into this learning experience covering the Basics, until we touch the floor. In this journey we will figure out how well we know, the basic stuff we are used to when talking about .NET C#, so here’s my question to you, as an experienced sailor:</p><pre class=\"ql-syntax\" spellcheck=\"false\">Employee employee1 = new(1, \"Alex Villegas C\");\r\nEmployee employee2 = employee1;\r\nemployee1 = null;\r\n</pre><p>What do you think would be the value of the&nbsp;<strong>employee2&nbsp;</strong>variable at the end of this execution?</p><p><strong><em>Take your time…</em></strong></p><p>When you create Objects you’re dealing with reference types.</p><pre class=\"ql-syntax\" spellcheck=\"false\">employee2 = employee1;\r\n</pre><p>So here (above), we will pass a reference (<strong>Not a value</strong>), in other words, now both variables share the same reference to a single object. So if you modify a property of&nbsp;<strong>employee2&nbsp;</strong>this changes&nbsp;<strong>employee1&nbsp;</strong>as well<strong>.</strong></p><p>So, please see here (below):</p><pre class=\"ql-syntax\" spellcheck=\"false\">employee1 = null;\r\n</pre><p>If you pass a&nbsp;<strong>Null&nbsp;</strong>value to an object, just like in the example.</p><blockquote><em>What would happen? This is a great question…</em></blockquote><p><br></p><p>It will remove the reference between&nbsp;<strong>employee1&nbsp;</strong>and the actual&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">Employee</code>&nbsp;object. So our variable&nbsp;<strong>employee1&nbsp;</strong>now has no reference, but what about&nbsp;<strong>employee2…</strong>&nbsp;let me ask you again:</p><blockquote><em>What do you think would be the value of the&nbsp;</em><strong><em>employee2&nbsp;</em></strong><em>variable at the end of this execution?</em></blockquote><blockquote><em>Will the employee2 variable be Null as well?</em></blockquote><p>If you thought&nbsp;<strong>employee2&nbsp;</strong>value was&nbsp;<strong>Null&nbsp;</strong>you are wrong 👀</p><p><strong>Remember,&nbsp;</strong>Both variables have reference types, but each individual variable is different, and if we remove the reference from the first variable, this change will not affect the 2nd one.</p>", "Dear reader, we will not sail on the surface, we will dive into this learning experience covering the Basics, until we touch the floor. In this journey we will figure out how well we know, the basic stuff we are used to when talking about .NET C#, so here’s my question to you, as an experienced sailor:\r\n\r\nEmployee employee1 = new(1, \"Alex Villegas C\");\r\nEmployee employee2 = employee1;\r\nemployee1 = null;\r\n\r\n\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nTake your time…\r\n\r\nWhen you create Objects you’re dealing with reference types.\r\n\r\nemployee2 = employee1;\r\n\r\n\r\nSo here (above), we will pass a reference (Not a value), in other words, now both variables share the same reference to a single object. So if you modify a property of employee2 this changes employee1 as well.\r\n\r\nSo, please see here (below):\r\n\r\nemployee1 = null;\r\n\r\n\r\nIf you pass a Null value to an object, just like in the example.\r\n\r\nWhat would happen? This is a great question…\r\n\r\n\r\n\r\n\r\nIt will remove the reference between employee1 and the actual Employee object. So our variable employee1 now has no reference, but what about employee2… let me ask you again:\r\n\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\nWill the employee2 variable be Null as well?\r\n\r\nIf you thought employee2 value was Null you are wrong 👀\r\n\r\nRemember, Both variables have reference types, but each individual variable is different, and if we remove the reference from the first variable, this change will not affect the 2nd one." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("84bcbf0f-5fa9-42d6-a043-28b438a66a88"),
                column: "Name",
                value: "marty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryPosts",
                keyColumn: "Id",
                keyValue: new Guid("521da6cc-3ac6-44eb-920d-9dfe7b4184f7"));

            migrationBuilder.DeleteData(
                table: "CategoryPosts",
                keyColumn: "Id",
                keyValue: new Guid("774f1b97-14be-4ee4-b324-bdabcad6f96b"));

            migrationBuilder.DeleteData(
                table: "CategoryPosts",
                keyColumn: "Id",
                keyValue: new Guid("867258b6-9ad3-44ba-9a74-c47ca6d37e52"));

            migrationBuilder.DeleteData(
                table: "CategoryPosts",
                keyColumn: "Id",
                keyValue: new Guid("931c5eba-3986-48e4-8567-a040053e3994"));

            migrationBuilder.DeleteData(
                table: "CategoryPosts",
                keyColumn: "Id",
                keyValue: new Guid("ad461b17-232f-46d6-a563-3f5efdd96375"));

            migrationBuilder.DeleteData(
                table: "CategoryPosts",
                keyColumn: "Id",
                keyValue: new Guid("f690af47-04c5-44e3-bc89-6d94cee2348d"));

            migrationBuilder.AlterColumn<int>(
                name: "No",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR NO");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 23, 13, 21, 11, 259, DateTimeKind.Utc).AddTicks(8068));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cd6bf86c-5b4e-4fba-b4e8-f0c4a9897448"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ad3ea5a1-fb1d-45a0-a68b-91d07f82995d"));

            migrationBuilder.AlterColumn<int>(
                name: "No",
                table: "UserFiles",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR No",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR NO");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "UserFiles",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 23, 13, 21, 11, 261, DateTimeKind.Utc).AddTicks(8534));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d5bb19fd-b8eb-4452-aa5b-df346f21c7d7"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4819f80c-2575-4fcb-9217-32ab071e8733"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 19, 18, 19, 18, 312, DateTimeKind.Utc).AddTicks(1913),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 23, 13, 21, 11, 260, DateTimeKind.Utc).AddTicks(3519));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 19, 18, 19, 18, 310, DateTimeKind.Utc).AddTicks(9242),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 23, 13, 21, 11, 259, DateTimeKind.Utc).AddTicks(672));

            migrationBuilder.AlterColumn<int>(
                name: "No",
                table: "Files",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR NO");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Files",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 23, 13, 21, 11, 261, DateTimeKind.Utc).AddTicks(3415));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 19, 18, 19, 18, 312, DateTimeKind.Utc).AddTicks(9521),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 23, 13, 21, 11, 261, DateTimeKind.Utc).AddTicks(994));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CategoryPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 19, 18, 19, 18, 312, DateTimeKind.Utc).AddTicks(7005),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 23, 13, 21, 11, 260, DateTimeKind.Utc).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3e0afaa8-f82a-4b2b-8763-c54733aa423f"),
                column: "ConcurrencyStamp",
                value: "5d9cc1b3-f4e8-41e3-bb94-797ec6fe8f2d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84bcbf0f-5fa9-42d6-a043-28b438a66a88"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "75d73fe2-0eff-4c35-b075-5f18603481ca", "kitty", "AQAAAAIAAYagAAAAEI4vinoh+ho0F4plO+UOmbLDfqLOCq5AFwhaPeqLsEkFkH1uWGSzBlRfBejlbpbRWA==", "6ab55f36-fc94-425e-81aa-fea1da7b979c", "kitty" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f142dc98-4019-460d-a647-07c71916a596"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "121ac447-f1e4-41e2-b10e-1c524a8a3ba3", "AQAAAAIAAYagAAAAEF6KuH0DQha+5Kf+zkJKKi3v626EgGmHMr2yAYD2S9YGDsXNo81Zkw8J2380wYUGnw==", "12e4e489-7294-40a2-94a5-fcf2ff1cf916" });

            migrationBuilder.InsertData(
                table: "CategoryPosts",
                columns: new[] { "Id", "CategoryId", "DateCreated", "No", "PostId" },
                values: new object[,]
                {
                    { new Guid("1590f682-68b3-4062-a83e-85688c65feff"), new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("aac2e4e5-4372-4571-9bb7-9f3918d02013") },
                    { new Guid("1a5a0912-37fe-4f16-ae40-d7a6fa4b7583"), new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("ec5f0508-ba97-471d-abae-101d885ab075") },
                    { new Guid("28de7b3c-3adc-4d2c-94b0-d9d2891d04b0"), new Guid("55fcaf16-fa4b-40b0-8ee5-770e2ef3a5fe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("5b5264ae-b7d6-468d-ab25-7a0c6459f889") },
                    { new Guid("73d2e37f-f1ba-422b-956c-2d6de273798c"), new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("766b7995-dd2c-42d3-b2aa-9b75de70a818") },
                    { new Guid("7ec70157-dcfe-4f7a-a5e9-87b72d6cff43"), new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("62a37d63-b02a-4a2b-8b27-ed42ac3e6c4c") },
                    { new Guid("8bdb8cce-00db-402c-8087-50e17188ca86"), new Guid("74dbe707-ab60-4fc7-84b3-c8f387beebb3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("a6470270-a886-4cbb-b5df-ffc779ee1dc9") }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("5b5264ae-b7d6-468d-ab25-7a0c6459f889"),
                columns: new[] { "ContentHTML", "ContentText" },
                values: new object[] { "What Is Borscht? Borscht is a sour soup that is traditionally made with meat stock and boiled vegetables. The Ukrainian version, which features beets, is perhaps the most well known type — but varieties of borscht can be found throughout Central and Eastern Europe and Northern Asia. Borscht Ingredients These are the ingredients you’ll need to make this top-rated borscht recipe: Sausage: This Ukrainian borscht recipe starts with a pound of pork sausage. Vegetables: You’ll need beets, carrots, baking potatoes, cabbage, and an onion. Canned tomatoes: Use drained diced tomatoes and canned tomato paste. Vegetable oil: Cook the onion in oil. Water: You’ll need almost nine cups of water for this big-batch soup. Garlic: Three cloves of garlic add bold flavor. Sugar: A teaspoon of white sugar lends subtle sweetness. Seasonings: Season the borscht with salt and pepper to taste. Sour cream: Top the borscht with sour cream. Fresh herbs: Garnish the soup with fresh parsley or dill. How to Make Borscht You’ll find the full, step-by-step recipe below — but here’s a brief overview of what you can expect when you make Ukrainian borscht: Cook the sausage and set aside. Boil water, add the sausage, then add the vegetables and diced tomatoes. Cook the onion, stir in the tomato paste, and thin with water. Transfer to the pot. Add the garlic, cover, and turn off the heat. Stir in the sugar and seasonings. Ladle into bowls and garnish with sour cream and fresh herbs. Tip from recipe creator Patti: “This soup can be served vegetarian-style by omitting the sausage.” How to Store Borscht Store leftover borscht in an airtight container in the refrigerator for up to three days. Reheat in the microwave or on the stove. Can You Freeze Borscht? Yes, borscht freezes well! When you add it to your freezer-safe containers, make sure to leave an inch or two of space at the top to allow for expansion. Freeze the borscht for up to two months. Thaw in the refrigerator overnight, then reheat in the microwave or on the stove. Allrecipes Community Tips and Praise “This was the first time I've had borscht and now I see why so many people love it,” says one Allrecipes community member. “I can't believe how good it is.” “Just perfect,” raves Olechka. “Classic recipe, great taste, my favorite.” “BEST BORSCHT EVER,” according to KLaura Anderson-Bradfield. “I have made many different beet soup recipes over the years. The addition of an acidic ingredient (tomato) still allowed the beets to shine but removed the heavy, sometimes too earthy taste common to borscht.”", "What Is Borscht? Borscht is a sour soup that is traditionally made with meat stock and boiled vegetables. The Ukrainian version, which features beets, is perhaps the most well known type — but varieties of borscht can be found throughout Central and Eastern Europe and Northern Asia. Borscht Ingredients These are the ingredients you’ll need to make this top-rated borscht recipe: Sausage: This Ukrainian borscht recipe starts with a pound of pork sausage. Vegetables: You’ll need beets, carrots, baking potatoes, cabbage, and an onion. Canned tomatoes: Use drained diced tomatoes and canned tomato paste. Vegetable oil: Cook the onion in oil. Water: You’ll need almost nine cups of water for this big-batch soup. Garlic: Three cloves of garlic add bold flavor. Sugar: A teaspoon of white sugar lends subtle sweetness. Seasonings: Season the borscht with salt and pepper to taste. Sour cream: Top the borscht with sour cream. Fresh herbs: Garnish the soup with fresh parsley or dill. How to Make Borscht You’ll find the full, step-by-step recipe below — but here’s a brief overview of what you can expect when you make Ukrainian borscht: Cook the sausage and set aside. Boil water, add the sausage, then add the vegetables and diced tomatoes. Cook the onion, stir in the tomato paste, and thin with water. Transfer to the pot. Add the garlic, cover, and turn off the heat. Stir in the sugar and seasonings. Ladle into bowls and garnish with sour cream and fresh herbs. Tip from recipe creator Patti: “This soup can be served vegetarian-style by omitting the sausage.” How to Store Borscht Store leftover borscht in an airtight container in the refrigerator for up to three days. Reheat in the microwave or on the stove. Can You Freeze Borscht? Yes, borscht freezes well! When you add it to your freezer-safe containers, make sure to leave an inch or two of space at the top to allow for expansion. Freeze the borscht for up to two months. Thaw in the refrigerator overnight, then reheat in the microwave or on the stove. Allrecipes Community Tips and Praise “This was the first time I've had borscht and now I see why so many people love it,” says one Allrecipes community member. “I can't believe how good it is.” “Just perfect,” raves Olechka. “Classic recipe, great taste, my favorite.” “BEST BORSCHT EVER,” according to KLaura Anderson-Bradfield. “I have made many different beet soup recipes over the years. The addition of an acidic ingredient (tomato) still allowed the beets to shine but removed the heavy, sometimes too earthy taste common to borscht.”" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("62a37d63-b02a-4a2b-8b27-ed42ac3e6c4c"),
                columns: new[] { "ContentHTML", "ContentText" },
                values: new object[] { "Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design. Diagram illustrating the components and relationships of Event Sourcing and Command Query Responsibility Segregation (CQRS) in an ASP.NET Core application. Basic CQRS Representation In this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions. Introduction to Event Sourcing Event Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state. What is CQRS? Command Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.", "Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design. Diagram illustrating the components and relationships of Event Sourcing and Command Query Responsibility Segregation (CQRS) in an ASP.NET Core application. Basic CQRS Representation In this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions. Introduction to Event Sourcing Event Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state. What is CQRS? Command Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences." });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("766b7995-dd2c-42d3-b2aa-9b75de70a818"),
                columns: new[] { "ContentHTML", "ContentText" },
                values: new object[] { "Dear reader, we will not sail on the surface, we will dive into this learning experience covering the Basics, until we touch the floor. In this journey we will figure out how well we know, the basic stuff we are used to when talking about .NET C#, so here’s my question to you, as an experienced sailor:\r\n\r\nEmployee employee1 = new(1, \"Alex Villegas C\");\r\nEmployee employee2 = employee1;\r\nemployee1 = null;\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nTake your time…\r\n\r\nWhen you create Objects you’re dealing with reference types.\r\n\r\nemployee2 = employee1;\r\nSo here (above), we will pass a reference (Not a value), in other words, now both variables share the same reference to a single object. So if you modify a property of employee2 this changes employee1 as well.\r\n\r\nSo, please see here (below):\r\n\r\nemployee1 = null;\r\nIf you pass a Null value to an object, just like in the example.\r\n\r\nWhat would happen? This is a great question…\r\n\r\nIt will remove the reference between employee1 and the actual Employee object. So our variable employee1 now has no reference, but what about employee2… let me ask you again:\r\n\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nWill the employee2 variable be Null as well?\r\n\r\nIf you thought employee2 value was Null you are wrong 👀\r\nRemember, Both variables have reference types, but each individual variable is different, and if we remove the reference from the first variable, this change will not affect the 2nd one.", "Dear reader, we will not sail on the surface, we will dive into this learning experience covering the Basics, until we touch the floor. In this journey we will figure out how well we know, the basic stuff we are used to when talking about .NET C#, so here’s my question to you, as an experienced sailor:\r\n\r\nEmployee employee1 = new(1, \"Alex Villegas C\");\r\nEmployee employee2 = employee1;\r\nemployee1 = null;\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nTake your time…\r\n\r\nWhen you create Objects you’re dealing with reference types.\r\n\r\nemployee2 = employee1;\r\nSo here (above), we will pass a reference (Not a value), in other words, now both variables share the same reference to a single object. So if you modify a property of employee2 this changes employee1 as well.\r\n\r\nSo, please see here (below):\r\n\r\nemployee1 = null;\r\nIf you pass a Null value to an object, just like in the example.\r\n\r\nWhat would happen? This is a great question…\r\n\r\nIt will remove the reference between employee1 and the actual Employee object. So our variable employee1 now has no reference, but what about employee2… let me ask you again:\r\n\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nWill the employee2 variable be Null as well?\r\n\r\nIf you thought employee2 value was Null you are wrong 👀\r\nRemember, Both variables have reference types, but each individual variable is different, and if we remove the reference from the first variable, this change will not affect the 2nd one." });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("a6470270-a886-4cbb-b5df-ffc779ee1dc9"),
                columns: new[] { "ContentHTML", "ContentText", "Title" },
                values: new object[] { "In this deep dive, we’ll go through the API design, starting from the basics and advancing towards the best practices that define exceptional APIs.\r\n\r\nAs a developer, you’re likely familiar with many of these concepts, but I’ll provide a detailed explanation to deepen your understanding.\r\n\r\nAPI Design: An E-commerce Example\r\nLet’s consider an API for an e-commerce platform like Shopify, which, if you’re not familiar with is a well-known e-commerce platform that allows businesses to set up online stores.\r\n\r\nIn API design, we’re concerned with defining the inputs (like product details for a new product) and outputs (like the information returned when someone queries a product) of an API.\r\n\r\n\r\nThis means that we focus on the interface rather than the low-level implementation\r\n\r\nAPI Design and CRUD:\r\nSo, the focus is mainly on defining how the CRUD operations are exposed to the user or system interacting with your e-commerce API.\r\n\r\nCRUD Stands for Create, Read, Update, Delete. These are the basic operations of any data-driven application.\r\n\r\n\r\nFor example, to add a new product (Create), you would make a POST request to /api/products where the product details are sent in the request body.\r\n\r\nTo retrieve products (Read), you need to fetch data with a GET request from /products.\r\n\r\nFor updating product information (Update), we use PUT or PATCH requests to /products/:id, where id is the id of a product we need to update.\r\n\r\nRemoving is similar to updating; we make a DELETE request to /products/:id where id is the product we need to remove (Delete).", "In this deep dive, we’ll go through the API design, starting from the basics and advancing towards the best practices that define exceptional APIs.\r\n\r\nAs a developer, you’re likely familiar with many of these concepts, but I’ll provide a detailed explanation to deepen your understanding.\r\n\r\nAPI Design: An E-commerce Example\r\nLet’s consider an API for an e-commerce platform like Shopify, which, if you’re not familiar with is a well-known e-commerce platform that allows businesses to set up online stores.\r\n\r\nIn API design, we’re concerned with defining the inputs (like product details for a new product) and outputs (like the information returned when someone queries a product) of an API.\r\n\r\n\r\nThis means that we focus on the interface rather than the low-level implementation\r\n\r\nAPI Design and CRUD:\r\nSo, the focus is mainly on defining how the CRUD operations are exposed to the user or system interacting with your e-commerce API.\r\n\r\nCRUD Stands for Create, Read, Update, Delete. These are the basic operations of any data-driven application.\r\n\r\n\r\nFor example, to add a new product (Create), you would make a POST request to /api/products where the product details are sent in the request body.\r\n\r\nTo retrieve products (Read), you need to fetch data with a GET request from /products.\r\n\r\nFor updating product information (Update), we use PUT or PATCH requests to /products/:id, where id is the id of a product we need to update.\r\n\r\nRemoving is similar to updating; we make a DELETE request to /products/:id where id is the product we need to remove (Delete).", "API Design 101: From Basics to Best Practices" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("aac2e4e5-4372-4571-9bb7-9f3918d02013"),
                columns: new[] { "ContentHTML", "ContentText", "TitleSlugify" },
                values: new object[] { "Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design. Diagram illustrating the components and relationships of Event Sourcing and Command Query Responsibility Segregation (CQRS) in an ASP.NET Core application. Basic CQRS Representation In this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions. Introduction to Event Sourcing Event Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state. What is CQRS? Command Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.", "Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design. Diagram illustrating the components and relationships of Event Sourcing and Command Query Responsibility Segregation (CQRS) in an ASP.NET Core application. Basic CQRS Representation In this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions. Introduction to Event Sourcing Event Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state. What is CQRS? Command Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.", "implementing-event-sourcing" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("ec5f0508-ba97-471d-abae-101d885ab075"),
                columns: new[] { "ContentHTML", "ContentText" },
                values: new object[] { "Dear reader, we will not sail on the surface, we will dive into this learning experience covering the Basics, until we touch the floor. In this journey we will figure out how well we know, the basic stuff we are used to when talking about .NET C#, so here’s my question to you, as an experienced sailor:\r\n\r\nEmployee employee1 = new(1, \"Alex Villegas C\");\r\nEmployee employee2 = employee1;\r\nemployee1 = null;\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nTake your time…\r\n\r\nWhen you create Objects you’re dealing with reference types.\r\n\r\nemployee2 = employee1;\r\nSo here (above), we will pass a reference (Not a value), in other words, now both variables share the same reference to a single object. So if you modify a property of employee2 this changes employee1 as well.\r\n\r\nSo, please see here (below):\r\n\r\nemployee1 = null;\r\nIf you pass a Null value to an object, just like in the example.\r\n\r\nWhat would happen? This is a great question…\r\n\r\nIt will remove the reference between employee1 and the actual Employee object. So our variable employee1 now has no reference, but what about employee2… let me ask you again:\r\n\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nWill the employee2 variable be Null as well?\r\n\r\nIf you thought employee2 value was Null you are wrong 👀\r\nRemember, Both variables have reference types, but each individual variable is different, and if we remove the reference from the first variable, this change will not affect the 2nd one.", "Dear reader, we will not sail on the surface, we will dive into this learning experience covering the Basics, until we touch the floor. In this journey we will figure out how well we know, the basic stuff we are used to when talking about .NET C#, so here’s my question to you, as an experienced sailor:\r\n\r\nEmployee employee1 = new(1, \"Alex Villegas C\");\r\nEmployee employee2 = employee1;\r\nemployee1 = null;\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nTake your time…\r\n\r\nWhen you create Objects you’re dealing with reference types.\r\n\r\nemployee2 = employee1;\r\nSo here (above), we will pass a reference (Not a value), in other words, now both variables share the same reference to a single object. So if you modify a property of employee2 this changes employee1 as well.\r\n\r\nSo, please see here (below):\r\n\r\nemployee1 = null;\r\nIf you pass a Null value to an object, just like in the example.\r\n\r\nWhat would happen? This is a great question…\r\n\r\nIt will remove the reference between employee1 and the actual Employee object. So our variable employee1 now has no reference, but what about employee2… let me ask you again:\r\n\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nWill the employee2 variable be Null as well?\r\n\r\nIf you thought employee2 value was Null you are wrong 👀\r\nRemember, Both variables have reference types, but each individual variable is different, and if we remove the reference from the first variable, this change will not affect the 2nd one." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("84bcbf0f-5fa9-42d6-a043-28b438a66a88"),
                column: "Name",
                value: "kitty");
        }
    }
}
