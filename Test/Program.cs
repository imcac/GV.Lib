using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GV.Lib;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(
            DynamicWS.GetServiceResultByUrlAndMethod("http://iom.unioncloud.com/ws/IOM_WebService.asmx", "IOM_Role_GetMemberListByRoleIdForCount",
                "strJson=[{\"IOM_Version\": \"Web3.0\"},{\"roleId\": \"4e5fba85-c602-4e80-95be-b52f9bf117c6\",\"pageSize\":\"10\",\"pageIndex\":\"1\",\"serviceId\": \"IBD101\"}]"));

            Console.Read();
        }
    }
}
