using Microsoft.AspNetCore.Mvc;
using Task_Ferramenta.Models;
using Task_Ferramenta.Repositories;

namespace Task_Ferramenta.Controllers
{
    [ApiController]
    [Route("api/ferramenta")]
    public class ProdottoController : Controller
    {
        [HttpGet]
        public IActionResult ElencoProdotti()
        {
            return Ok(ProdottoRepo.getInstance().GetAll());
        }

        [HttpPost]
        public IActionResult InserisciProdotto(Prodotto objProd)
        {
            if (ProdottoRepo.getInstance().insert(objProd))
                return Ok();

            return BadRequest();
        }

        [HttpPatch]
        public IActionResult ModificaProdotto(Prodotto objProd)
        {
            if (ProdottoRepo.getInstance().update(objProd))
                return Ok();

            return BadRequest();
        }

        private IActionResult EliminaProdotto(int varId)
        {
            if (ProdottoRepo.getInstance().delete(varId))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("codice/{varCodice}"), HttpPost("codice/{varCodice}")]
        public IActionResult EliminaPerCodiceProdotto(string varCodice)
        {
            Prodotto? pro = ProdottoRepo.getInstance().GetByCodice(varCodice);
            if (pro is null)
                return BadRequest();

            return EliminaProdotto(pro.ProdottoId);
        }



        [HttpGet("{varCodice}")]


        public IActionResult ValoreProdottoPerCodice(string varCodice)
        {
            Prodotto? pro = ProdottoRepo.getInstance().GetByCodice(varCodice);
            if (pro is not null)
                return Ok(pro);

            return NotFound();

        }
    }
}
