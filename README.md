## Usage

For development I used MSSQL server. I have not tested this on any other database.

1. Ensure you have dotnet installed on your system
2. `git clone https://github.com/RossLote/legendary-memory.git`
3. `cd legendary-memory`
4. Open `appsettings.Development.json` in a text editor and change `Data.CodingChallengeAPIConnection.ConnectionString` to your database connection string e.g. `Server=localhost;Database={{MYDATABASE}};user id={{MYUSER}};password={{MYPASSWORD}}`;
5. run `dotnet ef database update`
6. run `dotnet run`
7. You should now be able to run the Postman tests.

## Re-seed that database
If you need to re-run the Postman tests you will need to re-seed the database:

`dotnet ef database update 0 && dotnet ef database update`

I normally wouldn't recommend dropping databases just for re-seeding but for this demo I think it's acceptable.

## Documentation
To access the swagger documentation start the dev server and visit `http://localhost:5000/`

## Notes

I have made a couple of observations about the implementation of the postman tests.

1. I normally wouldn't recommend having a pluralised url for the list endpoint and singular for the object. It can make developing for the api more complicated than necessary. Pick one and stick with it.
2. The test for the `PUT` method should actually be a `PATCH`. I've made the tests pass but I would normally expect to get the entire object passed into the endpoint for a `PUT` request.