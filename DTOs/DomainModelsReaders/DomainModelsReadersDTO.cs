using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DomainModelsReaders
{
    public record DomainModelsReadersDTO(IEnumerable<EntityDto>? Entities);

    public record EntityDto(string? Name,IEnumerable<string>? AttributesNames);
    public record PageModel(string Code, string Title);

}
