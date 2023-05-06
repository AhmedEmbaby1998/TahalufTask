using DTOs.DomainModelsReaders;

namespace Services.DomainModelsReaders
{
    public interface IDomainModelsReader
    {
        DomainModelsReadersDTO ReadAttributes(string jsonFilePath);
        PageModel? GetPageModel(string jsonPage);
    }
}