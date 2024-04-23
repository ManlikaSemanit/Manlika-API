using Manlika_WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Manlika_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortDataController : Controller
    {   
        //-----------------------------------------------------------------//
        //-----------------2. ทำ Web API โดยใช้ .net and C# -----------------//
        //-----------------------------------------------------------------//

        [Authorize]
        [Route("SortData")]
        [HttpPost]
        public IActionResult SortData([FromBody] Sort data)
        {
            string strError = "";
            try
            {
                if (data.p1 != null)
                {
                    string[] characters = data.p1.Split(',').ToArray();

                    if (characters.Count() > 99)
                    {
                        strError = "Can not send data more than 99.";
                        return Ok(strError);
                    }
                    else
                    {
                        SortedSet<string> distinctChar = new();
                        SortedSet<string> duplicateChar = new();

                        foreach (string cha in characters)
                        {
                            if (!distinctChar.Add(cha.Trim()))
                                duplicateChar.Add(cha.Trim());
                        }

                        List<string> result = duplicateChar
                          .OrderBy(s =>
                            {
                                int i = 0;
                                return !int.TryParse(s, out i) ? i : int.MaxValue;
                            }
                          )
                          .ToList();

                        var returnResult = result.Select(s => new Rank { rank = s });

                        return Ok(returnResult);
                    }
                }
                else
                {
                    strError = "No data to sort.";
                    return Ok(strError);
                }
                
            }
            catch
            {
                throw;
            }
        }
    }
}
