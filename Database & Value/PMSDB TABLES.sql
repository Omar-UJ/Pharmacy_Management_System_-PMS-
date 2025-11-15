CREATE DATABASE PMS;
















CREATE TABLE PHARMACY(
p_id  INT PRIMARY KEY IDENTITY(1,1),
p_name varchar (150) NOT NULL,
p_branch varchar (150) NOT NULL,
p_phone varchar(20)UNIQUE NOT NULL,
p_sdate date NOT NULL,
p_city varchar(150),
p_address varchar(150)NOT NULL,
totalEmp int,
m_activation_code varchar(250) NOT NULL
);

















CREATE TABLE MANAGER(
m_id INT PRIMARY KEY IDENTITY(1000,1),
m_name varchar (150) NOT NULL,
m_lname varchar (150) NOT NULL,
m_phone varchar(20)UNIQUE NOT NULL,
m_dob date NOT NULL,
m_city varchar(150),
m_address varchar(150)NOT NULL,
m_password varchar(150)NOT NULL,
m_gender  varchar(10) NOT NULL,
p_id int NOT NULL,
FOREIGN KEY (p_id) REFERENCES PHARMACY(p_id)
ON DELETE CASCADE ON UPDATE CASCADE
);




















CREATE TABLE ITEM(
i_id INT PRIMARY KEY IDENTITY(1000,7),
i_name varchar (150) NOT NULL,
i_descr varchar (255) NOT NULL,
i_pur_price float NOT NULL,
i_sell_price float NOT NULL,
i_sdate date NOT NULL,
i_import_date date NOT NULL,
i_expdate date NOT NULL,
i_qty int NOT NULL,
m_id int NOT NULL,
p_id int NOT NULL,
FOREIGN KEY (m_id) REFERENCES MANAGER(m_id) 
ON DELETE NO ACTION ON UPDATE NO ACTION,
FOREIGN KEY (p_id) REFERENCES PHARMACY(p_id)
ON DELETE CASCADE ON UPDATE CASCADE
);


















CREATE TABLE EXP_ITEM(
i_id INT NOT NULL,
i_name varchar (150) NOT NULL,
i_descr varchar (255) NOT NULL,
i_pur_price float NOT NULL,
i_sell_price float NOT NULL,
i_sdate date NOT NULL,
i_import_date date NOT NULL,
i_expdate date NOT NULL,
i_qty int NOT NULL,
m_id int NOT NULL,
p_id int NOT NULL,
removed_date date,
FOREIGN KEY (m_id) REFERENCES MANAGER(m_id) 
ON DELETE NO ACTION ON UPDATE NO ACTION,
FOREIGN KEY (p_id) REFERENCES PHARMACY(p_id)
ON DELETE CASCADE ON UPDATE CASCADE
);

















CREATE TABLE CASHIER(
ca_id INT PRIMARY KEY IDENTITY(1050,1),
ca_name varchar (150) NOT NULL,
ca_lname varchar (150) NOT NULL,
ca_phone varchar(20)UNIQUE NOT NULL,
ca_dob date NOT NULL,
ca_city varchar(150),
ca_address varchar(150)NOT NULL,
ca_password varchar(150)NOT NULL,
ca_gender  varchar(10) NOT NULL,
ca_status  varchar(10) NOT NULL,
ca_salary  float NOT NULL,
p_id int NOT NULL,
FOREIGN KEY (p_id) REFERENCES PHARMACY(p_id)
ON DELETE CASCADE ON UPDATE CASCADE
);



















CREATE TABLE PHARMACIST(
ph_id INT PRIMARY KEY IDENTITY(1700,1),
ph_name varchar (150) NOT NULL,
ph_lname varchar (150) NOT NULL,
ph_phone varchar(20)UNIQUE NOT NULL,
ph_dob date NOT NULL,
ph_city varchar(150),
ph_address varchar(150)NOT NULL,
ph_password varchar(150)NOT NULL,
ph_gender  varchar(10) NOT NULL,
ph_status  varchar(10) NOT NULL,
ph_salary  float NOT NULL,
p_id int NOT NULL,
FOREIGN KEY (p_id) REFERENCES PHARMACY(p_id)
ON DELETE CASCADE ON UPDATE CASCADE
);

















CREATE TABLE OTHERS(
oe_id INT PRIMARY KEY IDENTITY(20112,1),
oe_name varchar (150) NOT NULL,
oe_lname varchar (150) NOT NULL,
oe_phone varchar(20)UNIQUE NOT NULL,
oe_dob date NOT NULL,
oe_city varchar(150),
oe_address varchar(150)NOT NULL,
oe_gender  varchar(10) NOT NULL,
oe_status  varchar(10) NOT NULL,
oe_job_pos varchar(150)NOT NULL,
oe_salary  float NOT NULL,
p_id int NOT NULL,
FOREIGN KEY (p_id) REFERENCES PHARMACY(p_id)
ON DELETE CASCADE ON UPDATE CASCADE
);














CREATE TABLE TRANSACTION_RECORD(
t_id INT PRIMARY KEY IDENTITY(20224,7),
i_id int NOT NULL,
i_name varchar (150) NOT NULL,
i_descr varchar (255) NOT NULL,
i_pur_price float NOT NULL,
i_sell_price float NOT NULL,
i_sdate date NOT NULL,
i_import_date date NOT NULL,
i_expdate date NOT NULL,
i_qty int NOT NULL,
p_id int NOT NULL,
ca_id int NOT NULL,
ph_id int NOT NULL,
pur_date date NOT NULL,
total_price float NOT NULL,
FOREIGN KEY (p_id) REFERENCES PHARMACY(p_id),
FOREIGN KEY (ca_id) REFERENCES CASHIER(ca_id) 
ON DELETE NO ACTION ON UPDATE NO ACTION,
FOREIGN KEY (ph_id) REFERENCES PHARMACIST(ph_id) 
ON DELETE NO ACTION ON UPDATE NO ACTION
);





















Create procedure EXP_ITEMS
@i_expdate  varchar(150) , @p_id int
AS
SELECT
* FROM
ITEM
WHERE
i_expdate<=@i_expdate and p_id=@p_id 
ORDER BY
i_sdate;


Create procedure TRAN_REPORT
@p_id int
AS
SELECT
* FROM
TRANSACTION_RECORD WHERE p_id=@p_id
ORDER BY
pur_date;



Create procedure EXP_REPORT
AS
SELECT
* FROM
EXP_ITEM
ORDER BY
removed_date;



Create procedure TD_TRAN_REPORT
@p_id int,@date DATE
AS
SELECT
* FROM
TRANSACTION_RECORD
WHERE
pur_date=@date and p_id=@p_id 
ORDER BY
i_qty;



TD_TRAN_REPORT 1,'2022-06-16'

Create procedure OUT_OFF_STOCK_ITEMS
@i_qty  varchar(150) , @p_id int
AS
SELECT
* FROM
ITEM
WHERE
i_qty<=@i_qty and p_id=@p_id 
ORDER BY
i_qty;




Create VIEW VIEW_OOSI
AS
SELECT
i_id,i_name,i_descr,i_pur_price,i_sell_price,i_qty,p_id
FROM
ITEM





Create VIEW VIEW_ITEMS
AS
SELECT
i_id,i_name,i_descr,i_pur_price,i_sell_price,i_qty,
i_sdate,i_import_date,i_expdate,p_id
FROM
ITEM
WHERE 
i_qty>0







CREATE TRIGGER EXP_AUDIT
ON ITEM
FOR DELETE
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO EXP_ITEM(
i_id,i_name,i_descr,i_pur_price,i_sell_price,
i_sdate,i_import_date,i_expdate,i_qty,m_id,p_id,removed_date
)
SELECT
d.i_id,d.i_name,d.i_descr,d.i_pur_price,i_sell_price,d.i_sdate,i_import_date,d.i_expdate,d.i_qty,d.m_id,p_id,GETDATE()
FROM deleted d
END







CREATE TRIGGER TRANSACTION_AUDIT
ON ITEM
FOR DELETE
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO TRANSACTION_RECORD(
i_id,i_name,i_descr,i_price,
i_sdate,i_expdate,i_qty,m_id,p_id,pur_date,total_price,ph_id
)
SELECT
d.i_id,d.i_name,d.i_descr,d.i_price,d.i_sdate,d.i_expdate,d.i_qty,d.m_id,d.p_id,GETDATE()
FROM deleted d
END