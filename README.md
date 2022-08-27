# ui-tests-csharp-selenium-nunit

# ***About***

This project presents automated UI-tests for website https://av.by/. The project was completed using the following tecnology stacks:
  1. Chrome WebDriver.
  2. Selenium
  3. NUnit
  4. C#


# ***Getting Started***


The project is made in Microsoft Visual Studio Community 2019 Version 16.11.2.
Programming language C#.

For running test you neeed following steps:
1.  https://github.com/igor-kadach/ui-tests-csharp-selenium-nunit - сlone the project to your repository. 
2.  Selenium.WebDriver.ChromeDriver v.104.0.5112.7900 - download from NuGet Package Manager and install in the copied project.
3.  Seleium.WebDriver v.4.4.0 - download from NuGet Package Manager and install in the copied project.
4.  NUnit v.3.13.1 - download from NuGet Package Manager and install in the copied project.

Tests executed from UnitTest1.cs. in package "Tests".
May need to be added following usings:
* using NUnit.Framework;
* using OpenQA.Selenium;
* using OpenQA.Selenium.Chrome;
* using System.Threading;
* using UITests.PageObjects;


For running ***CheckUploadPhotoTest*** test you need change constant named filePath which situated in ***TestDatas*** class. 
Assign a value to this constant your path, where situated picture what you want upload to site. 
For example: public const string filePath = ***"C:\\Users\\Igor\\Desktop\\forTest.jpg";***




# ***Running Tests***

### Attention, please!
----------------------
***ChangePasswordTest()*** 
After running test ***ChangePasswordTest()*** your password to login on site will be changed to ***123456789Qq***. For re-running test you should manual change password on site (here: https://av.by/profile/settings) to ***123456qwerty***. Or swap passwords in the project in ***TestDatas class***: ***public const string password = "123456qwerty";***  ***→***  ***public const string password = "123456789Qq";*** and ***public const string newPasswordForTest = "123456789Qq";*** ***→*** ******public const string newPasswordForTest = "123456qwerty";***  

***CheckFavoriteTest()***

After the first run of the test ***CheckFavoriteTest()*** to run it again. You should delete manual bookmark here: ***https://av.by/profile/bookmarks*** .

***SaveSearchingTest()*** 

After the first run of the test ***SaveSearchingTest()*** to run it again. You should delete manual saved search result here: ***https://av.by/profile/saved-filters*** .



### It will be fixed with next commits.



to be continued...
