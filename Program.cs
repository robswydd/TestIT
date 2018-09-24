using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestIT
{   
    class Program
    {
        static void Main(string[] args)
        {
            string connString=  @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\robgallagher\source\repos\RestWebService\EmployeeDataBase\Company.mdf;Integrated Security=True;Connect Timeout=30";
            DAL.DAL dal = new DAL.DAL(connString);
           
            int employeeCode = Convert.ToInt16(args[0]);
            Console.WriteLine("My code is: " + employeeCode + "<br>");


            //HTTP Request Type - GET"
            //Performing Operation - READ"
            //Data sent via query string
            //POST - Data sent as name value pair and 
            //resides in the <form section> of the browser
           
            Company.Employee emp = dal.GetEmployee(employeeCode);
            if (emp == null)
                Console.WriteLine(employeeCode + "No Employee Found");
            else
            {
                Console.WriteLine("Yowsa!");

                // now write out retrieved Employee XML:
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(emp.GetType());
                x.Serialize(Console.Out,emp);
                Console.WriteLine();

                // this didn't work for me: I don't think this handler could see the assembly:
                //context.Response.ContentType = "text/xml";
                //WriteResponse(serializedEmployee);
            }
        }
    }
}