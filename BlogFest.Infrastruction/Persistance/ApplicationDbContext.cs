using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlogFest.Domain;
using BlogFest.Infrastruction.Persistance.DataModels;
using BlogFest.Infrastructure.Persistance.DataModels;
using BlogFest.Infrastruction.Persistance.Configuration;
using BlogFest.Infrastruction.Authtorization;
using BlogFest.Domain.Content;

namespace BlogFest.Infrastructure.Persistance
{
	public class ApplicationDbContext : IdentityDbContext<AuthUser, AuthIdentityRole, Guid>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			Database.Migrate();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.HasSequence<int>("No");

			builder.Ignore<BaseDataModel>();

			builder.Entity<ReactionTypeData>().Property(x => x.Id).HasConversion<int>();

			builder.ApplyConfiguration(new NotificationConfiguration());
			builder.ApplyConfiguration(new UserModelConfiguration());
			builder.ApplyConfiguration(new PostConfiguration());
			builder.ApplyConfiguration(new CategoryConfiguration());
			builder.ApplyConfiguration(new CategoryPostConfiguration());
			builder.ApplyConfiguration(new CommentConfiguration());
			builder.ApplyConfiguration(new FileConfiguration());
			builder.ApplyConfiguration(new UserFileConfiguration());

			SeedData(builder);
		}

		public DbSet<NotificationDataModel> Notifications { get; set; }
		public DbSet<PostDataModel> Posts { get; set; }
		public DbSet<UserModel> Users { get; set; }
		public DbSet<CommentDataModel> Comments { get; set; }
		public DbSet<FileDataModel> Files { get; set; }
		public DbSet<CategoryDataModel> Categories { get; set; }
		public DbSet<CategoryPostDataModel> CategoriesPosts { get; set; }
		public DbSet<PostFileData> PostFiles { get; set; }
		public DbSet<PostReactionData> PostReactions { get; set; }
		public DbSet<ReactionTypeData> ReactionType { get; set; }
		public DbSet<UserFileData> UserFiles { get; set; }

		private void SeedData(ModelBuilder builder)
		{

			SeedFiles(builder);

			SeedPostReactionTypes(builder);

			SeedCategory(builder, new CategoryDataModel
			{
				Title = "Sport",
				EncodedTitle = "Sport",
				Enabled = true,
			});			
			
			SeedCategory(builder, new CategoryDataModel
			{
				Title = "Animals",
				EncodedTitle = "Animals",
				Enabled = true,
			});			
			
			SeedCategory(builder, new CategoryDataModel
			{
				Title = "Finance",
				EncodedTitle = "Finance",
				Enabled = true,
			});		
			
			var hobbieCatId = SeedCategory(builder, new CategoryDataModel
			{
				Title = "Hobbie",
				EncodedTitle = "Hobbie",
				Enabled = true,
			});

			SeedCategory(builder, new CategoryDataModel
			{
				Title = "Languages",
				EncodedTitle = "Languages",
				Enabled = true,
			});		
			
			SeedCategory(builder, new CategoryDataModel
			{
				Title = "Music",
				EncodedTitle = "Music",
				Enabled = true,
			});

			var cookingCategoryId = SeedCategory(builder, new CategoryDataModel
			{
				Title = "Сooking",
				EncodedTitle = "Сooking",
				Enabled = true,
			});

			var roleId = SeedRole(builder);

			var adminId = SeedUser(builder, "admin", "admin", "admin", "Administrator of this wonderful site. I’m also a .net developer and write about clean architecture, domain driven design.");
			var martinId = SeedUser(builder, "marty", "Martin", "Fowler", "I am Martin Fowler: an author, speaker… essentially a loud-mouthed pundit on the topic of software development, primarily for Enterprise Applications");


			SeedPost(builder, new List<Guid> { cookingCategoryId}, new PostDataModel{
				Title = "Ukrainian Red Borscht Soup",
				UserId = adminId,
				PostStatus = PostStatus.Published,
				TitleSlugify = "ukrainian-red-borscht-soup",
				Slug = "ukrainian-red-borscht-soup",
				ContentText = "What Is Borscht? \r\n\r\nBorscht is a sour soup that is traditionally made with meat stock and boiled vegetables. The Ukrainian version, which features beets, is perhaps the most well known type — but varieties of borscht can be found throughout Central and Eastern Europe and Northern Asia. \r\n\r\nBorscht Ingredients\r\n\r\nThese are the ingredients you’ll need to make this top-rated borscht recipe: \r\n\r\nSausage: This Ukrainian borscht recipe starts with a pound of pork sausage. \r\nVegetables: You’ll need beets, carrots, baking potatoes, cabbage, and an onion. \r\nCanned tomatoes: Use drained diced tomatoes and canned tomato paste. \r\nVegetable oil: Cook the onion in oil. \r\nWater: You’ll need almost nine cups of water for this big-batch soup. \r\nGarlic: Three cloves of garlic add bold flavor. \r\nSugar: A teaspoon of white sugar lends subtle sweetness. \r\nSeasonings: Season the borscht with salt and pepper to taste. \r\nSour cream: Top the borscht with sour cream. \r\nFresh herbs: Garnish the soup with fresh parsley or dill. \r\nHow to Make Borscht\r\n\r\nYou’ll find the full, step-by-step recipe below — but here’s a brief overview of what you can expect when you make Ukrainian borscht: \r\n\r\nCook the sausage and set aside. \r\nBoil water, add the sausage, then add the vegetables and diced tomatoes. \r\nCook the onion, stir in the tomato paste, and thin with water. Transfer to the pot. \r\nAdd the garlic, cover, and turn off the heat. Stir in the sugar and seasonings. \r\nLadle into bowls and garnish with sour cream and fresh herbs. \r\n\r\n\r\n",
				ContentHTML = "<h2><strong>What Is Borscht?&nbsp;</strong></h2><p>Borscht is a sour soup that is traditionally made with meat stock and boiled vegetables. The Ukrainian version, which features beets, is perhaps the most well known type — but varieties of borscht can be found throughout Central and Eastern Europe and Northern Asia.&nbsp;</p><h2><strong>Borscht Ingredients</strong></h2><p>These are the ingredients you’ll need to make this top-rated borscht recipe:&nbsp;</p><ul><li><strong>Sausage</strong>: This Ukrainian borscht recipe starts with a pound of pork sausage.&nbsp;</li><li><strong>Vegetables</strong>: You’ll need beets, carrots, baking potatoes, cabbage, and an onion.&nbsp;</li><li><strong>Canned tomatoes</strong>: Use drained diced tomatoes and canned tomato paste.&nbsp;</li><li><strong>Vegetable oil</strong>: Cook the onion in oil.&nbsp;</li><li><strong>Water</strong>: You’ll need almost nine cups of water for this big-batch soup.&nbsp;</li><li><strong>Garlic</strong>: Three cloves of garlic add bold flavor.&nbsp;</li><li><strong>Sugar</strong>: A teaspoon of white sugar lends subtle sweetness.&nbsp;</li><li><strong>Seasonings</strong>: Season the borscht with salt and pepper to taste.&nbsp;</li><li><strong>Sour cream</strong>: Top the borscht with sour cream.&nbsp;</li><li><strong>Fresh herbs</strong>: Garnish the soup with fresh parsley or dill.&nbsp;</li></ul><h2><strong>How to Make Borscht</strong></h2><p>You’ll find the full, step-by-step recipe below — but here’s a brief overview of what you can expect when you make Ukrainian borscht:&nbsp;</p><ol><li>Cook the sausage and set aside.&nbsp;</li><li>Boil water, add the sausage, then add the vegetables and diced tomatoes.&nbsp;</li><li>Cook the onion, stir in the tomato paste, and thin with water. Transfer to the pot.&nbsp;</li><li>Add the garlic, cover, and turn off the heat. Stir in the sugar and seasonings.&nbsp;</li><li>Ladle into bowls and garnish with sour cream and fresh herbs.&nbsp;</li></ol><p><br></p>"
			});

			SeedPost(builder, new List<Guid> { hobbieCatId }, new PostDataModel
			{
				Title = "Implementing Event Sourcing",
				UserId = adminId,
				PostStatus = PostStatus.Hidden,
				TitleSlugify = "implementing-event-sourcing",
				Slug = "implementing-event-sourcing",
				ContentText = "Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design.\r\n\r\nBasic CQRS Representation\r\n\r\nIn this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions.\r\n\r\nIntroduction to Event Sourcing\r\n\r\nEvent Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state.\r\n\r\n\r\n\r\n\r\nWhat is CQRS?\r\n\r\nCommand Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.\r\n\r\nBenefits of Event Sourcing and CQRS in Microservices\r\n\r\nThe combination of Event Sourcing and CQRS offers several advantages when applied to microservices-based applications:\r\n\r\n\r\n\r\n\r\nHistorical Transparency: Event Sourcing ensures a comprehensive record of all state changes, providing historical transparency for auditing, compliance, and debugging purposes.\r\nFlexibility in Query Optimization: CQRS empowers you to optimize read and write paths differently. This means you can tailor the read path for query performance while optimizing the write path for high throughput.\r\nScalability and Performance: Microservices architectures demand efficient scaling. Event Sourcing and CQRS allow you to scale different parts of your application independently, enhancing overall performance.\r\nResilience and Fault Tolerance: Event Sourcing enhances resilience by allowing the reconstruction of application state after a failure. CQRS helps isolate errors and failures in the write path from affecting the read path.\r\nSupport for Complex Domains: Event Sourcing allows you to capture complex domain behavior accurately by recording fine-grained events. CQRS then enables tailored views of this data for various use cases.\r\nGetting Started with ASP.NET Core Microservices\r\n\r\nSetting the Foundation: Creating an ASP.NET Core Microservices Solution\r\n\r\n\r\n\r\n\r\nTo implement Event Sourcing and Command Query Responsibility Segregation (CQRS) in ASP.NET Core microservices, you’ll first need to set up your development environment and create the necessary solution structure. Here’s a step-by-step guide to get you started:\r\n\r\n1. Install .NET Core SDK: Make sure you have the latest .NET Core SDK installed on your machine. You can download it from the official Microsoft website.\r\n\r\n2. Create a New Solution: Open your command-line interface and navigate to the directory where you want to create your solution. Use the following command to create a new ASP.NET Core solution:\r\n\r\ndotnet new sln -n MicroservicesSolution\r\n\r\n\r\n3. Create Microservices Projects: Inside your solution folder, create individual projects for each microservice. For example, you can create projects named OrderService, PaymentService, and NotificationService:\r\n\r\ndotnet new webapi -n OrderService\r\ndotnet new webapi -n PaymentService\r\ndotnet new webapi -n NotificationService\r\n\r\n\r\n4. Add Projects to Solution: Add the microservices projects to the solution using the following command:\r\n\r\ndotnet sln MicroservicesSolution.sln add OrderService\\OrderService.csproj\r\ndotnet sln MicroservicesSolution.sln add PaymentService\\PaymentService.csproj\r\ndotnet sln MicroservicesSolution.sln add NotificationService\\NotificationService.csproj\r\n\r\nDefining Domain Events and Commands\r\n\r\nWith your solution structure in place, you’re ready to define the core building blocks of Event Sourcing and CQRS: domain events and commands.\r\n\r\n\r\n\r\n\r\nCreate a Shared Library: To avoid duplicating domain-related code, create a shared library that contains common classes like domain events, commands, and value objects. Use the following command to create a class library project:\r\n\r\n\r\n\r\n\r\ndotnet new classlib -n SharedDomain\r\n\r\nAdd the Shared Library to Solution: Add the shared library project to the solution:\r\n\r\n\r\n\r\n\r\ndotnet sln MicroservicesSolution.sln add SharedDomain\\SharedDomain.csproj\r\n\r\nDefine Domain Events and Commands: Inside the SharedDomain project, define your domain events and commands as C# classes. For example:\r\n\r\n\r\n\r\n\r\npublic class OrderPlacedEvent\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public DateTime Timestamp { get; set; }\r\n}\r\n\r\npublic class ProcessPaymentCommand\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public decimal Amount { get; set; }\r\n}\r\n\r\nReference the Shared Library: In each microservice project, add a reference to the SharedDomain library:\r\n\r\n\r\n\r\n\r\ndotnet add OrderService\\OrderService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add PaymentService\\PaymentService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add NotificationService\\NotificationService.csproj reference SharedDomai\r\n\r\n\r\n\r\n",
				ContentHTML = "<p>Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design.</p><p>Basic CQRS Representation</p><p>In this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions.</p><h1>Introduction to Event Sourcing</h1><p>Event Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state.</p><p><br></p><h1>What is CQRS?</h1><p>Command Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.</p><h2>Benefits of Event Sourcing and CQRS in Microservices</h2><p>The combination of Event Sourcing and CQRS offers several advantages when applied to microservices-based applications:</p><p><br></p><ol><li><strong>Historical Transparency:</strong>&nbsp;Event Sourcing ensures a comprehensive record of all state changes, providing historical transparency for auditing, compliance, and debugging purposes.</li><li><strong>Flexibility in Query Optimization:</strong>&nbsp;CQRS empowers you to optimize read and write paths differently. This means you can tailor the read path for query performance while optimizing the write path for high throughput.</li><li><strong>Scalability and Performance:</strong>&nbsp;Microservices architectures demand efficient scaling. Event Sourcing and CQRS allow you to scale different parts of your application independently, enhancing overall performance.</li><li><strong>Resilience and Fault Tolerance:</strong>&nbsp;Event Sourcing enhances resilience by allowing the reconstruction of application state after a failure. CQRS helps isolate errors and failures in the write path from affecting the read path.</li><li><strong>Support for Complex Domains:</strong>&nbsp;Event Sourcing allows you to capture complex domain behavior accurately by recording fine-grained events. CQRS then enables tailored views of this data for various use cases.</li></ol><h2>Getting Started with ASP.NET Core Microservices</h2><p>Setting the Foundation: Creating an ASP.NET Core Microservices Solution</p><p><br></p><p>To implement Event Sourcing and Command Query Responsibility Segregation (CQRS) in ASP.NET Core microservices, you’ll first need to set up your development environment and create the necessary solution structure. Here’s a step-by-step guide to get you started:</p><p><strong>1. Install .NET Core SDK:</strong>&nbsp;Make sure you have the latest .NET Core SDK installed on your machine. You can download it from the official&nbsp;<a href=\"https://dotnet.microsoft.com/download\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">Microsoft website</a>.</p><p><strong>2. Create a New Solution:&nbsp;</strong>Open your command-line interface and navigate to the directory where you want to create your solution. Use the following command to create a new ASP.NET Core solution:</p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet new sln -n MicroservicesSolution\r\n</pre><p><strong>3. Create Microservices Projects:</strong>&nbsp;Inside your solution folder, create individual projects for each microservice. For example, you can create projects named&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">OrderService</code>,&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">PaymentService</code>, and&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">NotificationService</code>:</p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet new webapi -n OrderService\r\ndotnet new webapi -n PaymentService\r\ndotnet new webapi -n NotificationService\r\n</pre><p><strong>4. Add Projects to Solution:</strong>&nbsp;Add the microservices projects to the solution using the following command:</p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet sln MicroservicesSolution.sln add OrderService\\OrderService.csproj\r\ndotnet sln MicroservicesSolution.sln add PaymentService\\PaymentService.csproj\r\ndotnet sln MicroservicesSolution.sln add NotificationService\\NotificationService.csproj\r\n</pre><h2>Defining Domain Events and Commands</h2><p>With your solution structure in place, you’re ready to define the core building blocks of Event Sourcing and CQRS: domain events and commands.</p><p><br></p><ul><li><strong>Create a Shared Library:</strong>&nbsp;To avoid duplicating domain-related code, create a shared library that contains common classes like domain events, commands, and value objects. Use the following command to create a class library project:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet new classlib -n SharedDomain\r\n</pre><ul><li><strong>Add the Shared Library to Solution:</strong>&nbsp;Add the shared library project to the solution:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet sln MicroservicesSolution.sln add SharedDomain\\SharedDomain.csproj\r\n</pre><ul><li><strong>Define Domain Events and Commands:</strong>&nbsp;Inside the&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">SharedDomain</code>&nbsp;project, define your domain events and commands as C# classes. For example:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">public class OrderPlacedEvent\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public DateTime Timestamp { get; set; }\r\n}\r\n\r\npublic class ProcessPaymentCommand\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public decimal Amount { get; set; }\r\n}\r\n</pre><ul><li><strong>Reference the Shared Library:</strong>&nbsp;In each microservice project, add a reference to the&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">SharedDomain</code>&nbsp;library:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet add OrderService\\OrderService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add PaymentService\\PaymentService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add NotificationService\\NotificationService.csproj reference SharedDomai\r\n</pre><p><br></p>"
			});

			SeedPost(builder, new List<Guid> { hobbieCatId }, new PostDataModel
			{
				Title = "API Design 101: Best Practices",
				UserId = adminId,
				PostStatus = PostStatus.Published,
				TitleSlugify = "api-design-101-from-basics-to-best-practices",
				Slug = "api-design-101-from-basics-to-best-practices",
				ContentText = "The Tech side of startups can sometimes be very fluid and contain a lot of unknowns. What tech stack to use? Which components might be overkill for now but worth keeping an eye on in the future? How to balance the pace of business features development while keeping the quality bar high enough to have a maintainable codebase?\r\n\r\n\r\n\r\n\r\nHere I want to share our experience building from the ground up — how we shaped our processes based on needs and how our processes evolved as we extended our tech stack with new components.\r\n\r\nBusinesses want to conquer the market and engineers — try cool stuff and stretch their brains. Meanwhile, the industry produces new languages, frameworks, and libraries in such quantities that you will not be able to check them all. And, usually, if you scratch the shiny surface of the Next Big Thing, you will find a good old concept. \r\n\r\n\r\n\r\n\r\nGood, if you are lucky.\r\n\r\nOne of the most exciting topics to argue about is the processes — whether you rely on trunk-based development, prefer a more monstrous GitHub flow, are a fan of mobbing, or find it more efficient to spend time in PR-based code reviews.\r\n\r\nI have experience working in an environment where artifacts were thrown away on users without any standardized process. In case of issues, developers had a lot of fun (nope!) trying to figure out what version of components was actually deployed.\r\n\r\nOn another spectrum is the never-ending queue to CI. After you create PR you have to entertain yourself in the nearest 30 minutes by betting whether the CI cluster will find a resource to run tests over your changes. Sometimes the platform team introduces new, exciting, and useful features that might break compatibility with existing boilerplate for CI. These may result in failing all your checks at the last minute, after an hour of waiting.",
				ContentHTML = "<p>The Tech side of startups can sometimes be very fluid and contain a lot of unknowns. What tech stack to use? Which components might be&nbsp;overkill&nbsp;for now but worth keeping an eye on in the future? How to balance the pace of business features development while keeping the quality bar high enough to have a maintainable codebase?</p><p><br></p><p>Here I want to share our experience building&nbsp;from the ground up — how we shaped our processes based on needs and how our processes evolved as we extended our tech stack with new components.</p><p>Businesses want to conquer the market and engineers — try cool stuff and stretch their brains. Meanwhile, the industry produces new languages, frameworks, and libraries in such quantities that you will not be able to check them all. And, usually, if you scratch the shiny surface of the Next Big Thing, you will find a good old concept. </p><p><br></p><p>Good, if you are lucky.</p><p>One of the most exciting topics to argue about is the processes — whether you rely on&nbsp;<a href=\"https://trunkbaseddevelopment.com/\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">trunk-based development</a>, prefer a more monstrous&nbsp;<a href=\"https://www.endoflineblog.com/gitflow-considered-harmful\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">GitHub flow</a>, are a fan of&nbsp;<a href=\"https://www.agilealliance.org/glossary/mob-programming/\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">mobbing</a>, or find it more efficient to spend time in&nbsp;<a href=\"https://trunkbaseddevelopment.com/short-lived-feature-branches/\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">PR-based</a>&nbsp;code reviews.</p><p>I have experience working in an environment where artifacts were thrown away on users without any standardized process. In case of issues, developers had a lot of fun (nope!) trying to figure out what version of components was actually deployed.</p><p>On another spectrum is the never-ending queue to CI. After you create PR you have to entertain yourself in the nearest 30 minutes by betting whether the CI cluster will find a resource to run tests over your changes. Sometimes the platform team introduces new, exciting, and useful features that might break compatibility with existing boilerplate for CI. These may result in failing all your checks at the last minute, after an hour of waiting.</p>"
			});

			SeedPost(builder, new List<Guid> { hobbieCatId }, new PostDataModel
			{
				Title = ".NET/C# Fundamentals for Senior Devs",
				UserId = adminId,
				PostStatus = PostStatus.Published,
				TitleSlugify = "net-fundamentals-for-senior-devs",
				Slug = "net-fundamentals-for-senior-devs",
				ContentText = "Dear reader, we will not sail on the surface, we will dive into this learning experience covering the Basics, until we touch the floor. In this journey we will figure out how well we know, the basic stuff we are used to when talking about .NET C#, so here’s my question to you, as an experienced sailor:\r\n\r\nEmployee employee1 = new(1, \"Alex Villegas C\");\r\nEmployee employee2 = employee1;\r\nemployee1 = null;\r\n\r\n\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\n\r\nTake your time…\r\n\r\nWhen you create Objects you’re dealing with reference types.\r\n\r\nemployee2 = employee1;\r\n\r\n\r\nSo here (above), we will pass a reference (Not a value), in other words, now both variables share the same reference to a single object. So if you modify a property of employee2 this changes employee1 as well.\r\n\r\nSo, please see here (below):\r\n\r\nemployee1 = null;\r\n\r\n\r\nIf you pass a Null value to an object, just like in the example.\r\n\r\nWhat would happen? This is a great question…\r\n\r\n\r\n\r\n\r\nIt will remove the reference between employee1 and the actual Employee object. So our variable employee1 now has no reference, but what about employee2… let me ask you again:\r\n\r\nWhat do you think would be the value of the employee2 variable at the end of this execution?\r\nWill the employee2 variable be Null as well?\r\n\r\nIf you thought employee2 value was Null you are wrong 👀\r\n\r\nRemember, Both variables have reference types, but each individual variable is different, and if we remove the reference from the first variable, this change will not affect the 2nd one.",
				ContentHTML = "<p>Dear reader, we will not sail on the surface, we will dive into this learning experience covering the Basics, until we touch the floor. In this journey we will figure out how well we know, the basic stuff we are used to when talking about .NET C#, so here’s my question to you, as an experienced sailor:</p><pre class=\"ql-syntax\" spellcheck=\"false\">Employee employee1 = new(1, \"Alex Villegas C\");\r\nEmployee employee2 = employee1;\r\nemployee1 = null;\r\n</pre><p>What do you think would be the value of the&nbsp;<strong>employee2&nbsp;</strong>variable at the end of this execution?</p><p><strong><em>Take your time…</em></strong></p><p>When you create Objects you’re dealing with reference types.</p><pre class=\"ql-syntax\" spellcheck=\"false\">employee2 = employee1;\r\n</pre><p>So here (above), we will pass a reference (<strong>Not a value</strong>), in other words, now both variables share the same reference to a single object. So if you modify a property of&nbsp;<strong>employee2&nbsp;</strong>this changes&nbsp;<strong>employee1&nbsp;</strong>as well<strong>.</strong></p><p>So, please see here (below):</p><pre class=\"ql-syntax\" spellcheck=\"false\">employee1 = null;\r\n</pre><p>If you pass a&nbsp;<strong>Null&nbsp;</strong>value to an object, just like in the example.</p><blockquote><em>What would happen? This is a great question…</em></blockquote><p><br></p><p>It will remove the reference between&nbsp;<strong>employee1&nbsp;</strong>and the actual&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">Employee</code>&nbsp;object. So our variable&nbsp;<strong>employee1&nbsp;</strong>now has no reference, but what about&nbsp;<strong>employee2…</strong>&nbsp;let me ask you again:</p><blockquote><em>What do you think would be the value of the&nbsp;</em><strong><em>employee2&nbsp;</em></strong><em>variable at the end of this execution?</em></blockquote><blockquote><em>Will the employee2 variable be Null as well?</em></blockquote><p>If you thought&nbsp;<strong>employee2&nbsp;</strong>value was&nbsp;<strong>Null&nbsp;</strong>you are wrong 👀</p><p><strong>Remember,&nbsp;</strong>Both variables have reference types, but each individual variable is different, and if we remove the reference from the first variable, this change will not affect the 2nd one.</p>"
			});

			SeedPost(builder, new List<Guid> { hobbieCatId }, new PostDataModel
			{
				Title = "Implementing Event Sourcing",
				UserId = adminId,
				PostStatus = PostStatus.Draft,
				TitleSlugify = "implementing-event-sourcing",
				Slug = "implementing-event-sourcing-2",
				ContentText = "Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design.\r\n\r\nBasic CQRS Representation\r\n\r\nIn this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions.\r\n\r\nIntroduction to Event Sourcing\r\n\r\nEvent Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state.\r\n\r\n\r\n\r\n\r\nWhat is CQRS?\r\n\r\nCommand Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.\r\n\r\nBenefits of Event Sourcing and CQRS in Microservices\r\n\r\nThe combination of Event Sourcing and CQRS offers several advantages when applied to microservices-based applications:\r\n\r\n\r\n\r\n\r\nHistorical Transparency: Event Sourcing ensures a comprehensive record of all state changes, providing historical transparency for auditing, compliance, and debugging purposes.\r\nFlexibility in Query Optimization: CQRS empowers you to optimize read and write paths differently. This means you can tailor the read path for query performance while optimizing the write path for high throughput.\r\nScalability and Performance: Microservices architectures demand efficient scaling. Event Sourcing and CQRS allow you to scale different parts of your application independently, enhancing overall performance.\r\nResilience and Fault Tolerance: Event Sourcing enhances resilience by allowing the reconstruction of application state after a failure. CQRS helps isolate errors and failures in the write path from affecting the read path.\r\nSupport for Complex Domains: Event Sourcing allows you to capture complex domain behavior accurately by recording fine-grained events. CQRS then enables tailored views of this data for various use cases.\r\nGetting Started with ASP.NET Core Microservices\r\n\r\nSetting the Foundation: Creating an ASP.NET Core Microservices Solution\r\n\r\n\r\n\r\n\r\nTo implement Event Sourcing and Command Query Responsibility Segregation (CQRS) in ASP.NET Core microservices, you’ll first need to set up your development environment and create the necessary solution structure. Here’s a step-by-step guide to get you started:\r\n\r\n1. Install .NET Core SDK: Make sure you have the latest .NET Core SDK installed on your machine. You can download it from the official Microsoft website.\r\n\r\n2. Create a New Solution: Open your command-line interface and navigate to the directory where you want to create your solution. Use the following command to create a new ASP.NET Core solution:\r\n\r\ndotnet new sln -n MicroservicesSolution\r\n\r\n\r\n3. Create Microservices Projects: Inside your solution folder, create individual projects for each microservice. For example, you can create projects named OrderService, PaymentService, and NotificationService:\r\n\r\ndotnet new webapi -n OrderService\r\ndotnet new webapi -n PaymentService\r\ndotnet new webapi -n NotificationService\r\n\r\n\r\n4. Add Projects to Solution: Add the microservices projects to the solution using the following command:\r\n\r\ndotnet sln MicroservicesSolution.sln add OrderService\\OrderService.csproj\r\ndotnet sln MicroservicesSolution.sln add PaymentService\\PaymentService.csproj\r\ndotnet sln MicroservicesSolution.sln add NotificationService\\NotificationService.csproj\r\n\r\nDefining Domain Events and Commands\r\n\r\nWith your solution structure in place, you’re ready to define the core building blocks of Event Sourcing and CQRS: domain events and commands.\r\n\r\n\r\n\r\n\r\nCreate a Shared Library: To avoid duplicating domain-related code, create a shared library that contains common classes like domain events, commands, and value objects. Use the following command to create a class library project:\r\n\r\n\r\n\r\n\r\ndotnet new classlib -n SharedDomain\r\n\r\nAdd the Shared Library to Solution: Add the shared library project to the solution:\r\n\r\n\r\n\r\n\r\ndotnet sln MicroservicesSolution.sln add SharedDomain\\SharedDomain.csproj\r\n\r\nDefine Domain Events and Commands: Inside the SharedDomain project, define your domain events and commands as C# classes. For example:\r\n\r\n\r\n\r\n\r\npublic class OrderPlacedEvent\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public DateTime Timestamp { get; set; }\r\n}\r\n\r\npublic class ProcessPaymentCommand\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public decimal Amount { get; set; }\r\n}\r\n\r\nReference the Shared Library: In each microservice project, add a reference to the SharedDomain library:\r\n\r\n\r\n\r\n\r\ndotnet add OrderService\\OrderService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add PaymentService\\PaymentService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add NotificationService\\NotificationService.csproj reference SharedDomai\r\n\r\n\r\n\r\n",
				ContentHTML = "<p>Event Sourcing and Command Query Responsibility Segregation (CQRS) have emerged as powerful architectural patterns to address the complexities of microservices design.</p><p>Basic CQRS Representation</p><p>In this article, we’ll explore how ASP.NET Core empowers you to integrate Event Sourcing and CQRS seamlessly into your microservices ecosystem. By understanding their fundamentals, practical implementation, and tools available, you’ll be well-equipped to architect robust and efficient microservices solutions.</p><h1>Introduction to Event Sourcing</h1><p>Event Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state.</p><p><br></p><h1>What is CQRS?</h1><p>Command Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.</p><h2>Benefits of Event Sourcing and CQRS in Microservices</h2><p>The combination of Event Sourcing and CQRS offers several advantages when applied to microservices-based applications:</p><p><br></p><ol><li><strong>Historical Transparency:</strong>&nbsp;Event Sourcing ensures a comprehensive record of all state changes, providing historical transparency for auditing, compliance, and debugging purposes.</li><li><strong>Flexibility in Query Optimization:</strong>&nbsp;CQRS empowers you to optimize read and write paths differently. This means you can tailor the read path for query performance while optimizing the write path for high throughput.</li><li><strong>Scalability and Performance:</strong>&nbsp;Microservices architectures demand efficient scaling. Event Sourcing and CQRS allow you to scale different parts of your application independently, enhancing overall performance.</li><li><strong>Resilience and Fault Tolerance:</strong>&nbsp;Event Sourcing enhances resilience by allowing the reconstruction of application state after a failure. CQRS helps isolate errors and failures in the write path from affecting the read path.</li><li><strong>Support for Complex Domains:</strong>&nbsp;Event Sourcing allows you to capture complex domain behavior accurately by recording fine-grained events. CQRS then enables tailored views of this data for various use cases.</li></ol><h2>Getting Started with ASP.NET Core Microservices</h2><p>Setting the Foundation: Creating an ASP.NET Core Microservices Solution</p><p><br></p><p>To implement Event Sourcing and Command Query Responsibility Segregation (CQRS) in ASP.NET Core microservices, you’ll first need to set up your development environment and create the necessary solution structure. Here’s a step-by-step guide to get you started:</p><p><strong>1. Install .NET Core SDK:</strong>&nbsp;Make sure you have the latest .NET Core SDK installed on your machine. You can download it from the official&nbsp;<a href=\"https://dotnet.microsoft.com/download\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">Microsoft website</a>.</p><p><strong>2. Create a New Solution:&nbsp;</strong>Open your command-line interface and navigate to the directory where you want to create your solution. Use the following command to create a new ASP.NET Core solution:</p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet new sln -n MicroservicesSolution\r\n</pre><p><strong>3. Create Microservices Projects:</strong>&nbsp;Inside your solution folder, create individual projects for each microservice. For example, you can create projects named&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">OrderService</code>,&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">PaymentService</code>, and&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">NotificationService</code>:</p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet new webapi -n OrderService\r\ndotnet new webapi -n PaymentService\r\ndotnet new webapi -n NotificationService\r\n</pre><p><strong>4. Add Projects to Solution:</strong>&nbsp;Add the microservices projects to the solution using the following command:</p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet sln MicroservicesSolution.sln add OrderService\\OrderService.csproj\r\ndotnet sln MicroservicesSolution.sln add PaymentService\\PaymentService.csproj\r\ndotnet sln MicroservicesSolution.sln add NotificationService\\NotificationService.csproj\r\n</pre><h2>Defining Domain Events and Commands</h2><p>With your solution structure in place, you’re ready to define the core building blocks of Event Sourcing and CQRS: domain events and commands.</p><p><br></p><ul><li><strong>Create a Shared Library:</strong>&nbsp;To avoid duplicating domain-related code, create a shared library that contains common classes like domain events, commands, and value objects. Use the following command to create a class library project:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet new classlib -n SharedDomain\r\n</pre><ul><li><strong>Add the Shared Library to Solution:</strong>&nbsp;Add the shared library project to the solution:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet sln MicroservicesSolution.sln add SharedDomain\\SharedDomain.csproj\r\n</pre><ul><li><strong>Define Domain Events and Commands:</strong>&nbsp;Inside the&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">SharedDomain</code>&nbsp;project, define your domain events and commands as C# classes. For example:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">public class OrderPlacedEvent\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public DateTime Timestamp { get; set; }\r\n}\r\n\r\npublic class ProcessPaymentCommand\r\n{\r\n    public Guid OrderId { get; set; }\r\n    public decimal Amount { get; set; }\r\n}\r\n</pre><ul><li><strong>Reference the Shared Library:</strong>&nbsp;In each microservice project, add a reference to the&nbsp;<code style=\"background-color: rgb(242, 242, 242);\">SharedDomain</code>&nbsp;library:</li></ul><p><br></p><pre class=\"ql-syntax\" spellcheck=\"false\">dotnet add OrderService\\OrderService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add PaymentService\\PaymentService.csproj reference SharedDomain\\SharedDomain.csproj\r\ndotnet add NotificationService\\NotificationService.csproj reference SharedDomai\r\n</pre><p><br></p>"
			});

			SeedPost(builder, new List<Guid> { hobbieCatId }, new PostDataModel
			{
				Title = "The Architecture of a Modern Startup",
				UserId = martinId,
				PostStatus = PostStatus.Published,
				TitleSlugify = "the-architecture-of-a-modern-startup",
				Slug = "the-architecture-of-a-modern-startup",
				ContentText = "The Tech side of startups can sometimes be very fluid and contain a lot of unknowns. What tech stack to use? Which components might be overkill for now but worth keeping an eye on in the future? How to balance the pace of business features development while keeping the quality bar high enough to have a maintainable codebase?\r\n\r\n\r\n\r\n\r\nHere I want to share our experience building from the ground up — how we shaped our processes based on needs and how our processes evolved as we extended our tech stack with new components.\r\n\r\nBusinesses want to conquer the market and engineers — try cool stuff and stretch their brains. Meanwhile, the industry produces new languages, frameworks, and libraries in such quantities that you will not be able to check them all. And, usually, if you scratch the shiny surface of the Next Big Thing, you will find a good old concept. \r\n\r\n\r\n\r\n\r\nGood, if you are lucky.\r\n\r\nOne of the most exciting topics to argue about is the processes — whether you rely on trunk-based development, prefer a more monstrous GitHub flow, are a fan of mobbing, or find it more efficient to spend time in PR-based code reviews.\r\n\r\nI have experience working in an environment where artifacts were thrown away on users without any standardized process. In case of issues, developers had a lot of fun (nope!) trying to figure out what version of components was actually deployed.\r\n\r\nOn another spectrum is the never-ending queue to CI. After you create PR you have to entertain yourself in the nearest 30 minutes by betting whether the CI cluster will find a resource to run tests over your changes. Sometimes the platform team introduces new, exciting, and useful features that might break compatibility with existing boilerplate for CI. These may result in failing all your checks at the last minute, after an hour of waiting.",
				ContentHTML = "<p>The Tech side of startups can sometimes be very fluid and contain a lot of unknowns. What tech stack to use? Which components might be&nbsp;overkill&nbsp;for now but worth keeping an eye on in the future? How to balance the pace of business features development while keeping the quality bar high enough to have a maintainable codebase?</p><p><br></p><p>Here I want to share our experience building&nbsp;from the ground up — how we shaped our processes based on needs and how our processes evolved as we extended our tech stack with new components.</p><p>Businesses want to conquer the market and engineers — try cool stuff and stretch their brains. Meanwhile, the industry produces new languages, frameworks, and libraries in such quantities that you will not be able to check them all. And, usually, if you scratch the shiny surface of the Next Big Thing, you will find a good old concept. </p><p><br></p><p>Good, if you are lucky.</p><p>One of the most exciting topics to argue about is the processes — whether you rely on&nbsp;<a href=\"https://trunkbaseddevelopment.com/\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">trunk-based development</a>, prefer a more monstrous&nbsp;<a href=\"https://www.endoflineblog.com/gitflow-considered-harmful\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">GitHub flow</a>, are a fan of&nbsp;<a href=\"https://www.agilealliance.org/glossary/mob-programming/\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">mobbing</a>, or find it more efficient to spend time in&nbsp;<a href=\"https://trunkbaseddevelopment.com/short-lived-feature-branches/\" rel=\"noopener noreferrer\" target=\"_blank\" style=\"color: inherit;\">PR-based</a>&nbsp;code reviews.</p><p>I have experience working in an environment where artifacts were thrown away on users without any standardized process. In case of issues, developers had a lot of fun (nope!) trying to figure out what version of components was actually deployed.</p><p>On another spectrum is the never-ending queue to CI. After you create PR you have to entertain yourself in the nearest 30 minutes by betting whether the CI cluster will find a resource to run tests over your changes. Sometimes the platform team introduces new, exciting, and useful features that might break compatibility with existing boilerplate for CI. These may result in failing all your checks at the last minute, after an hour of waiting.</p>"
			});

			SeedUserRoles(builder, roleId, adminId);
		}
		private void SeedPost(ModelBuilder builder, List<Guid> categories, PostDataModel post)
		{
			var id = Guid.NewGuid();
			post.Id = id;

			var catPost = categories.Select(x => new CategoryPostDataModel
			{
				Id = Guid.NewGuid(),
				CategoryId = x,
				PostId = id
			}).ToList();

			builder.Entity<CategoryPostDataModel>().HasData(catPost);

			builder.Entity<PostDataModel>().HasData(post);
		}
		private void SeedUserRoles(ModelBuilder builder, Guid roleId, Guid userId)
		{
			builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
			{
				RoleId = roleId,
				UserId = userId
			});
		}

		private Guid SeedRole(ModelBuilder builder)
		{
			var roleId = Guid.NewGuid();
			builder.Entity<AuthIdentityRole>().HasData(new AuthIdentityRole
			{
				Name = "Admin",
				NormalizedName = "ADMIN",
				Id = roleId,
				ConcurrencyStamp = Guid.NewGuid().ToString()
			});

			return roleId;
		}

		private void SeedFiles(ModelBuilder builder)
		{
			builder.Entity<FileDataModel>().HasData(new FileDataModel
			{
				Id = Guid.NewGuid(),
				Path = "Images\\default-user-img.jpeg",
				Name = "Default-Image",
				Type = MediaTypes.ProfilePhoto
			});

			builder.Entity<FileDataModel>().HasData(new FileDataModel
			{
				Id = Guid.NewGuid(),
				Path = "Images\\default-image-title-preview.jpg",
				Name = "Default-image-title-preview",
				Type = MediaTypes.ImageTitlePreview
			});
		}

		private void SeedPostReactionTypes(ModelBuilder builder)
		{
			builder.Entity<ReactionTypeData>().HasData(
			Enum.GetValues(typeof(ReactionTypeId)).Cast<ReactionTypeId>().Select(x => new ReactionTypeData
			{
				Id = x,
				Description = x.ToString()
			}));
		}

		private Guid SeedCategory(ModelBuilder builder, CategoryDataModel category)
		{
			var id = Guid.NewGuid();
			category.Id = id;
			builder.Entity<CategoryDataModel>().HasData(category);
			return id;
		}


		private Guid SeedUser(ModelBuilder builder, string name, string firstName = "", string lastName = "", string bio = "", string email = "")
		{
			var id = Guid.NewGuid();
			var user = new UserModel
			{
				Id = id,
				Name = name,
				FirstName = firstName,
				LastName = lastName,
				Bio = bio,
				IsCommentAllowed = true,
				IsCreatePostAllowed = true,
				Active = true,
			};

			var authUser = new AuthUser
			{
				Id = id,
				Email = "",
				EmailConfirmed = true,
				UserName = name,
				NormalizedUserName = name.ToLower(),
				SecurityStamp = Guid.NewGuid().ToString(),
			};

			PasswordHasher<AuthUser> ph = new PasswordHasher<AuthUser>();
			authUser.PasswordHash = ph.HashPassword(authUser, "jVKhpWN2rRkb");

			builder.Entity<UserModel>().HasData(user);
			builder.Entity<AuthUser>().HasData(authUser);

			return id;
		}
	}
}
