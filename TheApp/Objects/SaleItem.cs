namespace TheApp.Objects
{
    public class SaleItem
    {
        public int saleID { get; set; } 
        public int userID { get; set; } // userID of who posted it
        public string category { get; set; } // sale or auction
        public string SaleType { get; set; }
        public string saleLablel { get; set; } // what it will be labeled as like 20 minutes studio time
        public string desc { get; set; }
        public string saleText { get; set; } // for unsure
        public double price { get; set; }
        public double minPrice { get; set; } // min price is for auctions mostly atm

        public SaleItem()
        {

        }

        public SaleItem(int saleID, int userID, string category, string saleType, string saleLablel,
            string desc, string saleText, double price, double minPrice)
        {
            this.saleID = saleID;
            this.userID = userID;
            this.category = category;
            SaleType = saleType;
            this.saleLablel = saleLablel;
            this.desc = desc;
            this.saleText = saleText;
            this.price = price;
            this.minPrice = minPrice;
        }
    }
}
