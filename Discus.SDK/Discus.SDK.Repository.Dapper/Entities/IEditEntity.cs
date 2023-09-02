using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discus.SDK.Repository.Dapper.Entities
{
    public interface IEditEntity
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public long EditById { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime EditByTime { get; set; }
    }
}
