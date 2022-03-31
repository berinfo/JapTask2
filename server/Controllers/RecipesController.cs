﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Models;
using server.Response;
using server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Controllers
{
  //  [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService; 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneRecipe(int id)
        {
            var res = await _recipeService.GetOneRecipe(id);
            if(res == null)
            {
                return NotFound();  
            }
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateRecipeDto newRecipe)
        {
            return Ok(await _recipeService.CreateRecipe(newRecipe));
        }

        [HttpGet("GetByCategory")]
        public async Task<IActionResult> GetRecipesByCategory(int categoryId, int skip, int pageSize)
        {
            var res = await _recipeService.GetRecipesByCategory(categoryId, skip, pageSize);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchRecipes(int categoryId, string word)
        {
            var res = await _recipeService.SearchRecipes(categoryId, word);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}
