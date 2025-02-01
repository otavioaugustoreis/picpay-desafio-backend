using Picpay.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Interfaces
{
    public  interface ITransferenciaService
    {
        Task<IEnumerable<TransferenciaModel>> GetTransferencias();
        Task<TransferenciaModel> GetById(int? id);
        Task<TransferenciaModel> Add(TransferenciaModel transferenciaDto);
    }
}
