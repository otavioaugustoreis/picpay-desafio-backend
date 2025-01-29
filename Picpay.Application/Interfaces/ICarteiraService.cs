using Picpay.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Services
{
    public interface ICarteiraService 
    {
        Task<IEnumerable<TransferenciaModel>> GetCarteiras();
        Task<TransferenciaModel> GetById(int? id);
        Task Add(TransferenciaModel categoriaDto);
    }
}
