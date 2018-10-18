using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace controle
{
    class Program
    {
        static void Main(string[] args)
        {
            int choix;
            string host;
            string user;
            string bdd;
            string pwd;
            MySqlCommand Cmd;
            MySqlConnection Cnx;

            Requetes rq;

            /*paramètres de connexion
            Console.WriteLine("Donner le nom du serveur");
            host = Console.ReadLine();
            Console.WriteLine("Donner le nom de la base de données");
            bdd = Console.ReadLine();
            Console.WriteLine("Donner le nom de l'utilisateur");
            user= Console.ReadLine();
            Console.WriteLine("Donner le mot de passe");
            pwd = Console.ReadLine(); */

            host = "localhost";
            bdd = "gesper";
            user = "root";
            pwd = "";


            // connexion

            rq = new Requetes(host, user, bdd, pwd);

            do
            {
                do
                {
                    Console.WriteLine("1 - liste complète des employés (utiliser une requête)");
                    Console.WriteLine("2 - liste complète des services (utiliser la table, sans écrire de requête)");
                    Console.WriteLine("3 - Mettre à jour le salaire d'un employé en passant en paramètre le nom de l'employé et le pourcentage d'augmentation (utiliser la procédure stockée)");
                    Console.WriteLine("4 - Donner la masse salariale mensuelle d'un service (procédure stockée paramétrée)");
                    Console.WriteLine("5 - Liste des employés cadres qui gagnent plus que la moyenne des salaires des cadres(utiliser une requête)");
                    Console.WriteLine("6 - Création d'un nouvel employé");
                    Console.WriteLine("7 - Liste des employés qui ont une licence et le bac");
                    Console.WriteLine("8 - Liste des employés qui ont un salaire compris entre une borne inférieure et une borne supérieure)");
                    Console.WriteLine("9 - Mise a jour du budget d'un service administratif");
                    Console.WriteLine("10 - Liste des employés  qui ont plus de diplômes que la moyenne des diplômes possédée par chaque employés");
                    Console.WriteLine("11 - Fin du traitement");


                    choix = Int32.Parse(Console.ReadLine());

                } while (choix < 0 || choix > 12);

                switch (choix)
                {
                    #region 1 - liste complète des employés (utiliser une requête)")
                    case 1:
                        Console.WriteLine("\n1 - liste complète des employés (utiliser une requête)");

                        Console.WriteLine(rq.ListeEmployes());


                        break;
                    #endregion
                    #region 2 - liste complète des services (utiliser la table, sans écrire de requête)")
                    case 2:
                        Console.WriteLine("\n1 - liste complète des services (utiliser la table, sans écrire de requête)");
                        Console.WriteLine(rq.ListeServices());

                        break;
                    #endregion
                   

                    #region 3 - mettre à jour le salaire d'un employé en passant en paramètre le nom de l'employé et le pourcentage d'augmentation (utiliser la procédure stockée majSalaire)
                    case 3:
                        Console.WriteLine("\n3 - mettre à jour le salaire d'un employé en passant en paramètre le nom de l'employé et le pourcentage d'augmentation (utiliser la procédure stockée majSalaire)");
                        Console.WriteLine(rq.MajSalaire("Poulard", 0.2));
                        break;
                    #endregion


                    #region 4 - Donner la masse salariale mensuelle d'un service (procédure stockée paramétrée)
                    case 4:
                        Console.WriteLine("\n4 - Donner la masse salariale mensuelle d'un service (procédure stockée paramétrée)");
                        Console.WriteLine(rq.MasseSalariale("Atelier B"));




                        break;
                    #endregion
                    #region 5 - liste des employés cadres qui gagnent plus que la moyenne des salaires des cadres(utiliser une requête)
                    case 5:
                        Console.WriteLine("\n5 - liste des employés cadres qui gagnent plus que la moyenne des salaires des cadres(utiliser une requête)");
                        Console.WriteLine(rq.ListeCadrePlus());


                        break;
                    #endregion

                    #region 6 - liste des employés cadres qui gagnent plus que la moyenne des salaires des cadres(utiliser une requête)
                    case 6:
                        Console.WriteLine("\n6 - Création d'un nouvel employé");
                        Console.WriteLine(rq.creEmploye(14,"Lima","Milan","M",true,4500,4));


                        break;
                    #endregion
                    #region 7 - liste des employés cadres qui gagnent plus que la moyenne des salaires des cadres(utiliser une requête)
                    case 7:
                        Console.WriteLine("\n7 - Liste des employés qui ont une licence et le bac");
                        Console.WriteLine(rq.listeEmployeDiplome());


                        break;
                    #endregion
                    #region 8 - liste des employés cadres qui gagnent plus que la moyenne des salaires des cadres(utiliser une requête)
                    case 8:
                        Console.WriteLine("\n8 - Liste des employés qui ont un salaire compris entre une borne inférieure et une borne supérieure");
                        Console.WriteLine(rq.salaireEmploye(2000,6000));


                        break;
                    #endregion
                    #region 9 - liste des employés cadres qui gagnent plus que la moyenne des salaires des cadres(utiliser une requête)
                    case 9:
                        Console.WriteLine("\n9 - Mise a jour du budget d'un service administratif");
                        Console.WriteLine(rq.MisJourBudget(3,0.3));


                        break;
                    #endregion
                    #region 10 - liste des employés cadres qui gagnent plus que la moyenne des salaires des cadres(utiliser une requête)
                    case 10:
                        Console.WriteLine("\n10 - Liste des employés  qui ont plus de diplômes que la moyenne des diplômes possédée par chaque employés");
                        Console.WriteLine(rq.MoyenneDiplome());
                        break;
                    #endregion

                    #region 11 - Fin de traitement
                    case 11:
                        Console.WriteLine("\n11 - Fin de traitement");

                        break;
                        #endregion
                }
            }
            while (choix != 11);

            Console.ReadLine();
        }
    }
}
