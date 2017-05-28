﻿using System;
using HeuristicAlghorithmsComparer.Model;
using HeuristicAlghorithmsComparer.Model.Services;

namespace HeuristicAlghorithmsComparer.Design
{
    public class DesignDataService 
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }

        public void CheckDbConnection()
        {
            throw new NotImplementedException();
        }
    }
}