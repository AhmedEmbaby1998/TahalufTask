using DTOs.DomainModelsReaders;
using Helpers.JSON;
using Newtonsoft.Json;
using Services.DomainModelsReaders.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModelsReaders
{
    public class DomainModelsReader : IDomainModelsReader
    {
        public DomainModelsReadersDTO ReadAttributes(string jsonFilePath)
        {
            return new JSONDataCollector<DeserializingObjectModel, DomainModelsReadersDTO>(jsonFilePath)
                .Read()
                .Validate()
                .Convert()
                .Finalize(a => new DomainModelsReadersDTO(a?.DomainSourceBindings?.Select(x =>
                {
                    return new EntityDto(x?.Entity?.Name, x?.Entity?.Attributes?.Select(z => z?.Name ?? string.Empty));
                })))
                .Data;
        }

        public PageModel? GetPageModel(string jsonPage)
        {
            return JsonConvert.DeserializeObject<PageModel?>(jsonPage);
        }
    }

}
