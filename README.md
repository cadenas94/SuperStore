"# Superstore" 

DEVELOPMENT STEPS

1.- Create SQL Database "Superstore"

2.- Import the excel sheets via SQL Server Import and Export Wizard

3.- Creation of the Store Procedure GetStateSales which select thre columns with State, Year and Sales.

4.- Creation of Windows Forms App(.NET Framework) project with VS. This project allow the creation of a simple interface to develop the requirements.

5.- App development steps:

  A) Add Model folder with the necessary objects as the solution was though.

  B) Add Folder SQLConnection to manage the connections with database. Due to we only need to read data from DB, I decide to use ADO.NET where we cal the Store Procedure   previously created which returns the data in a SqlDataReader object. Then it is transfered to a List which allow us to use the data easier. 
  
  C) Utils class with all the next methods:
  
  - DataReader_DomEntry: Load the data from SqlDataReaded into a List
  - IncrementSales: Calculate the incremented Sales
  - ExportData: Export the forecasted sales to a csv file.
  - FillChart1: Display the data in the first bonus chart
  - FillChart2: Display the data in the second bonus chart
  - SumGroups: Mrthod to group the sales by year (first bonus chart)
  
  D) App config file with the connection string wich is used for DB access. Important to modify in order to connect to other local datasource!!.
  
  ![datasource](https://user-images.githubusercontent.com/32109371/197046926-8016ca21-904e-4641-ba3e-aa0468c7efd9.PNG)
  

  E) In Form1.cs, we create all the necessary toolboxes. 
  
  ![image](https://user-images.githubusercontent.com/32109371/197021166-9aee95b3-7c04-4367-9609-1932d449919d.png)

- Year picker, where users can choose the year.
- States ListBox, where users can select the State in case you want to adjust the Sales with an Increment. The user can adjust only the increment to an specific state or to all of them("All states" option). In case the user does not select any of the options, it will be calculated for all of them.(Exercise 2 - Bonus)
- Increment TextBox, where users can apply a percentage of increment to the total sales of the selected year (Exercise 2)
- ListView which will load 4 columns.STATE, SALES (Exercise 1), INCREMENT(%) and INCREASED SALES.
- Total Sales Button, This button is the trigger to display all the results based on user choice (year, state, increment)
- Export Forecast Data button, allows the user to download the forecasted data to a csv. 
- Chart Bonus 1 with the aggregated seeding year sales and the forecasted sales for the year selected by the user
- Chart Bonus 2 with the breakdown by state of the seeding year sales and the forecasted year sales. Note that if the increment is very small, it will be harder to see the difference between forecasted and not.

Doing a test, selecting, for example, the year 2020 and an increment of 30%, the interface displays the next:

![image](https://user-images.githubusercontent.com/32109371/197025453-5ff49384-a92e-4a15-afdb-8941b1a4f296.png)


Next Steps (NOT INCLUDED IN THE PROJECT)
- Use of try and catch in the code to handle the error cases.
- Use of a log package(Nlog or Log4net) to manage all the possible error cases and have a .log file which the exceptions track.
- Development of automatic test from specific parameters.
