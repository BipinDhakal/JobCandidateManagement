using AutoMapper;
using JobCandidateManagement.App.Models;
using JobCandidateManagement.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateManagement.App.Common.Mapper.AutoMapper
{
    public class CandidateInformationMapperProfile : Profile
    {
        public CandidateInformationMapperProfile() 
        { 
            CreateMap<CandidateInformation, CandidateInformationViewModel>().ReverseMap();
        }

    }
}
