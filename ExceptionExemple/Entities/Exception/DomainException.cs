using System;

namespace ExceptionExemple.Entities.Exception {
    class DomainException : ApplicationException{

        public DomainException(string mensage) : base(mensage) { }
    }
}
