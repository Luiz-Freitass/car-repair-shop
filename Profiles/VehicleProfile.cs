using AutoMapper;
using Car_Repair_Shop.Data.Dtos.VehicleDto;
using Car_Repair_Shop.Models;

namespace Car_Repair_Shop.Profiles;

public class VehicleProfile : Profile
{
    public VehicleProfile()
    {
        CreateMap<CreateVehicleDto, Vehicle>();
        CreateMap<Vehicle, ReadVehicleDto>();
        CreateMap<UpdateVehicleDto, Vehicle>();
    }
}

