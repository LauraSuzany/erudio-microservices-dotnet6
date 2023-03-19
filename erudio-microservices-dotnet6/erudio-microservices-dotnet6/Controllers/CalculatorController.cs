using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace erudio_microservices_dotnet6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Addition(double firstNumber, double secondNumber)
        {
            try
            {
                double sum = firstNumber + secondNumber;
                return Ok(sum.ToString());
            }
            catch (Exception)
            {
               return BadRequest("Invelid input");
            }        
        }

        [HttpGet("Subtract/{firstNumber}/{secondNumber}")]
        public IActionResult Subtract(double firstNumber, double secondNumber)
        {
            try
            {
                double sum = firstNumber - secondNumber;
                return Ok(sum.ToString());
            }
            catch (Exception)
            {
                return BadRequest("Invelid input");
            }            
        }

        [HttpGet("Multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(double firstNumber, double secondNumber)
        {
            try
            {
                double sum = firstNumber * secondNumber;
                return Ok(sum.ToString());
            }
            catch (Exception)
            {
                return BadRequest("Invelid input");
            }
        }


        [HttpGet("Division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(double firstNumber, double secondNumber)
        {
            try
            {
                double sum = firstNumber / secondNumber;
                return Ok(sum.ToString());
            }
            catch (Exception)
            {
                return BadRequest("Invelid input");
            }
        }

        [HttpGet("Average")]
        public IActionResult Average()
        {
            List<double>? dListNumber;
            try
            {
                dListNumber = Newtonsoft.Json.JsonConvert.DeserializeObject<List<double>>(HttpContext.Request.Form["numbers"].ToString());
            }
            catch (Exception)
            {
                return BadRequest("Invelid input");
            }
           
            try
            {
                double sum = 0;
                double average = 0;
                if (dListNumber != null)
                {
                    foreach(double number in dListNumber)
                    {
                        sum += number;
                    }
                    average = sum / dListNumber.Count();
                }
                return Ok(average);
            }
            catch (Exception)
            {

                return BadRequest("Invelid input");
            }

        }

        [HttpGet("SquareRoot/{number}")]
        public IActionResult SquareRoot(double number)
        {   
            try
            {
                if (number < 0)
                {
                    return BadRequest("Não é possível calcular a raiz quadrada de um número negativo.");
                }
                double raiz = Math.Sqrt(number);
                return Ok("A raiz quadrada de " + number + " é " + raiz + ".");
            }
            catch (Exception)
            {

                return BadRequest("Invelid input");
            }
        }
    }
}