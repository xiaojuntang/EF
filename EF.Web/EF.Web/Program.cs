using EF.Domain;
using FE.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EF.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeWorkContext db = new HomeWorkContext();
        }
    }
}
