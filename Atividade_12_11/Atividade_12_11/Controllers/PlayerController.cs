using Atividade_12_11.Model;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_12_11.Controllers
{
    public class PlayerController : ControllerBase
    {

        public static List<Player> players = new List<Player>() {
            { new Player { id = "1", Vida = 3, QuantidadeItens = 0, PosicaoX = 0f, PosicaoY = 0f, PosicaoZ = 0f } },
            { new Player { id = "2", Vida = 10, QuantidadeItens = 3780, PosicaoX = 33.7f, PosicaoY = 1.122f, PosicaoZ = 2214.6f } }
        };

        [HttpGet]
        [Route("Player")]
        public IActionResult GetJogadores()
        {
            return Ok(players);
        }

        [HttpGet]
        [Route("Player/{id}")]
        public IActionResult GetPlayerByID(string id)
        {
            var player = players.FirstOrDefault(a => a.id == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpPost]
        [Route("Player")]
        public IActionResult AddPlayer([FromBody] Player novoJogador)
        {
            players.Add(novoJogador);
            return Ok(novoJogador);
        }

        [HttpPut]
        [Route("Player/{id}")]
        public IActionResult UpdatePlayer(string id, [FromBody] Player jogadorAtualizado)
        {
            var player = players.FirstOrDefault(a => a.id == id);
            if (player == null)
            {
                return NotFound();
            }
            player.Vida = jogadorAtualizado.Vida;
            player.QuantidadeItens = jogadorAtualizado.QuantidadeItens;
            player.PosicaoX = jogadorAtualizado.PosicaoX;
            player.PosicaoY = jogadorAtualizado.PosicaoY;
            player.PosicaoZ = jogadorAtualizado.PosicaoZ;
            return Ok(player);
        }

        [HttpDelete]
        [Route("Player/{id}")]
        public IActionResult DeletePlayer(string id)
        {
            var player = players.FirstOrDefault(a => a.id == id);
            if (player == null)
            {
                return NotFound();
            }
            players.Remove(player);
            return Ok();
        }

    }
}
