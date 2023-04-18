using System;
using System.Threading.Tasks;
using AutoMapper;
using HomeApi.Contracts.Models.Rooms;
using HomeApi.Data.Models;
using HomeApi.Data.Queries;
using HomeApi.Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace HomeApi.Controllers
{
    /// <summary>
    /// Контроллер комнат
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository _repository;
        private readonly IMapper _mapper;

        public RoomsController(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //TODO: Задание - добавить метод на получение всех существующих комнат
        /// <summary>
        /// Получение всех комнат
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _repository.GetRooms();

            var resp = new GetRoomsResponse()
            {
                RoomAmount = rooms.Length,
                Rooms = _mapper.Map<Room[], RoomView[]>(rooms)
            };

            return StatusCode(200, resp);
        }

        /// <summary>
        /// Обновление или изменение комнаты
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit(
            [FromRoute] Guid id,
            [FromBody] EditRoomRequest request)
        {
            var existingRoom = await _repository.GetRoomById(id);
            if (existingRoom == null)
                return StatusCode(400, $"Ошибка: Устройство с идентификатором {id} не существует.");

            await _repository.UpdateRoom(
                existingRoom,
                new UpdateRoomQuery(request.NewName, request.NewArea, request.NewGasConnected, request.NewVoltage)
            );

            return StatusCode(200, $"Комната обновлена! Имя - {existingRoom.Name}, Площадь - {existingRoom.Area},  Наличие газа - {existingRoom.GasConnected}, Напряжение - {existingRoom.Voltage}");
        }

        /// <summary>
        /// Добавление комнаты
        /// </summary>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add([FromBody] AddRoomRequest request)
        {
            var existingRoom = await _repository.GetRoomByName(request.Name);
            if (existingRoom == null)
            {
                var newRoom = _mapper.Map<AddRoomRequest, Room>(request);
                await _repository.AddRoom(newRoom);
                return StatusCode(201, $"Комната {request.Name} добавлена!");
            }

            return StatusCode(409, $"Ошибка: Комната {request.Name} уже существует.");
        }
    }
}