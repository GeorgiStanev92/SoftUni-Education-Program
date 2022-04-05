using System.Collections.Generic;

namespace ProductShop.Dtos.Output
{
    internal class UserSoldProductsOutputDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<SoldProdcutOutputDto> SoldProducts { get; set; }
    }
}
