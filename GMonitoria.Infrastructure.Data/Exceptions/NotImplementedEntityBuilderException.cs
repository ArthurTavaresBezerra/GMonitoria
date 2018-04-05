using Microsoft.EntityFrameworkCore;
using GMonitoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GMonitoria.Infrastructure.Data.Exceptions
{
    //
    // Resumo:
    //     The exception that is thrown when a requested method or operation is not implemented.

    public class NotImplementedEntityBuilderException : Exception
    {
        public NotImplementedEntityBuilderException() :base () { }

        public NotImplementedEntityBuilderException(string message) : base(message) { }

        public NotImplementedEntityBuilderException(string message, Exception inner) : base(message, inner) { }


    }
}
