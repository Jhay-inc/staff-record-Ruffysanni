using System;

namespace StaffRecordApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("============================== Welcome to Dunamis Staff Kwoterz ===================================\n");
            AllSchoolStaffsOps allStaffInfo = new AllSchoolStaffsOps();
            allStaffInfo.EnterStaffDetails();
            //staffInfo.DisplayStaffDetail();
        }
    }
}
