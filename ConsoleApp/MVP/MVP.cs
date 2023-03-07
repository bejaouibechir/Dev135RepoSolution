using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.MVP
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
        public View()
        {
            
        }

        public void Afficher()
        {
            foreach (var item in _model)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Presenter 
    {
        private readonly View _view;
        private readonly Model _model;

        public Presenter(View view,Model model)
        {
            _view = view;
            _model = model;
        } 

        public View Action()
        {
            return _view;
        }

    }

}
