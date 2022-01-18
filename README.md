# Angular and .NET Work Test

## Test instructions 

- You will need to fork this repository and complete all the task required for this work test.
- To submit this work test you will have to send us the link for the forked repository that you pushed the commits to. 
- This test needs to be completed 1 hour before the interview.

## Work Test Scenario
As a developer you are required to implement some new features and update existing features based on the tasks below. The scenario for this test is a web app responsible for managing the DES library.  

The front-end is implemented in Angular 9 and the back-end is a web API implemented in ASP.NET Core 3.1. 

## Tasks
- The project is not compiling so it needs to be fixed.
- Do not commit unnecessary files.
- Implement a routing mechanism for the home and books pages.
- Add a button on the home page that will redirect users to the list of books.
- Display a list of books on the books page.
- Implement a new feature to borrow a book and return it.
  - Prevent books from being borrowed until they are returned.
- Show the users which books cannot be borrowed. 
- TDD is expected to be used.
- Implement unit and integration tests.
- The project should compile and run after the changes.

## Optional Challenges
- Add authentication.
- Add a database.
- Implement e2e tests.
- Change the architecture to support a better design. Your ideal implementation for this problem.

## How to run
- Install [.NET Core 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1)
- Install [Node 12.16.1 or >](https://nodejs.org/en/download/)

### FrontEnd

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 9.1.1.

#### Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

#### Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

#### Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

#### Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

#### Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

#### Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
