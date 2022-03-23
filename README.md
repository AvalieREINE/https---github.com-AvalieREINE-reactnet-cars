#  Design pattern decision:
## MVC design pattern
I chose this pattern as I want to separate the views from the models and controllers. It would help separating the data and allow modification in each data without affecting the others. This would make the application code clean and easy to understand, and it’s more scalable. 

# How to build the app:
- Clone the repository
- Open with Visual Studio Code and restore
- cd into ClientApp folder and run the command: 
```bash
npm install 
```
- On the terminal run the command:
```bash
 dotnet run 
```
- Once it's successfully running, go to [https://localhost:5001/](https://localhost:5001/)and try out different functions there
- Go to [https://localhost:5001/swagger](https://localhost:5001/swagger) to see the auto generated docs for api calls and try out all the api calls there
