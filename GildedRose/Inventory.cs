using System.Collections.Generic;

namespace GildedRose
{
    class Inventory
    {
        private readonly IEnumerable<Item> items;

        public Inventory(IEnumerable<Item> items)
        {
            this.items = items;
        }

        /// <summary>
        /// Items:
        /// "+5 Dexterity Vest"
        /// "Aged Brie"
        /// "Elixir of the Mongoose"
        /// "Sulfuras, Hand of Ragnaros"
        /// "Backstage passes to a TAFKAL80ETC concert"
        /// "Conjured Mana Cake"
        /// </summary>
        public void UpdateQuality()
        {
            int max = 50;
            int min = 0;
            foreach (var item in this.items)
            {
                if (item.Name == "Aged Brie")
                {
                    item.SellIn--;
                    if (0 > item.SellIn)
                    {
                        if (item.Quality <= max - 2)
                        {
                            item.Quality = item.Quality + 2;
                        }
                    }
                    else
                    {
                        if (item.Quality <= max - 1)
                        {
                            item.Quality++;
                        }
                    }
                }
                else if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }
                else
                {
                    item.SellIn--;
                    if (item.Quality <= min || item.Quality >= max)
                    {
                        continue;
                    }
                    else
                    {
                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {

                            if (item.SellIn > 10)
                            {
                                item.Quality++;
                            }

                            else if (item.SellIn <= 10)
                            {
                                item.Quality = item.Quality + 2;

                                if (item.SellIn <= 5)
                                {
                                    item.Quality++;
                                } 
                                
                            } 
                            if(item.SellIn <0)
                            {
                                item.Quality = 0;
                            }
                           
                            


                        }
                        else if (item.Name.ToLower().Contains("conjured") && item.SellIn <= 0)
                        {
                            item.Quality = item.Quality - 4;
                        }
                        else if (item.Name.ToLower().Contains("conjured") || item.SellIn <= 0)
                        {
                            item.Quality = item.Quality - 2;
                        }
                        else
                        {
                            item.Quality--;
                        }
                    }
                }
                
            }

            // TODO ...
            // Hint: Iterate through this.items and check Name property to access specific item
        }
    }
}
