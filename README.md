NewsAPI is an API based in .Net 8 framework as a web api project.

- It implements a layered design with two layers: controllers & repositories.

- It uses entity framework as ORM using code first approach, so wasn't necessary to upload a copy of the DB, it could be build from code using the command: dotnet ef database update, standing the in root folder of the project.
  
- It implements an generic repository with basic functions for ADD / MODIFY / GET / DELETE any entity.

- From that generic repository the child repository for the News entity is inherited with the functionality that is specific to that entity (save image files).

- The image files are stored in the folder "wwwroot/images", and a reference to it is stored in a property of the entity (ImageUrl)
  
- The API has the following endpoints:

    * GET: api/News  => Get all news
    * GET: api/News/{id}  => Get a news by id
    * POST: api/News  => Create a new News, in a form file the image
    * PUT: api/News/{id}  => Modify a News, in a form file the image
    * DELETE: api/News/{id}  => Delete a News (providing the id)
  


