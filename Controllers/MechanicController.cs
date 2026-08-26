using AutoMapper;
using Car_Repair_Shop.Data;
using Car_Repair_Shop.Data.Dtos.MechanicDto;
using Car_Repair_Shop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car_Repair_Shop.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Admin")]
public class MechanicController : ControllerBase
{
    private IMapper _mapper;
    private AppDbContext _appDbContext;
    public MechanicController(IMapper mapper, AppDbContext context)
    {
        _mapper = mapper;
        _appDbContext = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMechanic(CreateMechanicDto dto)
    {
        var mechanic = _mapper.Map<Mechanic>(dto);
        
        _appDbContext.Mechanics.Add(mechanic);
        await _appDbContext.SaveChangesAsync();
        
        var readMechanic = _mapper.Map<ReadMechanicDto>(mechanic);
        return CreatedAtAction(nameof(GetMechanicById), new { id = mechanic.Id }, readMechanic);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMechanics([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        var mechanics = await _appDbContext.Mechanics
            .Skip(skip)
            .Take(take)
            .ToListAsync();
        return Ok(_mapper.Map<List<ReadMechanicDto>>(mechanics));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMechanicById(int id)
    {
        var mechanic = await _appDbContext.Mechanics.FirstOrDefaultAsync(mechanic => mechanic.Id == id);
        if (mechanic == null) return NotFound();

        return Ok(_mapper.Map<ReadMechanicDto>(mechanic));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMechanic(int id, [FromBody] UpdateMechanicDto dto )
    {
        var mechanic = await _appDbContext.Mechanics.FirstOrDefaultAsync(mechanic => mechanic.Id == id);

        if (mechanic == null) return NotFound();

        _mapper.Map(dto, mechanic);
        await _appDbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMechanic(int id)
    {
        var mechanic = await _appDbContext.Mechanics.FirstOrDefaultAsync(mechanic => mechanic.Id == id);

        if (mechanic == null) return NotFound();

        _appDbContext.Mechanics.Remove(mechanic);
        await _appDbContext.SaveChangesAsync();
        return NoContent();
    }
}

