using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityName, int id)
            : base($"{entityName} con Id={id} no fue encontrado.")
        {
        }
    }

    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string entityName)
            : base($"{entityName} ya existe.")
        {
        }
    }

    public class InvalidEntityException : Exception
    {
        public InvalidEntityException(string entityName, string reason)
            : base($"{entityName} no es válido: {reason}")
        {
        }
    }
}
