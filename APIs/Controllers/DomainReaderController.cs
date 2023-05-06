using APIs.Helpers;
using Helpers.JSON;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.DomainModelsReaders;
using System.Text;

namespace APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DomainReaderController : BaseController
    {
        private readonly IDomainModelsReader _domainModelReaderService;
        private readonly DomainReaderOption _domainReaderSettings;
        public DomainReaderController(IDomainModelsReader domainModelReaderService,
                                      IOptions<DomainReaderOption> domainReaderOption)
        {
            _domainModelReaderService = domainModelReaderService;
            this._domainReaderSettings=domainReaderOption.Value;
        }

        [HttpGet("GetAllAttributes")]
        public async Task<IActionResult> GetAllAttributes() {
            return await base.GetResultAsync(async() =>
            {
                var strBuilder = new StringBuilder();
                var jsonFiles = _domainReaderSettings.DomainReaderURI.GetAllJSONFiles();

                var tasks = new List<Task>();
                jsonFiles.Chunk(4).ToList().ForEach(chunk =>
                {
                    var t = Task.Factory.StartNew(() =>
                    {
                        foreach (var f in jsonFiles)
                        {
                            var model = _domainModelReaderService.ReadAttributes(_domainReaderSettings.DomainReaderURI);

                            model?.Entities?.ToList().ForEach(e =>
                            {
                                strBuilder.Append(
                                    $"entity name is {e.Name} and attributes are {string.Concat(e.AttributesNames, ",")}");
                            });
                        }
                    });

                    tasks.Add(t);
                });

                await Task.WhenAll(tasks.ToArray());
                return Ok(strBuilder.ToString());
            });
        }


        [HttpGet("GetAllPagesContainsDashboard")]
        public async Task<IActionResult> GetAllPagesContainsDashboard()
        {
            return await base.GetResultAsync(async() =>
            {
                var jsonFiles = _domainReaderSettings.DomainReaderURI.GetAllJSONFiles();
                var strBuilder = new StringBuilder();

                var tasks = new List<Task>();
                jsonFiles.Chunk(4).ToList().ForEach(chunk =>
                {
                    var t = Task.Factory.StartNew(() =>
                    {
                        foreach (var f in chunk)
                        {
                            var model = _domainModelReaderService.GetPageModel(f);
                            if (model?.Title?.Contains("dashboard") ?? false)
                                strBuilder.Append(model.Code);
                        }
                    });

                    tasks.Add(t);
                });

                await Task.WhenAll(tasks.ToArray());

                return Ok(strBuilder.ToString());
            });
        }
    }
}