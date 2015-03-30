CREATE TABLE Account
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
)

CREATE TABLE typeAgent
(
	id INT IDENTITY (1,1) PRIMARY KEY,
	name VARCHAR(50) NOT NULL
)

CREATE TABLE Agent
(
	id INT IDENTITY (1,1) PRIMARY KEY,
	type INT CONSTRAINT agentTypeAgent REFERENCES typeAgent(id) NOT NULL,
	name VARCHAR(50) NOT NULL
)

CREATE TABLE Nomenclature
(
	id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	purchase_price INT NOT NULL,
	sale_price INT NOT NULL,
	name VARCHAR (50) NOT NULL
)

CREATE TABLE Storage
(
	id INT CONSTRAINT StorageNomenclature REFERENCES Nomenclature (id) PRIMARY KEY,
	quantity INT NOT NULL,
	total INT NOT NULL,
	avg_total FLOAT NOT NULL
)

CREATE TABLE turnSheets
(
	id INT NOT NULL CONSTRAINT turnSheetsAccount REFERENCES Account(id) PRIMARY KEY,
	turn_credit INT NOT NULL,
	turn_debit INT NOT NULL,
	saldo_beg_credit INT NOT NULL,
	saldo_beg_debit INT NOT NULL,
	saldo_fin_credit INT NOT NULL,
	saldo_fin_debit INT NOT NULL
)

CREATE TABLE typeDocument
(
	id INT IDENTITY (1,1) PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	type_agent INT CONSTRAINT typeDocumentsTypeAgent REFERENCES typeAgent(id) NOT NULL
)

CREATE TABLE typeTransactions
(
	id INT IDENTITY (1,1) PRIMARY KEY,
	typeDocument INT CONSTRAINT typeTransactionsTypeDocument REFERENCES typeDocument(id) NOT NULL,
	creditAccount INT CONSTRAINT typeTransactionsAccountCredit REFERENCES Account(id) NOT NULL,
	debitAccount INT CONSTRAINT typeTransactionsAccountDebit REFERENCES Account(id) NOT NULL
)

CREATE TABLE operationsLog
(
	id INT IDENTITY (1,1) PRIMARY KEY,
	data DATETIME NOT NULL,
	price INT NOT NULL,
	quantity INT NOT NULL,
	total INT NOT NULL,
	type INT CONSTRAINT operationLogType REFERENCES typeDocument(id) NOT NULL,
	agent_id INT CONSTRAINT operationLogAgent REFERENCES Agent(id) NOT NULL,
	nomenclature_id INT CONSTRAINT operationLogNomenclature REFERENCES Nomenclature(id) NOT NULL
)

CREATE TABLE transactionLog
(
	id INT IDENTITY (1,1) PRIMARY KEY,
	type INT CONSTRAINT transactionLogType REFERENCES typeTransactions(id) NOT NULL,
	operation INT CONSTRAINT transactionLogOperation REFERENCES operationsLog(id) NOT NULL
)