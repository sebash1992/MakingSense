# My Blog

My Blog is a small application writed using .net Core 2.0 and Angular, that shows the basic action that can be performed in a blog

## Installation

```cmd
npm install
cd application.SPA
ng build --prod
cd ..\application.API\
dotnet run
```

## Usage
Test User 1:
Username:Test1@myblog.com
Password:test@user1

Test User 2:
Username:Test2@myblog.com
Password:test@user2


## Docuementation
The project was documented using Swagger, to acces the documentation once the project is running enter to http://localhost:5000/swagger/



## TODO

- [x] Add swagger documentation
- [ ] Add in the UI the posibility to create a new account
- [ ] Implement TDD
- [ ] Improve styles
- [ ] Give the option to share a post
- [ ] Add paggination
- [ ] Add Filtering

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
