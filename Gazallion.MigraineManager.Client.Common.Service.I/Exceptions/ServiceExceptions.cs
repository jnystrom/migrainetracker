using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazallion.MigraineManager.Client.Common.Service.I.Exceptions
{
    public class NoContentException : Exception
    {
        public NoContentException() : base("The resource was not defined, or not available") { }
    }
    public class BadRequestException : Exception
    {
        public BadRequestException() : base("There was a problem with the request, most probably within the representation format") { }
        public BadRequestException(string message) : base(message) { }
    }
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base("The request could not be completed, as the caller is not authenticated") { }
        public UnauthorizedException(string message) : base(message) { }
    }
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base("The request could not be completed, as the caller is not permitted") { }
        public ForbiddenException(string message) : base(message) { }
    }
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("The requested resource could not be found") { }
        public NotFoundException(string message) : base(message) { }
    }
    public class ConflictException : Exception
    {
        public ConflictException() : base("This might be result of a conversion error during XML marshaling") { }
        public ConflictException(string message) : base(message) { }
    }
    public class PreconditionFailedException : Exception
    {
        public PreconditionFailedException() : base("The caller sent an out of date version of the resource") { }
        public PreconditionFailedException(string message) : base(message) { }
    }
    public class ServerErrorException : Exception 
    {
        public ServerErrorException() : base("There was a serious, and non-recoverable, problem whilst attempting to fulfill the request") { }
        public ServerErrorException(string message) : base(message) { }    
    }
    

}
