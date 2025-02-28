using Picpay.Application.Models;
using Picpay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Services
{
    public interface ICarteiraService 
    {
        Task<IEnumerable<CarteiraModel>> GetAllAsync();

    }
}
