using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseEntity<TKey>//Generic Class [BaseClass] specify the pkey type
    {
        public  TKey Id { get; set; }
    }
}
