﻿using EmpireSimulator.Models.Buildings;
using EmpireSimulator.Models.GameEffects;
using EmpireSimulator.Models.GameEvents;
using EmpireSimulator.Models.Resourses;
using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models {
    public class GameplayContext {
        public WorkerContext newWorkerContext;
        public WorkerContext curentWorkerContext;
        public ResoursesContext resoursesContext = new();
        public EventContext eventContext = new();
        public EffectContext effectContext = new();
        public BuildingContext buildingContext;
        public TurnCounter turnCounter = new();
        public ScoreCounter scoreCounter;
        public bool continuePlaying = true;
        public bool exited = false;
        private GameplayManager _manager;
        public GameplayManager Manager { get { return _manager; } }
        public string EmpireName { get; set; }

        public GameplayContext(GameplayManager manager) {
            _manager = manager;
            newWorkerContext = new(this);
            curentWorkerContext = new(this);
            buildingContext = new(this);
            scoreCounter = new(this);
        }
    }
}
