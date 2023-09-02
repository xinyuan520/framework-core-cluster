using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discus.SDK.Repository.Dapper.Entities
{
    public interface IDeleted
    {
        bool IsDeleted { get; set; }
    }
}
