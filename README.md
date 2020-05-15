# IsotelAPI
## Using Graphiql
The nuget at  https://www.nuget.org/packages/graphiql/  is made for .NET Core and does not work with the standard .NET framework.
We tried using the Graphiql repo at https://github.com/graphql/graphiql   directly but it had some issues building on a windows machine.(https://github.com/graphql/graphiql/issues/318) .

We finally used the fork at https://github.com/mattferrin/graphiql to get this working on a Windows Machine. 
### Steps were as under
1.	Clone repo from https://github.com/mattferrin/graphiql
2.	Install Yarn from https://yarnpkg.com/en/docs/install#windows-stable
3.	Open Command Prompt and Navigate to main project
4.	Use **“Yarn Install”** to install all dependencies
5.	**“npm run build”** on the parent directory
6.	Navigate to Example directory
7.	**“npm install”**
8.	Update function graphQLFetcher in example/index.html to hit the HobbyAPIServer  

![update url](http://cennest.com/weblog/wp-content/uploads/2018/07/qraphiql.png)
9. **“npm start”**
10.  Navigate to localhost:8080 and explore the schema
