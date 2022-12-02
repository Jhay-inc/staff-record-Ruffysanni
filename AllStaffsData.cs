using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffRecordApplication
{
    public class AllStaffsData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public string DateCreated { get; set; }
        public DateTime Id { get; set; }
        public string IdCard;

        List<StaffsData> staffsDatas = new List<StaffsData>();
    }

    public class StaffsData
    {
        list.add(new Staffs(staffId, FirstName, LastName, Email, Department, Role, DateCreated));
        list.add(new Staffs(staffId, FirstName, LastName, Email, Department, Role, DateCreated));
        list.add(new Staffs(staffId, FirstName, LastName, Email, Department, Role, DateCreated));
        list.add(new Staffs(staffId, FirstName, LastName, Email, Department, Role, DateCreated));
    }
}
