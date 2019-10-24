using FOCA.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FOCA.Database.Controllers
{
    public class ProjectController : BaseController<Project>
    {
        public void Save(Project item)
        {
            using (FocaContextDb context = new FocaContextDb())
            {
                context.Projects.AddOrUpdate(item);

                context.SaveChanges();
            }
        }

        public Project GetProjectById(int idProject)
        {
            try
            {
                using (FocaContextDb context = new FocaContextDb())
                {
                    return context.Projects.FirstOrDefault(x => x.Id == idProject);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Project> GetAllProjects()
        {
            using (FocaContextDb context = new FocaContextDb())
            {
                return context.Projects.ToList();
            }
        }

        public void DeleteProjectById(int idProject)
        {
            try
            {
                using (FocaContextDb context = new FocaContextDb())
                {
                    Project p = context.Projects.First(x => x.Id == idProject);

                    if (p != null)
                    {
                        context.Projects.Remove(p);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
