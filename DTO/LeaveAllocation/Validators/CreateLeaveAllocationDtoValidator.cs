/*using FluentValidation;
using LMS_Backend.Contracts.Persistence;
using System;
namespace LMS_Backend.DTO.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
            private readonly ILeaveTypeRepository _leaveTypeRepository;

            public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
            {
                _leaveTypeRepository = leaveTypeRepository;

                RuleFor(p => p.LeaveTypeId)
                    .GreaterThan(0)
                    .MustAsync(async (id, token) =>
                    {
                        var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                        return leaveTypeExists;
                    })
                    .WithMessage("{PropertyName} does not exist.");
            }
        }
    }

*/