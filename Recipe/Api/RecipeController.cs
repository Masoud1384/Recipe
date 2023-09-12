using Application;
using Application.Contracts.RecipeContracts;
using Application.Contracts.UserContracts;
using Microsoft.AspNetCore.Mvc;

namespace Recipe.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeApplication _recipeApplication;

        public RecipeController(IRecipeApplication recipeApplication)
        {
            _recipeApplication = recipeApplication;
        }

        // GET: api/<RecipeController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _recipeApplication.SelectAllRecipes();
            return Ok(result);
        }

        // GET api/<RecipeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _recipeApplication.FindRecipe(r => r.Id == id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        // POST api/<RecipeController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateRecipeCommand recipeCmd)
        {
            int? id; 
            var result = _recipeApplication.AddRecipe(recipeCmd,out id);
            if (result)
            {
                var url = Url.Action(nameof(Get), "Recipe", new { id = id }, Request.Scheme);
                return Created(url, recipeCmd);
            }
            return BadRequest();
        }

        // PUT api/<RecipeController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UpdateRecipeCommand recipeCmd)
        {
            var isSuccesed = _recipeApplication.Update(recipeCmd);
            //Restful api rules must be followed
            //if the object is not exists in put request so it should be generated
            if (!isSuccesed)
            {
                var createcmd = new CreateRecipeCommand
                {
                    AuthorId = recipeCmd.AuthorId,
                    Description = recipeCmd.Description,
                    Ingredients = recipeCmd.Ingredients,
                    Instructions=  recipeCmd.Instructions,
                    Title = recipeCmd.Title,
                    Image = recipeCmd.Image,
                };
                int? newid;
                isSuccesed = _recipeApplication.AddRecipe(createcmd,out newid);
            }
            if (isSuccesed)
                return Ok();

            return BadRequest();
        }

        // DELETE api/<RecipeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _recipeApplication.DeleteRecipe(id);
            if (result)
                return Ok();

            return NotFound();

        }
    }
}
