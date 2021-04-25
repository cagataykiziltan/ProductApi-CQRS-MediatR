# ProductApi-CQRS-MediatR
A Product CRUD Api Example with CQRS pattern, MediatR and Unit tests  <br/>
Author : M.Çağatay KIZILTAN

# PROJECT LOGIC

Project includes operations...

**AddProduct** : Adds product. <br/>
**GetAllProducts** : Gets all products without filter. <br/>
**GetByIdProduct** : Gets product with specific ID <br/>
**UpdateProduct** : Updates product. <br/>
**SearchProductsByDescription** : Searchs product with the product description. <br/>
**SearchProductsByTitle** : Searchs product with the product title. <br/>
**SearchProductsByCategoryName**: Searchs product with the category name. <br/>
**SearchProductsByStockInterval**: Searchs product with interval between min stock and max stock. <br/>

and all products must have a category.

# PROJECT ARCHITECTURE

Onion architecture was used in the project.

**ProductApi.Domain** : Layer for modelling domain. For the project, product domain.  <br/>
**ProductApi.Infrastructure** : Layer for data access and some infra components. Repository and Unit of work pattern were used to access data.  <br/>
**ProductApi.Application** :  This is the layer used for transaction management and CQRS pattern.  <br/>
**ProductApi.Presentation** :  Api Layer to present api to clients.  <br/>
**ProductApi.Application.Tests** :  Unit tests for application layer.  <br/>
**ProductApi.Domain.Tests** :  Unit tests for domain layer.  <br/>

![Capture](https://user-images.githubusercontent.com/45563744/115993555-0b8b5180-a5dc-11eb-93a0-4d5a603fe5a8.PNG)

For layers, all dependencies, directly or indirectly, go into domain layer. However domain layer is not depend on any layer.

![Capture2](https://user-images.githubusercontent.com/45563744/115993757-ea773080-a5dc-11eb-9c28-6b81142c89da.PNG)

# CQRS

**Commands** : includes operation request/response models changing data resource like create, update delete.<br/>
**Query** : includes operation request/response models querying data resource.<br/>
**Handlers** : includes operations itself like CRUD or business.<br/>
**Events** :  Events catch the events like productCreated, productUpdated or productDeleted and take action depending on event.<br/>

For managing relations and business case flows MediatR was used
