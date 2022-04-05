using WeekMenu.Models;
using WeekMenu.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeekMenu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LunchMenuController: ControllerBase
    {
        private readonly LunchMenuService _lunchMenuService;

        public LunchMenuController(LunchMenuService lunchMenuService) =>
            _lunchMenuService = lunchMenuService;

        [HttpGet]
        public async Task<List<LunchMenu>> Get() =>
            await _lunchMenuService.HttpGet();

        [HttpGet("{day:length(24)}")]
        public async Task<ActionResult<LunchMenu>> Get(string day)
        {
            var lunchMenu = await _lunchMenuService.httpGet(day);

            if ( lunchMenu == null)
            {
                return NotFound();
            }
            return lunchMenu;
        }

        [HttpPost]
        public async Task<IActionResult> Post(LunchMenu lunchMenu)
        {
            await _lunchMenuService.httpPost(lunchMenu);
            return CreatedAtAction(nameof(Get), new { id = lunchMenu.Id }, lunchMenu);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, LunchMenu newLunchMenu)
        {
            var lunchMenu = await _lunchMenuService.httpGetById(id);

            if ( lunchMenu == null)
            {
                return NotFound();
            }

            newLunchMenu.Id = lunchMenu.Id;

            await _lunchMenuService.httpPut(id, newLunchMenu);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var lunchMenu = await _lunchMenuService.httpGetById(id);

            if ( lunchMenu == null)
            {
                return NotFound();
            }

            await _lunchMenuService.httpDelete(id);
            return NoContent();
        }
    }
}
