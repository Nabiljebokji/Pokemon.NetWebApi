using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokemonReviews.Commands.CategoryCommands;
using PokemonReviews.Dto;
using PokemonReviews.Interfaces;
using PokemonReviews.Models;
using PokemonReviews.Queries.CategoryQuery;

namespace PokemonReviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(IMediator mediator, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mediator = mediator;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(result);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            var query = new GetCategoryIDQuery() { categoryId = categoryId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPokemonByCategoryId(int categoryId)
        {
            var query = new GetPokemonCategoryIDQuery() { categoryId = categoryId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryCreate)
        {
            var command = new CreateCategoryCommand() { categoryDto = categoryCreate };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] CategoryDto updatedCategory)
        {
            if (updatedCategory == null)
                return BadRequest(ModelState);

            if (categoryId != updatedCategory.Id)
                return BadRequest(ModelState);

            if (!await _categoryRepository.CategoryExists(categoryId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var command = new UpdateCategoryIdCommand() { categoryID = categoryId, updatedCategory = updatedCategory };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var command = new DeleteCategoryCommand() { categoryId = categoryId };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
