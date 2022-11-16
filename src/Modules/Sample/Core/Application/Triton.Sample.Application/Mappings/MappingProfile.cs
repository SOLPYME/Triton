using AutoMapper;
using Triton.Sample.Application.Features.Directors.Commands.CreateDirector;
using Triton.Sample.Application.Features.Streamers.Commands.CreateStreamer;
using Triton.Sample.Application.Features.Streamers.Commands.UpdateStreamer;
using Triton.Sample.Application.Features.Videos.Queries.GetVideosList;
using Triton.Sample.Domain;

namespace Triton.Sample.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVm>();
            CreateMap<CreateStreamerCommand, Streamer>();
            CreateMap<UpdateStreamerCommand, Streamer>();
            CreateMap<CreateDirectorCommand, Director>();
        }
    }
}
