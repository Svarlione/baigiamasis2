using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using baigiamasis2.Models;
using baigiamasis2.DTO;
using baigiamasis2.Services.Mappers;
using baigiamasis2.Services.UserServices;
using baigiamasis2.Services.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using System.Text;

/// <summary>
/// Контроллер для управления пользователями в системе регистрации.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UserRegSistem : ControllerBase
{
    private readonly UserService _userService;
    private readonly UserMapper _userMapper;
    private readonly IAuthService _authService;
    public UserRegSistem(UserService userService, UserMapper userMapper, IAuthService authService)
    {
        _userService = userService;
        _userMapper = userMapper;
        _authService = authService;
    }

    /// <summary>
    /// Создает нового пользователя.
    /// </summary>
    /// <param name="createUserDto">Данные пользователя для создания.</param>
    /// <returns>HTTP-статус 200 с идентификатором созданного пользователя или HTTP-статус 400 в случае ошибки.</returns>
    [HttpPost("user/create")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
    {
        try
        {
            long userId = _userService.CreateUser(createUserDto);
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
    /// <param name="updateUserDto">Обновленные данные пользователя.</param>
    /// <returns>HTTP-статус 200 в случае успешного обновления или HTTP-статус 400 в случае ошибки.</returns>
    [HttpPut("user/update")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateUser([FromBody] UpdateUserDto updateUserDto)
    {
        try
        {
            _userService.UpdateUser(updateUserDto);
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
    /// <param name="userAddressDto">Данные адреса для создания.</param>
    /// <returns>HTTP-статус 200 в случае успешного создания или HTTP-статус 400 в случае ошибки.</returns>
    [HttpPost("address/create")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateUserAddress([FromBody] AdressDto userAddressDto)
    {
        try
        {
            UserAdress userAddress = _userMapper.MapToUserAdressEntity(userAddressDto);
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
    /// <param name="userAddressDto">Обновленные данные пользовательского адреса.</param>
    /// <returns>HTTP-статус 200 в случае успешного обновления или HTTP-статус 400 в случае ошибки.</returns>
    [HttpPut("address/update")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateUserAddress([FromBody] AdressDto userAddressDto)
    {
        try
        {
            UserAdress userAddress = _userMapper.MapToUserAdressEntity(userAddressDto);
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
    /// <param name="imageDto">Данные изображения для создания.</param>
    /// <returns>HTTP-статус 200 в случае успешного создания или HTTP-статус 400 в случае ошибки.</returns>
    [HttpPost("image/create")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateImage([FromBody] ImageDto imageDto)
    {
        try
        {
            _userService.CreateImage(imageDto);
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
    /// <param name="imageDto">Обновленные данные изображения.</param>
    /// <returns>HTTP-статус 200 в случае успешного обновления или HTTP-статус 400 в случае ошибки.</returns>
    [HttpPut("image/update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateImage([FromBody] ImageDto imageDto)
    {
        try
        {
            ImageUpdateDto updateDto = new ImageUpdateDto
            {
                Name = imageDto.Name,
                Description = imageDto.Description,
                ImageBytes = imageDto.ImageBytes
            };

            _userService.UpdateImage(updateDto);
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

    [HttpPost("login")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginInfoDto request)
    {
        try
        {
            // Преобразовать пароль из byte[] в строку
            string password = Encoding.UTF8.GetString(request.Password);

            var token = await _authService.LoginAsync(request.UserName, password);
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    [HttpPost("signup")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignUp([FromBody] SingUpDto request)
    {
        try
        {
            var token = await _authService.SignUpAsync(request.UserName, request.Role, request.Password);
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }
}
