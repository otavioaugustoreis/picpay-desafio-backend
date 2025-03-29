using Microsoft.Extensions.Options;
using Picpay.Application.Models;
using Picpay.Domain.Entities;
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
        Task<TransferenciaModel> Add(TransferenciaModel transferenciaDto);

        Task Transferir(CarteiraEntity carteiraDevedor, CarteiraEntity carteiraRecebidor, double valor);
    }
}
