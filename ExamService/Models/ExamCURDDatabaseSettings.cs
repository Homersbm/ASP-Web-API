using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamService.Models
{
    public class ExamCURDDatabaseSettings : IExamCURDDatabaseSettings
    {
        public string ExamCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }


    public interface IExamCURDDatabaseSettings
    {
        string ExamCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
