/*using AutoMapper;
using LMS_Backend.DTO;
using LMS_Backend.DTO.LeaveAllocation;
using LMS_Backend.DTO.LeaveRequest;
using LMS_Backend.DTO.LeaveType;
using LMS_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using LMS_Backend.Entities;

namespace LMS_Backend.LeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region LeaveRequest Mappings
            CreateMap<Domain.LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<Domain.LeaveRequest, LeaveRequestListDto>()
                .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => src.DateCreated))
                .ReverseMap();
            CreateMap<Domain.LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<Domain.LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
            #endregion LeaveRequest

            CreateMap<LeaveAllocation1, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation1, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation1, UpdateLeaveAllocationDto>().ReverseMap();

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
        }
    }
}
*/