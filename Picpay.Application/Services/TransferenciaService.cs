using Picpay.Application.Interfaces;
using Picpay.Application.Models;
using Picpay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Services
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly ITransferenciaRepository transferenciaRepository;

        public TransferenciaService(ITransferenciaRepository transferenciaRepository)
        {
            this.transferenciaRepository = transferenciaRepository;
        }

        public Task Add(TransferenciaModel categoriaDto)
        {
            throw new NotImplementedException();
        }

        public Task<TransferenciaModel> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransferenciaModel>> GetTransferencias()
        {
            throw new NotImplementedException();
        }
    }
}
