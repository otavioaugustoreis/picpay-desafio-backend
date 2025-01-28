using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int PkId { get; set; }

        public BaseEntity() { }

        protected BaseEntity(int pkId)
        {
            PkId = pkId;
        }
    }
}
