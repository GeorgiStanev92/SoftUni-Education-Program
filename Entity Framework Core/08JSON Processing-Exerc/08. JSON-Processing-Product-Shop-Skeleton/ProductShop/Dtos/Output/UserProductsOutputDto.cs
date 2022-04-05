namespace ProductShop.Dtos.Output
{
    public class UserProductsOutputDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public ProductsOutputDto SoldProducts { get; set; }
    }
}
