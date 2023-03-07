using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

namespace ConsoleApp.UnitOfWork
{
    public class UnitOfWork<T>
    {
        List<string> _instrcutions = new List<string>();

        public void SaveChanges()
        {
            foreach (var item in _instrcutions)
            {
                System.Console.WriteLine($"Execution de {item}");
            }
        }

        public void Add(T entity) {
            _instrcutions.Add($"Ajout de l'entité {entity}");
            
        }
        public void Delete(T entity)
        {
            _instrcutions.Add($"Supression de l'entité {entity}");
        }
        public void Update(T entity)
        {
            _instrcutions.Add($"Mise à jour de l'entité {entity}");
        }
    }
}
