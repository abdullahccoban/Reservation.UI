using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models;

namespace Reservation.UI.Controllers;

public class AdminController : Controller
{
    private readonly IHotelInformationService _infoService;
    private readonly IPhotoService _photoService;
    private readonly ITagService _tagService;
    private readonly IRoomService _roomService;
    private readonly IRoomFeatureService _roomFeatureService;
    private readonly IRoomPriceService _roomPriceService;

    public AdminController(IHotelInformationService infoService, IPhotoService photoService, ITagService tagService, IRoomService roomService, IRoomFeatureService roomFeatureService, IRoomPriceService roomPriceService)
    {
        _infoService = infoService;
        _photoService = photoService;
        _tagService = tagService;
        _roomService = roomService;
        _roomFeatureService = roomFeatureService;
        _roomPriceService = roomPriceService;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
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
    
    [Route("Admin/Promotion/{hotelId:int}")]
    public IActionResult Promotion(int hotelId)
    {
        AdminViewModel model = new AdminViewModel
        {
            HotelId = hotelId
        };
        return View(model);
    }
    
    [Route("Admin/WorkingRange/{hotelId:int}")]
    public IActionResult WorkingRange(int hotelId)
    {
        AdminViewModel model = new AdminViewModel
        {
            HotelId = hotelId
        };
        return View(model);
    }
    
    [Route("Admin/Reservation/{hotelId:int}")]
    public IActionResult Reservation(int hotelId)
    {
        AdminViewModel model = new AdminViewModel
        {
            HotelId = hotelId
        };
        return View(model);
    }
    
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
    
    [Route("Admin/QA/{hotelId:int}")]
    public IActionResult QA(int hotelId)
    {
        AdminViewModel model = new AdminViewModel
        {
            HotelId = hotelId
        };
        return View(model);
    }
    
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