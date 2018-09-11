using AutoMapper;
using BLL.DTO;
using BLL.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication.Model;

namespace WebApplication.Contollers
{
    [Route("/users")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(_userService.GetUsers());
        }

        [HttpGet("{id}")]
        public UserViewModel Get(int id)
        {
            return _mapper.Map<UserViewModel>(_userService.GetUser(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                _userService.AddUser(_mapper.Map<UserDTO>(user));
                return Ok(user);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                _userService.EditUser(_mapper.Map<UserDTO>(user));
                return Ok(user);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                _userService.DeleteUser(id);
            }
            return Ok(id);
        }



    }
}
