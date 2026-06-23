using System;

namespace AvaliacaoDotnet.Core.Validation;

public class ValidacaoException : Exception
{
    public ValidacaoException(string message) : base(message) { }
}
