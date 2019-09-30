using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingSite.API.Models;
using DatingSite.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DatingSite.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ValuesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        // GET api/values
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await dataContext.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await dataContext.Values.FirstOrDefaultAsync(v=> v.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> AddValue([FromBody] Value value)
        {
            dataContext.Values.Add(value);
            await dataContext.SaveChangesAsync();
            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditValue(int id, [FromBody] Value  value)
        {
            var data = await dataContext.Values.FindAsync(id);
            data.Name = value.Name;
            dataContext.Update(data);
            await dataContext.SaveChangesAsync();
            return Ok(data);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await dataContext.Values.FindAsync(id);
            dataContext.Values.Remove(data);
            await dataContext.SaveChangesAsync();
            return Ok(data);
        }
    }
}
