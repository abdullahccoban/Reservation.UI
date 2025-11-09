using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models;
using Reservation.UI.Models.DTOs.Request.Hotel;

namespace Reservation.UI.Controllers;

[Authorize(Roles = "HotelAdmin, SuperAdmin")]
public class AdminController : Controller
{
    private readonly IHotelService _hotelService;
    private readonly IHotelInformationService _infoService;
    private readonly IPhotoService _photoService;
    private readonly ITagService _tagService;
    private readonly IRoomService _roomService;
    private readonly IRoomFeatureService _roomFeatureService;
    private readonly IRoomPriceService _roomPriceService;
    private readonly IWorkingRangeService _workingRangeService;
    private readonly IHotelAdminService _hotelAdminService;
    private readonly IQaService _qaService;

    public AdminController(IHotelInformationService infoService, IPhotoService photoService, ITagService tagService, IRoomService roomService, IRoomFeatureService roomFeatureService, IRoomPriceService roomPriceService, IWorkingRangeService workingRangeService, IHotelService hotelService, IHotelAdminService hotelAdminService, IQaService qaService)
    {
        _infoService = infoService;
        _photoService = photoService;
        _tagService = tagService;
        _roomService = roomService;
        _roomFeatureService = roomFeatureService;
        _roomPriceService = roomPriceService;
        _workingRangeService = workingRangeService;
        _hotelService = hotelService;
        _hotelAdminService = hotelAdminService;
        _qaService = qaService;
    }
    
    [Authorize(Roles = "SuperAdmin")]
    [HttpGet("Admin/SuperAdmin")]
    public async Task<IActionResult> SuperAdmin(int page = 1, int pageSize = 10, string? searchTerm = null)
    {
        var hotels = await _hotelService.SearchHotels(new HotelSearchRequestDto
        {
            PageSize = pageSize,
            Page = page,
            SearchTerm = searchTerm
        });
        HotelListViewModel model = new HotelListViewModel()
        {
            Page = hotels.Page,
            PageSize = hotels.PageSize,
            TotalCount = hotels.TotalCount,
            Items = hotels.Items,
            SearchTerm = searchTerm
        };
        return View(model);
    }
    
    [Authorize(Roles = "SuperAdmin")]
    [Route("Admin/HotelAdmin/{hotelId:int}")]
    public async Task<IActionResult> HotelAdmin(int hotelId)
    {
        AdminViewModel model = new AdminViewModel
        {
            HotelId = hotelId,
            HotelAdmins = await _hotelAdminService.GetAllHotelAdmins(hotelId)
        };
        return View(model);
    }
    
    public async Task<IActionResult> Index()
    {
        AdminViewModel model = new AdminViewModel()
        {
            Hotels = await _hotelService.GetHotels(User.Claims.Where(i => i.Type == "email").FirstOrDefault().Value.ToString())
        };
        
        return View(model);
    }
    
    [Authorize(Policy = "HotelPermission")]
    [Route("Admin/Hotel/{hotelId:int}")]
    public async Task<IActionResult> Hotel(int hotelId)
    {
        AdminViewModel model = new AdminViewModel
        {
            HotelId = hotelId,
            HotelInfos = await _infoService.GetAllHotelInfos(hotelId)
        };
        return View(model);
    }
    
    [Authorize(Policy = "HotelPermission")]
    [Route("Admin/Photo/{hotelId:int}")]
    public async Task<IActionResult> Photo(int hotelId)
    {
        AdminViewModel model = new AdminViewModel
        {
            HotelId = hotelId,
            Photos = await _photoService.GetAllPhotos(hotelId)
        };
        return View(model);
    }
    
    [Authorize(Policy = "HotelPermission")]
    [Route("Admin/Promotion/{hotelId:int}")]
    public IActionResult Promotion(int hotelId)
    {
        AdminViewModel model = new AdminViewModel
        {
            HotelId = hotelId
        };
        return View(model);
    }
    
    [Authorize(Policy = "HotelPermission")]
    [Route("Admin/WorkingRange/{hotelId:int}")]
    public async Task<IActionResult> WorkingRange(int hotelId)
    {
        AdminViewModel model = new AdminViewModel
        {
            HotelId = hotelId,
            WorkingRanges = await _workingRangeService.GetAllWorkingRanges(hotelId)
        };
        return View(model);
    }
    
    [Authorize(Policy = "HotelPermission")]
    [Route("Admin/Reservation/{hotelId:int}")]
    public IActionResult Reservation(int hotelId)
    {
        AdminViewModel model = new AdminViewModel
        {
            HotelId = hotelId
        };
        return View(model);
    }
    
    [Authorize(Policy = "HotelPermission")]
    [Route("Admin/Room/{hotelId:int}")]
    public async Task<IActionResult> Room(int hotelId)
    {
        AdminViewModel model = new AdminViewModel
        {
            HotelId = hotelId,
            Rooms = await _roomService.GetAllRooms(hotelId)
        };
        return View(model);
    }
    
    [Route("Admin/RoomDetail/{roomId:int}")]
    public async Task<IActionResult> RoomDetail(int roomId)
    {
        var roomTask = _roomService.GetRoom(roomId);
        var featuresTask = _roomFeatureService.GetAllRoomFeatures(roomId);
        var pricesTask = _roomPriceService.GetAllRoomPrices(roomId);

        await Task.WhenAll(roomTask, featuresTask, pricesTask);

        RoomViewModel model = new RoomViewModel()
        {
            RoomId = roomId,
            Room = await roomTask,
            RoomFeatures = await featuresTask,
            RoomPrices = await pricesTask
        };

        return View(model);
    }
    
    [Authorize(Policy = "HotelPermission")]
    [Route("Admin/QA/{hotelId:int}")]
    public async Task<IActionResult> QA(int hotelId)
    {
        AdminViewModel model = new AdminViewModel
        {
            HotelId = hotelId,
            Qa = await _qaService.GetAllQuestions(hotelId)
        };
        return View(model);
    }
    
    [Authorize(Policy = "HotelPermission")]
    [Route("Admin/Tag/{hotelId:int}")]
    public async Task<IActionResult> Tag(int hotelId)
    {
        AdminViewModel model = new AdminViewModel
        {
            HotelId = hotelId,
            Tags = await _tagService.GetAllTags(hotelId)
        };
        return View(model);
    }
}