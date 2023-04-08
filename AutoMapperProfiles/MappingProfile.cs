using AutoMapper;
using FileSharingAPI.Entities;
using FileSharingAPI.FileManagment.Model;
using System.Collections.Generic;

namespace FileSharingAPI.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<List<FileHeader>, List<GetFileHeadersResult>>();
        }
    }
}
