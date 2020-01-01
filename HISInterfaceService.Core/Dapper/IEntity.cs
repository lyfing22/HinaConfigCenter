using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HinaConfigCenter.Core.Dapper
{
  public interface IEntity<T>
    {
          T Id { get; set; }
    }
}
