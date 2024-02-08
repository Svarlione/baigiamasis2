using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using baigiamasis2.Models;
using baigiamasis2.Services;


namespace baigiamasis2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegSistem : ControllerBase
    {
        private readonly UserService _userService;

        public UserRegSistem(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Создает нового пользователя.
        /// </summary>
        /// <param name="user">Данные пользователя для создания.</param>
        /// <returns>HTTP-статус 200 с идентификатором созданного пользователя или HTTP-статус 400 в случае ошибки.</returns>
        [HttpPost("user/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                long userId = _userService.CreateUser(user);
                return Ok(new { UserId = userId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        /// <summary>
        /// Обновляет информацию о пользователе.
        /// </summary>
        /// <param name="user">Обновленные данные пользователя.</param>
        /// <returns>HTTP-статус 200 в случае успешного обновления или HTTP-статус 400 в случае ошибки.</returns>
        [HttpPut("user/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                _userService.UpdateUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        /// <summary>
        /// Создает новый адрес пользователя.
        /// </summary>
        /// <param name="userAddress">Данные адреса для создания.</param>
        /// <returns>HTTP-статус 200 в случае успешного создания или HTTP-статус 400 в случае ошибки.</returns>
        [HttpPost("address/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateUserAddress([FromBody] UserAdress userAddress)
        {
            try
            {
                _userService.CreateUserAddress(userAddress);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        /// <summary>
        /// Обновляет информацию о пользовательском адресе.
        /// </summary>
        /// <param name="userAddress">Обновленные данные пользовательского адреса.</param>
        /// <returns>HTTP-статус 200 в случае успешного обновления или HTTP-статус 400 в случае ошибки.</returns>
        [HttpPut("address/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUserAddress([FromBody] UserAdress userAddress)
        {
            try
            {
                _userService.UpdateUserAddress(userAddress);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        /// <summary>
        /// Создает новое изображение.
        /// </summary>
        /// <param name="image">Данные изображения для создания.</param>
        /// <returns>HTTP-статус 200 в случае успешного создания или HTTP-статус 400 в случае ошибки.</returns>
        [HttpPost("image/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateImage([FromBody] Image image)
        {
            try
            {
                _userService.CreateImage(image);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        /// <summary>
        /// Обновляет информацию об изображении.
        /// </summary>
        /// <param name="image">Обновленные данные изображения.</param>
        /// <returns>HTTP-статус 200 в случае успешного обновления или HTTP-статус 400 в случае ошибки.</returns>
        [HttpPut("image/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateImage([FromBody] Image image)
        {
            try
            {
                _userService.UpdateImage(image);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        /// <summary>
        /// Удаляет пользователя по идентификатору.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>HTTP-статус 200 в случае успешного удаления или HTTP-статус 400 в случае ошибки.</returns>
        [HttpDelete("user/delete/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteUser(long userId)
        {
            try
            {
                _userService.DeleteUser(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        /// <summary>
        /// Получает пользователя по идентификатору.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>HTTP-статус 200 с данными пользователя или HTTP-статус 400 в случае ошибки.</returns>
        [HttpGet("user/{userId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUserByUserId(long userId)
        {
            try
            {
                var user = _userService.GetUserByUserId(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }
    }
}
