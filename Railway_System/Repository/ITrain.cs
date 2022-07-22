﻿using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public interface ITrain
    {
        public string SaveTrain(Train train);
        public string UpdateTrain(Train train);
        public string DeleteTrain(int TrainId);
        Train GetTrain(int TrainId);
        List<Train> GetAllTrains();
    }
}