using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models.ViewModels
{
    public class ProjectsViewModel
    {
        public IQueryable<Project> Projects { get; set; }
        public PageInfo PageInfo { get; set; }

    }
}
