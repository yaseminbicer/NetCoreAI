using Microsoft.AspNetCore.Mvc;
using NetCoreAI.Project20_RecipeSuggestion.Models;

namespace NetCoreAI.Project20_RecipeSuggestion.Controllers
{
    public class DefaultController1 : Controller
    {
        private readonly OpenAIServices _openAIServices;

        public DefaultController1(OpenAIServices openAIServices)
        {
            _openAIServices = openAIServices;
        }
        [HttpGet]
        public IActionResult CreateRecipe()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRecipe(string ingredients)
        {
            var result=await _openAIServices.GetRecipeAsync(ingredients);
            ViewBag.recipe =result;
            return View();
        }
    }
}
