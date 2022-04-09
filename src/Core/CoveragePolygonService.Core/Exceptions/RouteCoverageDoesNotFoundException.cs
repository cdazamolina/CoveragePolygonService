using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoveragePolygonService.Core.Exceptions
{
    public class RouteCoverageDoesNotFoundException : Exception
    {
        public RouteCoverageDoesNotFoundException()
        {
        }

        public RouteCoverageDoesNotFoundException(string message) : base(message)
        {
        }

        public RouteCoverageDoesNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RouteCoverageDoesNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
