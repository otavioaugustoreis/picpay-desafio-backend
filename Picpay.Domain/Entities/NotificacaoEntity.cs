using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Domain.Entities
{
    public class NotificacaoEntity
    {
        public string Status { get; set; }
        public NotificacaoData Data { get; set; }
    }
}
