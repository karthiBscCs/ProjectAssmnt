Hello,
I've attached the .bak file for the backup of the SQL Server database, named EmpDet.
Additionally, please update the connection string in the appsettings.json file for your server:
"ConnectionStrings": {
    "EmpContn": "Data Source=1.2.3.4;Initial Catalog=EmpDet;User ID=SA;Password=Pass123;"
}