using AutoMapper;
using BLL.DTO;
using BLL.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Model;

namespace WebApp.Contollers
{
    [Route("/roles")]
    public class RoleController : Controller
    {
        private IRoleService _roleService;
        private IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<RoleViewModel> Get()
        {
            return _mapper.Map<IEnumerable<RoleViewModel>>(_roleService.GetRoles());
        }

        [HttpGet("{id}")]
        public RoleViewModel Get(int id)
        {
            return _mapper.Map<RoleViewModel>(_roleService.GetRole(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                _roleService.AddRole(_mapper.Map<RoleDTO>(role));
                return Ok(role);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                _roleService.EditRole(_mapper.Map<RoleDTO>(role));
                return Ok(role);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                _roleService.DeleteRole(id);
            }
            return Ok(id);
        }
    }
}
