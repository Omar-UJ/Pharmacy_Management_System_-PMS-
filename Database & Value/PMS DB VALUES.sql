
insert into PHARMACY(p_name,p_branch,p_phone,p_city,p_sdate, p_address,totalEmp,m_activation_code)
values
/*('kenema','mexico','0912345679','AA','1989-7-17','near shebele',50),*/
('Axum','mexico','0945674859','AA','1986-3-16','in wabi shebele',70,'SHSDFHSGD&SDf'),
('mina','kotebe','0987654894','AA','1987-3-6','near sami cafe',60,'GSDG@#^%@$'),
('soloda','alembank','0919876543','AA','1987-6-14','near alpha school',57),
('lion','merkato','0976897607','AA','1990-9-14','near addis ababa building',55),
('addis','mexico','0918980078','AA','1999-7-7','near tom fast food',50),
('rose','piyassa','0912886789','AA','1989-6-7','near geneve cafe',40),
('alpha','alembank','0912340979','AA','1988-2-6','near freinds gamezone',60),
('bole','bole atlas','0919877679','AA','1990-9-19','near ramadan hotel',80),
('brook','aratKilo','0998475679','DD','1999-5-16','near eduction minister',60),
('lidet','lideta','0912189479','AA','1970-4-12','near lideta church',80),
('kebron','hayek dar','0912987679','AW','1990-4-5','near haile resort',70),
('pelican','bulgaria','0997648327','AA','1979-8-6','near tigist building',60),
('jegol','harar','0912365679','HA','1990-4-6','near tadesse tefera building',90),
('life','abay','091135679','DB','1978-11-9','near abay river cafe',50),
('goh','mexico','0911345679','AA','1987-3-7','near saint mary university',80),
('tsion','mexico','0911344600','AA','1988-8-7','near telebar',70),
('netsanet','alembank','0911672879','AA','2001-9-19','near kaldis coffee',50),
('haven','signal','0911345279','AA','1970-1-9','near magic carpet school',67),
('blu','kazanchis','0911344579','AA','1999-8-7','near radison blue hotel',54),
('redcross','stadium','0911349979','AA','1946-9-5','near the police station',57);

insert into MANAGER(m_name,m_lname,m_phone,m_dob,m_city,m_address,m_password,m_gender,p_id)
values
('uj','uj','0987\564738','2000-2-19','AA','AyerTena','111','M',3),
('yamin','nigatu','0948674880','1995-4-2','AA','mexico','v^g5s114684458g5s@7&*a72012jh','M',2),
('yonatan','kassahun','0998557790','1996-4-4','AA','alembank','v^g5s-998604479g5s@7&*a72012jh','M',3),
('victor','getnet','0992357790','1996-4-4','AA','gofa','v^g5s3564028g5s@7&*a72012jh','M',4)

insert into ITEM(i_name,i_descr,i_pur_price,i_sdate,i_import_date,i_expdate,i_qty,m_id,p_id,i_sell_price)
values
('Acenocoumarol','prevention and treatment of harmful blood clots',39.9,'2018-1-1',GETDATE(),'2020-1-11',3,1002,1,43),
('Aminophylline','prevent and treat wheezing and shortness of breath',49.9,'2022-1-2',GETDATE(),'2026-1-11',12,1002,1,52),
('Benzylpenicillin','it is used for the treatment of infections caused by gram-positive cocci',99.9,'2022-1-3',GETDATE(),'2026-1-11',32,1002,1,105),
('Cefuroxime',' is used to treat certain infections caused by bacteria',89.9,'2022-1-4',GETDATE(),'2026-1-11',7,1002,1,94),
('Centchroman','it is used for contraception',79.9,'2022-1-12',GETDATE(),'2026-1-5',8,1002,1,82),
('Chloramphenicol','used to treat serious infections',69.9,'2022-1-3',GETDATE(),'2026-1-16',21,1004,1,73),
('Chlorthalidone',' it is used to treat high blood pressure. ',89.9,'2022-1-13',GETDATE(),'2026-1-11',14,1002,1,94),
('Clarithromycin','It is used to treat chest infections.',39.9,'2022-1-21',GETDATE(),'2026-1-1',15,1002,1,45),
('Doxapram','it is used to stimulate breathing.',69.9,'2022-1-21',GETDATE(),'2026-1-1',3,1003,1,75),
('Flucytosine','it is used for the treatment of serious infections caused by certain strains.',39.0,'2022-1-11',GETDATE(),'2026-1-11',9,1002,1,45),
('Furazolidone','it is used to treat cholera.',99.9,'2022-1-21',GETDATE(),'2026-1-11',13,1004,1,103),
('Ketoconazole','it is used to treat certain serious fungal infections in the body.',39.9,'2022-1-11',GETDATE(),'2026-1-11',34,1002,1,45),
('Loperamide','it is used to treat diarrhoea. ',39.9,'2020-1-11',GETDATE(),'2021-1-25',45,1003,1,42),
('Mebendazole','it is used to treat pinworm, roundworm, and hookworm infections.',89.9,'2022-1-30',GETDATE(),'2026-1-11',13,1002,1,93.4),
('Niclosamide','it is used to treat tapeworm infections. ',99.9,'2022-1-11',GETDATE(),'2026-1-11',55,1002,1,103.5),
('Nitrazepam','it is used to treat panic disorders, severe anxiety, and seizures.',89.9,'2022-1-11',GETDATE(),'2026-1-11',15,1004,1,97)
