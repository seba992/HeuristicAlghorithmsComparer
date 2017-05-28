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
            MessageBox.Show(_dbContext.TestFunction.SingleOrDefault(x => x.Id == 1).Name);
        }

        public void CheckInsertOperation()
        {
            _dbContext.ExitFlag.Add(new ExitFlag
            {
                Description = "test"
            });
            _dbContext.SaveChanges();
        }

        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

                        var item = new DataItem("Welcome to MVVM Light");
                        callback(item, null);
        }
    }
}