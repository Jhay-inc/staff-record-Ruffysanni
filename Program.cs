using System;

namespace StaffRecordApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Dunamis Staff Kwoterz \n");
            AllSchoolStaffs allStaffInfo = new AllSchoolStaffs();
            allStaffInfo.EnterStaffDetails();
            //staffInfo.DisplayStaffDetail();
        }
    }
}
