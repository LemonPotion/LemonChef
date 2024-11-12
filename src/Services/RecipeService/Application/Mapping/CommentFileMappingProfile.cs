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
                Duration = dto.Duration,
                FileFormat = dto.FileFormat,
                FileName = dto.FileName,
                FileSizeInBytes = dto.FileSizeInBytes
            });

        CreateMap<CommentFileUpdateRequest, CommentFile>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CommentId, opt => opt.MapFrom(src => src.CommentId))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.FileFormat, opt => opt.MapFrom(src => src.FileFormat))
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.FileSizeInBytes));

        CreateMap<CommentFile, CommentFileCreateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CommentId, opt => opt.MapFrom(src => src.CommentId))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.FileFormat, opt => opt.MapFrom(src => src.FileFormat))
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.FileSizeInBytes));

        CreateMap<CommentFile, CommentFileUpdateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CommentId, opt => opt.MapFrom(src => src.CommentId))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.FileFormat, opt => opt.MapFrom(src => src.FileFormat))
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.FileSizeInBytes));

        CreateMap<CommentFile, CommentFileGetResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CommentId, opt => opt.MapFrom(src => src.CommentId))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.FileFormat, opt => opt.MapFrom(src => src.FileFormat))
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.FileSizeInBytes));
    }
}