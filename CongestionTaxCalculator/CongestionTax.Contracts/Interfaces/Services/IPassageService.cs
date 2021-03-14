using System.Collections.Generic;
using CongestionTax.Contracts.Dtos;
using CongestionTax.Contracts.Dtos.Register;

namespace CongestionTax.Contracts.Interfaces.Services
{
    public interface IPassageService
    {
        PassageDto Save(RegisterPassage registerPassage);
        List<PassageDto> GetByRegNumber(string regNumber);
    }
}