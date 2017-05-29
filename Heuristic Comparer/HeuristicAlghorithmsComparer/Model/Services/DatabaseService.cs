using System;
using System.Linq;
using System.Windows;
using HeuristicAlghorithmsComparer.Database;
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

        public void CheckDbConnection()
        {
            MessageBox.Show(_dbContext.TestFunctions.SingleOrDefault(x => x.Id == 1).Name);
        }

        public void CheckInsertOperation()
        {
            _dbContext.ExitFlags.Add(new ExitFlag
            {
                Description = "test"
            });
            _dbContext.SaveChanges();
        }

        public TestFunction GetTestFunction(Enums.TestFunction testFunction)
        {
            return _dbContext.TestFunctions.First(x => x.Id == (int) testFunction);
        }

        public void SaveResult(Result result)
        {
            _dbContext.Results.Add(result);
            _dbContext.SaveChanges();
        }

        public Database.Alghoritm GetAlghoritm(Alghoritm alghoritm)
        {
            return _dbContext.Alghoritms.First(x => x.Id == (int) alghoritm);
        }

        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

                        var item = new DataItem("Welcome to MVVM Light");
                        callback(item, null);
        }
    }
}