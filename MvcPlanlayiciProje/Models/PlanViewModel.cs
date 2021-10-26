using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPlanlayiciProje.Models
{
    public class PlanViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }
        public string Description { get; internal set; }
        public int UserId { get; internal set; }
        public string Title { get; internal set; }
        public string UserName { get; set; }
    }
}
