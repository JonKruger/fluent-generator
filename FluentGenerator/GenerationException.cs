using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FluentGenerator
{
    [Serializable]
    public class GenerationException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public GenerationException()
        {
        }

        public GenerationException(string message) : base(message)
        {
        }

        public GenerationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected GenerationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
