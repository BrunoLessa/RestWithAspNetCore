using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET api/values
        [HttpGet("soma/{firstNumber}/{secondNumber}")]
        public IActionResult SumNumbers(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var resultado = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(resultado.ToString());
            }
            return BadRequest("Erro: invalid input");
        }
        
        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult SubNumbers(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var resultado = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(resultado.ToString());
            }
            return BadRequest("Erro: invalid input");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult MultNumbers(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var resultado = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(resultado.ToString());
            }
            return BadRequest("Erro: invalid input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult DivNumbers(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var resultado = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(resultado.ToString());
            }
            return BadRequest("Erro: invalid input");
        }

        [HttpGet("sqr/{firstNumber}")]
        public IActionResult SqrNumbers(string firstNumber)
        {
            if (IsNumeric(firstNumber) )
            {
                var resultado = Math.Sqrt(Convert.ToDouble(ConvertToDecimal(firstNumber)));
                return Ok(resultado.ToString());
            }
            return BadRequest("Erro: invalid input");
        }

        private decimal ConvertToDecimal(string numero)
        {
            decimal valorDecimal;
            if (decimal.TryParse(numero, out valorDecimal))
                return valorDecimal;
            return 0;
        }

        private bool IsNumeric(string numero)
        {
            double numerico;
            bool ehnumerico = double.TryParse(numero, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out numerico);
            return ehnumerico;
        }
    }
}
