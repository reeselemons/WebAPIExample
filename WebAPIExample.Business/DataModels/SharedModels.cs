using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIExample.Business.DataModels
{
    public abstract class DTO<L, T> : Shared
    {
        public abstract T Map(L item);
        public abstract List<T> MapToList(List<L> item);
    }

    public class Shared
    {
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}
