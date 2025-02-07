using Picpay.Application.Interfaces;
using Picpay.Application.Models;
using Picpay.Domain.Enums;
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
        private readonly ICarteiraRepository carteiraRepository;
        private readonly IUsuarioRepository usuarioRepository;
        public TransferenciaService(ITransferenciaRepository transferenciaRepository, ICarteiraRepository carteiraRepository, IUsuarioRepository usuarioRepository)
        {
            this.transferenciaRepository = transferenciaRepository;
            this.carteiraRepository = carteiraRepository;
            this.usuarioRepository = usuarioRepository;
        }

        //Rever a logica e adicionar o HttpClient
        public async Task<TransferenciaModel> Add(TransferenciaModel transferenciaDto)
        {
            var usuario = await usuarioRepository.GetByIdAsync(transferenciaDto.FkDevedor);

            if(usuario.TgTipo == TipoUsuario.LOJISTA)
            {
                return null;
            }

            var carteiraDevedor = await carteiraRepository.GetUsuarioPorCarteira(transferenciaDto.FkDevedor);

            var carteiraRebidor = await carteiraRepository.GetUsuarioPorCarteira(transferenciaDto.FkRecebidor);

            if (carteiraRebidor.Saldo <= 0) 
            {
                return null;
            }

            return transferenciaDto;
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
