# Tp ProcedureStockee #

**But du TP**
* Pouvoir gérer une base de données se nommant Gesper en c#

Les outils mis en oeuvre :
  * Git.
  * C#.
  * MySql.
  
 Ce tp contient deux classes :
  * Une class Connexion
  >>Contient deux méthodes pour ouvrir et fermer la connection à la base de données,un accesseur et un constructeur.
  * Une class Requêtes
  >>Contient plusieurs méthodes pour chaque requêtes. Dans chaque méthodes des requêtes et procédure on été faites en sql. Des vues ont été réalisé en sql pour certaines procédure.
  Comme par exemple :
  * Procédure(avec vue) :
  
  ```sql
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
```
  * Méthode de la class Requêtes :
  ```cs
  public string MoyenneDiplome()
        {
            string result = "";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "MoyenneDiplome";
            cmdSql.CommandType = CommandType.StoredProcedure;
            MySqlDataReader reader = cmdSql.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    result += String.Format("{0} {1}\n",reader[0], reader[1]);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            cnx.Close();
            return result;
        }
  ```
-Classes
-Méthodes
-Constructeur
-Accesseur/Mutateur
-Connection à une base de données
-Effectuer une procédure en c#/sql
-Effectuer une requête en c#/sql
