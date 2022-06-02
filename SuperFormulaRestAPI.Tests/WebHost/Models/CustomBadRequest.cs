using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperFormulaRestAPITests.WebHost.Models
{
    public class CustomBadRequest
    {
        public string ? Type { get; set; }
        public string ? Title { get; set; }
        public int Status { get; set; }
        public string ? TraceId { get; set; }
        public ModelErrors ? Errors { get; set; }
    }

    public class ModelErrors
    {
        public List<string> ? ErrorMessages { get; set; }
    }
}
