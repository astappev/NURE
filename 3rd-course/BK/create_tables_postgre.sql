CREATE SEQUENCE account_ids;
CREATE TABLE account
(
	id INTEGER PRIMARY KEY DEFAULT NEXTVAL('account_ids'),
	name CHAR(64) NOT NULL,
    notes CHAR(128)
);

CREATE SEQUENCE agent_type_ids;
CREATE TABLE agent_type
(
	id INTEGER PRIMARY KEY DEFAULT NEXTVAL('account_ids'),
	name CHAR(64) NOT NULL
);
INSERT INTO agent_type(name)
VALUES ('Поставщик'), ('Покупатель');

CREATE SEQUENCE agent_ids;
CREATE TABLE agent
(
	id INTEGER PRIMARY KEY DEFAULT NEXTVAL('agent_ids'),
    name CHAR(64) NOT NULL,
	agent_type INTEGER CONSTRAINT agentAgent_type REFERENCES agent_type(id) ON UPDATE CASCADE ON DELETE CASCADE NOT NULL,
    notes CHAR(128)
);

CREATE SEQUENCE nomenclature_ids;
CREATE TABLE nomenclature
(
	id INTEGER NOT NULL PRIMARY KEY DEFAULT NEXTVAL('nomenclature_ids'),
    name CHAR(64) NOT NULL,
	purchase_price INTEGER NOT NULL,
	sale_price INTEGER NOT NULL,
	rate CHAR(64),
    notes CHAR(128)
);

CREATE TABLE storage
(
	nomenclature_id INTEGER CONSTRAINT storageNomenclature REFERENCES nomenclature(id) ON UPDATE CASCADE ON DELETE CASCADE PRIMARY KEY,
	quantity INTEGER NOT NULL,
	total INTEGER NOT NULL,
	avg_total INTEGER NOT NULL
);

CREATE TABLE turn_sheets
(
	account_id INTEGER NOT NULL CONSTRAINT turn_sheetsAccount REFERENCES account(id) ON UPDATE CASCADE ON DELETE CASCADE PRIMARY KEY,
	turn_credit INTEGER NOT NULL,
	turn_debit INTEGER NOT NULL,
	saldo_beg_credit INTEGER NOT NULL,
	saldo_beg_debit INTEGER NOT NULL,
	saldo_fin_credit INTEGER NOT NULL,
	saldo_fin_debit INTEGER NOT NULL
);

CREATE SEQUENCE document_type_ids;
CREATE TABLE document_type
(
	id INTEGER PRIMARY KEY DEFAULT NEXTVAL('document_type_ids'),
	name CHAR(64) NOT NULL,
	agent_type INTEGER CONSTRAINT document_typeAgent_type REFERENCES agent_type(id) NOT NULL,
    description CHAR(128)
);
INSERT INTO document_type(name, agent_type, description)
VALUES ('ПН', 1, 'Приходная накладная'), ('РН', 2, 'Расходная накладная'), ('БВП', 2, 'Банковская выписка прибыли'), ('БВР', 1, 'Банковская выписка расходов'); // 1 - поставщик, 2 - покупатель

CREATE SEQUENCE transaction_type_ids;
CREATE TABLE transaction_type
(
	id INTEGER PRIMARY KEY DEFAULT NEXTVAL('transaction_type_ids'),
	document_type INTEGER CONSTRAINT transaction_typeDocument_type REFERENCES document_type(id) ON UPDATE CASCADE ON DELETE CASCADE NOT NULL,
	account_credit INTEGER CONSTRAINT transaction_typeAccountCredit REFERENCES account(id) ON UPDATE CASCADE ON DELETE CASCADE NOT NULL,
	account_debit INTEGER CONSTRAINT transaction_typeAccountDebit REFERENCES account(id) ON UPDATE CASCADE ON DELETE CASCADE NOT NULL
);

CREATE SEQUENCE operation_log_ids;
CREATE TABLE operation_log
(
	id INTEGER PRIMARY KEY DEFAULT NEXTVAL('operation_log_ids'),
	data TIMESTAMP NOT NULL,
	price INTEGER NOT NULL,
	quantity INTEGER NOT NULL,
	total INTEGER NOT NULL,
	document_type INTEGER CONSTRAINT operation_logDocument_type REFERENCES document_type(id) ON UPDATE CASCADE ON DELETE CASCADE NOT NULL,
	agent_id INTEGER CONSTRAINT operation_logAgent REFERENCES agent(id) ON UPDATE CASCADE ON DELETE CASCADE NOT NULL,
	nomenclature_id INTEGER CONSTRAINT operation_logNomenclature REFERENCES nomenclature(id) ON UPDATE CASCADE ON DELETE CASCADE NOT NULL
);

CREATE SEQUENCE transaction_log_ids;
CREATE TABLE transaction_log
(
	id INTEGER PRIMARY KEY DEFAULT NEXTVAL('transaction_log_ids'),
	transaction_type INTEGER CONSTRAINT transaction_logTransaction_type REFERENCES transaction_type(id) ON UPDATE CASCADE ON DELETE CASCADE NOT NULL,
	operation_id INTEGER CONSTRAINT transaction_logOperation_log REFERENCES operation_log(id) ON UPDATE CASCADE ON DELETE CASCADE NOT NULL,
    total INTEGER NOT NULL
);