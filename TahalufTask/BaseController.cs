using Helpers.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace APIs
{
    public class BaseController:ControllerBase
    {
        protected async Task<IActionResult> GetResultAsync(Func<Task<IActionResult>> func)
        {
            try
            {
                return await func();

            }catch (BusinessExecption ex)
            {
                return BadRequest(ex.Message);
            }catch(Exception ex)
            {
                //should log here 
                return StatusCode(500, "error happened");
            }
        }

        protected IActionResult GetResult(Func<IActionResult> func)
        {
            try
            {
                return func();

            }
            catch (BusinessExecption ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                //should log here 
                return StatusCode(500, "error happened");
            }
        }
    }
}
