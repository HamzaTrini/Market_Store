namespace MarketStore.Models
{
    public class total_sales
    {
        public UserFp user { get; set; }
        public OrderFp order { get; set; }
        public OrderProductFp orderproduct {get;  set;}
        public ProductFp product { get; set; }
        public StoreFp store { get; set; }
        public StoreProductFp storeproduct { get; set; }    
        public CategoryFp category { get; set; }


    }
}
