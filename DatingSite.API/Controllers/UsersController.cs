using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingSite.API.Data;
using DatingSite.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingSite.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var usersToReturn = _mapper.Map<IEnumerable<UsersForListDto>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);
            var userForReturn = _mapper.Map<UserForDetailedDto>(user);
            return Ok(userForReturn);
        }
    }
}