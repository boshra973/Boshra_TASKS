﻿using Microsoft.Identity.Client;

namespace MVC1.ViewModel
{
    public class EmpDeptColorTempMsgBranchViewModel
    {
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public List<string> Branches {  get; set; }
        public int Temp {  get; set; }
        public string Msg { get; set; }
        public string Color { get; set; }

    }
}
