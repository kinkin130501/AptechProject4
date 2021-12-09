using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data
{
    public class SystemEnum
    {
        public static string howtoCreate = "tao trang .net";
        public enum ActivationCodeTarget
        {
            Teacher,
            Student
        }
        public enum Department
        {
            Dev,
            Ba,
            Tester,
            PM,
            HelpDesk
        }
        public enum PartnerStatus
        {
            Pending,
            Approved,
            Cancel,
            Rejected
        }
        public enum DepartmentStatus
        {
            Apply,
            Expired
        }
        public enum RoleNumber
        {
            Partner,
            Developer,
            Leader,
            PM
        }
    }
}
