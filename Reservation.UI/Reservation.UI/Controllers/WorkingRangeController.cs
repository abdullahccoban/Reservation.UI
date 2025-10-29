using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.WorkingRange;

namespace Reservation.UI.Controllers;

[Route("workingRange")]
public class WorkingRangeController : Controller
{
    private readonly IWorkingRangeService _workingRangeService;

    public WorkingRangeController(IWorkingRangeService workingRangeService)
    {
        _workingRangeService = workingRangeService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateWorkingRangeRequestDto request)
    {
        await _workingRangeService.CreateWorkingRange(request);
        return Json(new { success = true });
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateWorkingRangeRequestDto request)
    {
        await _workingRangeService.UpdateWorkingRange(request);
        return Json(new { success = true });
    }
    
    [HttpPost("remove")]
    public async Task<IActionResult> Remove(int id)
    {
        await _workingRangeService.RemoveWorkingRange(id);
        return Json(new { success = true });
    }
}