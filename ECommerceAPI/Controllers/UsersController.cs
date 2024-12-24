using ECommerce.Domain.Entities;
using ECommerce.Inflastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserRepository _userRepository;
        public UsersController()
        {
            _userRepository = new UserRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userRepository.GetUsersAsync());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] User user)
        {
            if (_userRepository.EmailExists(user.Email, user.Id))
            {
                return Conflict(new { message = "O e-mail já está em uso." });
            }

            _userRepository.InsertUserAsync(user);

            if (user.Id == 0)
            {
                return BadRequest(new { message = "Erro ao inserir o usuário." });
            }

            return Ok(user);  
        }

        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            var existingUser = _userRepository.GetByIdAsync(user.Id);
            if (existingUser == null)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }

            if (_userRepository.EmailExists(user.Email, user.Id))
            {
                return Conflict(new { message = "O e-mail já está em uso por outro usuário." });
            }

            _userRepository.UpdateUserAsync(user);
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.DeleteUserAsync(id);
            return NoContent(); // 204
        }

    }
}
