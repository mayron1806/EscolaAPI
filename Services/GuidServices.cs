using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAPI.Services
{
    public class GuidServices
    {
        public static (bool sucesso, Guid resultado) GuidValido(string guid){
            bool sucesso = Guid.TryParse(guid, out Guid resultado);
            return (sucesso, resultado);

        }
    }
}