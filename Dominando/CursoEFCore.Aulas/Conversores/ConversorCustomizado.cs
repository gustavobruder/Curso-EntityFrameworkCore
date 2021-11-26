using System;
using System.Linq;
using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CursoEFCore.Aulas.Conversores
{
    public class ConversorCustomizado : ValueConverter<Status, string>
    {
        public ConversorCustomizado() : base(
            status => ConverterParaBancoDados(status),
            value => ConverterParaAplicacao(value),
            new ConverterMappingHints(size: 1))
        {
        }

        static string ConverterParaBancoDados(Status status)
        {
            return status.ToString()[0..1];
        }

        static Status ConverterParaAplicacao(string value)
        {
            var status = Enum
                .GetValues<Status>()
                .FirstOrDefault(s => s.ToString()[0..1] == value);

            return status;
        }
    }
}