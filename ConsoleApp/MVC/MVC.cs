using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.MVC
{
    public class Model : List<string>
    {
        public Model()
        {
            Add("Donnée 1");
            Add("Donnée 2");
            Add("Donnée 3");
        }
    }
    public class View
    {
        private readonly Model _model;

        public View(Model model)
        {
            _model = model;
        }

        public void Afficher()
        {
            foreach (var item in _model)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Controller
    {
        public View Action(Model model)
        {
            return new View(model);
        }

    }



}
