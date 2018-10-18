#Requêtes#
1)
delimiter |

drop procedure if exists creEmploye |

create procedure creEmploye (nom varchar(50),prenom varchar(50),sexe char,cadre bit, salaire decimal,service int)
begin
insert into Employe(emp_nom,emp_prenom,emp_sexe,emp_cadre,emp_salaire,emp_service) values(nom,prenom,sexe,cadre,salaire,service);
end
|
call creEmploye("Imal","Enzo",'M',1,6500,3)|

delimiter ;

2)

delimiter |

drop procedure if exists listeEmploye |

create procedure listeEmploye()
begin
select emp_id,emp_nom,emp_prenom from employe inner join posseder on employe.emp_id=posseder.pos_employe inner join diplome on diplome.dip_id=posseder.pos_diplome and  dip_libelle = "Bac" and emp_id in (select emp_id from employe inner join posseder on employe.emp_id=posseder.pos_employe inner join diplome on diplome.dip_id=posseder.pos_diplome and dip_libelle = "Licence");
end
|
call listeEmploye()|
delimiter ;

3)

delimiter |

drop procedure if exists salaireEmploye |

create procedure salaireEmploye(borneInf decimal,borneSup decimal)
begin
select emp_nom,emp_salaire from employe where emp_salaire>borneInf and emp_salaire<borneSup;
end
|
call salaireEmploye(2000,6000)|
delimiter ;

4)

delimiter |

drop procedure if exists MisJourBudget |

create procedure MisJourBudget(numero int,pourcentage double)
begin
update service set ser_budget= ser_budget + ser_budget * pourcentage where ser_id=numero;
end
|
call MisJourBudget(3,0.3)|
delimiter ;


5) 

create view QTD as select pos_employe, count(distinct pos_diplome) as cd from posseder group by pos_employe ;

delimiter |
DROP PROCEDURE if EXISTS MoyenneDiplome |
CREATE PROCEDURE MoyenneDiplome ()
BEGIN
	select emp_nom, emp_prenom from employe  inner join QTD on employe.emp_id=QTD.pos_employe where cd > (select avg(cd) from QTD);
END
|
CALL MoyenneDiplome()|
delimiter ;




delimiter |
DROP PROCEDURE if EXISTS MajSalaire |
CREATE PROCEDURE MajSalaire (IN nom varchar(55), IN pourcent decimal)
BEGIN
	update employe set emp_salaire = emp_salaire +  emp_salaire*pourcent where emp_nom = nom;
END
|
delimiter ;




delimiter |
DROP PROCEDURE if EXISTS MasseSalariale |
CREATE PROCEDURE MasseSalariale (IN Service varchar(55), OUT masseSalariale decimal)
BEGIN
	select sum(emp_salaire) into masseSalariale from employe inner join service on employe.emp_service = service.ser_id where ser_designation = Service;
END
|
delimiter ;


/*create view listeCadre as select * from employe where emp_cadre = '1';*/


/*
SELECT * FROM `employe`
INTERSECT
SELECT * FROM `service`;


update service set ser_budget=2000 where ser_id=3;

	update service set ser_budget= ser_budget + ser_budget * 0.3 where ser_id=3;*/ 

