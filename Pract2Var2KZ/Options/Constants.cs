using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Pract2Var2KZ.Options
{
    public static class Constants
    {
        // макс ур сытости
        public const int DefaultAnimalMaxHunger = 100;
        public const int CatMaxHunger = 200;
        public const int KittenMaxHunger = 100;

        // max age
        public const int AnimalHighestAge = 100;
        public const int CatHighestAge = 30;
        public const int KittenHighestAge = 3;

        // max weight
        public const double AnimalMaxWeight = 19000;
        public const double CatMaxWeight = 21;
        public const double KittenMaxWeight = 8;

        // min weight
        public const double AnimalMinWeight = 0.02;
        public const double CatMinWeight = 8;
        public const double KittenMinWeight = 0.2;

        // потеря веса игра 
        public const double CatWeightLossPercent = 0.02;
        public const double KittenWeightLossPercent = 0.01;

        // набор веса 
        public const double CatWeightGainPercent = 0.04;
        public const double KittenWeightGainPercent = 0.02;

        // уменьшение сытости / игра
        public const double PlayCoef = 0.1;
        public const double CatHungerDecreasePerPlay = CatMaxHunger * PlayCoef;
        public const double KittenHungerDecreasePerPlay =KittenMaxHunger * PlayCoef;
            
        // увеличение сытости / кормыч
        public const double FeedCoef = 0.2;
        public const double CatHungerIncreasePerFeed = CatMaxHunger * FeedCoef;
        public const double KittenHungerIncreasePerFeed = KittenMaxHunger * FeedCoef;

        // уровень сытости - начало потери веса
        public const double HungerLoseLevel = 0.5;
        public const double HungerWeightLosePercent = 0.02;

        public const double HungerDecreaseUpdate = 2.0;


        // мин соотношение веса, сытости для возможности играть
        public const double MinWeightPercentForPlay = 0.5;
        public const double MinHungerPercentForPlay = 0.25;

        public const double MaxPossibleFeedingLevel = 1.0;

        // длительность блокировки возможности играть после вброса осуждающего взгляда
        public const int CatAngryLookBlockDuration = 15;
        public const int KittenAngryLookBlockDuration = 10;
    }
}
