﻿using DemoLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class BetterBizLogic : IBusinessLogic
    {
        ILogger _logger; //similar to a private backing field property
        IDataAccess _dataAccess;

        //BusinessLogic Contructer passes the 2 instances it will NEED (ILogger logger, IDataAccess dataAccess)
        public BetterBizLogic(ILogger logger, IDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        public void ProcessData()
        {
           
            //simulates action
            _logger.Log("Starting the processing of data.");
            Console.WriteLine();
            Console.WriteLine("Processing the data");
            _dataAccess.LoadData();
            _dataAccess.SaveData("ProcessedInfo");
            Console.WriteLine();
            _logger.Log("Finished processing of the data.");
            Console.WriteLine();
        }
    }
}
