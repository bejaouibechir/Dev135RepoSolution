//#define daorepo
//#define unitofwork
//using ConsoleApp.MVC;
using ConsoleApp.MVP;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static Func<double, double,double> procédure;
        static void Main(string[] args)
        {
            procédure = affiche;
            procédure.Invoke(12, 13);

            procédure = somme;
            procédure.Invoke(12, 13);
        }

        static double somme(double a,double b)
        {
            double result = a + b;
            Console.WriteLine(result);
            return result;
        }

        static double affiche(double a, double b)
        {
            Console.WriteLine(a);
            Console.WriteLine(b);
            return 0;
        }



    }
}






#if unitofwork
  using ConsoleApp.UnitOfWork;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string [] args)
        {
            UnitOfWork<string> unitOfWork = new UnitOfWork<string>();
            unitOfWork.Add("Vente 1");
            unitOfWork.Add("Vente 2");
            unitOfWork.SaveChanges();
            unitOfWork.Update("Vente 1");
            unitOfWork.Add("Vente 3");
        }

    }
}

#endif




#if daorepo
using ConsoleApp.DAO;
using System.Configuration;
namespace ConsoleApp
{
    
    internal class Program
    {
        
        static IRepository<IClient,string> _clientRepo; 
        static IRepository<Vente,int> _venteRepo;

        static void Main(string[] args)
        {
            string dbparam = ConfigurationManager.AppSettings["dbtype"].ToString();
            if (dbparam.Equals("0"))
            //Pour manipuler les données contre une base sql server
            {
                _clientRepo = new ClientSqlServerRepo();
                Client client = new Client();
                _clientRepo.Add(client as IClient);
                ClientV2<string> clientv2 = new ClientV2<string>();
                _clientRepo.Add(client as IClient);

                _venteRepo = new VenteSqlServerRepo();
            }


            if (dbparam.Equals("1"))
            //Pour manipuler les données contre une base my sql 
            {
                _clientRepo = new ClientMySqlRepo();
                _venteRepo = new VenteMySqlRepo();
            }

        }
    }
}

#endif
