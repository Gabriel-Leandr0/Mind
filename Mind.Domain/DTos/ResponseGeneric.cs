using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mind.Domain.ViewModels;

namespace Mind.Domain.DTos
{
    public class ResponseGeneric
    {
        public ResponseViewModel response { get; set; }
        public object data { get; set; }
    }
}