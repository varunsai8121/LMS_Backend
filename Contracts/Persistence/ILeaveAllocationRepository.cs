using LMS_Backend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LMS_Backend.Contracts
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        bool CheckAllocation(int leavetypeid, int employeeid);
        ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(int employeeid);
        LeaveAllocation GetLeaveAllocationsByEmployeeAndType(int employeeid, int leavetypeid);
    }
}
