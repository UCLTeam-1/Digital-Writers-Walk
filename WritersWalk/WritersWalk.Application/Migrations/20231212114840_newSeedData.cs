using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WritersWalk.Application.Migrations;

/// <inheritdoc />
public partial class newSeedData : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "AssignmentSurroundings",
            columns: new[] { "Id", "AssignmentId", "SurroundingsId" },
            values: new object[,]
            {
                { 1, 1, 1 },
                { 2, 2, 1 },
                { 3, 3, 1 },
                { 11, 1, 4 },
                { 12, 2, 4 },
                { 13, 3, 4 }
            });

        migrationBuilder.InsertData(
            table: "AssignmentTopics",
            columns: new[] { "Id", "AssignmentId", "TopicId" },
            values: new object[,]
            {
                { 1, 1, 1 },
                { 2, 2, 1 },
                { 3, 3, 1 }
            });

        migrationBuilder.UpdateData(
            table: "Assignments",
            keyColumn: "Id",
            keyValue: 1,
            columns: new[] { "Description", "Title" },
            values: new object[] { "Hvis du var et træ, hvordan så du så ud? Beskriv dig selv og dine omgivelser. Hvor står du? Hvilken slags træ er du? Hvad er dine kendetegn? Se på træerne omkring dig for at finde inspiration. Brug dine sanser.", "Et træ" });

        migrationBuilder.UpdateData(
            table: "Assignments",
            keyColumn: "Id",
            keyValue: 2,
            columns: new[] { "Description", "Title" },
            values: new object[] { "Tænk på en skillevej, du har mødt, hvor du valgte at gå én vej frem for en anden. Er det længe siden? Hvad skete der? Fulgte du den vej, andre allerede havde betrådt mange gange eller den mere ’vilde’ vej? Skriv hvad du kommer til at tænke på.", "Veje og vildveje" });

        migrationBuilder.UpdateData(
            table: "Assignments",
            keyColumn: "Id",
            keyValue: 3,
            columns: new[] { "Description", "Title" },
            values: new object[] { "Hvornår har du stået overfor en udfordring, som du er kommet igennem? Skriv om den: hvad skete der? Hvad gjorde du?", "En udfordring" });

        migrationBuilder.InsertData(
            table: "Assignments",
            columns: new[] { "Id", "Description", "Title" },
            values: new object[,]
            {
                { 4, "Hver ny dag bringer noget nyt – eller gør den? Hvornår er du sidst begyndt forfra? Er det nemt eller svært at starte på noget nyt? Hvad får udtrykket ”en ny begyndelse” dig til at tænke på?", "En ny begyndelse" },
                { 5, "Skriv som var stilheden en person, der har gået sammen med os på vores vandring. Nu har den forladt os – hvad efterlod den hos dig og hvor gik den hen?", "Skriv et brev til stilheden – start med ’Kære Stilhed’" },
                { 6, "Skriv om en ildsjæl du kender. En, der brænder for noget og sætter alt ind for at arbejde med det, vedkommende tror på eller elsker at lave. Kan du genkende noget hos dig selv i vedkommende?", "Ildsjæl" },
                { 7, "Beskriv det sted du er lige nu og den tur, du har gået herhen. Fortæl om noget ved denne tid på året, der gør dig glad.", "Efterår i skoven" },
                { 8, "Skriv om det, der er på den anden side af havet. Det, du ikke kan se, men forestiller dig – eller drømmer om. ", "Hvad ser du i horisonten" },
                { 9, "Skriv i din dagbog, hvad du har oplevet på en dag alene i naturen.  Hvordan ville du klare dig, hvis du skulle være her alene i tre dage? Ville det være en glæde eller en udfordring?", "Naturen – Et dagbogsnotat" },
                { 10, "Tænk på en sommerdag, da du var barn. Hvad er det første du kommer til at tænke på? Skriv om det. Hvem er med i dit minde? Beskriv vedkommende, hvis der er nogen, og hvis det kun er dig, så beskriv også, hvordan du selv ser ud.", "Sommerminder" }
            });

        migrationBuilder.UpdateData(
            table: "Surroundings",
            keyColumn: "Id",
            keyValue: 6,
            column: "Title",
            value: "Vand");

        migrationBuilder.InsertData(
            table: "Surroundings",
            columns: new[] { "Id", "Title" },
            values: new object[] { 7, "Åbent land" });

        migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
            values: new object[,]
            {
                { "1", "admin", "", "", "admin" },
                { "2", "user", "", "", "user" }
            });

        migrationBuilder.InsertData(
            table: "AssignmentSurroundings",
            columns: new[] { "Id", "AssignmentId", "SurroundingsId" },
            values: new object[,]
            {
                { 4, 4, 1 },
                { 5, 5, 2 },
                { 6, 6, 2 },
                { 7, 7, 2 },
                { 8, 8, 2 },
                { 9, 9, 3 },
                { 10, 10, 3 },
                { 14, 4, 4 },
                { 15, 5, 5 },
                { 16, 6, 5 },
                { 17, 7, 5 },
                { 18, 8, 5 },
                { 19, 9, 6 },
                { 20, 10, 6 },
                { 21, 1, 7 },
                { 22, 2, 7 },
                { 23, 3, 7 },
                { 24, 4, 7 }
            });

        migrationBuilder.InsertData(
            table: "AssignmentTopics",
            columns: new[] { "Id", "AssignmentId", "TopicId" },
            values: new object[,]
            {
                { 4, 4, 2 },
                { 5, 5, 2 },
                { 6, 6, 2 },
                { 7, 7, 3 },
                { 8, 8, 3 },
                { 9, 9, 3 },
                { 10, 10, 3 }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 7);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 9);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 10);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 11);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 12);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 13);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 14);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 15);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 16);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 17);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 18);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 19);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 20);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 21);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 22);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 23);

        migrationBuilder.DeleteData(
            table: "AssignmentSurroundings",
            keyColumn: "Id",
            keyValue: 24);

        migrationBuilder.DeleteData(
            table: "AssignmentTopics",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "AssignmentTopics",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "AssignmentTopics",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "AssignmentTopics",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "AssignmentTopics",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "AssignmentTopics",
            keyColumn: "Id",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "AssignmentTopics",
            keyColumn: "Id",
            keyValue: 7);

        migrationBuilder.DeleteData(
            table: "AssignmentTopics",
            keyColumn: "Id",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "AssignmentTopics",
            keyColumn: "Id",
            keyValue: 9);

        migrationBuilder.DeleteData(
            table: "AssignmentTopics",
            keyColumn: "Id",
            keyValue: 10);

        migrationBuilder.DeleteData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "1");

        migrationBuilder.DeleteData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "2");

        migrationBuilder.DeleteData(
            table: "Assignments",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "Assignments",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "Assignments",
            keyColumn: "Id",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "Assignments",
            keyColumn: "Id",
            keyValue: 7);

        migrationBuilder.DeleteData(
            table: "Assignments",
            keyColumn: "Id",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "Assignments",
            keyColumn: "Id",
            keyValue: 9);

        migrationBuilder.DeleteData(
            table: "Assignments",
            keyColumn: "Id",
            keyValue: 10);

        migrationBuilder.DeleteData(
            table: "Surroundings",
            keyColumn: "Id",
            keyValue: 7);

        migrationBuilder.UpdateData(
            table: "Assignments",
            keyColumn: "Id",
            keyValue: 1,
            columns: new[] { "Description", "Title" },
            values: new object[] { "Skriv en tekst på 500 ord, hvor du udfordrer dig selv", "En udfordring" });

        migrationBuilder.UpdateData(
            table: "Assignments",
            keyColumn: "Id",
            keyValue: 2,
            columns: new[] { "Description", "Title" },
            values: new object[] { "Skriv en tekst på 500 ord, hvor du starter med at skrive: 'Det var en mørk og stormfuld nat...'", "En ny begyndelse" });

        migrationBuilder.UpdateData(
            table: "Assignments",
            keyColumn: "Id",
            keyValue: 3,
            columns: new[] { "Description", "Title" },
            values: new object[] { "Skriv en tekst på 500 ord, hvor du skriver om en vej eller en vildvej", "Veje og Vildveje" });

        migrationBuilder.UpdateData(
            table: "Surroundings",
            keyColumn: "Id",
            keyValue: 6,
            column: "Title",
            value: "Hjem");
    }
}
