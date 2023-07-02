create database myfinance 
GO

use myfinance
go


create table account(
    id INT identity(1,1) not NULL,
    description VARCHAR(50) not NULL,
    type char(1) not NULL,
    PRIMARY KEY(id)
)
go

select * from account

INSERT into account([description], [type]) VALUES('Combustível', 'D')
INSERT into account([description], [type]) VALUES('Salário', 'R')
INSERT into account([description], [type]) VALUES('Alimentação', 'D')


create table account_transaction(
    id INT identity(1,1) not NULL,
    date DATETIME not NULL,
    value DECIMAL(9,2) not NULL,
    history VARCHAR(100) NULL,
    account_id int not NULL,
    PRIMARY KEY(id),
    FOREIGN key(account_id) REFERENCES account(id)
)
go

select * from account_transaction


INSERT into account_transaction(date, value, history, account_id) 
VALUES(getDate(), 25, 'Café da Manhã', 3)

INSERT into account_transaction(date, value, history, account_id) 
VALUES('2023/06/13', 180, 'Gasolina moto', 1)

INSERT into account_transaction(date, value, history, account_id) 
VALUES('2023/06/15', 5000, 'Adiantamento', 2)