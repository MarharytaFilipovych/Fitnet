```terminaloutput
Waiting for resource ready to execute for 'postgres'.
Finished waiting for resource 'postgres'.
fail: Microsoft.EntityFrameworkCore.Database.Command[20102]
Failed executing DbCommand (19ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT "MigrationId", "ProductVersion"
FROM "__EFMigrationsHistory"
ORDER BY "MigrationId";
info: Microsoft.EntityFrameworkCore.Migrations[20411]
Acquiring an exclusive lock for migration application. See https://aka.ms/efcore-docs-migrations-lock for more information if this takes too long.
info: Microsoft.EntityFrameworkCore.Migrations[20402]
Applying migration '20230321064710_Create_Passes_Tables'.
info: Microsoft.EntityFrameworkCore.Migrations[20402]
Starting process...	{"Executable": "/fitnet-ybbwrsyz", "Reconciliation": 9, "Cmd": "C:\\Program Files\\dotnet\\dotnet.exe", "Args": ["run", "--project", "C:\\3 course uni\\microservices\\FinnetApp\\Chapter-1-initial-architecture\\Src\\Fitnet\\Fitnet.csproj", "--no-build", "--configuration", "Debug", "--no-launch-profile"]}
Applying migration '20260225190819_AddOutboxAndSaga'.
info: Microsoft.EntityFrameworkCore.Migrations[20411]
Acquiring an exclusive lock for migration application. See https://aka.ms/efcore-docs-migrations-lock for more information if this takes too long.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT "MigrationId", "ProductVersion"
FROM "__EFMigrationsHistory"
ORDER BY "MigrationId";
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT 1
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
"MigrationId" character varying(150) NOT NULL,
"ProductVersion" character varying(32) NOT NULL,
CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);
info: Microsoft.EntityFrameworkCore.Migrations[20411]
Acquiring an exclusive lock for migration application. See https://aka.ms/efcore-docs-migrations-lock for more information if this takes too long.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
LOCK TABLE "__EFMigrationsHistory" IN ACCESS EXCLUSIVE MODE
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT "MigrationId", "ProductVersion"
FROM "__EFMigrationsHistory"
ORDER BY "MigrationId";
info: Microsoft.EntityFrameworkCore.Migrations[20402]
Applying migration '20230322141428_Create_Contracts_Table'.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
DO $EF$
BEGIN
IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'Contracts') THEN
CREATE SCHEMA "Contracts";
END IF;
END $EF$;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (6ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
CREATE TABLE "Contracts"."Contracts" (
"Id" uuid NOT NULL,
CONSTRAINT "PK_Contracts" PRIMARY KEY ("Id")
);
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230322141428_Create_Contracts_Table', '10.0.3');
info: Microsoft.EntityFrameworkCore.Migrations[20402]
Applying migration '20230407115944_AddPreparedAtDate'.
info: Microsoft.EntityFrameworkCore.Migrations[20411]
Acquiring an exclusive lock for migration application. See https://aka.ms/efcore-docs-migrations-lock for more information if this takes too long.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
LOCK TABLE "__EFMigrationsHistory" IN ACCESS EXCLUSIVE MODE
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
ALTER TABLE "Contracts"."Contracts" ADD "PreparedAt" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '2026-02-27T23:17:54.358347+02:00';
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230407115944_AddPreparedAtDate', '10.0.3');
info: Microsoft.EntityFrameworkCore.Migrations[20402]
Applying migration '20230407123603_AddSignedAtDate'.
info: Microsoft.EntityFrameworkCore.Migrations[20411]
Acquiring an exclusive lock for migration application. See https://aka.ms/efcore-docs-migrations-lock for more information if this takes too long.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
LOCK TABLE "__EFMigrationsHistory" IN ACCESS EXCLUSIVE MODE
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
ALTER TABLE "Contracts"."Contracts" ADD "SignedAt" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '2026-02-27T23:17:54.373255+02:00';
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230407123603_AddSignedAtDate', '10.0.3');
info: Microsoft.EntityFrameworkCore.Migrations[20402]
Applying migration '20230608060456_Make_Signed_At_column_not_required'.
info: Microsoft.EntityFrameworkCore.Migrations[20411]
Acquiring an exclusive lock for migration application. See https://aka.ms/efcore-docs-migrations-lock for more information if this takes too long.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
LOCK TABLE "__EFMigrationsHistory" IN ACCESS EXCLUSIVE MODE
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
ALTER TABLE "Contracts"."Contracts" ALTER COLUMN "SignedAt" DROP NOT NULL;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230608060456_Make_Signed_At_column_not_required', '10.0.3');
info: Microsoft.EntityFrameworkCore.Migrations[20402]
Applying migration '20230608060545_Add_Customer_id_column_to_Contracts_table'.
info: Microsoft.EntityFrameworkCore.Migrations[20411]
Acquiring an exclusive lock for migration application. See https://aka.ms/efcore-docs-migrations-lock for more information if this takes too long.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
LOCK TABLE "__EFMigrationsHistory" IN ACCESS EXCLUSIVE MODE
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
ALTER TABLE "Contracts"."Contracts" ADD "CustomerId" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230608060545_Add_Customer_id_column_to_Contracts_table', '10.0.3');
info: Microsoft.EntityFrameworkCore.Migrations[20402]
Applying migration '20230618131127_Contracts_add_columns_to_support_contract_expiration'.
info: Microsoft.EntityFrameworkCore.Migrations[20411]
Acquiring an exclusive lock for migration application. See https://aka.ms/efcore-docs-migrations-lock for more information if this takes too long.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
LOCK TABLE "__EFMigrationsHistory" IN ACCESS EXCLUSIVE MODE
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
ALTER TABLE "Contracts"."Contracts" ADD "Duration" interval NOT NULL DEFAULT INTERVAL '00:00:00';
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
ALTER TABLE "Contracts"."Contracts" ADD "ExpiringAt" timestamp with time zone;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230618131127_Contracts_add_columns_to_support_contract_expiration', '10.0.3');
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT "MigrationId", "ProductVersion"
FROM "__EFMigrationsHistory"
ORDER BY "MigrationId";
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT 1
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
"MigrationId" character varying(150) NOT NULL,
"ProductVersion" character varying(32) NOT NULL,
CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);
info: Microsoft.EntityFrameworkCore.Migrations[20411]
Acquiring an exclusive lock for migration application. See https://aka.ms/efcore-docs-migrations-lock for more information if this takes too long.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
LOCK TABLE "__EFMigrationsHistory" IN ACCESS EXCLUSIVE MODE
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT "MigrationId", "ProductVersion"
FROM "__EFMigrationsHistory"
ORDER BY "MigrationId";
info: Microsoft.EntityFrameworkCore.Migrations[20402]
Applying migration '20230503180333_Create_Offer_Table'.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
DO $EF$
BEGIN
IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'Offers') THEN
CREATE SCHEMA "Offers";
END IF;
END $EF$;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (13ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
CREATE TABLE "Offers"."Offers" (
"Id" uuid NOT NULL,
"CustomerId" uuid NOT NULL,
"PreparedAt" timestamp with time zone NOT NULL,
"Discount" numeric NOT NULL,
"OfferedFromDate" timestamp with time zone NOT NULL,
"OfferedFromTo" timestamp with time zone NOT NULL,
CONSTRAINT "PK_Offers" PRIMARY KEY ("Id")
);
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230503180333_Create_Offer_Table', '10.0.3');
info: Microsoft.Hosting.Lifetime[14]
Now listening on: https://localhost:48713
info: Microsoft.Hosting.Lifetime[14]
Now listening on: http://localhost:48714
info: Microsoft.Hosting.Lifetime[0]
Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
Content root path: C:\3 course uni\microservices\FinnetApp\Chapter-1-initial-architecture\Src\Fitnet
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (11ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (22ms) [Parameters=[@p='?' (DbType = Guid)], CommandType='Text', CommandTimeout='30']
SELECT c."Id", c."CustomerId", c."Duration", c."ExpiringAt", c."PreparedAt", c."SignedAt"
FROM "Contracts"."Contracts" AS c
WHERE c."Id" = @p
LIMIT 1
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (3ms) [Parameters=[@customerId='?' (DbType = Guid)], CommandType='Text', CommandTimeout='30']
SELECT c."Id", c."CustomerId", c."Duration", c."ExpiringAt", c."PreparedAt", c."SignedAt"
FROM "Contracts"."Contracts" AS c
WHERE c."CustomerId" = @customerId
ORDER BY c."PreparedAt" DESC
LIMIT 2
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (18ms) [Parameters=[@p0='?' (DbType = Guid), @p1='?' (DbType = Guid), @p2='?' (DbType = Object), @p3='?' (DbType = DateTime), @p4='?' (DbType = DateTime), @p5='?' (DbType = DateTime)], CommandType='Text', CommandTimeout='30']
INSERT INTO "Contracts"."Contracts" ("Id", "CustomerId", "Duration", "ExpiringAt", "PreparedAt", "SignedAt")
VALUES (@p0, @p1, @p2, @p3, @p4, @p5);
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (3ms) [Parameters=[@p='?' (DbType = Guid)], CommandType='Text', CommandTimeout='30']
SELECT c."Id", c."CustomerId", c."Duration", c."ExpiringAt", c."PreparedAt", c."SignedAt"
FROM "Contracts"."Contracts" AS c
WHERE c."Id" = @p
LIMIT 1
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (4ms) [Parameters=[@p2='?' (DbType = Guid), @p0='?' (DbType = DateTime), @p1='?' (DbType = DateTime)], CommandType='Text', CommandTimeout='30']
UPDATE "Contracts"."Contracts" SET "ExpiringAt" = @p0, "SignedAt" = @p1
WHERE "Id" = @p2;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (6ms) [Parameters=[@p0='?' (DbType = Guid), @p1='?' (DbType = DateTime), @p2='?', @p3='?' (DbType = DateTime), @p4='?', @p5='?' (DbType = Guid), @p6='?' (DbType = DateTime), @p7='?' (DbType = Guid), @p8='?', @p9='?' (DbType = DateTime), @p10='?' (DbType = Guid), @p11='?' (DbType = Guid), @p12='?' (DbType = DateTime), @p13='?' (DbType = DateTime)], CommandType='Text', CommandTimeout='30']
INSERT INTO "Passes"."OutboxMessages" ("Id", "CreatedAt", "Payload", "ProcessedAt", "Type")
VALUES (@p0, @p1, @p2, @p3, @p4);
INSERT INTO "Passes"."PassRegistrationSagas" ("SagaId", "CreatedAt", "PassId", "Status", "UpdatedAt")
VALUES (@p5, @p6, @p7, @p8, @p9);
INSERT INTO "Passes"."Passes" ("Id", "CustomerId", "From", "To")
VALUES (@p10, @p11, @p12, @p13);
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (6ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: EvolutionaryArchitecture.Passes.Infrastructure.Persistence.OutboxProcessor[1197388818]
Processing outbox message c9527563-e22e-4d6b-9046-208574399ed1 of type PassRegistered: PassRegistered:8f3475bd-00e2-41a3-a674-235c281dee24
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT p."SagaId", p."CreatedAt", p."PassId", p."Status", p."UpdatedAt"
FROM "Passes"."PassRegistrationSagas" AS p
WHERE p."Status" = 'Started'
LIMIT 1
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[@p1='?' (DbType = Guid), @p0='?' (DbType = DateTime), @p4='?' (DbType = Guid), @p2='?', @p3='?' (DbType = DateTime)], CommandType='Text', CommandTimeout='30']
UPDATE "Passes"."OutboxMessages" SET "ProcessedAt" = @p0
WHERE "Id" = @p1;
UPDATE "Passes"."PassRegistrationSagas" SET "Status" = @p2, "UpdatedAt" = @p3
WHERE "SagaId" = @p4;
info: EvolutionaryArchitecture.Passes.Infrastructure.Persistence.OutboxProcessor[1456596545]
Outbox message c9527563-e22e-4d6b-9046-208574399ed1 processed successfully.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (8ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (5ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (23ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (5ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (16ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (8ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (6ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (9ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (5ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (5ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (5ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT o."Id", o."CreatedAt", o."Payload", o."ProcessedAt", o."Type"
FROM "Passes"."OutboxMessages" AS o
WHERE o."ProcessedAt" IS NULL
```