using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ensek.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT Accounts ON");

            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(2344,'Tommy','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(2233,'Barry','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(8766,'Sally','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(2345,'Jerry','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(2346,'Ollie','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(2347,'Tara','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(2348,'Tammy','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(2349,'Simon','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(2350,'Colin','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(2351,'Gladys','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(2352,'Greg','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(2353,'Tony','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(2355,'Arthur','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(2356,'Craig','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(6776,'Laura','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(4534,'JOSH','TEST')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(1234,'Freya','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(1239,'Noddy','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(1240,'Archie','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(1241,'Lara','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(1242,'Tim','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(1243,'Graham','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(1244,'Tony','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(1245,'Neville','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(1246,'Jo','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(1247,'Jim','Test')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Accounts] ([AccountId],[FirstName],[LastName]) VALUES(1248,'Pam','Test')");

            migrationBuilder.Sql("SET IDENTITY_INSERT Accounts OFF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
