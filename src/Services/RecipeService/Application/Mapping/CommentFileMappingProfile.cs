using Application.Dto_s.LemonChefFile.CommentFile.Requests;
using Application.Dto_s.LemonChefFile.CommentFile.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class CommentFileMappingProfile : Profile
{
    public CommentFileMappingProfile()
    {
        CreateMap<CommentFileCreateRequest, CommentFile>()
            .ConstructUsing(dto => new CommentFile()
            {
                UserId = dto.UserId,
                CommentId = dto.CommentId,
                OriginalName = dto.FileData.FileName
            });

        CreateMap<CommentFileUpdateRequest, CommentFile>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CommentId, opt => opt.MapFrom(src => src.CommentId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.OriginalName, opt => opt.Ignore());

        CreateMap<CommentFile, CommentFileCreateResponse>()
            .ConstructUsing(file => new CommentFileCreateResponse(
                file.Id,
                file.CommentId,
                file.UserId, 
                file.GoogleDriveName));
        
        CreateMap<CommentFile, CommentFileUpdateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.CommentId, opt => opt.MapFrom(src => src.CommentId));

        CreateMap<CommentFile, CommentFileGetResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.CommentId, opt => opt.MapFrom(src => src.CommentId))
            .ForMember(dest => dest.FileData, opt => opt.Ignore());
    }
}