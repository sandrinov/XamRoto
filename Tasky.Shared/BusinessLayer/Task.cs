using System;
using System.Collections.Generic;
using System.Text;
using Tasky.Shared.BusinessLayer.Contracts;

namespace Tasky.Shared.BusinessLayer
{
    public class Task : IBusinessEntity
    {
        public Task()
        {
        }

 //       [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        // new property
        public bool Done { get; set; }
    }
}
