using AutoMapper;
using Car_Repair_Shop.Data.Dtos.WorkOrderPieceDto;
using Car_Repair_Shop.Models;

namespace Car_Repair_Shop.Profiles;

public class WorkOrderPieceProfile : Profile
{
    public WorkOrderPieceProfile()
    {
        CreateMap<CreateWorkOrderPieceDto, WorkOrderPiece>();
        CreateMap<WorkOrderPiece, ReadWorkOrderPieceDto>();
        CreateMap<UpdateWorkOrderPieceDto, WorkOrderPiece>();
    }
}

