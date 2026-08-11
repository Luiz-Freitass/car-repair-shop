using AutoMapper;
using Car_Repair_Shop.Data.Dtos.PieceDto;
using Car_Repair_Shop.Models;

namespace Car_Repair_Shop.Profiles;
public class PieceProfile : Profile
{
    public PieceProfile() 
    {
        CreateMap<CreatePieceDto, Piece>();
        CreateMap<Piece, ReadPieceDto>();
        CreateMap<UpdatePieceDto, Piece>();
    }
}

