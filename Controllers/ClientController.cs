using AutoMapper;
using Car_Repair_Shop.Data;
using Car_Repair_Shop.Data.Dtos.ClientDto;
using Car_Repair_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car_Repair_Shop.Controllers;

[ApiController]
[Route("[controller]")]

public class ClientController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public ClientController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientDto dto)
    {
        var client = _mapper.Map<Client>(dto);
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        var readClientDto = _mapper.Map<ReadClientDto>(client);
        return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, readClientDto);


    }

    [HttpGet]
    public async Task<IActionResult> GetAllClient([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        var clients = await _context.Clients
            .Skip(skip)
            .Take(take)
            .ToListAsync();
        return Ok(_mapper.Map<List<ReadClientDto>>(clients));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClientById(int id)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        if (client == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ReadClientDto>(client));
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClient(int id, [FromBody] UpdateClientDto dto)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        if (client == null) return NotFound();

        _mapper.Map(dto, client);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        if (client == null) return NotFound();

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}