
CREATE TABLE "Clientes" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Clientes" PRIMARY KEY AUTOINCREMENT,
    "NomeCompleto" TEXT NOT NULL,
    "Cpf" TEXT NOT NULL,
    "DataNascimento" TEXT NOT NULL,
    "Email" TEXT NULL
);

CREATE UNIQUE INDEX "IX_Clientes_Cpf" ON "Clientes" ("Cpf");

CREATE TABLE "Dividas" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Dividas" PRIMARY KEY AUTOINCREMENT,
    "ClienteId" INTEGER NOT NULL,
    "Valor" TEXT NOT NULL,
    "Paga" INTEGER NOT NULL,
    "DataCriacao" TEXT NOT NULL,
    "DataPagamento" TEXT NULL,
    CONSTRAINT "FK_Dividas_Clientes_ClienteId" FOREIGN KEY ("ClienteId") REFERENCES "Clientes" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Dividas_ClienteId" ON "Dividas" ("ClienteId");
