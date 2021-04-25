using ProductService.Domain.Products;
using ProductService.Domain.Products.Categories;
using ProductService.Domain.SeedWork;
using Xunit;

namespace ProductService.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void ProductDomainCreate_WithCorrectValues_CreatesUniqueDifferentEntities()
        {
            //Arrange
            const string description = "testDescription";
            const int stockQuantity = 15;
            const string title = "testTitle";
            const string categoryName = "HouseHoldAppliences";
            const int minStock = 10;

            //Act
            var firstProduct = Product.Create(description, stockQuantity, title, Category.Create(1, categoryName, minStock));
            var secondProduct = Product.Create(description, stockQuantity, title, Category.Create(1, categoryName, minStock));

            //Assert
            Assert.NotEqual(firstProduct.Id, secondProduct.Id);
        }

        [Fact]
        public void ProductDomainCreate_WithEmptyDescription_ThrowsException()
        {
            //Arrange
            const string description = null;
            const int stockQuantity = 15;
            const string title = "testTitle";
            const string categoryName = "HouseHoldAppliences";
            const int minStock = 10;

            //Act
            var actualException = Assert.Throws<BusinessRuleValidationException>(() => Product.Create(description, stockQuantity, title, Category.Create(1, categoryName, minStock)));

            //Assert
            Assert.Equal(MessageConstants.DescriptionCannotBeNull,actualException.Message);

        }

        [Fact]
        public void ProductDomainCreate_WithNegativeStockQuantity_ThrowsException()
        {
            //Arrange
            const string description = "testDescription";
            const int stockQuantity = -5;
            const string title = "testTitle";
            const string categoryName = "HouseHoldAppliences";
            const int minStock = 10;

            //Act
            var actualException = Assert.Throws<BusinessRuleValidationException>(() => Product.Create(description, stockQuantity, title, Category.Create(1, categoryName, minStock)));

            //Assert
            Assert.Equal(MessageConstants.StockQuantityCannotBeNegative,actualException.Message);
        }


        [Fact]
        public void ProductDomainCreate_WithEmptyTitle_ThrowsException()
        {
            //Arrange
            const string description = "testDescription";
            const int stockQuantity = 5;
            const string title = null;
            const string categoryName = "HouseHoldAppliences";
            const int minStock = 10;


            //Act
            var actualException = Assert.Throws<BusinessRuleValidationException>(() => Product.Create(description, stockQuantity, title, Category.Create(1, categoryName, minStock)));

            //Assert
            Assert.Equal(MessageConstants.TitleCannotBeNull,actualException.Message);
        }

        [Fact]
        public void ProductDomainCreate_WithStockQuantityLessThanMinStockQuantity_ThrowsException()
        {
            //Arrange
            const string description = "testDescription";
            const int stockQuantity = 3;
            const string title = "testTitle";
            const string categoryName = "HouseHoldAppliences";
            const int minStock = 10;

            //Act
            var actualException = Assert.Throws<BusinessRuleValidationException>(() => Product.Create(description, stockQuantity, title, Category.Create(1, categoryName, minStock)));

            //Assert
            Assert.Equal(MessageConstants.StockQuantityCannotBeLessThanMinStockQuantity, actualException.Message);
        }

        [Fact]
        public void ProductDomainCreate_WithTitleExceeding200Characters_ThrowsException()
        {

            //Arrange
            const string description = "testDescription";
            const int stockQuantity = 5;
            const string title = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" +
                                 "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            const string categoryName = "HouseHoldAppliences";
            const int minStock = 10;

            //Act
            var actualException = Assert.Throws<BusinessRuleValidationException>(() => Product.Create(description, stockQuantity, title, Category.Create(1, categoryName, minStock)));

            //Assert
            Assert.Equal(MessageConstants.TitleCannotExceed200Characters,actualException.Message);
        }


    }
}
