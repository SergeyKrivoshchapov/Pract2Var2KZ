using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.Modules
{
    public static class Constants
    {
        // Макс ур сытости
        public const int AdultMaxHunger = 200;
        public const int KittenMaxHunger = 100;

        // Потеря веса игра 
        public const double CatWeightLossPercent = 0.02;
        public const double KittenWeightLossPercent = 0.01;

        // Набор веса 
        public const double CatWeightGainPercent = 0.04;
        public const double KittenWeightGainPercent = 0.02;

        // Уменьшение сытости / игра
        public const double PlayCoef = 0.1;
        public const double CatHungerDecreasePerPlay = AdultMaxHunger * PlayCoef;
        public const double KittenHungerDecreasePerPlay =KittenMaxHunger * PlayCoef;
            
        // Увеличение сытости / кормыч
        public const double FeedCoef = 0.2;
        public const double CatHungerIncreasePerFeed = AdultMaxHunger * FeedCoef;
        public const double KittenHungerIncreasePerFeed = KittenMaxHunger * FeedCoef;

        // Уровень сытости - начало потери веса
        public const double HungerLoseLevel = 0.5;
        public const double HungerWeightLosePercent = 0.02;

        public const double HungerDecreaseUpdate = 2;
        public const int KittenHighestAge = 3;
    }
}
