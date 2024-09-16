using CleanArchitecture.Application.Categories.Commands;
using CleanArchitecture.Application.Categories.Queries;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Security;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<CategoryDto>>> GetCategories([FromQuery] GetCategoriesQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCategoryCommand command)
    {
        return await _mediator.Send(command);
    }
}
