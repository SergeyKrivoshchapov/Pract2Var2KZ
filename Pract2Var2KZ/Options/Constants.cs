using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.Options
{
    public static class Constants
    {
        // макс ур сытости
        public const int AdultMaxHunger = 200;
        public const int KittenMaxHunger = 100;

        // потеря веса игра 
        public const double CatWeightLossPercent = 0.02;
        public const double KittenWeightLossPercent = 0.01;

        // набор веса 
        public const double CatWeightGainPercent = 0.04;
        public const double KittenWeightGainPercent = 0.02;

        // уменьшение сытости / игра
        public const double PlayCoef = 0.1;
        public const double CatHungerDecreasePerPlay = AdultMaxHunger * PlayCoef;
        public const double KittenHungerDecreasePerPlay =KittenMaxHunger * PlayCoef;
            
        // увеличение сытости / кормыч
        public const double FeedCoef = 0.2;
        public const double CatHungerIncreasePerFeed = AdultMaxHunger * FeedCoef;
        public const double KittenHungerIncreasePerFeed = KittenMaxHunger * FeedCoef;

        // уровень сытости - начало потери веса
        public const double HungerLoseLevel = 0.5;
        public const double HungerWeightLosePercent = 0.02;

        public const double HungerDecreaseUpdate = 2.0;
        public const int KittenHighestAge = 3;

        // мин соотношение веса, сытости для возможности играть
        public const double MinWeightPercentForPlay = 0.5;
        public const double MinHungerPercentForPlay = 0.25;

        public const double MaxPossibleFeedingLevel = 1.0;

        // длительность блокировки возможности играть после вброса осуждающего взгляда
        public const int CatAngryLookBlockDuration = 15;
        public const int KittenAngryLookBlockDuration = 10;
    }
}
