using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discus.User.Application.Contracts.Dtos
{
    public class RedisDto
    {
        public string RedisKey { get; set; }

        public string RedisValue { get; set; }

        public int Expired { get; set; } = -1;
    }
}
