using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;
using HeuristicAlghorithmsComparer.Model.Database;
using Alghoritm = HeuristicAlghorithmsComparer.Model.Enums.Alghoritm;

namespace HeuristicAlghorithmsComparer.Model.Services
{
    public class DatabaseService : IDatabaseService
    {
        private EntityDataModelContainer _dbContext;

        public DatabaseService(EntityDataModelContainer dbcontext)
        {
            _dbContext = dbcontext;
        }

        public TestFunction GetTestFunction(Enums.TestFunction testFunction)
        {
            return _dbContext.TestFunctions.First(x => x.Id == (int) testFunction);
        }

        public void SaveResult(Result result)
        {
            try
            {
                _dbContext.Results.Add(result);
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public Database.Alghoritm GetAlghoritm(Alghoritm alghoritm)
        {
            return _dbContext.Alghoritms.First(x => x.Id == (int) alghoritm);
        }
    }
}