using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilView.Models
{
    public class FileData
    {
        public DateTime Day { get; set; }

        public string ToDoJob { get; set; }

        public string DoneJob { get; set; }

        public FileData(DateTime day, string todoJob, string doneJob)
        {
            Day = day;
            ToDoJob = todoJob;
            DoneJob = doneJob;
        }
    }
}
