# ProductApi-CQRS-MediatR
A Product CRUD Api Example with CQRS pattern, MediatR and Unit tests

**PROJECT LOGIC**

Project includes operations...

**AddProduct** : Adds product. <br/>
**GetAllProducts** : Gets all products without filter. <br/>
**GetByIdProduct** : Gets product with specific ID <br/>
**UpdateProduct** : Updates product. <br/>
**SearchProductsByDescription** : Searchs product with the product description. <br/>
**SearchProductsByTitle** : Searchs product with the product title. <br/>
**SearchProductsByCategoryName **: Searchs product with the category name. <br/>

and all products must be have a category.

**PROJECT ARCHITECTURE**

Onion architecture was used in the project.

**ProductApi.Domain** : Layer for modelling domain. For the project, product domain.  <br/>
**ProductApi.Infrastructure** : Layer for data access and some infra components. Repository and Unit of work pattern were used to access data.  <br/>
**ProductApi.Application** :  This is the layer used for transaction management and CQRS pattern.  <br/>
**ProductApi.Presentation** :  Api Layer to present api to clients.  <br/>

![Capture](https://user-images.githubusercontent.com/45563744/115993555-0b8b5180-a5dc-11eb-93a0-4d5a603fe5a8.PNG)

For layers, all dependencies, directly or indirectly, go into domain layer. However domain layer is not depend on any layer.

![Capture2](https://user-images.githubusercontent.com/45563744/115993757-ea773080-a5dc-11eb-9c28-6b81142c89da.PNG)

Author : M.Çağatay KIZILTAN
