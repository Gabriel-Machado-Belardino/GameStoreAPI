using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using GameStoreAPI.Models;
using GameStoreAPI.Models.Enuns;
using GameStoreAPI.Data;

namespace GameStoreAPI.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class GameStoreController : ControllerBase
    {
        
        private readonly DataContext _context;
        public GameStoreController(DataContext dataContext)
        {
            _context = dataContext;
        }

            //==========================
            //Buscar todos os jogos
            //==========================
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Games> lista = await _context.games.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


            //==========================
            //Buscar Jogo por Id
            //==========================
        [HttpGet("GetbyId/{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            try
            {
                Games game = await _context.games.FirstOrDefaultAsync(bBusca => bBusca.Id == id);
                return Ok(game);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


            //======================================
            //Buscar todos os jogos por categoria
            //=====================================

        
        [HttpGet("GetbyCategory/{cat}")]
        public async Task<IActionResult> GetbyCategory(int cat)
        {
            try
            {
                List<Games> gameC = await _context.games.ToListAsync();
                return Ok(gameC.FindAll(x => x.Category == (Categorys)cat));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

            //========================================
            //Buscar todos os jogos de uma compania
            //========================================

            [HttpGet("GetbyCompany/{comp}")]
            public async Task<IActionResult> GetbyCategory(Companys comp)
        {
            try
            {
                List<Games> gameComp = await _context.games.ToListAsync();
                return Ok(gameComp.FindAll(x => x.Company == comp));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


            //==========================
            //Buscar jogo com valor maximo
            //==========================

        [HttpGet("GetbyMaxValue/{valu}")]
            public async Task<IActionResult> GetbyCategory(decimal value)
        {
            try
            {
                List<Games> gameValu = await _context.games.ToListAsync();
                return Ok(gameValu.FindAll(gv => gv.Price <= value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
            //==========================
            //Adicionar um jogo
            //==========================
        [HttpPost("AddGame")]
        public async Task<IActionResult> AddGame(Games newGame)
        {
            try
            {
                await _context.games.AddAsync(newGame);
                await _context.SaveChangesAsync();
                return Ok(newGame);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


            //==========================
            //Alterar um jogo  ()
            //==========================
        [HttpPut("ModifyGame/{id}")]
        public async Task<IActionResult> Update(Games gameMod)
        {
            try
            {
                _context.games.Update(gameMod);
                int LinhasAfec = await _context.SaveChangesAsync();
                return Ok(LinhasAfec);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

            //==========================
            //Deletar um jogo
            //==========================

        
        [HttpDelete("DeleteGame/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Games gameR = await _context.games.FirstOrDefaultAsync(bBusca => bBusca.Id == id);
                _context.games.Remove(gameR);
                int LinhasAfec = await _context.SaveChangesAsync();
                return Ok(LinhasAfec);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}